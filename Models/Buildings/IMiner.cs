using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Buildings
{
    public interface IMiner
    {
        int BaseMining { get; }
        int MiningPerWorker { get; }
        int ImprovementMining { get; set; }
        int Delay { get; }

        void StartMining(DateTime lastMining, DateTime startMining);

        int GetFullMining();

        void AddMineEvent(TakeResource takeResource);
    }
}
