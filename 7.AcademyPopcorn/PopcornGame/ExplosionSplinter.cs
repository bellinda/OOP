using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PopcornGame
{
    public class ExplosionSplinter : MovingObject   //splinters that are produced after an explosion; they hit the blocks near the exploding block
    {
        public ExplosionSplinter(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { { '▼' } }, speed)
        {
        }

        public override void Update()
        {
            this.IsDestroyed = true;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }
    }
}
