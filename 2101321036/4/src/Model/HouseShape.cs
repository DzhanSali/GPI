using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Policy;

namespace Draw
{
    [Serializable]
    public class HouseShape : Shape
    {
        PointF[] housePoints;
        [NonSerialized]
        GraphicsPath path = new GraphicsPath();

        #region Constructor

        public HouseShape(RectangleF rect) : base(rect)
        {
            housePoints = new PointF[5];
        }

        public HouseShape(HouseShape house) : base(house)
        {
        }

        #endregion


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

            // Height of the triangle - 1/2 of the height of the house shape
            float triangleHeight = Rectangle.Height / 2f;
            //  Assign the width of the rectangle as the base of the triangle
            float triangleBase = Rectangle.Width;


            PointF[] trianglePoints = new PointF[3];
            // Assign the points of the triangle, which are the:
            //
            // Top-left corner of the rectangle
            trianglePoints[0] = new PointF(Rectangle.X, Rectangle.Y + triangleHeight);
            // Top center point of the rectangle (ergo the top of the triangle will allign with the center of rectangle)
            trianglePoints[1] = new PointF(Rectangle.X + triangleBase / 2f, Rectangle.Y);
            // Top-right corner of the rectangle
            trianglePoints[2] = new PointF(Rectangle.X + triangleBase, Rectangle.Y + triangleHeight);

            grfx.FillRectangle(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y + triangleHeight, Rectangle.Width, Rectangle.Height - triangleHeight);
            grfx.DrawRectangle(new Pen(Color.Black, BorderWidth), Rectangle.X, Rectangle.Y + triangleHeight, Rectangle.Width, Rectangle.Height - triangleHeight);
            grfx.FillPolygon(new SolidBrush(FillColor), trianglePoints);
            grfx.DrawPolygon(new Pen(Color.Black, BorderWidth), trianglePoints);

            path = new GraphicsPath();
            path.AddPolygon(trianglePoints);
        }
    }
}
