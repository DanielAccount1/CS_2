using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class SplashObject
    {
        protected Point Pos { get; set; }
        protected Point Dir { get; set; }
        protected Size Size { get; set; }

        public SplashObject()
        {
            Pos = new Point(0, 0);
            Dir = new Point(0, 0);
            Size = new Size(0, 0);
        }

        public SplashObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public virtual void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawImage(Image.FromFile("Images\\BaseObjectDefaultImage.png"),
                Pos.X, Pos.Y, Size.Height, Size.Width);
        }
        public virtual void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y + Dir.Y);
            if (Pos.X > SplashScreen.Width)
                Pos = new Point(0, Pos.Y);
            if (Pos.X < 0)
                Pos = new Point(SplashScreen.Width, Pos.Y);
            if (Pos.Y > SplashScreen.Height)
                Pos = new Point(Pos.X, 0);
            if (Pos.Y < 0)
                Pos = new Point(Pos.X, SplashScreen.Height);
        }
    }

    class SplashStar : SplashObject
    {
        static Image Image { get; } = Image.FromFile("Images\\Star.png");
        public SplashStar(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Height, Size.Width);
        }
    }

    class SplashPlanet : SplashObject
    {
        static Image Image { get; } = Image.FromFile("Images\\MarsAlikePlanet.png");
        public SplashPlanet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Height, Size.Width);
        }
        public override void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y + Dir.Y);
            if (Pos.X > SplashScreen.Width + Size.Width)
                Pos = new Point(0 - Size.Width, Pos.Y);
            if (Pos.X < 0 - Size.Width)
                Pos = new Point(SplashScreen.Width + Size.Width, Pos.Y);
            if (Pos.Y > SplashScreen.Height + Size.Height)
                Pos = new Point(Pos.X, 0 - Size.Height);
            if (Pos.Y < 0 - Size.Height)
                Pos = new Point(Pos.X, SplashScreen.Height + Size.Height);
        }
    }
}
