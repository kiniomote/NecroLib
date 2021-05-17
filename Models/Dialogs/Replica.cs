using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Dialogs
{
    [Serializable]
    public class Replica : IReplica
    {
        public ISpeaker Speaker { get; set; }

        private LocalizedString _text;

        public Replica(string localizationText, Speakers speaker)
        {
            _text = new LocalizedString(localizationText);
            Speaker = new Speaker(speaker);
        }

        public void SetName(string name)
        {
            _text = new LocalizedString(name);
        }

        public string GetDescription()
        {
            return _text.ToString();
        }

        public override string ToString()
        {
            return _text.GetName();
        }

    }
}
