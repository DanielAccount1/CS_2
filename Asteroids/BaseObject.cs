using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class GameObjectException : ApplicationException
    {
        public GameObjectException(string message) : base(message)
        {

        }
    }
    abstract class BaseObject : ICollision
    {
        public Point Pos { get; set; }
        public Point Dir { get; set; }
        public Size Size { get; set; }

        public Rectangle Rect => new Rectangle(Pos, Size);

        public BaseObject()
        {
            Pos = new Point(0, 0);
            Dir = new Point(0, 0);
            Size = new Size(0, 0);
        }

        public BaseObject(Point pos, Point dir, Size size)
        {
            if (size.Width < 0 || size.Height < 0)
                 throw new GameObjectException("Size cannot be defined by negative values");
            if (dir.X > 100 || dir.X < -100 || dir.Y > 100 || dir.Y < -100)
                throw new GameObjectException("Direction can be defined within -100 to 100");
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();
        public abstract void Update();

        public bool Collision(ICollision obj)
        {
            return this.Rect.IntersectsWith(obj.Rect);
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

        public override void Update()
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
        public override void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y + Dir.Y);
            if (Pos.X > Game.Width)
                Pos = new Point(0 - Size.Width, Pos.Y);
            if (Pos.X < 0)
                Pos = new Point(Game.Width + Size.Width, Pos.Y);
            if (Pos.Y > Game.Height)
                Pos = new Point(Pos.X, 0 - Size.Height);
            if (Pos.Y < 0)
                Pos = new Point(Pos.X, Game.Height + Size.Height);
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
        public override void Update()
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
    class Asteroid : BaseObject
    {
        static Image Image { get; } = Image.FromFile("Images\\Asteroid.png");
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        public Asteroid()
        {

        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Height, Size.Width);
        }

        public override void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y);
            if (Pos.X < -Size.Width)
                Pos = new Point(Game.Width + Game.Random.Next(1, 100),
                    Game.Random.Next(0, Game.Height));
        }
    }
    class Bullet : BaseObject
    {
        //static Image Image { get; } = Image.FromFile("Images\\Asteroid.png");
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillRectangle(Brushes.Red, Pos.X, Pos.Y, Size.Height, Size.Width);
        }

        public override void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y);
            if (Pos.X < -Size.Width)
                Pos = new Point(Game.Width + Game.Random.Next(1, 100),
                    Game.Random.Next(0, Game.Height));
        }
    }
}
