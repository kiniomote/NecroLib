using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Dialogs
{
    public interface IReplica : IDescribeable, IRenameable
    {
        ISpeaker Speaker { get; set; }
    }
}
