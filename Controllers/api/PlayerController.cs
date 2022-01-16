using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebFootballApp.Models;

namespace WebFootballApp.Controllers.api
{
    public class PlayerController : ApiController
    {
        PlayerModel dbContext = new PlayerModel();
        // GET: api/Player
        public IHttpActionResult Get()
        {

            try
            {
                List<Player> playersList = dbContext.Players.ToList();
                return Ok(new { playersList });
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/Player/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Player GetById = await dbContext.Players.FindAsync(id);
                if (GetById!=null)
                {
                     return Ok(new {GetById});
                }
                     return NotFound();
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        // POST: api/Player
        public async Task<IHttpActionResult> Post([FromBody]Player player)
        {
            try
            {
                dbContext.Players.Add(player);
                await dbContext.SaveChangesAsync();
                return Ok("The player have been added successfully");
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        // PUT: api/Player/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]Player updatePlayer)
        {
            try
            {
                   Player player = await dbContext.Players.FindAsync(id);
                if (player != null)
                {
                   player.FirstName = updatePlayer.FirstName;
                   player.LastNamme = updatePlayer.LastNamme;
                   player.Position = updatePlayer.Position;
                   player.Age = updatePlayer.Age;
                   await dbContext.SaveChangesAsync();
                   return Ok("The changes have been saved successfully");
                }
                   return NotFound();

            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE: api/Player/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
               Player player = await dbContext.Players.FindAsync(id);
               dbContext.Players.Remove(player);
               await dbContext.SaveChangesAsync();
               return Ok("The player have been removed successfully");
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
