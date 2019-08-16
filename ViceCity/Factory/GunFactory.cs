using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Factory.Contracts;

namespace ViceCity.Factory
{
    public class GunFactory : IGunFactory
    {
        

        public IGun CreateGun(string type, string name)
        {
            Type gunType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            IGun gunNew = (IGun)Activator.CreateInstance(gunType, name);

            return gunNew;
        }
    }
}
