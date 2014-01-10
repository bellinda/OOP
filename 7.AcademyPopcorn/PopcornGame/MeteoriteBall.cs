using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PopcornGame
{
    public class MeteoriteBall : Ball
    {
        public new const string CollisionGroupString = "ball";

        public int TrailLifetime { get; set; }

        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)        
        {
            this.TrailLifetime = 3;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> trails = new List<GameObject>();
            trails.Add(new TrailObject(this.TopLeft, 3));
            return trails;
        }
    }
}
