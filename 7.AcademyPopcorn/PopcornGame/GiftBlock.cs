using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PopcornGame
{
    public class GiftBlock : Block
    {
        public const char Symbol = '‼';

        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = GiftBlock.Symbol;
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
                List<Gift> newGift = new List<Gift>();
                newGift.Add(new Gift(this.TopLeft));
                return newGift;
            }
            else
            {
                return base.ProduceObjects();
            }
        }
    }
}
