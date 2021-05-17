using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Items.BlueprintBuilder
{
    public enum BlueprintItem
    {
        FirstNecro=0,
        HorrorMaker=1,
        HarbringerOfDeath=2,
        QueenOfMaggots=3,
        GiftOfGoola=4,
        ManticoreSpirit=5,
    }

    public interface IBlueprintBuilder
    {
        IBlueprint BuildBlueprint(string localizationName);
        IBlueprint BuildBlueprint(BlueprintItem blueprint);
    }
}
