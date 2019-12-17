using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mines_Sweeper.Classes;
using Mines_Sweeper.Const;
using Mines_Sweeper.Core;
using Mines_Sweeper.Dao;
using Mines_Sweeper.Repository;
using Mines_Sweeper.Validation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mines_Sweeper.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class GameController : Controller
    {
        /// <summary>
        /// It creates a new game. This method creates the structure of the game
        /// using the values from the body, this means create a matrix
        /// Height x Width with N bombs.
        /// it also call to an interface with in this time will save a new json
        /// file with the main structure.
        /// </summary>
        /// <param name="value"> this contains Height, Width and Bombs
        /// </param>
        /// <returns> a token for resume the game.</returns>
        [Route("api/[controller]/newgame")]
        [HttpPost]
        public ActionResult<NewGameResponse> NewGame([FromBody]NewPostBody value)
        {
            //validate input
            if (!NewGameValidation.IsBodyPostValid(value))
            {
                return BadRequest();
            }

            //create token
            NewGameResponse response = new NewGameResponse();
            response.Token = Guid.NewGuid().ToString();

            //generate structure to save (map with mines)
            MineMatrix mineMatrix = new MineMatrix(value.Height, value.Width, value.Bombs, response.Token);


            //save structure in repository
            //it could be an interface for db, file or memcached
            MineRepository repository = new MineRepository();
            repository.Save(mineMatrix);


            return response;
        }

        /// <summary>
        /// This is the core of the application, when you pick it returns the status
        /// of the cells, if it has a bomb, a number or cells to be discover and also
        /// it returns the status of the game if still continue or game over.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/[controller]/pick")]
        [HttpPost("token")]
        public ActionResult<PickResponse> Pick([FromBody]CellCoordinates value, string token)
        {
            //middleware checks token
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest();
            }
            // validate coordinates

            if (!PickValidation.IsPickValid(value))
            {
                return BadRequest();
            }

            MineRepository repository = new MineRepository();
            MineMatrix mineMatrix = repository.Load(token);

            if (mineMatrix == null)
            {
                return StatusCode(500);
            }

            // evaluate if bomb, number or zero
            MineSweeper core = new MineSweeper(mineMatrix);

            Cell cell = core.ProcessPoint(value.X, value.Y);

            PickResponse pr = new PickResponse();
            if (core.IsGameOver())
            {
                pr.GameStatus = GameStatus.GAME_OVER.ToString();
            }
            else
            {
                pr.GameStatus = GameStatus.PLAYING.ToString();
            }

            pr.TimeLapsed = DateTime.Now.Subtract(mineMatrix.StartedTime).Minutes; 
            
            return pr;
        }

        /// <summary>
        /// it marks a cell and returns if was marked or not.
        /// it returns the status of the game if still continue or game over.
        /// </summary>
        /// <param name="value">the coordinates</param>
        /// <returns></returns>
        [Route("api/[controller]/mark")]
        [HttpPost("token")]
        public ActionResult<string> Mark([FromBody]CellCoordinates value,string token)
        {
            //middleware checks token
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest();
            }
            // validate coordinates and verify if cell is not discovered.

            // make math for knowing the delta.

            // check if game is end

            // return json objects
            
            return NotFound();
        }
    }
}
