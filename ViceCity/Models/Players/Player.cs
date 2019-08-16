using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;
using ViceCity.Utilities;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.GunRepository = new GunRepository();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.InvalidPlayerName(value, ExceptionMessages.InvalidName);

                this.name = value;
            }
        }

        public bool IsAlive => this.LifePoints > 0;

        public IRepository<IGun> GunRepository { get; }

        public int LifePoints
        {
            get
            {
                return this.lifePoints;
            }
            private set
            {
                Validator.InvalidPlayerLifePoints(value, ExceptionMessages.InvalidLifePoints);

                this.lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            if (this.LifePoints - points < 0)
            {
                this.LifePoints = 0;
            }
            else
            {
                this.LifePoints -= points;
            }
        }
    }
}
