using System;
using System.Collections;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;


// Test data
//
// AyACWNzr9zB1tRAQAABgBnA+OHwc6AnIA4gHqA5IHOg5eDA4P/xwDmAGAAA=															
//


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

        public int NumCols { get; set; }
        public int NumRows { get; set; }

        public static BitArray ImageBits { get; set; }

        public ImageSpec(byte[] specBytes)
        {
            ValidateSpecBytes(specBytes);

            int p = 0;

            // WWHHBBBFFFCR[DDDD...]
            // W = Width (2 bytes)
            // H = Height (2 bytes)
            // B = Background Color R, G, B (3 bytes)
            // F = Foreground Color R, G, B (3 bytes)
            // C = Num colums of tiles (1 byte)
            // R = Num rows of tiles (1 byte)
            // D = Data (n bytes)

            Width = 256 * specBytes[p++] + specBytes[p++];
            Height = 256 * specBytes[p++] + specBytes[p++];

            var rgb24 = new Rgb24(specBytes[p++], specBytes[p++], specBytes[p++]);
            BackgroundColor = new Color(rgb24);

            rgb24 = new Rgb24(specBytes[p++], specBytes[p++], specBytes[p++]);
            ForegroundColor = new Color(rgb24);

            NumCols = specBytes[p++];
            NumRows = specBytes[p++];

            int numBytesData = specBytes.Length - p;
            int numBitsData = (specBytes.Length - p)*8;

            if (numBitsData < 0 ||
                numBitsData < NumCols * NumRows)
            {
                throw new FormatException("Not enough data bits supplied");
            }

            Byte[] b = new Byte[numBytesData];
            Array.Copy(specBytes, p, b, 0, numBytesData);
            ImageSpec.ImageBits = new BitArray(b);

        }

        private void ValidateSpecBytes(byte[] bytes)
        {
            // to-do: check valid bytes were passed
        }
    }
}
