using ElTonioloAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ElTonioloAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoriaController : ApiController
    {
        // GET: ccc
        public IEnumerable<dynamic> Get()
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                var categorias = from cat in bd.categoria select new { cat.id, cat.nome };
                return categorias.ToList();
            }
        }

        // GET: api/Categoria/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Categoria
        public string Post([FromBody]categoria cat)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                bd.categoria.Add(cat);
                bd.SaveChanges();
                return "Salvo com sucesso";
            }
        }

        // PUT: api/Categoria/5
        public string Put(int id, [FromBody]categoria cat)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                categoria alterar = bd.categoria.Find(id);
                alterar.nome = cat.nome;
                bd.SaveChanges();
                return "Alterado com sucesso";
            }
        }

        // DELETE: api/Categoria/5
        public string Delete(int id)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                bd.categoria.Remove(bd.categoria.Find(id));
                bd.SaveChanges();
                return "Deletado com sucesso";
            }
        }
    }
}
