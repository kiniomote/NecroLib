using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Items.ItemBuilder
{
    public interface IItemBuilderGenerator
    {
        IItem Generate(string localizationName);
    }
}
