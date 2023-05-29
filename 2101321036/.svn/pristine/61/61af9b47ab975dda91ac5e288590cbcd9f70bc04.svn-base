using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    public class PentagonShape : Shape
    {
        [NonSerialized]
        GraphicsPath path = new GraphicsPath();

        public PentagonShape(RectangleF rect) : base(rect)
        {
        }

        public PentagonShape(PentagonShape pentagon) : base(pentagon)
        {
        }

        public override bool Contains(PointF point)
        {
            return path.IsVisible(point);
        }

        public override int BorderWidth
        {
            get { return base.BorderWidth; }
            set { base.BorderWidth = value; }
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            PointF[] pentagonPoints = GetPentagonPoints();
            grfx.FillPolygon(new SolidBrush(FillColor), pentagonPoints);
            grfx.DrawPolygon(new Pen(Color.Black, BorderWidth), pentagonPoints);
            path = new GraphicsPath();
            path.AddPolygon(pentagonPoints);
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
