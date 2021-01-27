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
        static public BaseObject[] objs;
        static Timer timer = new Timer();

        static Game()
        {

        }

        static void Load()
        {
            objs = new BaseObject[30];
            ////Base object
            //for (int i = 0; i < 10; i++)
            //    objs[i] = new BaseObject(new Point(i * 15, i * 15),
            //        new Point(i, i), new Size(10, 10));

            //Galaxy
            for (int i = 0; i < 10; i++)
                objs[i] = new Galaxy(new Point(Random.Next(0, Game.Width), Random.Next(0, Game.Height)),
                    new Point(i, i), new Size(50, 50));

            //Star
            for (int i = 10; i < 20; i++)
                objs[i] = new Star(new Point(Random.Next(0, Game.Width), Random.Next(0, Game.Height)),
                    new Point(i, i), new Size(38, 38));

            //Planet
            for (int i = 20; i < objs.Length; i++)
                objs[i] = new Planet(new Point(Random.Next(0, Game.Width), Random.Next(0, Game.Height)),
                    new Point(i, i), new Size(28, 28));
        }

        static public void Init(Form form)
        {
            Graphics g; 
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

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

            Buffer.Render();        
        }

        static public void Update()
        {
            foreach (var obj in objs)
                obj.Update();
        }
    }
}
