using NecroLib.Models.Characters;
using NecroLib.Models.Units;
using NecroLib.Models.Battles.Battlefields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecroLib.Models.Battles
{
    [Serializable]
    public class Battler : IBattler
    {
        public Dictionary<HeroAttribute, int> BattleAttributes { get; private set; }
        public List<IBattleSquad> BattleSquads { get; private set; }
        public IBattlefieldPosition BattlefieldPosition { get; private set; }

        public List<IBattleUnit> BattleUnits { get; private set; }

        public Battler(List<IBattleSquad> squads, Dictionary<HeroAttribute, int> battleAttributes, IBattlefieldPosition battlefieldPosition)
        {
            BattleSquads = squads;
            BattleAttributes = battleAttributes;
            BattlefieldPosition = battlefieldPosition;
        }

        public Battler(ICharacter character)
        {
            Dictionary<SquadType, ISquad> squads = character.Ownership.Army.Squads;
            Dictionary<HeroAttribute, IHeroCharacteristic> battleAttributes = character.Characteristics.BattleCharacteristics;

            BattleSquads = new List<IBattleSquad>();

            foreach (var squad in squads)
            {
                BattleSquads.Add(new BattleSquad(squad.Value));
            }

            BattleAttributes = new Dictionary<HeroAttribute, int>();

            foreach (var attribute in battleAttributes)
            {
                BattleAttributes.Add(attribute.Key, attribute.Value.GetValue());
            }
        }

        public List<IBattleUnit> GetAliveUnits()
        {
            return BattleUnits.Where(battleUnit => !battleUnit.IsDead()).ToList();
        }

        public void SetBattleUnits()
        {
            BattleUnits = new List<IBattleUnit>();

            foreach(var squad in BattleSquads)
            {
                IBattleUnit battleUnit = new BattleUnit(squad, BattleAttributes, this);

                BattleUnits.Add(battleUnit);
            }
        }

        public bool IsAliveUnits()
        {
            bool alive = false;

            foreach (var unit in BattleUnits.Where(battleUnit => battleUnit.BattlePoint != null))
            {
                unit.CheckDeath();
                if (!unit.IsDead())
                {
                    alive = true;
                }
            }

            return alive;
        }
    }
}
