using NecroLib.Models.Images;
using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Dialogs
{
    [Serializable]
    public class Speaker : ISpeaker
    {
        private LocalizedString _name;
        private Speakers _speaker;

        public IImagePath Image { get; set; }

        public Speaker(Speakers speaker)
        {
            _speaker = speaker;
            _name = new LocalizedString(LocalizationNames.SPEAKERS[speaker]);
            Image = new ImagePath(ImagePaths.SPEAKERS[speaker]);
        }

        public Speakers GetSpeaker()
        {
            return _speaker;
        }

        public string GetName()
        {
            return _name.ToString();
        }

        public override string ToString()
        {
            return _name.GetName();
        }
    }
}
