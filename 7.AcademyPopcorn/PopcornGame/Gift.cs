using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PopcornGame
{
    public class Gift : MovingObject
    {
        public new const string CollisionGroupString = "gift";
        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '¶' } }, new MatrixCoords(1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override string GetCollisionGroupString()
        {
            return Gift.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed == true)
            {
                List<GameObject> list = new List<GameObject>();
                list.Add(new ShootingRacket(new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col), 6));
                return list;
            }
            else
            {
                return base.ProduceObjects();
            }
        }
    }
}
