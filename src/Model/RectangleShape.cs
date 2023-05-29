using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Draw
{
    [Serializable]
    /// <summary>
    /// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
    /// </summary>
    public class RectangleShape : Shape
	{
		#region Constructor
		
		public RectangleShape(RectangleF rect) : base(rect)
		{
		}
		
		public RectangleShape(RectangleShape rectangle) : base(rectangle)
		{
		}

        #endregion
        [NonSerialized]
        GraphicsPath path = new GraphicsPath();
        private float rotationAngle = 0f;

        /// <summary>
        /// Проверка за принадлежност на точка point към правоъгълника.
        /// В случая на правоъгълник този метод може да не бъде пренаписван, защото
        /// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
        /// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
        /// елемента в този случай).
        /// </summary>
        public override bool Contains(PointF point)
		{
			if (base.Contains(point))
				// Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
				// В случая на правоъгълник - директно връщаме true
				return true;
			else
				// Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
				return false;
		}

        public override int BorderWidth
        {
            get { return base.BorderWidth; }
            set { base.BorderWidth = value; }
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            PointF center = new PointF(Rectangle.X + Rectangle.Width / 2f, Rectangle.Y + Rectangle.Height / 2f);

            Matrix rotationMatrix = new Matrix();
            rotationMatrix.RotateAt(rotationAngle, center);

            grfx.Transform = rotationMatrix;

            grfx.FillRectangle(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawRectangle(new Pen(Color.Black, BorderWidth), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            path = new GraphicsPath();
            path.AddRectangle(Rectangle);

            grfx.ResetTransform();
        }
        public override float RotationAngle
        {
            get { return rotationAngle; }
            set { rotationAngle = value; }
        }
    }
}
