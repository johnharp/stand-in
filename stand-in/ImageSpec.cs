using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace stand_in
{
    public class ImageSpec
    {
        // Width of the image (in pixels)
        public int Width { get; set; }
        // Height of the image (in pixels)
        public int Height { get; set; }

        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }

        // Number of tiles in the image per row
        public int TilesPerRow { get; set; }

        public ImageSpec(byte[] specBytes)
        {
            ValidateSpecBytes(specBytes);

            int p = 0;

            Width = 256*specBytes[p++] + specBytes[p++];
            Height = 256 * specBytes[p++] + specBytes[p++];

            var rgb24 = new Rgb24(specBytes[p++], specBytes[p++], specBytes[p++]);
            BackgroundColor = new Color(rgb24);

            rgb24 = new Rgb24(specBytes[p++], specBytes[p++], specBytes[p++]);
            ForegroundColor = new Color(rgb24);

            TilesPerRow = specBytes[p++];
        }

        private void ValidateSpecBytes(byte[] bytes)
        {
            // to-do: check valid bytes were passed
        }
    }
}
