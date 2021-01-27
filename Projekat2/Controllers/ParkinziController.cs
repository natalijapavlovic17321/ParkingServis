using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projekat.Models;

namespace Projekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkinziController : ControllerBase
    {
        public ParkinziContext Context{get;set;}
        public ParkinziController(ParkinziContext context)
        {
          Context=context;
        }

        [Route("PreuzmiViseParkinga")]
        [HttpGet]
        [EnableCors("CORSAll")]
        public async Task<List<Parkinzi>> PreuzmiParkinge()
        {
            return await Context.Park.Include(p=>p.Parkings).ThenInclude(par=> par.Listamesta).ToListAsync();
        }
        [Route("UpisParkinga")]
        [HttpPost]
        public async Task UpisParkinga([FromBody] Parkinzi park)
        {
           Context.Park.Add(park);
           await Context.SaveChangesAsync();
        }
        [Route("IzmeniViseParkinga")]
        [HttpPut]
        public async Task IzmeniParkinge([FromBody] Parkinzi park)
        {
            Context.Update<Parkinzi>(park);
            await Context.SaveChangesAsync();
        }
        [Route("IzbrisiViseParkinga /{id}")]
        [HttpDelete]
        public async Task IzbrisiParkinge(int id)
        {
          var park= await Context.FindAsync<Parkinzi>(id);
          Context.Remove(park);
          await Context.SaveChangesAsync();
        }
        [Route("UpisJednogParkinga/{idPark}")]
        [HttpPost]
        public async Task UpisJednogparkinga(int idPark, [FromBody] Parking par)
        {
            var park= await Context.Park.FindAsync(idPark);
            par.Parkinzi=park;
            par.N=park.N;
            par.M=park.M;
            //iste dimenzije svih parkinga
            //Povecavanje broja Parkinga
            if(park.Num==park.Parkings.ToList().LongCount())
                return;
            //park.Num++;
            Context.JedanParking.Add(par);
            await Context.SaveChangesAsync();
           // Context.Update<Parkinzi>(park);
           // await Context.SaveChangesAsync();
        }
        [Route("UpisMesta/{idPark}")]
        [HttpPost]
        public async Task<IActionResult> UpisMesta(int idPark,[FromBody]Mesta mes)
        {
            var park=await Context.Park.FindAsync(idPark);
            var parking= await Context.JedanParking.FindAsync(mes.Naselje); 
            mes.Parking=parking;
            mes.Parkinzi=park;
            if (Context.Mesto.Any(p => p.Tablica == mes.Tablica) )
            {
                var xy = Context.Mesto.Where(p => p.Tablica == mes.Tablica).FirstOrDefault();
                return BadRequest(new { X = xy?.X, Y = xy?.Y });
            }
            var thatLok = Context.Mesto.Where(p => p.X == mes.X && p.Y == mes.Y && p.Povrsina==mes.Povrsina && p.Naselje==mes.Naselje).FirstOrDefault();
            if (thatLok != null)
            {
                 return StatusCode(406);
            }
            parking.Brojzauzetih++;
            Context.Mesto.Add(mes);
            //Context.Update<Parking>(parking);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [Route("PreuzmiJedanParking")]
        [HttpGet]
        [EnableCors("CORSAll")]
        public async Task<List<Parking>> PreuzmiJedanParking()
        {
            return await Context.JedanParking.Include(p=>p.Listamesta).ToListAsync() ;
        }
        [Route("PreuzmiMesto")]
        [HttpGet]
        [EnableCors("CORSAll")]
        public async Task<List<Mesta>> Preuzmimesto()
        {
            return await Context.Mesto.ToListAsync() ;
        }
        [Route("IzmeniJedanParking")]
        [HttpPut]
        public async Task IzmenijedanParking([FromBody] Parking parking)
        {
            Context.Update<Parking>(parking);
            await Context.SaveChangesAsync();
        }
        [Route("IzmeniMesta")]
        [HttpPut]
        public async Task IzmeniMesta([FromBody] Mesta mes)
        { 
            Context.Update<Mesta>(mes);
            await Context.SaveChangesAsync();
        }
        [Route("IzbrisiJedanParking/{naselje}")]
        [HttpDelete]
        public async Task IzbrisiJedanParking(string naselje)
        {
          var parking= await Context.FindAsync<Parking>(naselje);
          Context.Remove(parking);
          await Context.SaveChangesAsync();
        }
        [Route("IzbrisiMesto/{tablica}")]
        [HttpDelete]
        public async Task IzbrisiMesto(string tablica)
        {
          var mes= await Context.FindAsync<Mesta>(tablica);
          Context.Remove(mes);
          await Context.SaveChangesAsync();
        }
    }
}