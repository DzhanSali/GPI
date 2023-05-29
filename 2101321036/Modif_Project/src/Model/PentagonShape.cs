using System.Drawing;

namespace Draw
{
    public class PentagonShape : Shape
    {
        public PentagonShape(RectangleF rect) : base(rect)
        {
        }

        public PentagonShape(PentagonShape pentagon) : base(pentagon)
        {
        }

        public override bool Contains(PointF point)
        {
            return base.Contains(point);
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
     
            PointF[] pentagonPoints = GetPentagonPoints();
            grfx.FillPolygon(new SolidBrush(FillColor), pentagonPoints);
            grfx.DrawPolygon(Pens.Black, pentagonPoints);
        }

        private PointF[] GetPentagonPoints()
        {
            PointF[] pentagonPoints = new PointF[5];

            pentagonPoints[0] = new PointF(Rectangle.X + Rectangle.Width / 2f, Rectangle.Y);
            pentagonPoints[1] = new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height / 3f);
            pentagonPoints[2] = new PointF(Rectangle.X + Rectangle.Width * 2f / 3f, Rectangle.Y + Rectangle.Height);
            pentagonPoints[3] = new PointF(Rectangle.X + Rectangle.Width / 3f, Rectangle.Y + Rectangle.Height);
            pentagonPoints[4] = new PointF(Rectangle.X, Rectangle.Y + Rectangle.Height / 3f);

            return pentagonPoints;
        }
    }
}
