using System;
using System.Collections.Generic;
using System.Drawing;

namespace Draw
{

    public class GroupShape : Shape
    {


        public GroupShape(RectangleF rect) : base(rect)
        {
        }

        public GroupShape(RectangleShape rectangle) : base(rectangle)
        {
        }

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

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            foreach (Shape shape in SubShape)
            {
                // Calculate the relative position of the sub-shape within the group shape
                PointF subShapeLocation = new PointF(shape.Location.X - Location.X, shape.Location.Y - Location.Y);
                shape.Location = subShapeLocation;

                // Draw the sub-shape
                shape.DrawSelf(grfx);

                // Reset the location of the sub-shape to its original value
                shape.Location = new PointF(shape.Location.X + Location.X, shape.Location.Y + Location.Y);
            }
        }


    }
}


// foreach (item in SubShape){
// if (base.Contains(point))          
// return true;
// else               
//    return false; }
