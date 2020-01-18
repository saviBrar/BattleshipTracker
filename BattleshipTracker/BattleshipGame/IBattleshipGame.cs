using System;
namespace BattleshipTracker
{
    public interface IBattleshipGame
    {
        public IBoard CreateBoard();
        public bool AddBattleship(IBoard board, IBoardCell startCell, IBattleship ship);
        public AttackResult Attack(IBoard board, IBoardCell cellToAttack);
    }
}
