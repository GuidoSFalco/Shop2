using Microsoft.AspNetCore.Mvc;
using Shop2.Shared.Data;
using Shop2.Shared.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop2.Server.Controllers
{
    [ApiController]
    [Route("api/shop")]
    public class ComprasController : ControllerBase
    {
        private readonly dbContext context;

        public ComprasController(dbContext context)
        {
            this.context = context;
            this.context = context;
        }

        [HttpGet]
        public ActionResult<List<Compra>> Get()
        {
            return context.Compras.ToList();
        }

        [HttpPost]
        public ActionResult<Compra> Post(Compra compra)
        {
            try
            {
                context.Compras.Add(compra);
                context.SaveChanges();
                return compra;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("{id:int}")]
        public ActionResult<Compra> Get(int id)
        {
            var compra = context.Compras.Where(x => x.Id == id).FirstOrDefault();
            if (compra == null)
            {
                return NotFound($"No existe el pais con id igual a {id}.");
            }
            return compra;


        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Compra compra)
        {
            if (id != compra.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var pepe = context.Compras.Where(x => x.Id == id).FirstOrDefault();
            if (pepe == null)
            {
                return NotFound("no existe la compra a modificar.");
            }
            pepe.Producto = compra.Producto;
            pepe.Cant = compra.Cant;
            try
            {
                context.Compras.Update(pepe);
                context.SaveChanges();
                return Ok("Los datos han sido cambiados");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var compra = context.Compras.Where(x => x.Id == id).FirstOrDefault();
            if (compra == null)
            {
                return NotFound($"No existe el pais con id igual a {id}.");
            }

            try
            {
                context.Compras.Remove(compra);
                context.SaveChanges();
                return Ok($"La compra {compra.Cant} ha sido borrada.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }


}
