using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int PistolBulletsPerBarrel = 10;
        private const int PistolTotalBullets = 100;


        public Pistol(string name) 
            : base(name, PistolBulletsPerBarrel, PistolTotalBullets)
        {
        }

        public override int Fire()
        {
            if (this.CanFire)
            {
                this.BulletsPerBarrel--;

                return 1;
            }
            else
            {
                if (this.TotalBullets > 0)
                {
                    if (this.TotalBullets - PistolBulletsPerBarrel >= 0)
                    {
                        this.BulletsPerBarrel = PistolBulletsPerBarrel;
                        this.TotalBullets -= PistolBulletsPerBarrel;
                        this.BulletsPerBarrel--;

                        return 1;
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
