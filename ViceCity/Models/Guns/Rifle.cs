using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int RifleBulletsPerBarrel = 50;
        private const int RiflelTotalBullets = 500;


        public Rifle(string name) 
            : base(name, RifleBulletsPerBarrel, RiflelTotalBullets)
        {
        }

        public override int Fire()
        {
            if (this.CanFire)
            {
                this.BulletsPerBarrel -= 5;

                return 5;
            }
            else
            {
                if (this.TotalBullets > 0)
                {
                    if (this.TotalBullets - RifleBulletsPerBarrel >= 0)
                    {
                        this.BulletsPerBarrel = RifleBulletsPerBarrel;
                        this.TotalBullets -= RifleBulletsPerBarrel;
                        this.BulletsPerBarrel -= 5;

                        return 5;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
                
            }
        }
    }
}
