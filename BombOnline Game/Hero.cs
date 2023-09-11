using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test
{
    public class Hero : Character
    {
      


        public int list_speed = 1;
        public int list_bomb = 1;
        public int list_power = 1;



        public void EatItem(Hero character, Maps map)
        {

            List<ItemSpeed> itemsToRemove = new List<ItemSpeed>();
            foreach (ItemSpeed itm in map.speed_items)
            {
                if (SplashKit.SpriteCollision(character._sprite, itm._sprite))
                {
                    itemsToRemove.Add(itm);
                    list_speed += 1;
                }
            }
            foreach (ItemSpeed itm in itemsToRemove)
            {
                map.speed_items.Remove(itm);
            }

            if (map.bomb_items != null)
            {
                List<ItemBomb> itemsbombToRemove = new List<ItemBomb>();
                foreach (ItemBomb itm in map.bomb_items)
                {
                    if (SplashKit.SpriteCollision(character._sprite, itm._sprite))
                    {
                        itemsbombToRemove.Add(itm);
                        list_bomb += 1;

                    }
                }
                foreach (ItemBomb itm in itemsbombToRemove)
                {
                    map.bomb_items.Remove(itm);
                }
            }
            if (map.power_items != null)
            {
                List<ItemPower> itemspowerToRemove = new List<ItemPower>();
                foreach (ItemPower itm in map.power_items)
                {
                    if (SplashKit.SpriteCollision(character._sprite, itm._sprite))
                    {
                        itemspowerToRemove.Add(itm);
                        list_power += 1;

                    }
                }
                foreach (ItemPower itm in itemspowerToRemove)
                {
                    map.power_items.Remove(itm);
                }
            }
        }


        public List<Monster> _monsters = new List<Monster>();
        public List<Monster> _delete_monsters = new List<Monster>();

        public List<BombController> _bombs = new List<BombController>();
        public List<BombController> _delete = new List<BombController>();
        public void AddBomb(KeyCode keybomb)
        {
            if (SplashKit.KeyTyped(keybomb))
            {
                BombController bomb = new BombController();
                bomb.CreateBomb(X, Y);
                _bombs.Add(bomb);
            }
        }
        public void RemoveBomb()
        {
            foreach (BombController obj in _delete)
            {
                _bombs.Remove(obj);
            }
        }




      




        public List<Explosion1> _explosions = new List<Explosion1>();
        public List<Explosion1> _delete_exp = new List<Explosion1>();

        public Sprite character_die_sp;
        public void RemoveExp()
        {
            foreach (Explosion1 obj in _delete_exp)
            {
                _explosions.Remove(obj);
            }
        }

    

        public void DrawBomb(Map map, Hero character)
        {
            foreach (BombController bomb in _bombs)
            {
                if (bomb.elapsedMilliseconds < 3000)
                {

                    bomb.Draw();
                    int i = (int)(bomb.bombY / 40);
                    int j = (int)(bomb.bombX / 40);
                    map._grid[i, j] = 99;

                }
                else if (bomb.elapsedMilliseconds == 3000 && bomb.create_exp == false)
                {
                    Explosion1 exp = new Explosion1();
                    exp.power = list_power;
                    exp.CreateExp(bomb, map);
                    Console.WriteLine("added");
                    _explosions.Add(exp);
                    _delete_exp.Add(exp);
                    is_die = Collision(character, exp);
                    bomb.create_exp = true;
                }
                else if (bomb.elapsedMilliseconds > 3000 && bomb.elapsedMilliseconds < 4000)
                {
                   
                    DrawExp(map, bomb);
                }
                else if (bomb.elapsedMilliseconds >= 4000)
                {
                    int i = (int)(bomb.bombY / 40);
                    int j = (int)(bomb.bombX / 40);
                    map._grid[i, j] = 0;


                    _delete.Add(bomb);
                    RemoveExp();
                    bomb.create_exp = false;


                }

            }
            RemoveBomb();
        }


        public bool CheckCollision(Hero character, Hero rival)
        {
            foreach (Explosion1 exp in rival._explosions)
            {
                return Collision(character, exp);
            }
            return false;

        }

        public bool Collision(Hero character1, Explosion1 expl1)
        {
            int i = (int)(character1.Y / 40);
            int j = (int)(character1.X / 40);
            (int x, int y) cha_pos = (i, j);
            (int x, int y) up = expl1.exp_up_pos;;
            (int x, int y) down = expl1.exp_down_pos;
            (int x, int y) left = expl1.exp_left_pos;
            (int x, int y) right = expl1.exp_right_pos;
            (int x, int y) center = expl1.exp_center_pos;


            if (  (cha_pos.y == center.y && cha_pos.x == center.x) ||
                (cha_pos.y == up.y && cha_pos.x >= up.x && cha_pos.x < (up.x+3)      )||
            (cha_pos.y == down.y && cha_pos.x <= down.x && down != (0,0) && cha_pos.x > (down.x-3)) ||
            (cha_pos.y <= right.y && cha_pos.x == right.x && right != (0, 0)  && (cha_pos.y > (right.y - 3)) ) ||
            (cha_pos.y >= left.y && cha_pos.x == left.x && cha_pos.y < (left.y + 3)  ))


            {
                return true;
            }
            return false;
        }




        public void DrawExp(Map map, BombController bomb)
        {
            foreach (Explosion1 exp in _explosions)
            {
                exp.Draw_expl(map, bomb);
            }
        }

        public void UpdateBomb()
        {
            foreach (BombController bomb in _bombs)
            {
                bomb.Update();
            }
        }

        public void UpdateExpl()
        {
            foreach (Explosion1 exp in _explosions)
            {
                exp.Update_expl(exp);
            }
        }




        public KeyCode key_right;
        public KeyCode key_left;
        public KeyCode key_up;
        public KeyCode key_down;

        public virtual void HandleMovementAnimation(KeyCode right, KeyCode left, KeyCode down, KeyCode up)
        {

        }
        public void MoveRight2px(Maps map)
        {
            float nextX = X + 2;
            float nextY = Y;
            if (map.IsCellWalkable_r(nextX, nextY))
            {
                X += _speed;
                Set_position_x(X);
            }
        }

        public void MoveLeft2px(Maps map)
        {
            float nextX = X - 2;
            float nextY = Y;
            if (map.IsCellWalkable_l(nextX, nextY))
            {
                X -= _speed;
                Set_position_x(X);
            }
        }

        public void MoveUp2px(Maps map)
        {
            float nextX = X;
            float nextY = Y - 2;
            if (map.IsCellWalkable_u(nextX, nextY))
            {
                Y -= _speed;
                Set_position_y(Y);
            }
        }

        public void MoveDown2px(Maps map)
        {
            float nextX = X;
            float nextY = Y + 2;
            if (map.IsCellWalkable_d(nextX, nextY))
            {
                Y += _speed;
                Set_position_y(Y);
            }
        }

        public void HandleMovement(Maps map)
        {
            foreach (Monster mon in map._monsters)
            {
                is_die = mon.MonsterCatch(_sprite, mon);
                if (is_die)
                {
                    break;
                }
            }
  
            if (SplashKit.KeyDown(key_right) && !SplashKit.KeyDown(key_left) && !SplashKit.KeyDown(key_down) && !SplashKit.KeyDown(key_up))
            {
                for (int i = 0; i < list_speed; i++)
                {
                    MoveRight2px(map);
                }

            }
            else if (SplashKit.KeyReleased(key_right))
            {
               
                if (SplashKit.SpriteAnimationName(_sprite) == "move_r")
                {
                    SplashKit.SpriteStartAnimation(_sprite, "iddle_r");
                }
           
                
                
            }

            if (SplashKit.KeyDown(key_left) && !SplashKit.KeyDown(key_right) && !SplashKit.KeyDown(key_up) && !SplashKit.KeyDown(key_down))
            {
                for (int i = 0; i < list_speed; i++)
                {
                    MoveLeft2px(map);
                }
            }
            else if (SplashKit.KeyReleased(key_left))
            {
                if (SplashKit.SpriteAnimationName(_sprite) == "move_l")
                {
                    SplashKit.SpriteStartAnimation(_sprite, "iddle_l");
                }
                
             
            }

            if (SplashKit.KeyDown(key_down) && !SplashKit.KeyDown(key_left) && !SplashKit.KeyDown(key_right) && !SplashKit.KeyDown(key_up))
            {

                for (int i = 0; i < list_speed; i++)
                {
                    MoveDown2px(map);
                }

            }
            else if (SplashKit.KeyReleased(key_down))
            {
                if (SplashKit.SpriteAnimationName(_sprite) == "move_f")
                {
                    SplashKit.SpriteStartAnimation(_sprite, "iddle_f");
                }

            
            }

            if (SplashKit.KeyDown(key_up) && !SplashKit.KeyDown(key_left) && !SplashKit.KeyDown(key_down) && !SplashKit.KeyDown(key_right))
            {
                for (int i = 0; i < list_speed; i++)
                {
                    MoveUp2px(map);
                }

            }
            else if (SplashKit.KeyReleased(key_up))
            {
                if (SplashKit.SpriteAnimationName(_sprite) == "move_b")
                {
                    SplashKit.SpriteStartAnimation(_sprite, "iddle_b");
                }
           
            }
        }
    }
}
