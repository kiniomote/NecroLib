using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Resources;
using NecroLib.Models.Localization;
using NecroLib.Models.Images;

namespace NecroLib.Models.Buildings
{
    public interface IBuilding : INameable, IDescribeable, IImageable, IIconable
    {
        IImprovement Improvement { get; }

        void Upgrade(int level, int numberImprovement);

        bool Builded();
    }
}
