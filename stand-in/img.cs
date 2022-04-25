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

            using (var ms = new MemoryStream())
            {
                using Image<Rgba32> png = new Image<Rgba32>(
                    imageSpec.Width, imageSpec.Height,
                    imageSpec.BackgroundColor);
                png.SaveAsPng(ms);

                imageBytes = ms.ToArray();
            }

            return new FileContentResult(imageBytes, "image/png");
        }
    }
}
