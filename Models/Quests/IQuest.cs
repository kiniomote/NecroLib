using System;
using System.Collections.Generic;
using System.Text;
using NecroLib.Models.Battles;
using NecroLib.Models.Localization;
using NecroLib.Models.Characters;
using NecroLib.Models.Images;
using NecroLib.Models.Items;
using NecroLib.Models.Battles.Battlefields;
using NecroLib.Models.Battles.Ai;

namespace NecroLib.Models.Quests
{
    public interface IQuest : IDescribeable, INameable, IImageable
    {
        List<IQuest> NextQuests { get; }
        IQuest PrevQuest { get; set; }
        IBattler Enemy { get; }

        AiType AiType { get; }
        AiDifficulty AiDifficulty { get; }

        List<IBlueprint> BlueprintsReward { get; }

        IBattle Start(ICharacter character);

        void Complete(ICharacter character, bool withReward = false);
        void MakeAvailable();

        void RegisterNextQuests(List<IQuest> quests);
        void RegisterPrevQuest(IQuest quest);

        int Expirience();
        bool Completed();
        bool Available();
        bool IsMain();
        int? Exam();

        string GetDescriptionName();
    }
}
