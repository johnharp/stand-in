using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace stand_in
{
    public class ImageSpec
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Color BackgroundColor { get; set; }

        public ImageSpec(byte[] specBytes)
        {
            ValidateSpecBytes(specBytes);

            Width = 256*specBytes[0] + specBytes[1];
            Height = 256 * specBytes[2] + specBytes[3];

            var rgb24 = new Rgb24(specBytes[4], specBytes[5], specBytes[6]);
            BackgroundColor = new Color(rgb24);
        }

        private void ValidateSpecBytes(byte[] bytes)
        {
            // to-do: check valid bytes were passed
        }
    }
}
