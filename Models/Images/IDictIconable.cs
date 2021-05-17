using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Images
{
    public interface IDictIconable<T>
    {
        Dictionary<T, IImagePath> IconImages { get; }
    }
}
