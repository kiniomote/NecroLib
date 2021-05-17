using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NecroLib.Models.Images
{
    [Serializable]
    public class ImagePath : IImagePath
    {
        private string _imageName;
        private string _additionalName;

        public ImagePath(string imageName, string additionalName = "")
        {
            _imageName = imageName;
            _additionalName = additionalName;
        }

        public override string ToString()
        {
            return _imageName + _additionalName;
        }
    }
}
