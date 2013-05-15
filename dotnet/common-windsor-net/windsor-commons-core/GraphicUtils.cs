using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Windsor.Commons.Core
{
    public static class GraphicUtils
    {
        public static void Translate(GraphicsPath path, float xDelta, float yDelta)
        {
            Matrix matrix = new Matrix();
            matrix.Translate(xDelta, yDelta);
            path.Transform(matrix);
        }
        public static Color Lighten(Color color, double factor)
        {
            HSLColor hslColor = HSLColor.FromRGB(color);
            hslColor.L = hslColor.L * Math.Abs(factor);
            return hslColor.ToRGB();
        }
        public static Color Darken(Color color, double factor)
        {
            HSLColor hslColor = HSLColor.FromRGB(color);
            hslColor.L = hslColor.L * (1 - Math.Abs(factor));
            return hslColor.ToRGB();
        }
    }
    // See: http://www.easyrgb.com/index.php?X=MATH&H=18#text18
    [Serializable]
    public class HSLColor
    {
        public HSLColor()
        {
        }
        public HSLColor(double h, double s, double l)
        {
            H = h;
            S = s;
            L = l;
        }
        public double H
        {
            get;
            set;
        }
        public double S
        {
            get;
            set;
        }
        public double L
        {
            get;
            set;
        }
        public static HSLColor FromRGB(Color color)
        {
            return FromRGB(color.R, color.G, color.B);
        }
        public static HSLColor FromRGB(int r, int g, int b)
        {
            ExceptionUtils.ThrowIfNotInRange(r, 0, 255);
            ExceptionUtils.ThrowIfNotInRange(g, 0, 255);
            ExceptionUtils.ThrowIfNotInRange(b, 0, 255);

            double var_R = (r / 255.0);
            double var_G = (g / 255.0);
            double var_B = (b / 255.0);

            double var_Min = Math.Min(Math.Min(var_R, var_G), var_B);
            double var_Max = Math.Max(Math.Max(var_R, var_G), var_B);
            double del_Max = var_Max - var_Min;

            double L = (var_Max + var_Min) / 2.0;
            double H, S;

            if (del_Max == 0.0)
            {
                H = 0.0;
                S = 0.0;
            }
            else
            {
                if (L < 0.5)
                {
                    S = del_Max / (var_Max + var_Min);
                }
                else
                {
                    S = del_Max / (2.0 - var_Max - var_Min);
                }

                double del_R = (((var_Max - var_R) / 6.0) + (del_Max / 2.0)) / del_Max;
                double del_G = (((var_Max - var_G) / 6.0) + (del_Max / 2.0)) / del_Max;
                double del_B = (((var_Max - var_B) / 6.0) + (del_Max / 2.0)) / del_Max;

                if (var_R == var_Max)
                {
                    H = del_B - del_G;
                }
                else if (var_G == var_Max)
                {
                    H = (1.0 / 3.0) + del_R - del_B;
                }
                else // (var_B == var_Max)
                {
                    H = (2.0 / 3.0) + del_G - del_R;
                }

                if (H < 0.0)
                {
                    H += 1.0;
                }
                if (H > 1.0)
                {
                    H -= 1.0;
                }
            }
            return new HSLColor(H, S, L);
        }
        public Color ToRGB()
        {
            double R, G, B;
            if (S == 0.0)
            {
                R = L * 255.0;
                G = L * 255.0;
                B = L * 255.0;
            }
            else
            {
                double var_1, var_2;
                if (L < 0.5)
                {
                    var_2 = L * (1.0 + S);
                }
                else
                {
                    var_2 = (L + S) - (S * L);
                }

                var_1 = 2.0 * L - var_2;

                R = 255.0 * Hue_2_RGB(var_1, var_2, H + (1.0 / 3.0));
                G = 255.0 * Hue_2_RGB(var_1, var_2, H);
                B = 255.0 * Hue_2_RGB(var_1, var_2, H - (1.0 / 3.0));
            }
            return Color.FromArgb((int)Math.Min(Math.Round(R), 255.0),
                                  (int)Math.Min(Math.Round(G), 255.0),
                                  (int)Math.Min(Math.Round(B), 255.0));
        }
        public double Hue_2_RGB(double v1, double v2, double vH)
        {
            if (vH < 0.0)
            {
                vH += 1.0;
            }
            if (vH > 1.0)
            {
                vH -= 1.0;
            }
            if ((6.0 * vH) < 1.0)
            {
                return (v1 + (v2 - v1) * 6.0 * vH);
            }
            if ((2.0 * vH) < 1.0)
            {
                return (v2);
            }
            if ((3.0 * vH) < 2.0)
            {
                return (v1 + (v2 - v1) * ((2.0 / 3.0) - vH) * 6.0);
            }
            return (v1);
        }
    }
}
