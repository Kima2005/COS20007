using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using SplashKitSDK;
using test;

public class Program
{


    public static void Main()
    {
        Window w = new Window("Crazy Arcade", 680, 680);
     //   bool finished = false;
        int choice = 0;
        Map map = null;
        Map1 map1 = null;
        Character2 character2 = null;
        Character1 character1 = null;
        Monster mon = null;
        GameControl gameControl= new GameControl();
        Hall hall = new Hall();
     

        while (!w.CloseRequested && !SplashKit.KeyTyped(KeyCode.QKey))
        {
            while (choice == 0 && !w.CloseRequested && !SplashKit.KeyTyped(KeyCode.QKey))
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                choice = hall.DrawHall(choice);
                switch (choice)
                {
                    case 1:                    
                    //   mon = new Monster();
                        map = new Map();
                        character1 = new Character1();
                        break;
                    case 2:                   
                        map = new Map();
                        character2 = new Character2();
                        character1 = new Character1();
                        break;
                    case 3:                   
                        map1 = new Map1();
                        character2 = new Character2();
                        character1 = new Character1();
                        break;
                }
                    SplashKit.RefreshScreen();
            }

            SplashKit.ProcessEvents();
            SplashKit.ClearScreen(Color.YellowGreen);
            if (gameControl.is_win)
            {
                Console.WriteLine("win");
 
                SplashKit.DrawSprite(gameControl.win_sp);
                SplashKit.UpdateSpriteAnimation(gameControl.win_sp);
                if (SplashKit.SpriteAnimationHasEnded(gameControl.win_sp))
                {
                    Console.WriteLine("end win");
                    choice = 0;
                    gameControl.is_win = false;
                    gameControl.is_alive = true;
                    gameControl.is_alive_1 = true;
                    gameControl.is_alive_2 = true;
                    SplashKit.SpriteStartAnimation(gameControl.win_sp, "win");
                }
            }

    
            if (choice == 1 && gameControl.is_win == false)
            {
                if (SplashKit.KeyTyped(KeyCode.HKey))
                {
                    choice = 0; // Return to the hall
                }
              
                map.Draw();
                map.DrawSpeeditem();
                map.DrawBombitem();
                map.DrawPoweritem();
                character1.EatItem(character1, map);
                //Console.WriteLine(mon.is_monster_die);
         
                //Draw bomb Blue
                gameControl.ControlDrawBomb1Player(character1, map);

                // Draw Player


                character1.Draw();
                character1.Update();
           
                character1.UpdateBomb();


           

                //Explosion
                character1.UpdateExpl();
                gameControl.Control_Die_1Player(character1);
                gameControl.MainControl1Player(character1, map);

            }


            if (choice==2 && gameControl.is_win == false) 
            {
                if (SplashKit.KeyTyped(KeyCode.HKey))
                {
                    choice = 0; // Return to the hall
                }
                map.Draw();
                map.DrawSpeeditem();
                map.DrawBombitem();
                map.DrawPoweritem();
                character1.EatItem(character1, map);
                character2.EatItem(character2, map);
                //Draw bomb Blue
                gameControl.ControlDrawBomb(character1, character2, map, mon);
                // Draw Player
                character2.Draw();
                character1.Draw();
                // Update the animation
                //Player
                character2.Update();
                character1.Update();

                character2.UpdateBomb();
                character1.UpdateBomb();

                //Explosion

                character2.UpdateExpl();
                character1.UpdateExpl();


                gameControl.Control_Die(character2, character1);
                gameControl.Control_Die(character1, character2);


                gameControl.MainControl(character1, character2, map);

            }
            if (choice == 3 && gameControl.is_win == false)
            {
                if (SplashKit.KeyTyped(KeyCode.HKey))
                {
                    choice = 0; // Return to the hall
                }
                
                map1.Draw();
                map1.DrawSpeeditem();
                if (map1 != null)
                {
                    character1.EatItem(character1, map1);
                    character2.EatItem(character2, map1);
                }
             
                // Draw Player
                character2.Draw();
                character1.Draw();
                character2.Update();
                character1.Update();
                gameControl.MainControlSpeed(character1, character2, map1);

            }
            if (choice == 4)
            {
                SplashKit.DrawText("End of Energy", Color.Black, "arial", 100 , 300, 350);

            }
            SplashKit.RefreshScreen(60);

        }

    }
}
