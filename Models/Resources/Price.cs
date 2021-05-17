using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Images;

namespace NecroLib.Models.Resources
{
    public class Price : IPrice
    {
        public Dictionary<ResourceType, int> Resources { get; private set; }

        public Dictionary<ResourceType, IImagePath> IconImages { get; }

        public Price(int rot, int stone, int metal, int silk, int rune)
        {
            Resources = new Dictionary<ResourceType, int>();
            IconImages = new Dictionary<ResourceType, IImagePath>();

            Dictionary<ResourceType, int> resourceTypes = new Dictionary<ResourceType, int>()
            {
                [ResourceType.Rot] = rot,
                [ResourceType.Stone] = stone,
                [ResourceType.Metal] = metal,
                [ResourceType.Silk] = silk,
                [ResourceType.Rune] = rune,
            };

            foreach (var type in resourceTypes)
            {
                Resources.Add(type.Key, type.Value);
                IconImages.Add(type.Key, new ImagePath(ImagePaths.RESOURCES_NAMES[type.Key], ImagePaths.ICON_IMAGE));
            }
        }

        public Price(IPrice price, int count = 1)
        {
            Resources = new Dictionary<ResourceType, int>();
            foreach (var resource in price.Resources)
            {
                Resources.Add(resource.Key, resource.Value * count);
            }
        }

        public Price(Dictionary<ResourceType, int> resources)
        {
            Resources = new Dictionary<ResourceType, int>();
            foreach (var resource in resources)
            {
                Resources.Add(resource.Key, resource.Value);
            }
        }

        public IPrice GetSumPrices(IPrice price)
        {
            IPrice sumPrice = new Price(this);
            foreach (var resource in price.Resources)
            {
                sumPrice.Resources[resource.Key] += resource.Value;
            }
            return sumPrice;
        }
    }
}
