using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebAPIProductos.Models;

namespace WebAPIProductos.Data
{
    public class ProductosData
    {

        public static List<Productos> lstproductos
            = new List<Productos>() {
                new Productos(){
                    Id = 1,
                    nombre = "Teclado",
                    cantidad = 1,
                    categoria = "Computacion",
                    descripcion = "Sirve para escribir en una computadora",
                    precio = 250
                }
            };

        public static bool RegistrarProducto(Productos objProductos, List<Productos> lstProductos)
        {
            int MaxID = ListarProductos().Select(x => x.Id).Max();

            objProductos.Id = MaxID + 1;

            lstProductos.Add(objProductos);

            return true;
        }

        public static bool ModificarProducto(Productos objProductos, List<Productos> lstProductos)
        {
            lstProductos.Where(x => x.Id == objProductos.Id).FirstOrDefault().nombre = objProductos.nombre;
            lstProductos.Where(x => x.Id == objProductos.Id).FirstOrDefault().cantidad = objProductos.cantidad;
            lstProductos.Where(x => x.Id == objProductos.Id).FirstOrDefault().precio = objProductos.precio;
            lstProductos.Where(x => x.Id == objProductos.Id).FirstOrDefault().descripcion = objProductos.descripcion;
            lstProductos.Where(x => x.Id == objProductos.Id).FirstOrDefault().categoria = objProductos.categoria;

            return true;
        }

        public static List<Productos> ListarProductos()
        {
            return lstproductos;
        }

        public static Productos ObtenerProducto(int id, List<Productos> lstProductos)
        {
            return lstProductos.Where(x => x.Id == id).FirstOrDefault();
        }

        public static bool Eliminar(int id)
        {

            ListarProductos().Remove(ListarProductos().Where(x => x.Id == id).FirstOrDefault());


            return true;
        }
    }
}