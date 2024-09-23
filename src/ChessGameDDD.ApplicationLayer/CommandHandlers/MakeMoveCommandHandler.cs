using System;
using ChessGameDDD.ApplicationLayer.Commands;
using ChessGameDDD.Domain.Entities;
using ChessGameDDD.Events;
using System.Collections.Generic;
using Polly;

namespace ChessGameDDD.ApplicationLayer.CommandHandlers
{
    public class MakeMoveCommandHandler
    {
        private readonly Policy _retryPolicy;
        
        public MakeMoveCommandHandler()
        {
            _retryPolicy = Policy
                .Handle<Exception>()
                .Retry(3, (exception, retryCount) =>
                {
                    // Log the retry attempt
                    Console.WriteLine($"Retry {retryCount} due to {exception.Message}");
                });
        }

        public Game HandleCommand(MakeMoveCommand moveCommand)
        {
            return _retryPolicy.Execute(() =>
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
            });   
        }
    }
}