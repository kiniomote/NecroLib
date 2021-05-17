using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Dialogs
{
    public class Communication : ICommunication
    {
        public const string FILE_NAME = "communication.dat";
        private static Dictionary<string, IDialog> _dialogs = new Dictionary<string, IDialog>();

        public void Deserialize(object toDeserialize)
        {
            if (toDeserialize == null)
                return;
            _dialogs = (Dictionary<string, IDialog>)toDeserialize;
        }

        public object Serialize()
        {
            return _dialogs;
        }

        // Getters

        public IDialog GetDialog(string name)
        {
            return _dialogs[name];
        }

        public Dictionary<string, IDialog> GetDialogs()
        {
            return _dialogs;
        }
    }
}
