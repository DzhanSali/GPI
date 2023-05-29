using System;
using System.Drawing;

namespace Draw
{

    public class HouseShape : Shape
    {
        #region Constructor

        public HouseShape(RectangleF rect) : base(rect)
        {
        }

        public HouseShape(HouseShape house) : base(house)
        {
        }

        #endregion


        public override bool Contains(PointF point)
        {
            return base.Contains(point);
        }


        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            float triangleHeight = Rectangle.Height / 3f;
            float triangleBase = Rectangle.Width;


            grfx.FillRectangle(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y + triangleHeight, Rectangle.Width, Rectangle.Height - triangleHeight);
            grfx.DrawRectangle(Pens.Black, Rectangle.X, Rectangle.Y + triangleHeight, Rectangle.Width, Rectangle.Height - triangleHeight);


            PointF[] trianglePoints = new PointF[3];
            trianglePoints[0] = new PointF(Rectangle.X, Rectangle.Y + triangleHeight);
            trianglePoints[1] = new PointF(Rectangle.X + triangleBase / 2f, Rectangle.Y);
            trianglePoints[2] = new PointF(Rectangle.X + triangleBase, Rectangle.Y + triangleHeight);
            grfx.FillPolygon(new SolidBrush(FillColor), trianglePoints);
            grfx.DrawPolygon(Pens.Black, trianglePoints);
        }

    }
}
