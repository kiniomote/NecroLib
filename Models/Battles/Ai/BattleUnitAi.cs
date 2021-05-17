using System;
using System.Collections.Generic;
using System.Text;

namespace NecroLib.Models.Battles.Ai
{
    public class BattleUnitAi : IBattleUnitAi
    {
        public const double AI_TYPE_FACTOR = 1.25;

        public IBattleUnit BattleUnit { get; private set; }
        public IUnitMove CurrentUnitMove { get; private set; }

        private IBattlerAi _battler;
        private Dictionary<UnitMove, IUnitMove> _unitMoves;

        public BattleUnitAi(IBattleUnit unit, IBattlerAi battler)
        {
            BattleUnit = unit;
            _battler = battler;
            AddUnitMoves();
        }

        public void MakeTurn()
        {
            double currentPriority = CurrentUnitMove?.GetMovePrioprity() ?? 0;

            bool changed = false;
            foreach (IUnitMove unitMove in _unitMoves.Values)
            {
                if (unitMove.GetMovePrioprity() > currentPriority)
                {
                    CurrentUnitMove = unitMove;
                    changed = true;
                }
            }

            CurrentUnitMove?.ReleaseMove(changed);
        }

        private void AddUnitMoves()
        {
            _unitMoves = new Dictionary<UnitMove, IUnitMove>();
            _unitMoves.Add(UnitMove.Attack, new AttackMoveAi(this, _battler));
            _unitMoves.Add(UnitMove.Chase, new ChaseMoveAi(this, _battler));
            _unitMoves.Add(UnitMove.Escape, new EscapeMoveAi(this, _battler));
            _unitMoves.Add(UnitMove.Hold, new HoldMoveAi(this, _battler));
        }
    }
}
