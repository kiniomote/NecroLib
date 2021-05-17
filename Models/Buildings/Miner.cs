using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace NecroLib.Models.Buildings
{
    public delegate void TakeResource(int value);

    public class Miner : IMiner
    {
        public const int MILLISECOND = 100;
        public const int SECOND_IN_HOUR = 3600;

        public int BaseMining { get; private set; }
        public int MiningPerWorker { get; private set; }

        public int ImprovementMining { get; set; }

        public int Delay { get; private set; }

        private Timer _timer;
        private TakeResource TakeResourceHandler;

        private int _remainder;

        public Miner(int baseMining, int miningPerWorker, int delay)
        {
            BaseMining = baseMining;
            MiningPerWorker = miningPerWorker;
            Delay = delay;
            ImprovementMining = 0;
            _remainder = 0;
        }

        private void MineEvent(object source, ElapsedEventArgs e)
        {
            int currentMining = (GetFullMining() + _remainder);
            TakeResourceHandler?.Invoke(currentMining / GetCountPerHourDelay());
            _remainder = currentMining % GetCountPerHourDelay();
        }

        private int GetCountPerHourDelay()
        {
            return SECOND_IN_HOUR / Delay;
        }

        public int GetFullMining()
        {
            return ImprovementMining != 0 ? (BaseMining + ImprovementMining) * MiningPerWorker : 0;
        }

        public void AddMineEvent(TakeResource takeResource)
        {
            TakeResourceHandler += takeResource;
        }

        public void StartMining(DateTime lastMining, DateTime startMining)
        {
            TimeSpan timeSpan = startMining - lastMining;
            double hours = timeSpan.TotalHours;
            TakeResourceHandler.Invoke(Convert.ToInt32(Convert.ToDouble(GetFullMining()) * hours));

            _timer = new Timer(Delay * MILLISECOND);
            _timer.AutoReset = true;
            _timer.Elapsed += MineEvent;
            _timer.Start();
        }
    }
}
