using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PopcornGame
{
    public class ExplodingBlock : Block
    {
        public const char Symbol = '☻';

        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = ExplodingBlock.Symbol;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.ProduceObjects();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed == true)
            {
                List<ExplosionSplinter> splinters = new List<ExplosionSplinter>();
                splinters.Add(new ExplosionSplinter(this.TopLeft, new MatrixCoords(-1, -1)));
                splinters.Add(new ExplosionSplinter(this.TopLeft, new MatrixCoords(-1, 0)));
                splinters.Add(new ExplosionSplinter(this.TopLeft, new MatrixCoords(-1, 1)));
                splinters.Add(new ExplosionSplinter(this.TopLeft, new MatrixCoords(0, -1)));
                splinters.Add(new ExplosionSplinter(this.TopLeft, new MatrixCoords(0, 1)));
                splinters.Add(new ExplosionSplinter(this.TopLeft, new MatrixCoords(1, -1)));
                splinters.Add(new ExplosionSplinter(this.TopLeft, new MatrixCoords(1, 0)));
                splinters.Add(new ExplosionSplinter(this.TopLeft, new MatrixCoords(1, 1)));

                return splinters;
            }
            else
                return base.ProduceObjects();
            
        }
    }
}
