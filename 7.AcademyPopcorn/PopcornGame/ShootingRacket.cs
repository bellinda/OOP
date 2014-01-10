using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PopcornGame
{
    public class ShootingRacket : Racket
    {
        private int bullets = 0;
        private bool hasBullets = false;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey();
                if (key.Key.Equals(ConsoleKey.Spacebar))
                {
            //if (this.hasBullets == true)
            //{
                List<Bullet> bullets = new List<Bullet>();
                bullets.Add(new Bullet(this.TopLeft));
                //this.hasBullets = false;
                return bullets;
            //}
            //else
            //    return base.ProduceObjects();
                }
                else
                    return base.ProduceObjects();
            }
            else
                return base.ProduceObjects();
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            foreach(var item in collisionData.hitObjectsCollisionGroupStrings)
            {
                if (item == "gift")
                {
                    this.ProduceObjects();
                }
            }
        }

        public void Shoot()
        {
            this.hasBullets = true;
            this.RespondToCollision(new CollisionData(this.TopLeft, "gift"));
            this.hasBullets = false;
        }
    }
}
