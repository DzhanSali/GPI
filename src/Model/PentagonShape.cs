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
        private float rotationAngle = 0f;

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

            PointF center = new PointF(Rectangle.X + Rectangle.Width / 2f, Rectangle.Y + Rectangle.Height / 2f);

            Matrix rotationMatrix = new Matrix();
            rotationMatrix.RotateAt(rotationAngle, center);

            grfx.Transform = rotationMatrix;

            PointF[] pentagonPoints = GetPentagonPoints();
            grfx.FillPolygon(new SolidBrush(FillColor), pentagonPoints);
            grfx.DrawPolygon(new Pen(Color.Black, BorderWidth), pentagonPoints);
            path = new GraphicsPath();
            path.AddPolygon(pentagonPoints);

            grfx.ResetTransform();
        }

        private PointF[] GetPentagonPoints()
        {
            PointF[] pentagonPoints = new PointF[5];

            // Top center of rectangle
            pentagonPoints[0] = new PointF(Rectangle.X + Rectangle.Width / 2f, Rectangle.Y);
            // Top right of rectangle
            pentagonPoints[1] = new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height / 3f);
            // Bottom right of rectangle
            pentagonPoints[2] = new PointF(Rectangle.X + Rectangle.Width * 2f / 3f, Rectangle.Y + Rectangle.Height);
            // Bottom left of rectangle
            pentagonPoints[3] = new PointF(Rectangle.X + Rectangle.Width / 3f, Rectangle.Y + Rectangle.Height);
            // Top left of rectangle
            pentagonPoints[4] = new PointF(Rectangle.X, Rectangle.Y + Rectangle.Height / 3f);

            return pentagonPoints;
        }
        public override float RotationAngle
        {
            get { return rotationAngle; }
            set { rotationAngle = value; }
        }
    }
}
