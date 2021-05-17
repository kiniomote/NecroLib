using NecroLib.Models.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Resources
{
    public enum ResourceType
    {
        Rot = 0,
        Stone = 1,
        Metal = 2,
        Silk = 3,
        Rune = 4
    }

    public interface IResourcePack
    {
        Dictionary<ResourceType, IResource> Resources { get; }

        void SpendResources(IPrice price);
        bool EnoughResources(IPrice price);
        bool EnoughResources(ResourceType resource, int value);
    }
}
