using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Monster : Character
    {

        private List<int> pattern = new List<int>() { 0, 1, 2, 3 };
        private int i = 0;
        private bool step = false;
        private int a = 0;

        private Bitmap monster_a;
        private AnimationScript monster_a_scr;
        private Sprite monster_a_sp;

        private Bitmap monster_r;
        private Bitmap monster_l;
        private Bitmap monster_u;
        private Bitmap monster_d;

        private AnimationScript rightscr;
        private AnimationScript leftscr;
        private AnimationScript upscr;
        private AnimationScript downscr;

        private Sprite spri_r;
        private Sprite spri_l;
        private Sprite spri_u;
        private Sprite spri_d;

        private Sprite monster_spri_pt;
        private static bool isResourceBundleLoaded = false;

        public Monster()
        {
                       
            if (!isResourceBundleLoaded)
            {
                SplashKit.LoadResourceBundle("monster_bundle", "monster.txt");
                isResourceBundleLoaded = true;
            }
            is_die = false;

           
            monster_r = SplashKit.BitmapNamed("monster_r");
            monster_l = SplashKit.BitmapNamed("monster_l");
            monster_u = SplashKit.BitmapNamed("monster_u");
            monster_d = SplashKit.BitmapNamed("monster_d");


            rightscr = SplashKit.LoadAnimationScript("monster_run_right", "monster_run_right.txt");
            leftscr = SplashKit.LoadAnimationScript("monster_run_left", "monster_run_left.txt");
            upscr = SplashKit.LoadAnimationScript("monster_run_front", "monster_run_up.txt");
            downscr = SplashKit.LoadAnimationScript("monster_run_back", "monster_run_down.txt");

            spri_r = SplashKit.CreateSprite(monster_r, rightscr);
            spri_l = SplashKit.CreateSprite(monster_l, leftscr);
            spri_u = SplashKit.CreateSprite(monster_u, upscr);
            spri_d = SplashKit.CreateSprite(monster_d, downscr);




            monster_a = SplashKit.BitmapNamed("monster_a");
            monster_a_scr = SplashKit.LoadAnimationScript("monster_a", "monster_appear.txt");
            monster_a_sp = SplashKit.CreateSprite(monster_a, monster_a_scr);



            monster_spri_pt = monster_a_sp;
            // Create a drawing option

            SplashKit.SpriteStartAnimation(monster_spri_pt, "appear");

            x = 40*5-20;
            y = 40*5-20;


            Set_position_x(x);
            Set_position_y(y);
            _sprite = monster_spri_pt;
        }

        public override void Set_position_x(float x)
        {
            SplashKit.SpriteSetX(monster_spri_pt, x);
            SplashKit.SpriteSetX(spri_l, x);
            SplashKit.SpriteSetX(spri_r, x);
            SplashKit.SpriteSetX(spri_u, x);
            SplashKit.SpriteSetX(spri_d, x);
            SplashKit.SpriteSetX(monster_a_sp, x);

        }

        public override void Set_position_y(float y)
        {
            SplashKit.SpriteSetY(monster_spri_pt, y);
            SplashKit.SpriteSetY(spri_l, y);
            SplashKit.SpriteSetY(spri_r, y);
            SplashKit.SpriteSetY(spri_u, y);
            SplashKit.SpriteSetY(spri_d, y);
            SplashKit.SpriteSetY(monster_a_sp, y);
        }

        public bool MonsterCatch(Sprite _sprite, Monster monster)
        {
            if (SplashKit.SpriteCollision(_sprite, monster.monster_spri_pt))
            {
     
                return true;
            }
            return false;
        }

     


        public void HandleMovementAnimation()
        {
            if (i == 0 && step)
            {
                if (pattern.Count == 0)
                {
                    pattern.AddRange(new int[] { 0, 1, 2, 3});
                }
                a = pattern[0]; 
                pattern.RemoveAt(0);
            }
            if (a == 0 )
            {
                if (i == 0 && SplashKit.SpriteAnimationHasEnded(monster_spri_pt))
                {
                    step = false;
                    _sprite = spri_r;
                    SplashKit.SpriteStartAnimation(_sprite, "move_r");
                }
                if (i < 80 && SplashKit.SpriteAnimationHasEnded(monster_spri_pt))
                {
                  
                    i += 1;
                    X += 0.5f;
                    Set_position_x(X);

                }
                else if (i == 80)
                {
                    i = 0;
                    step = true;
                }

            }
            if (a == 1)
            {
               
                if (i == 0 && SplashKit.SpriteAnimationHasEnded(monster_spri_pt))
                {
                    step = false;
                    _sprite = spri_l;
                    SplashKit.SpriteStartAnimation(_sprite, "move_l");
                   
                }
                if (i < 80 && SplashKit.SpriteAnimationHasEnded(monster_spri_pt))
                {
                    i += 1;
                    X -= 0.5f;
                    Set_position_x(X);
                }
                else if (i == 80)
                {
                    i = 0;
                    step = true;
                }
            }
            if (a == 2)
            {
             
                if (i == 0 && SplashKit.SpriteAnimationHasEnded(monster_spri_pt))
                {
                    step = false;
                    _sprite = spri_u;
                    SplashKit.SpriteStartAnimation(_sprite, "move_u");
                }
                if (i < 80 && SplashKit.SpriteAnimationHasEnded(monster_spri_pt))
                {
                    i += 1;
                    Y -= 0.5f;
                    Set_position_y(Y);
                }
                else if (i == 80)
                {
                    i = 0;
                    step = true;
                }
            }
            if (a == 3)
            {

                if (i == 0 && SplashKit.SpriteAnimationHasEnded(monster_spri_pt))
                {
                    step = false;
                    _sprite = spri_d;
                    SplashKit.SpriteStartAnimation(_sprite, "move_d");
                   
                }
                if (i < 80 && SplashKit.SpriteAnimationHasEnded(monster_spri_pt))
                {
                    i += 1;
                    Y += 0.5f;
                    Set_position_y(Y);
                }
                else if (i == 80)
                {
                    i = 0;
                    step = true;
                }
            }
        }

    }
}
