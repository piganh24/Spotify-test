using Core.DTOs.Track;
using Core.Resources.ErrorMassages;
using Microsoft.AspNetCore.Http;

namespace Core.Helpers
{
    public static class TrackWorker
    {
        private static readonly string _tracks = "tracks";

        public static async Task<TrackResponseDTO> SaveTrackAsync(IFormFile trackData)
        {
            try
            {
                string fullPath = "";
                string fileExtension = ".mp3";
                string fileName = Guid.NewGuid().ToString();

                if (trackData.Length != 0)
                {
                    fileExtension = Path.GetExtension(trackData.FileName) == ".mp3" ? Path.GetExtension(trackData.FileName) : throw new InvalidOperationException(ErrorMassages.BadMusicFileExtension);

                    fullPath = Path.Combine(Directory.GetCurrentDirectory(), _tracks, fileName + fileExtension);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await trackData.CopyToAsync(stream);
                    }
                }

                TagLib.File file = TagLib.File.Create(fullPath, TagLib.ReadStyle.Average);

                return new TrackResponseDTO()
                {
                    FileName = fileName + fileExtension,
                    Duration = (int)file.Properties.Duration.TotalSeconds
                };
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException(exception.Message);
            }
        }

        public static async Task RemoveTrackAsync(string trackId)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), _tracks);
                await Task.Run(() => File.Delete(Path.Combine(path, trackId)));
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException(exception.Message);
            }
        }
    }
}