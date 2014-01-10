using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        public Zombie(string name, Point location)
            : base(name, location, 10)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            this.IsAlive = true;
            return this.Size;
        }

        public override void Update(int timeElapsed)
        {
        }
    }
}
