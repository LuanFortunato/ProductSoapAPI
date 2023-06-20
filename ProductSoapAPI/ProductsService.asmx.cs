using ProductSoapAPI.Model.DAO;
using ProductSoapAPI.Model.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProductSoapAPI
{
    /// <summary>
    /// Descrição resumida de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]

        public string PostProduct(string name, string color, int supplier_id)

        {
            string feedback;
            ProductVO product = new ProductVO();
            ProductDAO productDAO = new ProductDAO();

            product.Name = name;
            product.Color = color;
            product.SupplierId = supplier_id;

            feedback = productDAO.PostProduct(product);
            return feedback;
        }
    }
}
