using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gas_model_ideal
{
    public class Circle
    {
        private int x0;
        private int y0;
        private int dx, dy;
        private int radius;
        private Color figColor;
        private Color borderColor;
        private Size containerSize;
        private Random random = new Random();

        public int X
        {
            get => x0;
            set
            {
                if (value < containerSize.Width - 2*radius)
                    x0 = Math.Max(1, value) % (containerSize.Width - 2 * radius);
                else
                    x0 = containerSize.Width - 2 * radius - 1;
            }
        }

        public int Y
        {
            get => y0;
            set
            {
                if(value < containerSize.Height - 2*radius)
                    y0 = Math.Max(1, value) % (containerSize.Height - (2*radius));
                else
                    y0 = containerSize.Height - (2*radius) - 1;
            }
        }

        public Color FigColor
        {
            get => figColor;
        }

        public Color BorderColor
        {
            get => borderColor;
        }
        public Circle(int x, int y, int r,Size containerSize)
        {
            this.containerSize = containerSize;
            radius = r;
            figColor = Color.FromArgb(
                random.Next(20, 200),
                random.Next(255),
                random.Next(255),
                random.Next(255)
            );
            borderColor = Color.FromArgb(
                random.Next(20, 200),
                random.Next(255),
                random.Next(255),
                random.Next(255)
            );
            dx = random.Next(-10,10);
            dy = random.Next(-10,10);
            (X, Y) = (x, y);
        }

        public Size FigureSize
        {
            get => new Size(2*radius,2*radius);
        }

        public void DrawCircle(Graphics g)
        {
            Pen p = new Pen(BorderColor, 4);
            Brush b = new SolidBrush(FigColor);
            g.FillEllipse(b, x0, y0, 2 * radius, 2 * radius);
            g.DrawEllipse(p, x0, y0, 2 * radius, 2 * radius);

        }
        public void NextPosition(Size containerSize)
        {
            if (x0 >= containerSize.Width - 2 * radius - dx || x0 <= 0)
                dx = -dx;
            x0 += dx;
            if (y0 >= containerSize.Height - 2 * radius - dy || y0 <= 0)
                dy = -dy;
            y0 += dy;
        }
    }
}
