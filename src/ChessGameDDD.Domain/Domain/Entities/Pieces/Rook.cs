using ChessGameDDD.Domain.BusinessRules.PieceRules;
using System.Collections.Generic;

namespace ChessGameDDD.Domain.Entities.Pieces
{
    public class Rook : Piece
    {
        internal override bool CanJumpOtherPiece => false;

        protected override IEnumerable<object> GetAtomicValues()
        {
            return null;
        }

        internal override void CanMakeMove(Move move, Board board)
        {
            base.CanMakeMove(move, board);
            this.DirectionIsAllowed(move);
        }
    }
}