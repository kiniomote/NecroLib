using NecroLib.Services.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Dialogs
{
    public interface ICommunication : ISerializable
    {
        IDialog GetDialog(string name);

        Dictionary<string, IDialog> GetDialogs();
    }
}
