using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Hall
    {
     
        private Bitmap background = SplashKit.LoadBitmap("background", "bg.png");
        private Bitmap player_bt1 = SplashKit.LoadBitmap("1", "1play_bt.png");
        private Bitmap player_bt11 = SplashKit.LoadBitmap("2", "lonely_bt.png");
        private Bitmap player_bt2 = SplashKit.LoadBitmap("3", "2play_bt.png");
        private Bitmap player_bt22 = SplashKit.LoadBitmap("4", "go_bt.png");

        private Bitmap shoe_bt = SplashKit.LoadBitmap("5", "shoe.png");
        private Bitmap shoe_bt1 = SplashKit.LoadBitmap("6", "fast_bt.png");
        private Bitmap survive_bt = SplashKit.LoadBitmap("7", "survival_bt.png");
        private Bitmap survive_bt1 = SplashKit.LoadBitmap("8", "alive_bt.png");

        public Hall()
        {
            SplashKit.LoadSoundEffect("music", "music.mp3");
            PlayMusic("music");
        }
        public void PlayMusic(string name)
        {
            SoundEffect music = SplashKit.SoundEffectNamed(name);
            music.Play();
        }


    
        public Rectangle rect = new Rectangle()
        {
            X = 60,
            Y = 60,
            Width = 220,
            Height = 85,
        };
        public Rectangle rect1 = new Rectangle()
        {
            X = 60,
            Y = 185,
            Width = 220,
            Height = 85,
        };
        public Rectangle rect2 = new Rectangle()
        {
            X = 60,
            Y = 300,
            Width = 220,
            Height = 85,
        };
        public Rectangle rect3 = new Rectangle()
        {
            X = 60,
            Y = 425,
            Width = 220,
            Height = 85,
        };
     
        public int DrawHall(int choice)
        {

            SplashKit.DrawBitmap(background, -120, -120);
            if (SplashKit.PointInRectangle(new Point2D { X = SplashKit.MouseX(), Y = SplashKit.MouseY() }, rect))
            {                   
                SplashKit.DrawBitmap(player_bt11, 50, 50);
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
              
                    return choice = 1;
                }
            }
            else
            {
                SplashKit.DrawBitmap(player_bt1, 50, 50);
            }

            if (SplashKit.PointInRectangle(new Point2D { X = SplashKit.MouseX(), Y = SplashKit.MouseY() }, rect1))
            {
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
              
                    return choice = 2;
                }
                SplashKit.DrawBitmap(player_bt22, 50, 175);
            }
            else
            {
                SplashKit.DrawBitmap(player_bt2, 50, 175);
            }
            if (SplashKit.PointInRectangle(new Point2D { X = SplashKit.MouseX(), Y = SplashKit.MouseY() }, rect2))
            {
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {

                    return choice = 3;
                }
                SplashKit.DrawBitmap(shoe_bt1, 50, 300);
            }
            else
            {
                SplashKit.DrawBitmap(shoe_bt, 50, 300);
            }
            if (SplashKit.PointInRectangle(new Point2D { X = SplashKit.MouseX(), Y = SplashKit.MouseY() }, rect3))
            {
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {

                    return choice = 4;
                }
                SplashKit.DrawBitmap(survive_bt1, 50, 425);
            }
            else
            {

                SplashKit.DrawBitmap(survive_bt, 50, 425);
            }
            return 0;
        }
    }
}
