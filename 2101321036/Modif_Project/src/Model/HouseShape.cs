﻿using System;
using System.Drawing;
using System.Security.Policy;

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
            grfx.DrawRectangle(Pens.Black, Rectangle.X, Rectangle.Y + triangleHeight, Rectangle.Width, Rectangle.Height - triangleHeight);
            grfx.FillPolygon(new SolidBrush(FillColor), trianglePoints);
            grfx.DrawPolygon(Pens.Black, trianglePoints);
            
        }

    }
}
