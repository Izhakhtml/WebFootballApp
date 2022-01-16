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
                List<Player> players = dbContext.Players.ToList();
                return Ok(new {players});
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception sql)
            {
                return BadRequest(sql.Message);
            }
        }
        // GET: api/Player/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                return Ok(new {GetById = await dbContext.Players.FindAsync(id)});
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception sql)
            {
                return BadRequest(sql.Message);
            }

        }
        // POST: api/Player
        public async Task<IHttpActionResult> Post([FromBody]Player player)
        {
            try
            {
                dbContext.Players.Add(player);
                await dbContext.SaveChangesAsync();
                return Ok("The player added");
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch(Exception sql)
            {
                return BadRequest(sql.Message);
            }

        }
        // PUT: api/Player/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]Player value)
        {
            try
            {
                Player player = await dbContext.Players.FindAsync(id);
                player.FirstName = value.FirstName;
                player.LastNamme = value.LastNamme;
                player.Position = value.Position;
                player.Age = value.Age;
                await dbContext.SaveChangesAsync();
                return Ok("The changes have been saved successfully");
            }
            catch (SqlException sql)
            {
                return BadRequest(sql.Message);
            }
            catch (Exception sql)
            {
                return BadRequest(sql.Message);
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
            catch (Exception sql)
            {
                return BadRequest(sql.Message);
            }

        }
    }
}
