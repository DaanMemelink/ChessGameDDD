using ChessGameDDD.ApplicationLayer.Commands;
using ChessGameDDD.Domain.Entities;
using ChessGameDDD.Events;
using System.Collections.Generic;

namespace ChessGameDDD.ApplicationLayer.CommandHandlers
{
    public class MakeMoveCommandHandler
    {
        public MakeMoveCommandHandler()
        {
        }

        public Game HandleCommand(MakeMoveCommand moveCommand)
        {
            // Create game via eventsourcing from DB
            // Get old events from DB (infrastructure layer)
            var oldEvents = new List<Event>();

            var game = Game.Create(oldEvents);

            // Map command to move
            // var move = new Move();

            // game.MakeMove(move);

            // persist events
            // Save to database (Infrastructure layer)
            var eventsToSave = game.GetEvents();

            // publsih events
            // MessagePublisher.publish(game.GetEvents());

            return game;
        }
    }
}