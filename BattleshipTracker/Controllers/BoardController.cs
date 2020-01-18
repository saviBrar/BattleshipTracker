using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BattleshipTracker.Models;
using BattleshipTracker.Exceptions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BattleshipTracker.Controllers
{
    [ApiController]
    [Route("")]
    public class BoardController : Controller
    {
        private readonly IBattleshipGame _game;
        public BoardController(IBattleshipGame game)
        {
            _game = game;
        }

        [HttpGet]
        [Route("Battleship/Create")]
        public IBoard Get()
        {

            var localBoard = _game.CreateBoard();

            HttpContext.Session.Set("LocalB", BoardSerializer.SerializeObject(localBoard));
            return localBoard;

        }

        [HttpPost]
        [Route("Battleship/AddBattleShip")]
        public PlaceBattleshipResponse AddBattleShip([FromBody] PlaceBattleshipRequest request)
        {
            if (request == null)
            {
                throw new ArgumentException("The request object is null.");
            }
            try
            {
                var orientation = (OrientationType)Enum.Parse(typeof(OrientationType), request.Orientation);

                byte[] deserial;
                bool canRead = HttpContext.Session.TryGetValue("LocalB", out deserial);
                if (canRead)
                {
                    var localB = BoardSerializer.DeSerializeObject(deserial);
                    bool result = _game.AddBattleship(localB, new BoardCell()
                    {
                        RowCoordinate = request.RowCoordinate,
                        ColumnCoordinate = request.ColumCoordinate
                    }, new Battleship() { Orientation = orientation, Width = request.Width });

                    HttpContext.Session.Set("LocalB", BoardSerializer.SerializeObject(localB));
                    return new PlaceBattleshipResponse() { Result = result, Board = localB };
                }

                //Force the player to create new game before placing battleship
                throw new HttpResponseException
                {
                    HttpStatusCode = HttpStatusCode.NotFound,
                    HttpResponseMessage = "The game board has not been created. Please create a game board before attacking."
                };
            }
            catch (Exception ex)
            {
                throw new HttpResponseException
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    HttpResponseMessage = ex.Message
                };
            }
        }

        [HttpPost]
        [Route("Battleship/Attack")]
        public AttackResponse Attack([FromBody] AttackRequest request)
        {
            if (request == null)
            {
                throw new ArgumentException("The request object is null.");
            }

            try
            {
                byte[] deserial;
                bool canRead = HttpContext.Session.TryGetValue("LocalB", out deserial);
                if (canRead)
                {
                    var localB = BoardSerializer.DeSerializeObject(deserial);
                    var HitOrMiss = _game.Attack(localB, new BoardCell()
                    {
                        RowCoordinate = request.RowCoordinate,
                        ColumnCoordinate = request.ColumnCoordinate
                    });
                    HttpContext.Session.Set("LocalB", BoardSerializer.SerializeObject(localB));
                    return new AttackResponse() { Board = localB, Result = Enum.GetName(typeof(AttackResult), HitOrMiss) };
                }

                //Force the player to create new game before placing battleship
                throw new HttpResponseException
                {
                    HttpStatusCode = HttpStatusCode.NotFound,
                    HttpResponseMessage = "The game board has not been created. Please create a game board before attacking."
                };
            }
            catch (Exception ex)
            {
                throw new HttpResponseException
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    HttpResponseMessage = ex.Message
                };
            }


        }
    }
}
