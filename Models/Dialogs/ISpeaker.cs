using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Images;
using NecroLib.Models.Localization;

namespace NecroLib.Models.Dialogs
{
    public enum Speakers
    {
        Main=0,
        Skull=1,
        Tailor=2,
    }

    public interface ISpeaker : INameable, IImageable
    {
        Speakers GetSpeaker();
    }
}
