using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private IDictionary<string, IGun> gunsByName;

        public GunRepository()
        {
            this.gunsByName = new Dictionary<string, IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.gunsByName.Values.ToList();

        public void Add(IGun model)
        {
            if (!this.gunsByName.ContainsKey(model.Name))
            {
                this.gunsByName.Add(model.Name, model);
            }
        }

        public IGun Find(string name)
        {
            return this.gunsByName[name];
        }

        public bool Remove(IGun model)
        {
            return this.gunsByName.Remove(model.Name);
        }
    }
}
