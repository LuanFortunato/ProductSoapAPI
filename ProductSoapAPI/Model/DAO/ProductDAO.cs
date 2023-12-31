﻿using ProductSoapAPI.Model.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProductSoapAPI.Model.DAO
{
    public class ProductDAO
    {
        public string PostProduct(ProductVO product) 
        {
            string msg;
            try
            {
                DBConnection conexaodb = new DBConnection();

                var sql = "INSERT INTO products (name, color, supplier_id) VALUES ( '" + product.Name + "' , '" + product.Color + "' , '" + product.SupplierId + "')";
                conexaodb.conectar();
                conexaodb.comandosql(sql);
                conexaodb.desconectar();
                msg = "Inserido com Sucesso";
            }
            catch (Exception e)
            { 
                msg = e.Message; 
            }

            return msg;
        }

        public string GetAllProducts()
        {
            string msg;
            try
            {
                DBConnection conexaodb = new DBConnection();

                var sql = "SELECT * FROM products";
                conexaodb.conectar();
                var products = conexaodb.GetData(sql, "Product");
                conexaodb.desconectar();
                msg = products;
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return msg;
        }
    }
}