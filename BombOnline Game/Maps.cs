using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public abstract class Maps
    {

        protected const int MapWidth = 17;
        protected const int MapHeight = 17;
        protected const int CellSize = 40;

        public int[,] _grid;
        public List<Monster> _monsters = new List<Monster>();
        public Monster monster1 = new Monster();
        public Monster monster2 = new Monster();

        public List<ItemBomb> bomb_items = new List<ItemBomb>();
        public ItemBomb bomb_itm;

        public List<ItemSpeed> speed_items = new List<ItemSpeed>();
        public ItemSpeed speed_itm;


        public List<ItemPower> power_items = new List<ItemPower>();
        public ItemPower power_itm;

        public System.Timers.Timer timer = new System.Timers.Timer();
        

        public abstract bool IsCellWalkable_r(float x, float y);
        public abstract bool IsCellWalkable_l(float x, float y);
        public abstract bool IsCellWalkable_u(float x, float y);
        public abstract bool IsCellWalkable_d(float x, float y);
        public abstract void Draw();

    }
}
