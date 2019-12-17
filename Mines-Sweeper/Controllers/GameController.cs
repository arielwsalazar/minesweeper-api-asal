using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mines_Sweeper.Classes;
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
            //genereate empty block maps

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
        [HttpPost]
        public string Pick([FromBody]CellCoordinates value)
        {
            //middleware checks token
            // validate coordinates
            // evaluate if bomb, number or zero
            // check if game is end
            // return json objects
            int x = value.X;
            int y = value.Y;
            return $"pick x: {x} y: {y}";
        }

        /// <summary>
        /// it marks a cell and returns if was marked or not.
        /// it returns the status of the game if still continue or game over.
        /// </summary>
        /// <param name="value">the coordinates</param>
        /// <returns></returns>
        [Route("api/[controller]/mark")]
        [HttpPost]
        public string Mark([FromBody]CellCoordinates value)
        {
            //middleware checks token
            // validate coordinates and vefiry if cell is not discovered.
            // make math for knowing the delta.
            // check if game is end
            // return json objects
            int x = value.X;
            int y = value.Y;
            return $"pick x: {x} y: {y}";
        }
    }
}
