using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Localization;

namespace NecroLib.Models.Characters
{
    public interface ILevel : INameable
    {
        void AddExpirience(int expirience);
        void FinishExam();
        int GetExpirience();
        int GetMaxExpirience();
        int GetLevel();
        bool FinishedExam();

        bool EnoughLevel(int level);
    }
}
