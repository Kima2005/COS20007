using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Explosion1
    {
        public int power = 1;

        private int col_up;
        private int col_down;
        private int col_right;
        private int col_left;

        public (int x, int y) exp_up_pos;
        public (int x, int y) exp_down_pos;
        public (int x, int y) exp_right_pos;
        public (int x, int y) exp_left_pos;
        public (int x, int y) exp_center_pos;


        private List<Sprite> exp_up_sp_list = new List<Sprite>();
        private List<Sprite> exp_down_sp_list = new List<Sprite>();
        private List<Sprite> exp_right_sp_list = new List<Sprite>();
        private List<Sprite> exp_left_sp_list = new List<Sprite>();

        private Bitmap exp_center;
        private Bitmap exp_up;
        private Bitmap exp_down;
        private Bitmap exp_right;
        private Bitmap exp_left;

        private AnimationScript exp_center_scr;
        private AnimationScript exp_up_scr;
        private AnimationScript exp_down_scr;
        private AnimationScript exp_right_scr;
        private AnimationScript exp_left_scr;

        private Sprite exp_center_sp;
        private Sprite exp_up_sp;
        private Sprite exp_down_sp;
        private Sprite exp_right_sp;
        private Sprite exp_left_sp;


        private static bool isResourceBundleLoaded = false;

        public Explosion1()
        {

            if (!isResourceBundleLoaded)
            {
                SplashKit.LoadResourceBundle("exp_bundle", "exp.txt");
                isResourceBundleLoaded = true;
            }



            exp_center = SplashKit.BitmapNamed("Exp_center");
            exp_up = SplashKit.BitmapNamed("Exp_up");
            exp_down = SplashKit.BitmapNamed("Exp_down");
            exp_right = SplashKit.BitmapNamed("Exp_right");
            exp_left = SplashKit.BitmapNamed("Exp_left");

            exp_center_scr = SplashKit.LoadAnimationScript("exp_center_anim", "exp_center_anim.txt");
            exp_up_scr = SplashKit.LoadAnimationScript("exp_up_anim", "exp_up_anim.txt");
            exp_down_scr = SplashKit.LoadAnimationScript("exp_down_anim", "exp_down_anim.txt");
            exp_right_scr = SplashKit.LoadAnimationScript("exp_right_anim", "exp_right_anim.txt");
            exp_left_scr = SplashKit.LoadAnimationScript("exp_left_anim", "exp_left_anim.txt");


            exp_center_sp = SplashKit.CreateSprite(exp_center, exp_center_scr);


        }

        public void CreateExp(BombController bomb_c1, Map map)
        {
            check_collision_center(bomb_c1);
            col_up = check_collision_up(map, bomb_c1);
            col_down = check_collision_down(map, bomb_c1);
            col_right = check_collision_right(map, bomb_c1);
            col_left = check_collision_left(map, bomb_c1);

            

            for (int i = 0; i < power; i++) 
            {
                int a = i + 1;
                exp_up_sp = SplashKit.CreateSprite(exp_up, exp_up_scr);
                SplashKit.SpriteStartAnimation(exp_up_sp, "exp_up");
                SplashKit.SpriteSetX(exp_up_sp, bomb_c1.bombX);
                SplashKit.SpriteSetY(exp_up_sp, bomb_c1.bombY - 40*a);
                exp_up_sp_list.Add(exp_up_sp);



                exp_down_sp = SplashKit.CreateSprite(exp_down, exp_down_scr);
                SplashKit.SpriteStartAnimation(exp_down_sp, "exp_down");
                SplashKit.SpriteSetX(exp_down_sp, bomb_c1.bombX);
                SplashKit.SpriteSetY(exp_down_sp, bomb_c1.bombY + 40*a);
                exp_down_sp_list.Add(exp_down_sp);

                exp_right_sp = SplashKit.CreateSprite(exp_right, exp_right_scr);
                SplashKit.SpriteStartAnimation(exp_right_sp, "exp_right");
                SplashKit.SpriteSetX(exp_right_sp, bomb_c1.bombX + 40*a);
                SplashKit.SpriteSetY(exp_right_sp, bomb_c1.bombY);
                exp_right_sp_list.Add(exp_right_sp);

                exp_left_sp = SplashKit.CreateSprite(exp_left, exp_left_scr);

                SplashKit.SpriteStartAnimation(exp_left_sp, "exp_left");
                SplashKit.SpriteSetX(exp_left_sp, bomb_c1.bombX - 40*a);
                SplashKit.SpriteSetY(exp_left_sp, bomb_c1.bombY);
                exp_left_sp_list.Add(exp_left_sp);


            }

            SplashKit.SpriteStartAnimation(exp_center_sp, "exp_center");
            SplashKit.SpriteSetX(exp_center_sp, bomb_c1.bombX);
            SplashKit.SpriteSetY(exp_center_sp, bomb_c1.bombY);

       



            

        }

        public void check_collision_center(BombController pos)
        {
                int i = (int)(pos.bombY / 40);
                int j = (int)(pos.bombX / 40);

                exp_center_pos = (i, j - 1);

            
        }

        public int check_collision_up(Map bitmap, BombController pos)
        {
            for (int m = 0; m<power; m++)
            {
                int i = (int)((pos.bombY - 40*(m+1)) / 40);
                int j = (int)(pos.bombX / 40);

                

                if (i<0)
                {
                    i +=1 ;
                }
                else if (i>17)
                {
                    i -= 1;
                }
                if (j < 0)
                {
                    j += 1;
                }
                else if (j > 17)
                {
                    j -= 1;
                }

                if (bitmap._grid[i, j] != 0)
                {
                    if (bitmap._grid[i, j] == 1 || bitmap._grid[i, j] == 9 || bitmap._grid[i, j] == 10)
                    {
                        bitmap._grid[i, j] = 0;
                        bitmap.AddItem(i, j);
                        return m;

                    }
                    exp_up_pos = (i, j - 1);
                    return m;
                }
                exp_up_pos = (i-1, j - 1);

            }
          
            return power;
        }

        public int check_collision_left(Map bitmap, BombController pos)
        {

            for (int m = 0; m < power; m++)
            {
                int i = (int)(pos.bombY / 40);
                int j = (int)((pos.bombX - 40 * (m + 1)) / 40);

              
                if (i < 0)
                {
                    i += 1;
                }
                else if (i > 17)
                {
                    i -= 1;
                }
                if (j < 0)
                {
                    j += 1;
                }
                else if (j > 17)
                {
                    j -= 1;
                }

                if (bitmap._grid[i, j] != 0)
                {
                    if (bitmap._grid[i, j] == 1 || bitmap._grid[i, j] == 9 || bitmap._grid[i, j] == 10)
                    {

                        bitmap._grid[i, j] = 0;
                        bitmap.AddItem(i, j);
                        exp_left_pos = (i - 1, j - 1);
                        return m;

                    }
                    exp_left_pos = (i - 1, j -1);
                    return m;
                }
              
                exp_left_pos = (i - 1, j - 1);
            }
            return power;
        }

        public int check_collision_down(Map bitmap, BombController pos)
        {
            for (int m = 0; m < power; m++)
            {            
                int i = (int)((pos.bombY + 40 * (m + 1)) / 40);
                int j = (int)(pos.bombX/ 40);
                if (i < 0 || i > 17)
                {
                    i = 0;
                }
                if (j < 0 || j > 17)
                {
                    j = 0;
                }
                if (bitmap._grid[i, j] != 0)
                {
                    if (bitmap._grid[i, j] == 1 || bitmap._grid[i, j] == 9 || bitmap._grid[i, j] == 10)
                    {
                        bitmap._grid[i, j] = 0;
                        bitmap.AddItem(i, j);
                        return m;

                    }
                    exp_down_pos = (i - 1, j - 1);
                    return m;
                }
                exp_down_pos = (i - 1, j - 1);
            }
            return power;
        }

        public int check_collision_right(Map bitmap, BombController pos)
        {
            for (int m = 0; m < power; m++)
            {
                int i = (int)(pos.bombY / 40);
                int j = (int)((pos.bombX + 40 * (m + 1)) / 40);
                if (i < 0 || i > 17)
                {
                    i = 0;
                }
                if (j < 0 || j > 17)
                {
                    j = 0;
                }
                if (bitmap._grid[i, j] != 0)
                {
                    if (bitmap._grid[i, j] == 1 || bitmap._grid[i, j] == 9 || bitmap._grid[i, j] == 10)
                    {

                        bitmap._grid[i, j] = 0;
                        bitmap.AddItem(i, j);
                        return m;

                    }
                    exp_right_pos = (i - 1, j - 1);
                    return m;
                }
                    exp_right_pos = (i - 1, j - 1);
            }
            return power;
        }

        public bool check_collision_monster(Monster monster)
        {
            if (SplashKit.SpriteCollision(monster._sprite, exp_center_sp) ||
                SplashKit.SpriteCollision(monster._sprite, exp_up_sp) ||
                SplashKit.SpriteCollision(monster._sprite, exp_down_sp) ||
                SplashKit.SpriteCollision(monster._sprite, exp_right_sp) ||
                SplashKit.SpriteCollision(monster._sprite, exp_left_sp))
            {
                return true;
            }
            return false;
        }
        /*
        public void Set_exp_x(float x)
        {
            SplashKit.SpriteSetX(exp_center_sp, x);
            SplashKit.SpriteSetX(exp_up_sp, x);
            SplashKit.SpriteSetX(exp_down_sp, x);
            SplashKit.SpriteSetX(exp_left_sp, x);
            SplashKit.SpriteSetX(exp_right_sp, x);


        }

        public void Set_exp_y(float y)
        {
            SplashKit.SpriteSetX(exp_center_sp, y);
            SplashKit.SpriteSetX(exp_up_sp, y);
            SplashKit.SpriteSetX(exp_down_sp, y);
            SplashKit.SpriteSetX(exp_left_sp, y);
            SplashKit.SpriteSetX(exp_right_sp, y);
        }
        */
        public void Draw_expl(Map map, BombController bomb_c)
        {
            SplashKit.DrawSprite(exp_center_sp);
            for (int i = 0; i < col_down; i++)
            {
                exp_down_sp = exp_down_sp_list[i];
                SplashKit.DrawSprite(exp_down_sp);

            }
            for (int i = 0; i < col_up; i++)
            {
                exp_up_sp = exp_up_sp_list[i];
                SplashKit.DrawSprite(exp_up_sp);              
            }
            for (int i = 0; i < col_right; i++)
            {
                exp_right_sp = exp_right_sp_list[i];
                SplashKit.DrawSprite(exp_right_sp);
            }
            for (int i = 0; i < col_left; i++)
            {
                exp_left_sp = exp_left_sp_list[i];
                SplashKit.DrawSprite(exp_left_sp);
            }


            if (map._monsters.Count() != 0)
            {
                foreach(Monster mon in map._monsters)
                {
                    if (mon.is_die != true)
                    {
                        mon.is_die = check_collision_monster(mon);
                    }
                }
               
            }

           
        }

        public void Update_expl(Explosion1 expl1)
        {
            SplashKit.UpdateSpriteAnimation(expl1.exp_center_sp);
            SplashKit.UpdateSpriteAnimation(expl1.exp_up_sp);
            SplashKit.UpdateSpriteAnimation(expl1.exp_down_sp);
            SplashKit.UpdateSpriteAnimation(expl1.exp_right_sp);
            SplashKit.UpdateSpriteAnimation(expl1.exp_left_sp);
        }

    }
}
