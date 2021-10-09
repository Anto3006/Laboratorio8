using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;
using Laboratorio8.Models;

namespace Laboratorio8.Handler
{
    public class ProductHandler
    {
        private readonly SqlConnection ConexionProducts;
        private readonly String RutaConexionProducts;

        public ProductHandler()
        {
            RutaConexionProducts = ConfigurationManager.ConnectionStrings["ProductConnection"].ToString();
            ConexionProducts = new SqlConnection(RutaConexionProducts);
        }

        public IEnumerable<ProductModel> GetAll()
        {
            List<ProductModel> productsList = new List<ProductModel>();
            string consulta = "SELECT * FROM Products";
            SqlCommand comandoParaConsulta = new SqlCommand(consulta, ConexionProducts);
            SqlDataAdapter adaptadorParaTabla = new SqlDataAdapter(comandoParaConsulta);
            DataTable consultaFormatoTabla = new DataTable();
            ConexionProducts.Open();
            adaptadorParaTabla.Fill(consultaFormatoTabla);
            ConexionProducts.Close();
            foreach(DataRow filaProducto in consultaFormatoTabla.Rows)
            {
                ProductModel product = new ProductModel
                {
                    Id = Convert.ToInt32(filaProducto["id"]),
                    Quantity = Convert.ToInt32(filaProducto["quantity"]),
                    Name = Convert.ToString(filaProducto["productName"]),
                    Price = Convert.ToDouble(filaProducto["price"])
                };
                productsList.Add(product);
            }
            return productsList;
        }
    }
}