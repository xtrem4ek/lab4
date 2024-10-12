using System;
using System.Drawing;
using System.Windows.Forms;

namespace CoordinateSystemApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Отримання координат x та y
            if (double.TryParse(txtX.Text, out double x) && double.TryParse(txtY.Text, out double y))
            {
                string quadrant = DetermineQuadrant(x, y);
                lblResult.Text = "Четверть: " + quadrant;

                // Оновлення графіка
                this.Invalidate(); // Це викликає OnPaint
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректні числові значення для x та y.");
            }
        }

        private string DetermineQuadrant(double x, double y)
        {
            if (x > 0 && y > 0) return "I";
            if (x < 0 && y > 0) return "II";
            if (x < 0 && y < 0) return "III";
            if (x > 0 && y < 0) return "IV";
            return "На осі координат";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Візуалізація точки
            if (double.TryParse(txtX.Text, out double x) && double.TryParse(txtY.Text, out double y))
            {
                int centerX = this.ClientSize.Width / 2;
                int centerY = this.ClientSize.Height / 2;

                // Визначення кольору точки на основі четверті
                Color pointColor = Color.Black;
                if (x > 0 && y > 0) pointColor = Color.Green;
                else if (x < 0 && y > 0) pointColor = Color.Blue;
                else if (x < 0 && y < 0) pointColor = Color.Red;
                else if (x > 0 && y < 0) pointColor = Color.Orange;

                // Малювання точки
                using (Brush brush = new SolidBrush(pointColor))
                {
                    e.Graphics.FillEllipse(brush, centerX + (int)x - 5, centerY - (int)y - 5, 10, 10);
                }
            }
        }
    }
}
