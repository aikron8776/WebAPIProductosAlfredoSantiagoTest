using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPIProductos.Data;
using WebAPIProductos.Models;

namespace WebAPIProductos.Controllers
{
    public class ProductoController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public List<Productos> ListarProductos()
        {
            return ProductosData.ListarProductos();
        }

        // GET api/<controller>/5
        [HttpGet]
        public Productos ObtenerProductoxID(int id)
        {
            return ProductosData.ObtenerProducto(id, ProductosData.ListarProductos());
        }

        // GET api/<controller>/5
        [HttpGet]
        public Productos GetbyId(int id, List<Productos> lstProductos)
        {
            return ProductosData.ObtenerProducto(id, lstProductos);
        }

        // POST api/<controller>
        [HttpPost]
        public bool Post([FromBody] Productos objProducto)
        {
            return ProductosData.RegistrarProducto(objProducto, ProductosData.ListarProductos());
        }

        // PUT api/<controller>/5
        [HttpPut]
        public bool Put([FromBody] Productos oUsuario)
        {
            return ProductosData.ModificarProducto(oUsuario, ProductosData.ListarProductos());
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public bool Delete(int id)
        {
            return ProductosData.Eliminar(id);
        }
    }
}
