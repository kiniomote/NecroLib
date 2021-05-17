using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Buildings
{
    public interface ITown
    {
        IMiningQuarter MiningQuarter { get; }
        IMilitaryQuarter MilitaryQuarter { get; }
    }
}
