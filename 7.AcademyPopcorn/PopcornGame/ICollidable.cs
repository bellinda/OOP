﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PopcornGame
{
    public interface ICollidable
    {
        bool CanCollideWith(string objectType);

        List<MatrixCoords> GetCollisionProfile();

        void RespondToCollision(CollisionData collisionData);

        string GetCollisionGroupString();
    }
}
