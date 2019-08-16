using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Utilities
{
    public static class Validator
    {

        public static void InvalidPlayerName(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void InvalidPlayerLifePoints(int value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void InvalidGunName(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message);
            }
        }

        public static void InvalidBulletsPerBarrel(int value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void InvalidTotalBullets(int value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
