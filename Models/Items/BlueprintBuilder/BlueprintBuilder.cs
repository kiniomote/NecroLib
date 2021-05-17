using NecroLib.Models.Images;
using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Items.BlueprintBuilder
{
    public class BlueprintBuilder : IBlueprintBuilder
    {
        private readonly Dictionary<BlueprintItem, string> BLUEPRINTS = LocalizationNames.BLUEPRINTS;

        public IBlueprint BuildBlueprint(string localizationName)
        {
            foreach (var blueprint in BLUEPRINTS)
            {
                if (blueprint.Value == localizationName)
                {
                    return BuildBlueprint(blueprint.Key);
                }
            }
            return null;
        }

        public IBlueprint BuildBlueprint(BlueprintItem blueprint)
        {
            IBlueprint newBlueprint = new Blueprint(blueprint);
            return newBlueprint;
        }
    }
}
