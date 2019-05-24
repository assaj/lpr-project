using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1h.Models;
using _1h.ViewModels;

using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace _1h.Controllers
{
    public class MoviesController : BaseController
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "NomeFilme!"};

            var custumers = new List<custumer>
            {
                new custumer{ Name = "custumer 1"},
                new custumer{ Name = "custumer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                custumers = custumers
            };
            return View(viewModel);
        }

        public JsonResult GravarJson(string nome)
        {

            //private SqlConnection conexao;
            JsonResult json = new JsonResult();
            var custumer = new custumer { Name = nome };
            json.Data = custumer;
            return json;
        }

        public ActionResult Buscar() 
        {
            try
            {
                var conexao = new Conexao();
                const string cmd = "SELECT CPF FROM usuarios";

                //var parameters = new List<MySqlParameter>();
                // var p = new MySqlParameter("@UFID", MySqlDbType.Int64) { Value = ufId }; parametros
                // parameters.Add(p);
                var ans =(List<usuario>)conexao.ExecutarConsulta<usuario>(cmd, null);
                var s = ans;
                return LargeJson(ans);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}