using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using MitosAPI.Models;
using System;
using MitosAPI;

namespace DiosesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiosController : ControllerBase
    {
        
        public readonly MITOSContext _dbcontext;

        public DiosController(MITOSContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Dios> lista = new List<Dios>();

            try
            {
                lista = _dbcontext.Dios.Include(c => c.oMitologia).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }

        [HttpGet]
        [Route("Obtener/{idDios:int}")]
        public IActionResult Obtener(int idDios)
        {
            Dios oDios = _dbcontext.Dios.Find(idDios);

            if (oDios == null)
            {
                return BadRequest("Dios no encontrado");
            }

            try
            {
                oDios = _dbcontext.Dios.Include(c => c.oMitologia).Where(p => p.IdDios == idDios).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oDios });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oDios });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Dios objeto)
        {

            try
            {
                _dbcontext.Dios.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        //[HttpPost]
        //[Route("Guardar")]
        //public async Task<IActionResult> Guardar([FromForm] Dios objeto, SubirImagenApi fichero)
        //{
        //    var ruta = String.Empty;
        //    if (fichero.Archivo.Length > 0)
        //    {
        //        var nombreArchivo = Guid.NewGuid().ToString() + ".jpg";
        //        ruta = $"Imagenes/{nombreArchivo}";
        //        using (var stream = new FileStream(ruta, FileMode.Create))
        //        {
        //            await fichero.Archivo.CopyToAsync(stream);
        //        }
        //        objeto.UrlImagen = ruta;
        //        try
        //        {
        //            _dbcontext.Dios.Add(objeto);
        //            _dbcontext.SaveChanges();

        //            return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
        //        }
        //        catch (Exception ex)
        //        {
        //            return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
        //        }
        //    }
        //    else
        //    {

        //    }

        //}
        //-----------------------------------------------
        [HttpPost("GuardarImagen")]
        public async Task<string> GuardarImagen([FromForm] SubirImagenApi fichero)
        {
            var ruta = String.Empty;
            if (fichero.Archivo.Length > 0)
            {
                var nombreArchivo = Guid.NewGuid().ToString() + ".jpg";
                ruta = $"Imagenes/{nombreArchivo}";
                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    await fichero.Archivo.CopyToAsync(stream);
                }
            }

            return ruta;
        }

        //----------------------------------------------

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Dios objeto)
        {
            Dios oDios = _dbcontext.Dios.Find(objeto.IdDios);

            if (oDios == null)
            {
                return BadRequest("Dios no encontrado");
            }

            try
            {
                oDios.Nombre = objeto.Nombre is null ? oDios.Nombre : objeto.Nombre;
                oDios.Poder = objeto.Poder is null ? oDios.Poder : objeto.Poder;
                oDios.IdMitologia = objeto.IdMitologia is null ? oDios.IdMitologia : objeto.IdMitologia;
                oDios.Afiliacion = objeto.Afiliacion is null ? oDios.Afiliacion : objeto.Afiliacion;
                oDios.Hogar = objeto.Hogar is null ? oDios.Hogar : objeto.Hogar;
                oDios.Posesiones = objeto.Posesiones is null ? oDios.Posesiones : objeto.Posesiones;
                oDios.UrlImagen = objeto.UrlImagen is null ? oDios.UrlImagen : objeto.UrlImagen;
                oDios.NombreImagen = objeto.NombreImagen is null ? oDios.NombreImagen : objeto.NombreImagen;

                _dbcontext.Dios.Update(oDios);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{idDios:int}")]
        public IActionResult Eliminar(int idDios)
        {
            Dios oDios = _dbcontext.Dios.Find(idDios);

            if (oDios == null)
            {
                return BadRequest("Dios no encontrado");
            }

            try
            {
                _dbcontext.Dios.Remove(oDios);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
        //PARA IMAGEN

    }
}