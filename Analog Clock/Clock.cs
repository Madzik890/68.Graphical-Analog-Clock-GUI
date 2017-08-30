using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Vector;

namespace Analog
{
    /// <summary>
    /// Main class who create analog clock
    /// in window form(created on CLR v4.0.30319).
    /// Class have two subclass:
    /// -Hand, this class creating hand for clock and 
    /// counting pos via angel 
    /// -Face, this class creating background for clock
    /// </summary>
    public class Clock
    {
        public Clock() {}

        public List<Hand> hands = new List<Hand>();
        public Face face = new Face(new vector2(155,130),5,100,Color.Chocolate);

        public virtual void Draw(PaintEventArgs e)
        {
            DrawBackground(e);
            DrawHands(e);
        }
        public virtual void RecentryOnWindow(Size size)//function which center the clock in window
        {
            face.pos = new vector2(size.Width / 2, size.Height / 2);
            foreach (Hand value in hands)
            {
                value.Begin = new vector2(size.Width/2, size.Height/2);
            }
        }   
       
        public class Hand//hands of the clock
        {
            public Hand() { }//default constructor
            public Hand(vector2 begin, Color color, float thickness,int radius)
            {
                this.begin = begin; this.color = color; this.thickness = thickness; this.radius = radius;
            }

            public vector2 Begin { set { this.begin = value; } get { return begin; } }
            public vector2 End { get { return end; } }
            public Color Color { set { this.color = value; } get { return color; } }
            public float Radius { set { this.radius = value; } get { return radius; } }
            public float thickness = 3;
            public double rotation = 0;//rotation lead

            public virtual void CalculateAngle()//public function which calculate shape of lead for the given angle   
            {
                end.x = Convert.ToInt32(Begin.x + radius * Math.Sin(rotation * Math.PI / 180));
                end.y = Convert.ToInt32(Begin.y - radius * Math.Cos(rotation * Math.PI / 180));
            }

            private Color color = Color.Aqua;//default color
            private vector2 begin = new vector2(100, 200);//default position
            private vector2 end = new vector2(0, 0);//second point of line who will be automatical counting 
            private float radius = 100;//radius for counting end_vector(last point) via angle
        }
        public class Face//class who create clock face
        {
            public Face() { }
            public Face(vector2 pos, int thickness, float radius, Color color)
            {
                this.pos = pos;this.thickness = thickness; this.radius = radius; this.color = color;
            }

            public Color color = Color.DarkViolet;
            public vector2 pos = new vector2(165, 150);
            public int thickness = 3;
            public float radius = 100;
        }

        private vector2 position = new vector2(165, 150);

        private void DrawHands(PaintEventArgs e)//drawing all clock hands and calculating angle for them
        {
            foreach (Hand value in hands)
            {
                Pen pen = new Pen(value.Color, value.thickness);
                // Create points that define line.
                value.CalculateAngle();

                Point point1 = new Point(value.Begin.x, value.Begin.y);
                Point point2 = new Point(value.End.x, value.End.y);

                // Draw line to screen.
                e.Graphics.DrawLine(pen, point1, point2);
            }

        }
        private void DrawBackground(PaintEventArgs e)
        {
             Pen pen = new Pen(face.color, face.thickness);
            e.Graphics.DrawEllipse(pen, face.pos.x - face.radius, face.pos.y- face.radius,
                   face.radius + face.radius, face.radius + face.radius);
        }
    }
}
