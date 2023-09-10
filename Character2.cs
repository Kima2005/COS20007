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
    public class Character2 : Hero
    {

        private Bitmap bazzi_die;
        private AnimationScript bazzi_die_scr;
        private Sprite bazzi_die_sp;

        private Bitmap bazzi_r;
        private Bitmap bazzi_l;
        private Bitmap bazzi_f;
        private Bitmap bazzi_b;

        private AnimationScript rightscr;
        private AnimationScript leftscr;
        private AnimationScript frontscr;
        private AnimationScript backscr;

        private Sprite spri_r;
        private Sprite spri_l;
        private Sprite spri_f;
        private Sprite spri_b;

        public Sprite spri_pt;

        private static bool isResourceBundleLoaded = false;
        public Character2() 
        {

            //Load sprite
            if (!isResourceBundleLoaded)
            {
                SplashKit.LoadResourceBundle("bazzi_bundle", "bazzi.txt");
                isResourceBundleLoaded = true;
            }       
            bazzi_r = SplashKit.BitmapNamed("Bazzi_Right");
            bazzi_l = SplashKit.BitmapNamed("Bazzi_Left");
            bazzi_f = SplashKit.BitmapNamed("Bazzi_Front");
            bazzi_b = SplashKit.BitmapNamed("Bazzi_Back");


            rightscr = SplashKit.LoadAnimationScript("bazzi_run_right", "bazzi_run_right.txt");
            leftscr = SplashKit.LoadAnimationScript("bazzi_run_left", "bazzi_run_left.txt");
            frontscr = SplashKit.LoadAnimationScript("bazzi_run_front", "bazzi_run_front.txt");
            backscr = SplashKit.LoadAnimationScript("bazzi_run_back", "bazzi_run_back.txt");

            spri_r = SplashKit.CreateSprite(bazzi_r, rightscr);
            spri_l = SplashKit.CreateSprite(bazzi_l, leftscr);
            spri_f = SplashKit.CreateSprite(bazzi_f, frontscr);
            spri_b = SplashKit.CreateSprite(bazzi_b, backscr);




            bazzi_die = SplashKit.BitmapNamed("Bazzi_die");
            bazzi_die_scr = SplashKit.LoadAnimationScript("bazzi_die_anim", "bazzi_die_anim.txt");
            bazzi_die_sp = SplashKit.CreateSprite(bazzi_die, bazzi_die_scr);

            character_die_sp = bazzi_die_sp;

            spri_pt = spri_l;
            // Create a drawing option

            SplashKit.SpriteStartAnimation(spri_pt, "move_l");

            x = 240;
            y = 80;


            Set_position_x(x);
            Set_position_y(y);
            _sprite = spri_pt;
        }

        public override void Set_position_x(float x)
        {
            SplashKit.SpriteSetX(spri_pt, x);
            SplashKit.SpriteSetX(spri_l, x);
            SplashKit.SpriteSetX(spri_r, x);
            SplashKit.SpriteSetX(spri_f, x);
            SplashKit.SpriteSetX(spri_b, x);
            SplashKit.SpriteSetX(bazzi_die_sp, x);

        }

        public override void Set_position_y(float y)
        {
            
            SplashKit.SpriteSetY(spri_pt, y);
            SplashKit.SpriteSetY(spri_l, y);
            SplashKit.SpriteSetY(spri_r, y);
            SplashKit.SpriteSetY(spri_f, y);
            SplashKit.SpriteSetY(spri_b, y);
            SplashKit.SpriteSetY(bazzi_die_sp, y);
        }


        public override void HandleMovementAnimation(KeyCode right, KeyCode left, KeyCode down, KeyCode up)
        {
            
            if (SplashKit.KeyTyped(right))
            {
                key_right = right;
                _sprite = spri_r;
                SplashKit.SpriteStartAnimation(_sprite, "move_r");

            }
            if (SplashKit.KeyTyped(left))
            {
                key_left = left;
                _sprite = spri_l;
                SplashKit.SpriteStartAnimation(_sprite, "move_l");

            }
            if (SplashKit.KeyTyped(down))
            {
                key_down = down;
                _sprite = spri_f;
                SplashKit.SpriteStartAnimation(_sprite, "move_f");
            }
            if (SplashKit.KeyTyped(up))
            {
                key_up = up;
                _sprite = spri_b;
                SplashKit.SpriteStartAnimation(_sprite, "move_b");
            }
        }


    }
}
