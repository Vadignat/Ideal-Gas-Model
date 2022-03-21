using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gas_model_ideal
{
    public class Painter
    {
        private int figureCount = 10;
        public int FigureCount
        {
            get => figureCount;
            set
            {
                figureCount = value switch
                {
                    <= 10 => 10,
                    >10 => value
                };
            }
        }

        private Random random = new Random();
        private List<Circle> fgs = new List<Circle>();
        public Painter(int figureCount, Size containerSize)
        {
            FigureCount = figureCount;
            CreateFigures(containerSize);
        }

        private void CreateFigures(Size containerSize)
        {
            for (int i = 0; i < FigureCount; i++)
            {
                var r = random.Next(35, 90);
                var x = random.Next(containerSize.Width - 2*r);
                var y = random.Next(containerSize.Height - 2*r);
                fgs.Add(new Circle(x, y, r, containerSize));
            }
        }
        public void AddFigure(int x, int y,Graphics g,Size containerSize)
        {
            figureCount++;
            var r = random.Next(35, 90);
            x = x - r;
            y = y - r;
            fgs.Add(new Circle(x, y, r, containerSize));
            fgs[figureCount-1].DrawCircle(g);
        }

        public void Paint(Graphics g, Size containerSize)
        {
            foreach (var figure in fgs)
            {
                figure.NextPosition(containerSize);
                figure.DrawCircle(g);
            }
        }     
    }
}
