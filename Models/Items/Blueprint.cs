using NecroLib.Models.Images;
using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Items.BlueprintBuilder;

namespace NecroLib.Models.Items
{
    public class Blueprint : IBlueprint
    {
        private LocalizedString _name;
        private LocalizedString _description;

        public IImagePath Image { get; set; }

        public Blueprint(BlueprintItem blueprint)
        {
            _name = new LocalizedString(LocalizationNames.BLUEPRINTS[blueprint], LocalizationNames.NAME);
            _description = new LocalizedString(LocalizationNames.BLUEPRINTS[blueprint], LocalizationNames.DESCRIPTION);
            Image = new ImagePath(ImagePaths.BLUEPRINTS[blueprint]);
        }

        public string GetName()
        {
            return _name.ToString();
        }

        public string GetDescription()
        {
            return _description.ToString();
        }

        public override string ToString()
        {
            return _name.GetName();
        }
    }
}
