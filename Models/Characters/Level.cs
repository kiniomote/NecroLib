using NecroLib.Models.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Characters
{
    public delegate void LevelUpHandler(int level);

    [Serializable]
    public class Level : ILevel
    {
        public const int MAX_LEVEL = 8;

        private static readonly List<int> MAX_EXPIRIENCE = new List<int>()
        {
            100,
            300, 1000, 2100, 3600,
            5500, 7800, 10500, 15200
        };

        private LocalizedString _name;
        
        private int _expirience;
        private int _maxExpirience;
        private int _currentLevel;
        private List<bool> _finishedExams;

        public event LevelUpHandler LevelUpEvent;

        public Level(LevelUpHandler levelUpHandler)
        {
            _currentLevel = 0;
            _expirience = 0;
            _maxExpirience = MAX_EXPIRIENCE[_currentLevel];
            _name = new LocalizedString(LocalizationNames.LEVEL_NAMES[_currentLevel]); ;
            _finishedExams = new List<bool>() { false, false, false, false, false, false, false, false, false };
            LevelUpEvent += levelUpHandler;
        }

        public void AddExpirience(int expirience)
        {
            if (_expirience + expirience > _maxExpirience)
            {
                if (_finishedExams[_currentLevel] && _currentLevel < MAX_LEVEL)
                    levelUp();
                else
                    _expirience = _maxExpirience;
            }
            else
            {
                _expirience += (expirience > 0 ? expirience : 0);
            }
        }

        public void FinishExam()
        {
            _finishedExams[_currentLevel] = true;
        }

        public bool FinishedExam()
        {
            return _finishedExams[_currentLevel];
        }

        public bool EnoughLevel(int level)
        {
            return _currentLevel >= level;
        }

        private void levelUp()
        {
            _currentLevel++;
            _expirience = 0;
            _maxExpirience = MAX_EXPIRIENCE[_currentLevel];
            _name = new LocalizedString(LocalizationNames.LEVEL_NAMES[_currentLevel]);
            LevelUpEvent?.Invoke(_currentLevel);
        }

        // Getters

        public int GetExpirience()
        {
            return _expirience;
        }

        public int GetLevel()
        {
            return _currentLevel;
        }

        public int GetMaxExpirience()
        {
            return _maxExpirience;
        }

        public string GetName()
        {
            return _name.ToString();
        }
    }
}
