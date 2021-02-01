using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    static class Game
    {
        static public ulong Timer { get; private set; } = 0;
        static BufferedGraphicsContext context;
        static public BufferedGraphics Buffer { get; private set; }
        static public Random Random { get; } = new Random();
        static public int Width { get; private set; }
        static public int Height { get; private set; }
        static public Image background = Image.FromFile("Images\\Starry-Dark-Space.jpg");
        static public List<BaseObject> objs;
        static public Bullet bullet = new Bullet(new Point(0, 400), new Point(5, 0), new Size(5, 15));
        static Timer timer = new Timer();

        static Game()
        {

        }

        static void Load()
        {
            objs = new List<BaseObject>();
            //Floating Planet
            objs.Add(new Planet(new Point(Random.Next(0, Game.Width), Random.Next(0, Game.Height)),
                    new Point(1, 0), new Size(100, 100)));
            //Floating Stars
            for (int i = 0; i < 40; i++)
                objs.Add(new Star(new Point(Random.Next(0, Game.Width), Random.Next(0, Game.Height)),
                    new Point(2, 0), new Size(10, 10)));
            //Floating Asteroids
            for (int i = 0; i < 20; i++)
                objs.Add(new Asteroid(new Point(Random.Next(0, Game.Width), Random.Next(0, Game.Height)),
                    new Point(-8, 0), new Size(25, 25)));
        }

        static public void Init(Form form)
        {
            Graphics g; 
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            if (form.ClientSize.Width > 1000 || form.ClientSize.Width < 0 ||
                form.ClientSize.Height > 1000 || form.ClientSize.Height < 0)
                throw new ArgumentOutOfRangeException();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
            Load();
            form.FormClosing += Form_FormClosing;
        }

        private static void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        static public void Draw()
        {
            //Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(background, 0, 0);
            //Buffer.Graphics.DrawRectangle(Pens.White, 10, 10, 100, 200);
            foreach (var obj in objs)
                obj.Draw();
            bullet.Draw();
            Buffer.Render();        
        }

        static public void Update()
        {
            foreach (var obj in objs)
            {
                obj.Update();
                if (obj.GetType() == new Asteroid().GetType())
                    if (obj.Collision(bullet))
                    {
                        obj.Pos = new Point(Game.Width, Random.Next(0, Game.Height));
                        bullet.Pos = new Point(0, Random.Next(0, Game.Height));
                    }
            }
            bullet.Update();
        }
    }
}
