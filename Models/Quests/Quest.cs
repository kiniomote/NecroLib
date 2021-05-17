using NecroLib.Models.Battles;
using NecroLib.Models.Battles.Battlefields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NecroLib.Models.Images;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using NecroLib.Models.Localization;
using NecroLib.Models.Characters;
using NecroLib.Models.Items;
using NecroLib.Models.Battles.Ai;
using NecroLib.Models.Items.BlueprintBuilder;

namespace NecroLib.Models.Quests
{
    [Serializable]
    public class Quest : IQuest
    {
        private bool _completed = false;
        private bool _available = false;
        private bool _isMain = false;
        private int? _exam = null;
        private int _expirience = 0;

        private ILocalizedString _name;
        private ILocalizedString _description;

        public IImagePath Image { get; set; }

        public List<IQuest> NextQuests { get; private set; }
        public IQuest PrevQuest { get; set; }
        public IBattler Enemy { get; private set; }

        public AiType AiType { get; private set; }
        public AiDifficulty AiDifficulty { get; private set; }

        [field: NonSerialized]
        public List<IBlueprint> BlueprintsReward { get; private set; }
        private List<string> _blueprints;

        public Quest(IBattler battler, AiType aiType, AiDifficulty aiDifficulty, string uniqueName, int expirience, List<IBlueprint> blueprints = null, bool isMain = false, int? exam = null)
        {
            NextQuests = new List<IQuest>();
            Enemy = battler;
            AiType = aiType;
            AiDifficulty = aiDifficulty;
            BlueprintsReward = blueprints != null ? blueprints : new List<IBlueprint>();
            _name = new LocalizedString(LocalizationNames.QUEST + '_' + uniqueName, LocalizationNames.NAME);
            _description = new LocalizedString(LocalizationNames.QUEST + '_' + uniqueName, LocalizationNames.DESCRIPTION);
            Image = new ImagePath(uniqueName);
            _expirience = expirience;
            _isMain = isMain;
            _exam = exam;
        }

        public IBattle Start(ICharacter character)
        {
            IBattle battle = new Battle(new Battler(character), Enemy, Complete, character);
            battle.InitBattlefield(Enemy.BattlefieldPosition.GetRows(), Enemy.BattlefieldPosition.GetColumns());
            battle.BattleCourse.SetDefenderAi(battle, AiType, AiDifficulty);
            return battle;
        }

        public void MakeAvailable()
        {
            _available = true;
        }

        public void RegisterNextQuests(List<IQuest> quests)
        {
            foreach (IQuest quest in NextQuests)
            {
                quest.PrevQuest = null;
            }

            NextQuests = quests;

            foreach (IQuest quest in NextQuests)
            {
                quest.PrevQuest = this;
            }
        }

        public void RegisterPrevQuest(IQuest quest)
        {
            if (PrevQuest != null)
            {
                List<IQuest> oldQuests = PrevQuest.NextQuests;
                oldQuests.Remove(this);
                PrevQuest.RegisterNextQuests(oldQuests);
            }
            PrevQuest = quest;
            if (PrevQuest != null)
            {
                List<IQuest> quests = PrevQuest.NextQuests;
                quests.Add(this);
                PrevQuest.RegisterNextQuests(quests);
            }
        }

        public void Complete(ICharacter character, bool withReward = false)
        {
            if (!_available || _completed)
                return;
            _completed = true;

            NextQuests.ForEach(quest => quest.MakeAvailable());

            if (withReward)
                GiveReward(character);
        }

        private void GiveReward(ICharacter character)
        {
            character.Level.AddExpirience(_expirience);
            character.Inventory.Blueprints.AddRange(BlueprintsReward);
            if (_exam != null && character.Level.GetLevel() == _exam && !character.Level.FinishedExam())
            {
                character.Level.FinishExam();
            }
        }

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            _blueprints = new List<string>();
            foreach (IBlueprint blueprint in BlueprintsReward)
            {
                _blueprints.Add(blueprint.ToString());
            }
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            BlueprintsReward = new List<IBlueprint>();
            IBlueprintBuilder blueprintBuilder = new BlueprintBuilder();
            foreach (string blueprint in _blueprints)
            {
                BlueprintsReward.Add(blueprintBuilder.BuildBlueprint(blueprint));
            }
        }

        // Getters

        public int? Exam()
        {
            return _exam;
        }

        public int Expirience()
        {
            return _expirience;
        }

        public bool Completed()
        {
            return _completed;
        }

        public bool Available()
        {
            return _available;
        }

        public bool IsMain()
        {
            return _isMain;
        }

        public string GetDescription()
        {
            return _description.ToString();
        }

        public string GetName()
        {
            return _name.ToString();
        }

        public override string ToString()
        {
            return _name.GetName();
        }

        public string GetDescriptionName()
        {
            return _description.GetName();
        }
    }
}
