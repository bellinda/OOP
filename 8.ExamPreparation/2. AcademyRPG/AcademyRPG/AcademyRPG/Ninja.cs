using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        private int attackPoints;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.attackPoints = 0;
            this.HitPoints = 1;
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
        }

        public int DefensePoints
        {
            get { return int.MaxValue; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            //availableTargets.Sort();
            var sortedAvailableTargets = availableTargets.OrderByDescending(x => x.HitPoints);
            foreach(var element in sortedAvailableTargets)
            {
                if (element.Owner != this.Owner && element.Owner != 0)
                {
                    return availableTargets.IndexOf(element);
                }
            }
            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.attackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.attackPoints += (2 * resource.Quantity);
                return true;
            }
            return false;
        }
    }
}
