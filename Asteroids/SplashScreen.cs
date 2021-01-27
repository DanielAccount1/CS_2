using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    class SplashScreen
    {
        static public ulong Timer { get; private set; } = 0;
        static BufferedGraphicsContext context;
        static public BufferedGraphics Buffer { get; private set; }
        static public Random Random { get; } = new Random();
        static public int Width { get; private set; }
        static public int Height { get; private set; }
        static public Image background = Image.FromFile("Images\\Starry-Dark-Space.jpg");
        static public List<SplashObject> objs;
        static Timer timer = new Timer();

        static SplashScreen()
        {

        }

        static void Load()
        {
            objs = new List<SplashObject>();
            //Floating Stars
            for (int i = 0; i < 40; i++)
                objs.Add(new SplashStar(new Point(Random.Next(0, SplashScreen.Width), Random.Next(0, SplashScreen.Height)),
                    new Point(3, 0), new Size(10, 10)));
            //Floating Planet
            objs.Add(new SplashPlanet(new Point(Random.Next(0, SplashScreen.Width), Random.Next(0, SplashScreen.Height)),
                    new Point(1, 0), new Size(100, 100)));
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
            Buffer.Graphics.DrawImage(background, 0, 0);

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
