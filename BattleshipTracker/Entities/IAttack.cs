using System;
namespace BattleshipTracker
{
    public interface IAttack
    {
        AttackResult AttackShip(IBoard board, IBoardCell cellToAttack);
    }
}
