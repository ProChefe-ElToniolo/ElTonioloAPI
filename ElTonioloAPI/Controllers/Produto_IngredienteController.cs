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
    [EnableCors(origins: "http://localhost:8080", headers:"*", methods:"*")]
    public class Produto_IngredienteController : ApiController
    {
        pro_chefeEntities bd = new pro_chefeEntities();
        // GET: api/Produto_Ingrediente
        public IEnumerable<dynamic> Get()
        {
            var prodIngs = from prodIng in bd.produto_ingrediente select new { prodIng.id_produto, prodIng.id_ingrediente, prodIng.preco_saida };
            return prodIngs;
        }

        // GET: api/Produto_Ingrediente/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Produto_Ingrediente
        public string Post([FromBody]produto_ingrediente prodIng)
        {
            bd.produto_ingrediente.Add(prodIng);
            bd.SaveChanges();
            return "Salvo com sucesso";
        }

        // PUT: api/Produto_Ingrediente/5
        public string Put(int id, [FromBody]produto_ingrediente prodIng)
        {
            produto_ingrediente alterar = bd.produto_ingrediente.Find(id);
            alterar.id_produto = prodIng.id_produto;
            alterar.id_ingrediente = prodIng.id_ingrediente;
            alterar.preco_saida = prodIng.preco_saida;
            bd.SaveChanges();
            return "Alterado com sucesso";
        }

        // DELETE: api/Produto_Ingrediente/5
        public string Delete(int id)
        {
            bd.produto_ingrediente.Remove(bd.produto_ingrediente.Find(id));
            bd.SaveChanges();
            return "Deletado com sucesso";
        }
    }
}
