using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using test;

namespace test
{
    public class GameControl
    {

        public bool is_win = false;
        private Bitmap Win;
        private AnimationScript win_anim_scr;
        public Sprite win_sp;


        public GameControl() 
        {
            
            SplashKit.LoadResourceBundle("win_bundle", "win.txt");
            Win = SplashKit.BitmapNamed("win");
            win_anim_scr = SplashKit.LoadAnimationScript("win_anim", "win_anim.txt");
            win_sp = SplashKit.CreateSprite(Win, win_anim_scr);

            SplashKit.SpriteStartAnimation(win_sp, "win");
            SplashKit.SpriteSetX(win_sp, 120);
            SplashKit.SpriteSetY(win_sp, 120);
        }




        public bool is_alive = true;
        public bool is_alive_1 = true;
        public bool is_alive_2 = true;
        SplashKitSDK.Timer dieTimer = SplashKit.CreateTimer("die timer");
        public void Control_Die(Hero character, Hero rival)
        {           
            if (character.is_die || character.CheckCollision(character, rival))
            {
                Console.WriteLine("hi11");
                if (is_alive)
                {
                    if (!character.is_die)
                    {
                        character.is_die = character.CheckCollision(character, rival);
                    }
                    
                    is_alive = false;
                    character._sprite = character.character_die_sp;
                    SplashKit.SpriteStartAnimation(character._sprite, "die_1");
                    dieTimer.Start();
                }

            }

            
            if (!is_alive && character.is_die)
            {
                Console.WriteLine("hi22");
                if (SplashKit.TimerTicks("die timer") > 2000 && is_alive_1)
                {
                    Console.WriteLine("hi1");
                    SplashKit.SpriteStartAnimation(character._sprite, "die_2");
                    is_alive_1 = false;
                }
                if (SplashKit.TimerTicks("die timer") > 3000 && is_alive_2)
                {
                    Console.WriteLine("hi2");
                    is_alive_2 = false;
                    SplashKit.SpriteStartAnimation(character._sprite, "die_3");
                }
                if (SplashKit.TimerTicks("die timer") > 5000)
                {
                    Console.WriteLine("hi3");
                    is_win = true;

                }
            }

        }

        public void MainControl(Character1 character1, Character2 character2, Maps map)
        {
          //  Console.WriteLine("main");
            if (is_alive)
            {
                if (character1._bombs.Count() < character1.list_bomb)
                {
                    character1.AddBomb(KeyCode.SpaceKey);
                }
                if (character2._bombs.Count() < character2.list_bomb)
                {
                    character2.AddBomb(KeyCode.KeypadEnter);
                }
                character2.HandleMovementAnimation(KeyCode.RightKey, KeyCode.LeftKey, KeyCode.DownKey, KeyCode.UpKey);
                character2.HandleMovement(map);

                character1.HandleMovementAnimation(KeyCode.DKey, KeyCode.AKey, KeyCode.SKey, KeyCode.WKey);
                character1.HandleMovement(map);
            }
        }

        public void ControlDrawBomb(Character1 character1, Character2 character2, Map map, Monster monster)
        {
            if (character1._bombs.Count() > 0)
            {
                character1.DrawBomb(map, character1);

            }
            // Draw bomb bazzi
            if (character2._bombs.Count() > 0)
            {
                character2.DrawBomb(map, character2);
            }
        }


        public void MainControl1Player(Character1 character1, Map map)
        {
            if (is_alive)
            {
                if (character1._bombs.Count() < character1.list_bomb)
                {
                    character1.AddBomb(KeyCode.SpaceKey);
                }
                character1.HandleMovementAnimation(KeyCode.DKey, KeyCode.AKey, KeyCode.SKey, KeyCode.WKey);
                character1.HandleMovement(map);         
                if (map._monsters.Count() == 0)
                {
                    is_win = true;
                }
            }
        }
        public void Control_Die_1Player(Hero character)
        {
            if (character.is_die)
            {
                if (is_alive)
                {
                    is_alive = false;
                    character._sprite = character.character_die_sp;
                    SplashKit.SpriteStartAnimation(character._sprite, "die_1");
                    dieTimer.Start();
                }

            }

            if (!is_alive && character.is_die)
            {
                if (SplashKit.TimerTicks("die timer") > 2000 && is_alive_1)
                {

                    SplashKit.SpriteStartAnimation(character._sprite, "die_2");
                    is_alive_1 = false;
                }
                if (SplashKit.TimerTicks("die timer") > 3000 && is_alive_2)
                {
                    is_alive_2 = false;
                    SplashKit.SpriteStartAnimation(character._sprite, "die_3");
                    is_win = true;
                }
            }
        }

        public void ControlDrawBomb1Player(Hero character, Map map)
        {

            // Draw bomb bazzi
            if (character._bombs.Count() > 0)
            {
                character.DrawBomb(map, character);
            }
        }


        public void MainControlSpeed(Character1 character1, Character2 character2, Maps map)
        {
            if (is_alive)
            {
                if (character1._bombs.Count() < character1.list_bomb)
                {
                    character1.AddBomb(KeyCode.SpaceKey);
                }
                if (character2._bombs.Count() < character2.list_bomb)
                {
                    character2.AddBomb(KeyCode.KeypadEnter);
                }
                character2.HandleMovementAnimation(KeyCode.RightKey, KeyCode.LeftKey, KeyCode.DownKey, KeyCode.UpKey);
                character2.HandleMovement(map);

                character1.HandleMovementAnimation(KeyCode.DKey, KeyCode.AKey, KeyCode.SKey, KeyCode.WKey);
                character1.HandleMovement(map);

                if (character1.list_speed == 10 || character2.list_speed == 10)
                {
                    is_win = true;
                }
            }
        }


    }
}
