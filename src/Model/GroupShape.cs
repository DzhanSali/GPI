using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    public class GroupShape : Shape
    {

        public GroupShape(RectangleF rect) : base(rect)
        {
        }

        public GroupShape(RectangleShape rectangle) : base(rectangle)
        {
        }

        private float rotationAngle = 0f;
        public List<Shape> SubShape = new List<Shape>();


        public override bool Contains(PointF point)
        {
            foreach (Shape shape in SubShape)
            {
                if (shape.Contains(point))
                {
                    return true;
                }
            }

            return false;
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

            foreach (Shape shape in SubShape)
            {
                PointF subShapeLocation = new PointF(shape.Location.X - Rectangle.X, shape.Location.Y - Rectangle.Y);
                shape.Location = subShapeLocation;

                Pen pen = new Pen(Color.Black, BorderWidth);
                shape.Pen = pen;
                shape.DrawSelf(grfx);

                shape.Location = new PointF(shape.Location.X + Rectangle.X, shape.Location.Y + Rectangle.Y);
            }
            grfx.ResetTransform();
        }

        public override float RotationAngle
        {
            get { return rotationAngle; }
            set { rotationAngle = value; }
        }
    }
}

