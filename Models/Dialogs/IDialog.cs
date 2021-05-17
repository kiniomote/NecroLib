using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Dialogs
{
    public interface IDialog
    {
        IReplica Start();
        IReplica Next();
        bool HasNextReplica();

        LinkedList<IReplica> GetReplicas();
    }
}
