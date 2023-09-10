using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;


namespace test
{

    public class BombController : GameObject
    {

        public bool create_exp = false;


        private System.Timers.Timer bomb_timer;
        private Bitmap bomb;
        private AnimationScript bomb_scr;
        private Sprite bomb_spr;
        private float bomb_x;
        private float bomb_y;

        public float bombX
        {
            get { return bomb_x; }
            set { bomb_x = value; }
        }

        public float bombY
        {
            get { return bomb_y; }
            set { bomb_y = value; }
        }

        public int elapsedMilliseconds;

        private static bool isResourceBundleLoaded = false;
        public BombController()
        {
           
            if (!isResourceBundleLoaded)
            {
                SplashKit.LoadResourceBundle("bomb_bundle", "bomb.txt");
                isResourceBundleLoaded = true;
            }

            bomb = SplashKit.BitmapNamed("bomb_bit");
            bomb_scr = SplashKit.LoadAnimationScript("bomb_anim", "bomb_anim.txt");
            bomb_spr = SplashKit.CreateSprite(bomb, bomb_scr);

            _sprite = bomb_spr;
            bomb_timer = new System.Timers.Timer(100);
            bomb_timer.Elapsed += TimerElapsed;
            bomb_timer.AutoReset = true;
            bomb_timer.Start();
            
        }

        public void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            elapsedMilliseconds += (int)bomb_timer.Interval;
        }


        public void CreateBomb(double x, double y)
        {

            SplashKit.SpriteStartAnimation(bomb_spr, "bomb_iddle");
            x += 10;
            y += 26;
            double a = Math.Round(x / 40);
            double b = Math.Round(y / 40);
            a = a * 40;
            b = b * 40;
            float c = (float)a;
            float d = (float)b;

            bombX = c;
            bombY = d;

            SplashKit.SpriteSetX(bomb_spr, c - 2);
            SplashKit.SpriteSetY(bomb_spr, d);


        }
    }
}
