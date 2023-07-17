using Core.Resources.ErrorMassages;
using System.Net;

namespace Core.Helpers
{
    public static class DataWorker
    {
        public static async Task IsValidIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new HttpExceptionWorker(ErrorMassages.IdValueError, HttpStatusCode.BadRequest);
            }

        }
    }
}