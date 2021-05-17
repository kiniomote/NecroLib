using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Images;
using NecroLib.Models.Localization;

namespace NecroLib.Models.Resources
{
    public interface IResource : INameable, IIconable
    {
        int GetValue();
        ResourceType GetResourceType();
        void IncreaseValue(int value);
        void DecreaseValue(int value);
        bool EnoughValue(int value);
    }
}
