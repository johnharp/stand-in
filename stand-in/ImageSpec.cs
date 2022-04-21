using System;
using SixLabors.ImageSharp;

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

            var colorVect = new System.Numerics.Vector4(
                (float)specBytes[4],
                (float)specBytes[5],
                (float)specBytes[6],
                255
                );
            BackgroundColor = new Color(colorVect);
        }

        private void ValidateSpecBytes(byte[] bytes)
        {
            // to-do: check valid bytes were passed
        }
    }
}
