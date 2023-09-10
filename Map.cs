using SplashKitSDK;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace test
{
    public class Map : Maps

    {

      
        private List<Monster> _delete_monsters = new List<Monster>();

  

        private Bitmap _floorImage;
        private Bitmap _null;
        private Bitmap _border;
        private Bitmap _b0;
        private Bitmap _o0;
        private Bitmap _o1;
        private Bitmap _o2;
        private Bitmap _o3;
        private Bitmap _o4;
        private Bitmap _o7;
        private Bitmap _s0;
        private Bitmap _w0;
        private Bitmap _w1;


        public Map()
        {

            _grid = new int[MapHeight, MapWidth];

            _floorImage = SplashKit.LoadBitmap("floor", "./map/floor.png");//0
            _border = SplashKit.LoadBitmap("border", "./map/border.png");//98
            _null = SplashKit.LoadBitmap("null", "./map/null.png");//99
            _b0 = SplashKit.LoadBitmap("b0", "./map/b0.png");//1
            _o0 = SplashKit.LoadBitmap("o0", "./map/o0.png");//2
            _o1 = SplashKit.LoadBitmap("o1", "./map/o1.png");//3
            _o2 = SplashKit.LoadBitmap("o2", "./map/o2.png");//4
            _o3 = SplashKit.LoadBitmap("o3", "./map/o3.png");//5
            _o4 = SplashKit.LoadBitmap("o4", "./map/o4.png");//6
            _o7 = SplashKit.LoadBitmap("o7", "./map/o7.png");//7
            _s0 = SplashKit.LoadBitmap("s0", "./map/s0.png");//8
            _w0 = SplashKit.LoadBitmap("w0", "./map/w0.png");//9
            _w1 = SplashKit.LoadBitmap("w1", "./map/w1.png");//10

            InitializeMap();

  
           // _monsters.Add(monster1);
            float m = 40 * 10 - 20;
            monster2.X = m;
            monster2.Y = m;
            monster2.Set_position_x(m);
            monster2.Set_position_y(m);
            _monsters.Add(monster2);


        }

        public void DrawSpeeditem()
        {
            foreach (ItemSpeed itm in speed_items)
            {
                if (speed_items.Count() != 0)
                {
                    itm.Draw();
                    itm.Update();

                }
            }
        }

        public void DrawBombitem()
        {
            foreach (ItemBomb itm in bomb_items)
            {
                if (bomb_items.Count() != 0)
                {
                    itm.Draw();
                    itm.Update();

                }
            }
        }

        public void DrawPoweritem()
        {
            foreach (ItemPower itm in power_items)
            {
                if (power_items.Count() != 0)
                {
                    itm.Draw();
                    itm.Update();

                }
            }
        }

        public void AddItem(int i, int j)
        {
            speed_itm = new ItemSpeed("speed_bit", "speed_anim", "speed_anim.txt", "speed_bundle", "speed_item.txt");

            SplashKit.SpriteStartAnimation(speed_itm._sprite, "speed_iddle");

            bomb_itm = new ItemBomb("bomb_itm_bit", "bomb_itm_anim", "bomb_itm_anim.txt", "bomb_itm_bundle", "bomb_item.txt");
            SplashKit.SpriteStartAnimation(bomb_itm._sprite, "bomb_itm_iddle");


            power_itm = new ItemPower("power_itm_bit", "power_anim", "power_anim.txt", "power_bundle", "power_item.txt");
            SplashKit.SpriteStartAnimation(power_itm._sprite, "power_iddle");


            Random rnd = new Random();


      
            
            if (rnd.Next(5) == 0)
            {
                speed_items.Add(speed_itm);
                speed_itm.Y_sp = i*40;
                speed_itm.X_sp = (j*40) - 5;
            }
            else if (rnd.Next(5) == 1)
            {
                bomb_items.Add(bomb_itm);
                bomb_itm.Y_sp = i*40-5;
                bomb_itm.X_sp = (j*40);
            }
            else if (rnd.Next(5) == 2)
            {
                power_items.Add(power_itm);
                power_itm.Y_sp = i * 40 - 5;
                power_itm.X_sp = (j * 40);
            }
            
        }

        private void InitializeMap()
        {
            // Define the map layout using 0s and 1s
            int[,] layout = new int[,]
            {
                {98, 98, 98, 98, 98, 98, 98, 98, 98, 98, 98, 98, 98, 98, 98, 98, 98},
                {98, 0, 0, 8, 8, 8, 8, 0, 1, 0, 8, 8, 8, 8, 0, 0, 98},
                {98, 1, 2, 3, 3, 3, 4, 2, 0, 2, 3, 3, 3, 4, 2, 1, 98},
                {98, 0, 1, 10, 0, 0, 0, 5, 8, 5, 10, 0, 0, 0, 1, 0, 98},
                {98, 1, 5, 10, 6, 99, 0, 5, 8, 5, 10, 6, 99, 0, 5, 1, 98},
                {98, 0, 5, 9, 99, 99, 0, 5, 8, 5, 9, 99, 99, 0, 5, 0, 98},
                {98, 0, 5, 10, 7, 99, 0, 5, 8, 5, 10, 7, 99, 0, 5, 0, 98},
                {98, 1, 5, 0, 0, 0, 0, 5, 0, 5, 0, 0, 0, 0, 5, 0, 98},
                {98, 0, 2, 3, 3, 3, 4, 8, 1, 8, 3, 3, 3, 4, 2, 0, 98},
                {98, 1, 1, 0, 1, 0, 1, 5, 0, 5, 0, 0, 0, 0, 1, 1, 98},
                {98, 0, 5, 10, 6, 99, 0, 5, 8, 5, 10, 6, 99, 0, 5, 0, 98},
                {98, 1, 5, 9, 99, 99, 0, 5, 8, 5, 9, 99, 99, 0, 5, 1, 98},
                {98, 0, 5, 10, 7, 99, 0, 5, 8, 5, 10, 7, 99, 0, 5, 0, 98},
                {98, 1, 5, 9, 0, 0, 0, 5, 8, 5, 9, 0, 0, 0, 5, 1, 98},
                {98, 0, 2, 3, 3, 3, 4, 2, 0, 2, 3, 3, 3, 4, 2, 0, 98},
                {98, 1, 0, 8, 8, 8, 8, 0, 1, 0, 8, 8, 8, 8, 0, 1, 98},
                {98, 98, 98, 98, 98, 98, 98, 98, 98, 98, 98, 98, 98, 98, 98, 98, 98}


            };








            // Copy the layout to the map grid
            for (int i = 0; i < MapHeight; i++)
            {
                for (int j = 0; j < MapWidth; j++)
                {
                    _grid[i, j] = layout[i, j];
                }
            }
        }

        public override void Draw()
        {
            for (int i = 0; i < MapHeight; i++)
                {
                    for (int j = 0; j < MapWidth; j++)
                    {
                        int cellValue = _grid[i, j];
                        float cellX = j * CellSize;
                        float cellY = i * CellSize;
                        if (cellValue == 0)
                        {
                            SplashKit.DrawBitmap(_floorImage, cellX, cellY);
                        }
                        else if (cellValue == 1)
                        {
                            SplashKit.DrawBitmap(_b0, cellX, cellY-4);
                        }
                        else if (cellValue == 2)
                        {
                            SplashKit.DrawBitmap(_o0, cellX, cellY-80);
                        }                  
                        else if (cellValue == 3)
                        {
                            SplashKit.DrawBitmap(_o1, cellX, cellY - 80);
                        }
                        else if (cellValue == 4)
                        {
                            SplashKit.DrawBitmap(_o2, cellX, cellY - 80);
                        }
                        else if (cellValue == 5)
                        {
                            SplashKit.DrawBitmap(_o3, cellX, cellY-40);
                        }
                        else if (cellValue == 6)
                        {
                            SplashKit.DrawBitmap(_o4, cellX, cellY - 20);
                        }
                        else if (cellValue == 7)
                        {
                            SplashKit.DrawBitmap(_o7, cellX, cellY-15);
                        }
                        else if (cellValue == 8)
                        {
                            SplashKit.DrawBitmap(_s0, cellX, cellY - 20);
                        }
                        else if (cellValue == 9)
                        {
                            SplashKit.DrawBitmap(_w0, cellX, cellY-10);
                        }
                        else if (cellValue == 10)
                        {
                            SplashKit.DrawBitmap(_w1, cellX, cellY - 10);
                        }
                        else if (cellValue == 98)
                        {
                            SplashKit.DrawBitmap(_border, cellX, cellY);
                        }
                        else if (cellValue == 99)
                        {
                            SplashKit.DrawBitmap(_null, cellX, cellY);
                        }

                    }               
                
            }
            /*
      
            foreach (Monster mon in _monsters)
            {
                if (mon.is_die)
                {
                    _delete_monsters.Add(mon);
                    foreach (Monster obj in _delete_monsters)
                    {
                        _monsters.Remove(obj);
                    }
                    RemoveMonster();
                }
            }*/
            _delete_monsters.AddRange(_monsters.Where(mon => mon.is_die));
            _monsters.RemoveAll(mon => mon.is_die);

            DrawMonster();
         
           
        }

        public void DrawMonster()
        {
            foreach (Monster mon in _monsters)
            {
                if (_monsters.Count() != 0)
                {
                    mon.HandleMovementAnimation();
                    mon.Draw();
                    mon.Update();
                  
                }
            }
        }

        public override bool IsCellWalkable_r(float x, float y)
        {
            float y_bottom = y + 60;
            float y_top = y + 32;
            float x_right = x + 50;
            

            int cellX = (int)(x_right / CellSize);
            int cellY_bottom = (int)(y_bottom / CellSize);
            int cellY_top = (int)(y_top / CellSize);
    
            if (cellX < MapWidth && cellY_top >= 0 && cellY_top < MapHeight && cellY_bottom >= 0 )
            {
                if ( _grid[cellY_top, cellX] != 1 && _grid[cellY_bottom, cellX] != 1 &&
                    _grid[cellY_top, cellX] != 2 && _grid[cellY_bottom, cellX] != 2 &&
                    _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 3 &&
                    _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 4 &&
                    _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 5 &&
                    _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 6 &&
                    _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 7 &&
                    _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 9 &&
                    _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 10 &&
                    _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 98 &&
                    _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 99)
                {
                    return true;
                }
            

            }

            return false;

        }


        public override bool IsCellWalkable_l(float x, float y)
        {
            float y_bottom = y + 60;
            float y_top = y + 32;
            float x_left = x + 10;
            
            int cellX = (int)(x_left / CellSize);
            int cellY_bottom = (int)(y_bottom / CellSize);
            int cellY_top = (int)(y_top / CellSize);

            int Check_left = (x_left < 0) ? -1 : 0; 
          
            if (Check_left >= 0 && cellX < MapWidth && cellY_top >= 0 && cellY_bottom < MapHeight)
            {
                if (_grid[cellY_top, cellX] != 1 && _grid[cellY_bottom, cellX] != 1
                    && _grid[cellY_top, cellX] != 2 && _grid[cellY_bottom, cellX] != 2
                    && _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 3
                     && _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 4
                      && _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 5
                       && _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 6
                        && _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 7
                          && _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 9
                           && _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 10
                            && _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 99
                             && _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 98
                             )
                {
                    return true;
                }


            }

            return false;

        }

        public override bool IsCellWalkable_u(float x, float y)
        {
           
            float y_top = y + 26;
            float x_left = x + 15;
            float x_right = x + 45;

            int cellX_left = (int)(x_left / CellSize);
            int cellX_right = (int)(x_right / CellSize);
            int cellY = (int)(y_top / CellSize);


            int check_up = (y_top < 0) ? -1 : 0;
           
            if (cellX_left >= 0 && cellX_right < MapWidth && check_up >= 0 && cellY < MapHeight)
            {
                if (_grid[cellY, cellX_right] != 1 && _grid[cellY, cellX_left] != 1 
                    && _grid[cellY, cellX_right] != 2 && _grid[cellY, cellX_left] != 2
                    && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 3
                    && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 4
                    && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 5
                    && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 6
                    && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 7
                    && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 9
                    && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 10
                    && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 98
                    && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 99)
                
                {
                    return true;
                }


            }

            return false;

        }

        public override bool IsCellWalkable_d(float x, float y)
        {

            float y_bottom = y + 66;
            float x_left = x + 15;
            float x_right = x + 45;

            int cellX_left = (int)(x_left / CellSize);
            int cellX_right = (int)(x_right / CellSize);
            int cellY = (int)(y_bottom / CellSize);

           
            if (cellX_left >= 0 && cellX_right < MapWidth && cellY >= 0 && cellY < MapHeight)
            {
                if (_grid[cellY, cellX_right] != 1 && _grid[cellY, cellX_left] != 1
                    && _grid[cellY, cellX_right] != 2 && _grid[cellY, cellX_left] != 2
                     && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 3
                      && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 4
                       && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 5
                        && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 6
                         && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 7
                           && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 9
                            && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 10
                             && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 99
                              && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 98
                           )
                {
                    return true;
                }


            }

            return false;

        }


    }

}
