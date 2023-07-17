using System.Drawing;
using System.Drawing.Imaging;
using Core.Resources.ErrorMassages;

namespace Core.Helpers
{
    public static class ImageWorker
    {
        private static readonly string _images = "images";

        public static Bitmap? FromBase64StringToImage(this string base64String)
        {
            byte[]? byteBuffer = Convert.FromBase64String(base64String);
            try
            {
                using (MemoryStream memoryStream = new MemoryStream(byteBuffer))
                {
                    memoryStream.Position = 0;
                    Image imgReturn;
                    imgReturn = Image.FromStream(memoryStream);
                    memoryStream.Close();
                    byteBuffer = null;
                    return new Bitmap(imgReturn);
                }
            }
            catch
            {
                return null;
            }
        }

        public static async Task<string> SaveImageAsync(string imageBase64)
        {
            if (!imageBase64.StartsWith("data:image/"))
                throw new HttpExceptionWorker(ErrorMassages.ErrorSavingImage, System.Net.HttpStatusCode.UnsupportedMediaType);

            string fileName = Path.GetRandomFileName() + ".jpg";

            try
            {
                string base64 = imageBase64;
                if (base64.Contains(","))
                    base64 = base64.Split(',')[1];

                var img = base64.FromBase64StringToImage();
                string directoryToSave = Path.Combine(Directory.GetCurrentDirectory(), _images, fileName);
                var saveImage = CompressImage(img, 1920, 1080, false);

                await Task.Run(async () => saveImage.Save(directoryToSave, ImageFormat.Jpeg));
            }
            catch
            {
                throw new HttpExceptionWorker(ErrorMassages.ErrorSavingImage, System.Net.HttpStatusCode.UnsupportedMediaType);
            }
            return fileName;
        }

        public static Bitmap? CompressImage(Bitmap originalPic, int maxWidth, int maxHeight, bool transparent = false)
        {
            try
            {
                int width = originalPic.Width;
                int height = originalPic.Height;
                int widthDiff = width - maxWidth;
                int heightDiff = height - maxHeight;
                bool doWidthResize = (maxWidth > 0 && width > maxWidth && widthDiff > heightDiff);
                bool doHeightResize = (maxHeight > 0 && height > maxHeight && heightDiff > widthDiff);

                if (doWidthResize || doHeightResize || (width.Equals(height) && widthDiff.Equals(heightDiff)))
                {
                    int iStart;
                    decimal divider;
                    if (doWidthResize)
                    {
                        iStart = width;
                        divider = Math.Abs((decimal)iStart / maxWidth);
                        width = maxWidth;
                        height = (int)Math.Round((height / divider));
                    }
                    else
                    {
                        iStart = height;
                        divider = Math.Abs((decimal)iStart / maxHeight);
                        height = maxHeight;
                        width = (int)Math.Round(width / divider);
                    }
                }

                using (Bitmap outBmp = new Bitmap(width, height, PixelFormat.Format24bppRgb))
                {
                    using (Graphics oGraphics = Graphics.FromImage(outBmp))
                    {
                        oGraphics.Clear(Color.White);
                        oGraphics.DrawImage(originalPic, 0, 0, width, height);

                        if (transparent)
                        {
                            outBmp.MakeTransparent();
                        }

                        return new Bitmap(outBmp);
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public static async Task RemoveImageAsync(string fileName)
        {
            string file = Path.Combine(Directory.GetCurrentDirectory(), _images, fileName);
            if (File.Exists(file))
                await Task.Run(() => File.Delete(file));
        }
    }
}