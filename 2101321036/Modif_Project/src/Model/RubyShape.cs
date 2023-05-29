using System;
using System.Drawing;

namespace Draw
{
    public class RubyShape : Shape
    {
        public RubyShape(RectangleF rect) : base(rect)
        {
        }

        public RubyShape(RubyShape ruby) : base(ruby)
        {
        }

        public override bool Contains(PointF point)
        {
            return base.Contains(point);
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            grfx.FillPolygon(new SolidBrush(FillColor), GetRubyPoints());
            grfx.DrawPolygon(Pens.Black, GetRubyPoints());
        }

        private PointF[] GetRubyPoints()
        {
            PointF[] points = new PointF[4];

            points[0] = new PointF(Rectangle.Left, Rectangle.Top + Rectangle.Height / 2);
            points[1] = new PointF(Rectangle.Left + Rectangle.Width / 2, Rectangle.Top);
            points[2] = new PointF(Rectangle.Right, Rectangle.Top + Rectangle.Height / 2);
            points[3] = new PointF(Rectangle.Left + Rectangle.Width / 2, Rectangle.Bottom);

            return points;
        }
    }
}
