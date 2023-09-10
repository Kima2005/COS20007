using SplashKitSDK;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace test
{
    public class Map1 : Maps
    {

        private Bitmap _floorImage;
        private Bitmap _boxImage;
        private Bitmap _wallImage;
        private Bitmap _houseImage;

        public Map1()
        {

            timer.Interval = TimeSpan.FromMinutes(0.1).TotalMilliseconds;
            timer.Elapsed += TimerElapsed;
            timer.Start();


            _grid = new int[MapHeight, MapWidth];
            _floorImage = SplashKit.LoadBitmap("floor", "./map/floor.png");//0
            _boxImage = SplashKit.LoadBitmap("box", "./map/box.png");
            _wallImage = SplashKit.LoadBitmap("wall", "./map/wall.png");
            _houseImage = SplashKit.LoadBitmap("house", "./map/house.png");

            InitializeMap();
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
        public void TimerElapsed(object sender, ElapsedEventArgs e)
        {

            List<(int, int)> pos_ij = new List<(int, int)>();
            speed_itm = new ItemSpeed("speed_bit", "speed_anim", "speed_anim.txt", "speed_bundle", "speed_item.txt");
            SplashKit.SpriteStartAnimation(speed_itm._sprite, "speed_iddle");
            for (int i = 0; i < MapHeight; i++)
            {
                for (int j = 0; j < MapWidth; j++)
                {
                    int cellValue = _grid[i, j];

                    if (cellValue == 0)
                    {
                        pos_ij.Add((i, j));
                    }

                }
            }
            Random random = new Random();
            int randomIndex = random.Next(0, pos_ij.Count);
            (int i, int j) randomElement = pos_ij[randomIndex];

            // Access the values of i and j
            int iValue = randomElement.Item1;
            int jValue = randomElement.Item2;

            speed_itm.Y_sp = iValue * 40;
            speed_itm.X_sp = ((jValue * 40) - 5);

            speed_items.Add(speed_itm);
        }
        private void InitializeMap()
        {
            // Define the map layout using 0s and 1s
            int[,] layout = new int[,]
            {
                     {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
                    {2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
                    {2, 0, 0, 1, 0, 3, 0, 0, 3, 0, 0, 3, 0, 1, 0, 0, 2},
                    {2, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2},
                    {2, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 2},
                    {2, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2},
                    {2, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2},
                    {2, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 2},
                    {2, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 2},
                    {2, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 2},
                    {2, 0, 0, 3, 0, 1, 1, 1, 0, 1, 1, 1, 0, 3, 0, 0, 2},
                    {2, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2},
                    {2, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 2},
                    {2, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 2},
                    {2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
                    {2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
                    {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}

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
                    else if (cellValue == 3)
                    {
                        SplashKit.DrawBitmap(_houseImage, cellX, cellY - 17);
                    }
                    else if (cellValue == 1)
                    {
                        SplashKit.DrawBitmap(_boxImage, cellX, cellY);
                    }
                    else if (cellValue == 2)
                    {
                        SplashKit.DrawBitmap(_wallImage, cellX, cellY);
                    }

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

            if (cellX < MapWidth && cellY_top >= 0 && cellY_top < MapHeight && cellY_bottom >= 0)
            {
                if (_grid[cellY_top, cellX] != 1 && _grid[cellY_bottom, cellX] != 1 &&
                    _grid[cellY_top, cellX] != 2 && _grid[cellY_bottom, cellX] != 2 &&
                    _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 3)
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
                    && _grid[cellY_top, cellX] != 3 && _grid[cellY_bottom, cellX] != 3)
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
                    && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 3)
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
                     && _grid[cellY, cellX_right] != 3 && _grid[cellY, cellX_left] != 3)
                {
                    return true;
                }


            }

            return false;

        }


    }

}
