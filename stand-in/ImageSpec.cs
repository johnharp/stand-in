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

            // WWHHBBBFFFNDDDD...
            // W = Width (2 bytes)
            // H = Height (2 bytes)
            // B = Background Color R, G, B (3 bytes)
            // F = Foreground Color R, G, B (3 bytes)
            // N = Num tiles per row (1 byte)
            // D = Data (n bytes)

            Width = 256 * specBytes[p++] + specBytes[p++];
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
