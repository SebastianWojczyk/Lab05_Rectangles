using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05_Rectangles
{
    public partial class Form1 : Form
    {
        private Graphics graph;
        private List<MyRectangle> listRectangles;
        private MyRectangle rectangleToMove;
        private Point pointTMP;
        public Form1()
        {
            InitializeComponent();

            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            graph = Graphics.FromImage(pictureBox.Image);

            listRectangles = new List<MyRectangle>();
            listRectangles.Add(new MyRectangle(new Point(200, 100),
                                             new Size(140, 170),
                                             Color.Red)
                            );
            listRectangles.Add(new MyRectangle(new Point(400, 200),
                                             new Size(100, 60),
                                             Color.Blue)
                            );
            listRectangles.Add(new MyRectangle(new Point(100, 250),
                                             new Size(50, 60),
                                             Color.Green)
                            );

            DrawImage();
        }

        private void DrawImage()
        {
            graph.Clear(Color.White);
            
            foreach (MyRectangle rect in listRectangles)
            {
                graph.FillRectangle(new SolidBrush(rect.FillColor),
                                    rect.X,
                                    rect.Y,
                                    rect.Width,
                                    rect.Height);
            }

            pictureBox.Refresh();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                rectangleToMove = null;
                foreach (MyRectangle rect in listRectangles)
                {
                    if (rect.Contains(e.Location))
                    {
                        rectangleToMove = rect;
                        pointTMP = e.Location;
                    }
                }
                /*
                listRectangles.Reverse();
                foreach (MyRectangle rect in listRectangles)
                {
                    if (rect.Contains(e.Location))
                    {
                        //this.Text = "OK";
                        rectangleToMove = rect;
                        pointTMP = e.Location;
                        break;
                    }
                    else
                    {
                        //this.Text = "---";
                        rectangleToMove = null;
                    }
                }
                listRectangles.Reverse();
                */
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (rectangleToMove != null)
                {
                    rectangleToMove.X += e.X - pointTMP.X;
                    rectangleToMove.Y += e.Y - pointTMP.Y;

                    pointTMP = e.Location;

                    DrawImage();
                }
            }
        }
    }
}
