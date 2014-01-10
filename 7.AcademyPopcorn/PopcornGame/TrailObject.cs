using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PopcornGame
{
    public class TrailObject : GameObject
    {
        private int lifetime;

        public TrailObject(MatrixCoords topLeft, int lifetime)
            : base(topLeft, new char[,] { { '*' } })
        {
            this.lifetime = lifetime;
        }

        public int Lifetime
        {
            get { return this.lifetime; }
            set { this.lifetime = lifetime; }
        }

        public override void Update()
        {
            this.lifetime--;
            if (this.lifetime <= 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
