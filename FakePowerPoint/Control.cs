using System.Drawing;

namespace FakePowerPoint
{
    public class Control
    {
        public void DrawAll(ref Graphics graphics)
        {
            var rectangle = new Rectangle(Color.FromArgb(153, 132, 120, 222), new System.Tuple<int, int>(100, 100));
            rectangle.Width = 100;
            rectangle.Height = 100;
            rectangle.Draw(graphics);
        }

    }
}
