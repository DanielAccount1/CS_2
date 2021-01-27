using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class BaseObject
    {
        protected Point Pos { get; set; }
        protected Point Dir { get; set; }
        protected Size Size { get; set; }

        public BaseObject()
        {
            Pos = new Point(0, 0);
            Dir = new Point(0, 0);
            Size = new Size(0, 0);
        }

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image.FromFile("Images\\BaseObjectDefaultImage.png"),
                Pos.X, Pos.Y, Size.Height, Size.Width);
        }
        public virtual void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y + Dir.Y);
            if (Pos.X > Game.Width)
                Pos = new Point(0, Pos.Y);
            if (Pos.X < 0)
                Pos = new Point(Game.Width, Pos.Y);
            if (Pos.Y > Game.Height)
                Pos = new Point(Pos.X, 0);
            if (Pos.Y < 0)
                Pos = new Point(Pos.X, Game.Height);
        }
    }
    class Star : BaseObject
    {
        static Image Image { get; } = Image.FromFile("Images\\Star.png");
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        { 
        
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Height, Size.Width);
        }
    }
    class Planet : BaseObject
    {
        static Image Image { get; } = Image.FromFile("Images\\MarsAlikePlanet.png");
        public Planet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Height, Size.Width);
        }
    }
    class Galaxy : BaseObject
    {
        static Image Image { get; } = Image.FromFile("Images\\SmapleGalaxy.png");
        public Galaxy(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Height, Size.Width);
        }
    }
    
}
