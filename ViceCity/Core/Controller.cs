using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

using ViceCity.Core.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Utilities;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Factory.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Factory;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private List<IPlayer> civilPlayers;
        private IGunFactory gunFactory;
        private IList<IGun> guns;
        private IPlayer mainPlayer;
        private INeighbourhood neighbourhood;

        public Controller()
        {
            this.civilPlayers = new List<IPlayer>();
            this.gunFactory = new GunFactory();
            this.guns = new List<IGun>();
            this.mainPlayer = new MainPlayer();
            this.neighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            Type[] typesGun = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.BaseType == typeof(Gun)).ToArray();

            Type gunTypeExists = typesGun.FirstOrDefault(t => t.Name == type);
            if (gunTypeExists == null)
            {
                return OutputMessages.InvalidGunType;
            }

            IGun gunNew = this.gunFactory.CreateGun(type, name);

            this.guns.Add(gunNew);

            return string.Format(OutputMessages.SuccessfullyAddedGun, name, type);
        }

        public string AddGunToPlayer(string name)
        {
            if (this.guns.Count == 0)
            {
                return OutputMessages.NoGunsInQueue;
            }

            string gunName = string.Empty;

            if (this.mainPlayer.Name.Contains(name))
            {
                this.mainPlayer.GunRepository.Add(this.guns[0]);
                gunName = this.guns[0].Name;
                this.guns.RemoveAt(0);

                return string.Format(OutputMessages.SuccessfullyAddedGunToVercceti, gunName);
            }

            IPlayer playerExists = this.civilPlayers.FirstOrDefault(p => p.Name == name);
            if (playerExists == null)
            {
                return OutputMessages.CivilPlayerDoesntExist;
            }

            playerExists.GunRepository.Add(this.guns[0]);
            gunName = this.guns[0].Name;
            this.guns.RemoveAt(0);

            return string.Format(OutputMessages.SuccessfullyAddedGunToPlayer, gunName, playerExists.Name);
        }

        public string AddPlayer(string name)
        {
            IPlayer civilPlayerNew = new CivilPlayer(name);
            this.civilPlayers.Add(civilPlayerNew);

            return string.Format(OutputMessages.SuccessfullyAddedCivilPlayer, name);        
        }

        public string Fight()
        {
            this.neighbourhood.Action(this.mainPlayer, this.civilPlayers);

            if (this.mainPlayer.LifePoints == 100 && 
                this.civilPlayers.All(p => p.LifePoints == 50))
            {
                return OutputMessages.EverythingIsOk;
            }

            int deadPlayers = this.civilPlayers.RemoveAll(p => p.IsAlive == false);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("A fight happened:");
            stringBuilder.AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!");
            stringBuilder.AppendLine($"Tommy has killed: {deadPlayers} players!");
            stringBuilder.AppendLine($"Left Civil Players: {this.civilPlayers.Count}!");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
