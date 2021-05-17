using NecroLib.Models.Images;
using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Resources
{
    [Serializable]
    public class Resource : IResource
    {
        private LocalizedString _name;
        private int _value;
        private ResourceType _type;

        public IImagePath IconImage { get; set; }

        public Resource(ResourceType type, int value = 0)
        {
            _value = (value > 0) ? value : 0;
            _name = new LocalizedString(LocalizationNames.RESOURCES_NAMES[type]);
            _type = type;
            IconImage = new ImagePath(ImagePaths.RESOURCES_NAMES[type], ImagePaths.ICON_IMAGE);
        }

        public int GetValue()
        {
            return _value;
        }

        public void IncreaseValue(int value)
        {
            _value += value;
        }

        public void DecreaseValue(int value)
        {
            if (!EnoughValue(value))
                throw new Exception("Can't decrease value " + _name.GetName() + " " + value.ToString() + " > " + _value.ToString());
            _value -= value;
        }

        public bool EnoughValue(int value)
        {
            return value <= _value;
        }

        public ResourceType GetResourceType()
        {
            return _type;
        }

        public string GetName()
        {
            return _name.ToString();
        }
    }
}
