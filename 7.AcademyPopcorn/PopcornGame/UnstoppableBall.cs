using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PopcornGame
{
    public class UnstoppableBall : Ball
    {
        public new const string CollisionGroupString = "unstoppable ball";

        public const char Symbol = '0';

        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body[0, 0] = UnstoppableBall.Symbol;
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            for (int i = 0; i < collisionData.hitObjectsCollisionGroupStrings.Count; i++)
            {
                if (collisionData.hitObjectsCollisionGroupStrings[i] == "unpassable block")    //the unstoppable ball can go through everything except unpassable blocks (it bounces off it)
                {
                    if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
                    {
                        this.Speed.Row *= -1;
                    }
                    if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
                    {
                        this.Speed.Col *= -1;
                    }
                }
            }
        }

        public override bool CanCollideWith(string otherCollisionGroupString) 
        {
            return otherCollisionGroupString == "unpassable block" || otherCollisionGroupString == "racket" || otherCollisionGroupString == "block";
        }

    }
}
