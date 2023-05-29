using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    public class RubyShape : Shape
    {
        [NonSerialized]
        GraphicsPath path = new GraphicsPath();
        private float rotationAngle = 0f;

        public RubyShape(RectangleF rect) : base(rect)
        {
        }

        public RubyShape(RubyShape ruby) : base(ruby)
        {
        }

        public override bool Contains(PointF point)
        {
            PointF[] rubyPoints = GetRubyPoints();
            path = new GraphicsPath();
            path.AddPolygon(rubyPoints);

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

            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(RotationAngle, Rectangle.Location + new SizeF(Rectangle.Width / 2, Rectangle.Height / 2));

            grfx.Transform = transformMatrix;
            grfx.FillPolygon(new SolidBrush(FillColor), GetRubyPoints());
            grfx.DrawPolygon(new Pen(Color.Black, BorderWidth), GetRubyPoints());

            grfx.ResetTransform();
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

        public override void Rotate90Degrees()
        {
            base.Rotate90Degrees();

            PointF center = new PointF(Rectangle.Left + Rectangle.Width / 2, Rectangle.Top + Rectangle.Height / 2);
            PointF[] rubyPoints = GetRubyPoints();

            Matrix rotationMatrix = new Matrix();
            rotationMatrix.RotateAt(90f, center);

            rotationMatrix.TransformPoints(rubyPoints);

            path.Reset();
            path.AddPolygon(rubyPoints);
        }

    }
}
