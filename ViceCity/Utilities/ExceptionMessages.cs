using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity
{
   public static class ExceptionMessages
    {
        public const string InvalidName =
            "Player's name cannot be null or a whitespace!";

        public const string InvalidLifePoints =
            "Player life points cannot be below zero!";

        public const string InvalidGunName =
            "Name cannot be null or a white space!";

        public const string InvalidBulletsPerBarrel =
            "Bullets cannot be below zero!";

        public const string InvalidTotalBullets =
            "Total bullets cannot be below zero!";
    }
}
