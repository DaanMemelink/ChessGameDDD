using ChessGameDDD.Domain.Core;
using ChessGameDDD.Domain.Domain.Entities;
using ChessGameDDD.Domain.Entities.Pieces;
using ChessGameDDD.Events;
using System;
using System.Collections.Generic;

namespace ChessGameDDD.Domain.Entities
{
    public class Board : Entity<Guid>
    {
        private BoardCell[,] boardSetup;

        private Board()
            : base(Guid.NewGuid())
        {
            boardSetup = new BoardCell[8, 8];
        }

        internal static Board Create()
        {
            return new Board();
        }

        internal Piece GetPieceToMove(BoardLocation boardLocation)
        {
            return new Rook();
        }

        internal void UpdateBoardPosition(Move move)
        {
            // set piece to location
            // not needed yet
        }

        internal IEnumerable<BoardCell> GetBoardCellsBetweenMoveLocations(Move move)
        {
            var fromBoardCell = GetBoardcellByMoveLocation(move.FromLocation);
            var toBoardCell = GetBoardcellByMoveLocation(move.ToLocation);
            // TODO: IMPLEMENT!!!!!!
            return null;
        }

        private BoardCell GetBoardcellByMoveLocation(BoardLocation location)
        {
            var fileBoardLocation = ParseFile(location.File);
            var rankBoardLocation = ParseRank(location.Rank);
            return boardSetup[fileBoardLocation, rankBoardLocation];
        }

        private int ParseFile(char file)
        {
            return file - 97;
        }

        private int ParseRank(char rank)
        {
            return rank - 49;
        }
    }
}