using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ontwikkelopdracht_Game
{
    public abstract class Character : MoveableObject
    {
        public int Cooldown { get; set; }
        public int BaseCooldown { get; set; }
        public bool CoolingDown { get; set; }

        public abstract void Fire();
    }
}
