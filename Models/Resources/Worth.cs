using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Resources
{
    public class Worth : IWorth
    {
        private IPrice _price;

        public Worth(IPrice price)
        {
            _price = price;
        }

        public void Buy(IResourcePack resources, int count = 1)
        {
            if (!EnoughResources(resources, count))
                return;
            resources.SpendResources(GetPrice(count));
        }

        public bool EnoughResources(IResourcePack resources, int count = 1)
        {
            return resources.EnoughResources(GetPrice(count));
        }

        public IPrice GetPrice(int count = 1)
        {
            return new Price(_price, count);
        }
    }
}
