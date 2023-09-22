using System.Linq;
using ChessGameDDD.Domain.Core;

namespace ChessGameDDD.Domain.Entities
{
    public abstract class Piece : ValueObject
    {
        internal abstract bool CanJumpOtherPiece { get; }

        internal virtual void CanMakeMove(Move move, Board board)
        {
            MoveIsAllowedOnBoard(move, board);
                        
            // Field doesn't contain own piece
            // Move checks king
        }

        public void MoveIsAllowedOnBoard(Move move, Board board)
        {
            // check if move jumps over other piece
            var piecesBetweenMove = board.GetPiecesBetweenMoveLocations(move);

            if (piecesBetweenMove.Any() && !CanJumpOtherPiece) {
                throw new BusinessRuleViolationException("Piece is not allowed to jump other pieces");
            }
        }
    }
}