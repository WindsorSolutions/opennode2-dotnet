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
    }
}
