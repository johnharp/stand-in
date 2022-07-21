using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace stand_in
{
    // Test data:
    // http://localhost:7071/api/img?d=AyACWNzr9zB1tRAQAABgBnA%2BOHwc6AnIA4gHqA5IHOg5eDA4P%2FxwDmAGAAA%3D
    //



    public static class img
    {
        [FunctionName("img")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string d = req.Query["d"];

            byte[] specBytes = System.Convert.FromBase64String(d);
            byte[] imageBytes = new byte[0];

            var imageSpec = new ImageSpec(specBytes);
            log.LogInformation($"Width: {imageSpec.Width} px, Height: {imageSpec.Height} px");
            log.LogInformation($"TilesPerRow: {imageSpec.NumCols}, NumRows: {imageSpec.NumRows}");

            using (var ms = new MemoryStream())
            {
                using Image<Rgba32> png = new Image<Rgba32>(
                    imageSpec.Width, imageSpec.Height,
                    imageSpec.BackgroundColor);

                for (int col = 0; col < imageSpec.NumCols; col++)
                {
                    for (int row = 0; row < imageSpec.NumRows; row++)
                    {
                        bool pixel = imageSpec.
                    }
                }

                png.SaveAsPng(ms);

                imageBytes = ms.ToArray();
            }

            return new FileContentResult(imageBytes, "image/png");
        }
    }
}
