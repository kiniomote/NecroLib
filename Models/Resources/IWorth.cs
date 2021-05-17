using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Resources
{
    public interface IWorth
    {
        bool EnoughResources(IResourcePack resources, int count=1);
        void Buy(IResourcePack resources, int count=1);
        IPrice GetPrice(int count=1);
    }
}
