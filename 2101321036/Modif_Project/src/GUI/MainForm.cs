using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Draw
{
	/// <summary>
	/// Върху главната форма е поставен потребителски контрол,
	/// в който се осъществява визуализацията
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
		/// </summary>
		private DialogProcessor dialogProcessor = new DialogProcessor();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		/// <summary>
		/// Изход от програмата. Затваря главната форма, а с това и програмата.
		/// </summary>
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		
		/// <summary>
		/// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
		/// </summary>
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);
		}
		
		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>
		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomRectangle();
			
			statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";
			
			viewPort.Invalidate();
		}

		/// <summary>
		/// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
		/// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
		/// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
		/// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
		/// </summary>
		void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (pickUpSpeedButton.Checked) {
				Shape sel = dialogProcessor.ContainsPoint(e.Location);
				if (sel != null)
				{
					if (dialogProcessor.Selection.Contains(sel))
					{
						dialogProcessor.Selection.Remove(sel);
					}
					else
					{
						dialogProcessor.Selection.Add(sel);
					}
					
				}
					statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
					dialogProcessor.IsDragging = true;
					dialogProcessor.LastLocation = e.Location;
					viewPort.Invalidate();				
			}
		}

		/// <summary>
		/// Прихващане на преместването на мишката.
		/// Ако сме в режм на "влачене", то избрания елемент се транслира.
		/// </summary>
		void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging) {
				if (dialogProcessor.Selection != null) statusBar.Items[0].Text = "Последно действие: Влачене";
				dialogProcessor.TranslateTo(e.Location);
				viewPort.Invalidate();
			}
		}

		/// <summary>
		/// Прихващане на отпускането на бутона на мишката.
		/// Излизаме от режим "влачене".
		/// </summary>
		void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
		}

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomRuby();

            statusBar.Items[0].Text = "Последно действие: Рисуване на рубин";

            viewPort.Invalidate();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomHouse();

            statusBar.Items[0].Text = "Последно действие: Рисуване на къща";

            viewPort.Invalidate();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomPentagon();

            statusBar.Items[0].Text = "Последно действие: Рисуване на пентагон (ковчег)";

            viewPort.Invalidate();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = colorDialog1.Color;

                foreach (Shape shape in dialogProcessor.Selection)
                {
                    shape.FillColor = selectedColor;
                }

                viewPort.Invalidate();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            // Check if there is any selection at all
            if (dialogProcessor.Selection.Count > 0)
            {
                float minX = float.MaxValue;
                float minY = float.MaxValue;
                float maxX = float.MinValue;
                float maxY = float.MinValue;

                // Calculate the bounding box of the selected shapes by finding their min and max values
                foreach (Shape item in dialogProcessor.Selection)
                {
                    RectangleF bounds = item.Rectangle;

                    if (bounds.Left < minX)
                        minX = bounds.Left;
                    if (bounds.Top < minY)
                        minY = bounds.Top;
                    if (bounds.Right > maxX)
                        maxX = bounds.Right;
                    if (bounds.Bottom > maxY)
                        maxY = bounds.Bottom;
                }
                //RectangleF boundingBox = RectangleF.FromLTRB(minX, minY, maxX, maxY);
               // GroupShape newShape = new GroupShape(boundingBox);

                 GroupShape groupShape = new GroupShape(new RectangleF(minX, minY, maxX - minX, maxY - minY));

                foreach (Shape item in dialogProcessor.Selection)
                {
                    groupShape.SubShape.Add(item);
                }

				dialogProcessor.AddRandomGroup(groupShape);
				dialogProcessor.ShapeList.Add(groupShape);
                viewPort.Invalidate();
            }
        }


    }
}
// calculate bounding box
			// new group shape
			// SubShape = Selection