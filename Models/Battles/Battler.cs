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
            FormBattleSquads(character.Ownership.Army.Squads);
            FormBattleAttributes(character.Characteristics.BattleCharacteristics);
        }

        private void FormBattleSquads(Dictionary<SquadType, ISquad> squads)
        {
            BattleSquads = new List<IBattleSquad>();

            squads.ForEach(squad => BattleSquads.Add(new BattleSquad(squad.Value)));
        }

        private void FormBattleAttributes(Dictionary<HeroAttribute, IHeroCharacteristic> battleAttributes)
        {
            BattleAttributes = new Dictionary<HeroAttribute, int>();

            battleAttributes.ForEach(attribute => BattleAttributes.Add(attribute.Key, attribute.Value.GetValue()));
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
