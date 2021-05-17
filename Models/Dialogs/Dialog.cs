using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Dialogs
{
    [Serializable]
    public class Dialog : IDialog
    {
        private LinkedList<IReplica> _replicas;

        [NonSerialized]
        private LinkedListNode<IReplica> _currentReplica = null;

        public Dialog(LinkedList<IReplica> replicas)
        {
            _replicas = replicas;
        }

        public IReplica Start()
        {
            _currentReplica = _replicas.First;
            return _currentReplica.Value;
        }

        public IReplica Next()
        {
            if (_currentReplica == null)
                throw new Exception("Cannot use method Next without Start");
            _currentReplica = _currentReplica.Next;
            return _currentReplica.Value;
        }

        public bool HasNextReplica()
        {
            return _currentReplica != null && _currentReplica != _replicas.Last;
        }

        // Getters 

        public LinkedList<IReplica> GetReplicas()
        {
            return _replicas;
        }
    }
}
