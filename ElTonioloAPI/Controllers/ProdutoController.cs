using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ElTonioloAPI.Models;

namespace ElTonioloAPI.Controllers
{
    [EnableCors(origins: "*", headers:"*", methods:"*")]
    public class ProdutoController : ApiController
    {
        // GET: api/Produto
        public IEnumerable<dynamic> Get()
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                var produtos = from prod in bd.produto select new { prod.id, prod.nome, prod.preco, prod.medida, prod.id_categoria, prod.imagem };
                return produtos.ToList();
            }
        }

        // GET: api/Produto/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Produto
        public string Post([FromBody]produto prod)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                bd.produto.Add(prod);
                bd.SaveChanges();
                return "postado com sucesso!";
            }
        }

        // PUT: api/Produto/5
        public string Put(int id, [FromBody]produto prod)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                produto alterar = bd.produto.Find(id);
                alterar.nome = prod.nome;
                alterar.descricao = prod.descricao;
                alterar.preco = prod.preco;
                alterar.id_categoria = prod.id_categoria;
                alterar.imagem = prod.imagem;
                bd.SaveChanges();
                return "alterado com sucesso";
            }
        }

        // DELETE: api/Produto/5
        public string Delete(int id)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                bd.produto.Remove(bd.produto.Find(id));
                bd.SaveChanges();
                return "Deletado com sucesso!";
            }
        }
    }
}
