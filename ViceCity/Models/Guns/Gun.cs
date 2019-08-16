using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Utilities;

namespace ViceCity.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.InvalidGunName(value, ExceptionMessages.InvalidGunName);

                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get
            {
                return this.bulletsPerBarrel;
            }
            protected set
            {
                Validator.InvalidBulletsPerBarrel(value, ExceptionMessages.InvalidBulletsPerBarrel);

                this.bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get
            {
                return this.totalBullets;
            }
            protected set
            {
                Validator.InvalidTotalBullets(value, ExceptionMessages.InvalidTotalBullets);

                this.totalBullets = value;
            }           
        }

        public bool CanFire => this.BulletsPerBarrel > 0;

        public abstract int Fire();
        
    }
}
