using System;
using System.Collections.Generic;
using System.Drawing;

namespace Draw
{
    [Serializable]
    /// <summary>
    /// Класът, който ще бъде използван при управляване на диалога.
    /// </summary>
    public class DialogProcessor : DisplayProcessor
	{
		#region Constructor
		
		public DialogProcessor()
		{
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Избран елемент.
		/// </summary>
		private List<Shape> selection = new List<Shape>();

		public List<Shape> Selection {
			get { return selection; }
			set { selection = value; }
		}
		
		/// <summary>
		/// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
		/// </summary>
		private bool isDragging;
		public bool IsDragging {
			get { return isDragging; }
			set { isDragging = value; }
		}
		
		/// <summary>
		/// Последна позиция на мишката при "влачене".
		/// Използва се за определяне на вектора на транслация.
		/// </summary>
		private PointF lastLocation;
		public PointF LastLocation {
			get { return lastLocation; }
			set { lastLocation = value; }
		}
		
		#endregion
		
		/// <summary>
		/// Добавя примитив - правоъгълник на произволно място върху клиентската област.
		/// </summary>
		public void AddRandomRectangle()
		{
			Random rnd = new Random();
			int x = rnd.Next(100,1000);
			int y = rnd.Next(100,600);
			
			RectangleShape rect = new RectangleShape(new Rectangle(x,y,100,200));
			rect.FillColor = Color.White;

			ShapeList.Add(rect);
		}

        public void AddRandomRuby()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            RubyShape ruby = new RubyShape(new Rectangle(x, y, 100, 200));
            ruby.FillColor = Color.White;

            ShapeList.Add(ruby);
        }

        public void AddRandomHouse()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            HouseShape house = new HouseShape(new Rectangle(x, y, 200, 130));
            house.FillColor = Color.White;

            ShapeList.Add(house);
        }

        public void AddRandomPentagon()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            PentagonShape pentagon = new PentagonShape(new Rectangle(x, y, 100, 200));
            pentagon.FillColor = Color.White;

            ShapeList.Add(pentagon);
        }

        public void AddRandomGroup(GroupShape groupShape)
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

			RectangleF bounds = groupShape.Rectangle;

            GroupShape randShape = new GroupShape(new RectangleF(x, y, bounds.Width, bounds.Height));
            randShape.FillColor = Color.White;

            groupShape.SubShape.Add(randShape);
            ShapeList.Add(randShape);
        }

        /// <summary>
        /// Проверява дали дадена точка е в елемента.
        /// Обхожда в ред обратен на визуализацията с цел намиране на
        /// "най-горния" елемент т.е. този който виждаме под мишката.
        /// </summary>
        /// <param name="point">Указана точка</param>
        /// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
        public Shape ContainsPoint(PointF point)
		{
			for(int i = ShapeList.Count - 1; i >= 0; i--){
				if (ShapeList[i].Contains(point)){
					ShapeList[i].FillColor = Color.Red;
						
					return ShapeList[i];
				}	
			}
			return null;
		}
		
		/// <summary>
		/// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
		/// </summary>
		/// <param name="p">Вектор на транслация.</param>
		public void TranslateTo(PointF p)
		{
			foreach(Shape item in Selection)
					item.Location = new PointF(item.Location.X + p.X - lastLocation.X, item.Location.Y + p.Y - lastLocation.Y);

			lastLocation= p;
		}
	}
}
