using System;
using System.Collections.Generic;
using NecroLib.Models.Characters;
using NecroLib.Models.Images;
using NecroLib.Models.Localization;
using NecroLib.Models.Resources;

namespace NecroLib.Models.Buildings
{
    public abstract class Building : IBuilding
    {
        protected bool _builded;

        protected LocalizedString _name;
        protected LocalizedString _description;

        public IImprovement Improvement { get; private set; }

        public IImagePath IconImage { get; set; }
        public IImagePath Image { get; set; }

        public Building(IImprovement improvement, string name, bool builded = false)
        {
            _builded = builded;
            Improvement = improvement;
            _name = new LocalizedString(name, LocalizationNames.NAME);
            _description = new LocalizedString(name, LocalizationNames.DESCRIPTION);
        }

        public abstract void Upgrade(int level, int numberImprovement);

        // Getters

        public bool Builded()
        {
            return _builded;
        }

        public string GetDescription()
        {
            return _description.ToString();
        }

        public string GetName()
        {
            return _name.ToString();
        }

        public override string ToString()
        {
            return _name.GetName();
        }
    }
}
