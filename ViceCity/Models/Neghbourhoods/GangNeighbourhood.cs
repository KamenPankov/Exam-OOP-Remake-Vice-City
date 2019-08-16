using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (true)
            {
                IGun currentGun = mainPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire || g.TotalBullets > 0);
                if (currentGun == null)
                {
                    break;
                }

                IPlayer civilPlayer = civilPlayers.FirstOrDefault(p => p.IsAlive);
                if (civilPlayer == null)
                {
                    break;
                }

                civilPlayer.TakeLifePoints(currentGun.Fire());
                //if (civilPlayer.IsAlive == false)
                //{
                //    break;
                //}
            }

            foreach (IPlayer civilPlayer in civilPlayers.Where(p => p.IsAlive))
            {
                while (true)
                {
                    IGun currentGun = civilPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire || g.TotalBullets > 0);
                    if (currentGun == null)
                    {
                        break;
                    }

                    mainPlayer.TakeLifePoints(currentGun.Fire());
                    if (!mainPlayer.IsAlive)
                    {
                        return;
                    }
                }
                
            }
        }
    }
}
