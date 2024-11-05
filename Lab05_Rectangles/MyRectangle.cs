using System.Drawing;

namespace Lab05_Rectangles
{
    internal class MyRectangle
    {
        private Point location;
        private Size size;
        private Color fillColor;

        public int X
        {
            get
            {
                return location.X;
            }
            set
            {
                location.X = value;
            }
        }
        public int Y
        {
            get
            {
                return location.Y;
            }
            set
            {
                location.Y = value;
            }
        }
        public int Width
        {
            get
            {
                return size.Width;
            }
        }
        public int Height
        {
            get
            {
                return size.Height;
            }
        }
        public Color FillColor
        {
            get
            {
                return fillColor;
            }
        }


        public MyRectangle(Point location, Size size, Color fillColor)
        {
            this.location = location;
            this.size = size;
            this.fillColor = fillColor;
        }

        public bool Contains(Point location)
        {
            if(location.X > this.X &&
               location.Y > this.Y &&
               location.X < this.X + this.Width &&
               location.Y < this.Y + this.Height)
            {
                return true;
            }
            return false;
        }
    }
}