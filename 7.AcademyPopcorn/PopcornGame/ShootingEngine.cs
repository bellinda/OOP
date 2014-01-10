using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PopcornGame
{
    public class ShootingEngine : Engine
    {
        public ShootingEngine(IRenderer renderer, IUserInterface userInterface)
            : base(renderer, userInterface)
        {
        }

        public void ShootPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).Shoot();
            }
            
        }
    }
}
