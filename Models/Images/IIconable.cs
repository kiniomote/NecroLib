using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Images
{
    public interface IIconable
    {
        IImagePath IconImage { get; set; }
    }
}
