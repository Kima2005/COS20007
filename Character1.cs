using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Character1 : Hero
    {
       

        private Bitmap blue_die;
        private AnimationScript blue_die_scr;
        private Sprite blue_die_sp;

        private Bitmap blue_r;
        private Bitmap blue_l;
        private Bitmap blue_f;
        private Bitmap blue_b;

        private AnimationScript blue_rightscr;
        private AnimationScript blue_leftscr;
        private AnimationScript blue_frontscr;
        private AnimationScript blue_backscr;

        private Sprite blue_spri_r;
        private Sprite blue_spri_l;
        private Sprite blue_spri_f;
        private Sprite blue_spri_b;

        private static bool isResourceBundleLoaded = false;

        public Sprite blue_spri_pt;


        public Character1()
        {

            //Load sprite
            if (!isResourceBundleLoaded)
            {
                SplashKit.LoadResourceBundle("blue_bundle", "blue.txt");
                isResourceBundleLoaded = true;
            }
          
            blue_r = SplashKit.BitmapNamed("Blue_Right");
            blue_l = SplashKit.BitmapNamed("Blue_Left");
            blue_f = SplashKit.BitmapNamed("Blue_Front");
            blue_b = SplashKit.BitmapNamed("Blue_Back");


            blue_rightscr = SplashKit.LoadAnimationScript("blue_run_right", "blue_run_right.txt");
            blue_leftscr = SplashKit.LoadAnimationScript("blue_run_left", "blue_run_left.txt");
            blue_frontscr = SplashKit.LoadAnimationScript("blue_run_front", "blue_run_front.txt");
            blue_backscr = SplashKit.LoadAnimationScript("blue_run_back", "blue_run_back.txt");

            blue_spri_r = SplashKit.CreateSprite(blue_r, blue_rightscr);
            blue_spri_l = SplashKit.CreateSprite(blue_l, blue_leftscr);
            blue_spri_f = SplashKit.CreateSprite(blue_f, blue_frontscr);
            blue_spri_b = SplashKit.CreateSprite(blue_b, blue_backscr);



            
            blue_die = SplashKit.BitmapNamed("Blue_die");
            blue_die_scr = SplashKit.LoadAnimationScript("blue_die_anim", "blue_die_anim.txt");
            blue_die_sp = SplashKit.CreateSprite(blue_die, blue_die_scr);

            character_die_sp = blue_die_sp;

            blue_spri_pt = blue_spri_l;
            // Create a drawing option

            SplashKit.SpriteStartAnimation(blue_spri_pt, "iddle_l");

            x = 150;
            y = 80;

            Set_position_x(x);
            Set_position_y(y);
            _sprite = blue_spri_l;
        }

        public override void Set_position_x(float x)
        {
            SplashKit.SpriteSetX(blue_spri_pt, x);
            SplashKit.SpriteSetX(blue_spri_l, x);
            SplashKit.SpriteSetX(blue_spri_r, x);
            SplashKit.SpriteSetX(blue_spri_f, x);
            SplashKit.SpriteSetX(blue_spri_b, x);
            SplashKit.SpriteSetX(blue_die_sp, x);

        }

        public override void Set_position_y(float y)
        {
            SplashKit.SpriteSetY(blue_spri_pt, y);
            SplashKit.SpriteSetY(blue_spri_l, y);
            SplashKit.SpriteSetY(blue_spri_r, y);
            SplashKit.SpriteSetY(blue_spri_f, y);
            SplashKit.SpriteSetY(blue_spri_b, y);
            SplashKit.SpriteSetY(blue_die_sp, y);
        }
        
        public override void HandleMovementAnimation(KeyCode right, KeyCode left, KeyCode down, KeyCode up)
        {
            if (SplashKit.KeyTyped(right))
            {
                key_right = right;
                _sprite = blue_spri_r;
                SplashKit.SpriteStartAnimation(_sprite, "move_r");

            }
            if (SplashKit.KeyTyped(left))
            {
                key_left = left;
                _sprite = blue_spri_l;
                SplashKit.SpriteStartAnimation(_sprite, "move_l");

            }
            if (SplashKit.KeyTyped(down))
            {
                key_down = down;
                _sprite = blue_spri_f;
                SplashKit.SpriteStartAnimation(_sprite, "move_f");
            }
            if (SplashKit.KeyTyped(up))
            {
                key_up = up;
                _sprite = blue_spri_b;
                SplashKit.SpriteStartAnimation(_sprite, "move_b");
            }
        }

    }
}
