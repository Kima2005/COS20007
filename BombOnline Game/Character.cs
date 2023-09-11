using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace test
{
    public class Character
    {

        public bool is_die;
        public int _speed = 2;

        public Sprite _sprite;

        public float x;
        public float y;

        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; } }

        public virtual void Set_position_x(float x) { }
        public virtual void Set_position_y(float x) { }
        public void Draw()
        {
            SplashKit.DrawSprite(_sprite);
        }

        public void Update()
        {
            SplashKit.UpdateSpriteAnimation(_sprite);
        }


    }
}
