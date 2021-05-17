using NecroLib.Models.Localization;
using NecroLib.Services.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NecroLib.Models.Resources
{
    [Serializable]
    public class ResourcePack : IResourcePack
    {
        public Dictionary<ResourceType, IResource> Resources { get; private set; }

        public ResourcePack()
        {
            Resources = new Dictionary<ResourceType, IResource>();
            foreach (ResourceType resource in LocalizationNames.RESOURCES_NAMES.Keys)
            {
                Resources.Add(resource, new Resource(resource));
            }
        }

        public void SpendResources(IPrice price)
        {
            foreach (KeyValuePair<ResourceType, int> resource in price.Resources)
            {
                Resources[resource.Key].DecreaseValue(resource.Value);
            }
        }

        public bool EnoughResources(IPrice price)
        {
            foreach (KeyValuePair<ResourceType, int> resource in price.Resources)
            {
                if (!Resources[resource.Key].EnoughValue(resource.Value))
                    return false;
            }
            return true;
        }

        public bool EnoughResources(ResourceType resource, int value)
        {
            return Resources[resource].EnoughValue(value);
        }

        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            Resources.OnDeserialization(context);
        }
    }
}
