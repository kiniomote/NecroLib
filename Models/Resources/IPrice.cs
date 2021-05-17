using NecroLib.Models.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Resources
{
    public interface IPrice : IDictIconable<ResourceType>
    {
        Dictionary<ResourceType, int> Resources { get; }

        IPrice GetSumPrices(IPrice price);
    }
}
