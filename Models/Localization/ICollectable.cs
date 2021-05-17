using System;
using System.Collections.Generic;

namespace NecroLib.Models.Localization
{
    public interface ICollectable
    {
        bool ExsistInCollection(IEnumerable<ICollectable> collection);
    }
}
