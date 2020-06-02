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
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class IngredienteController : ApiController
    {
        // GET: api/Ingrediente
        public IEnumerable<dynamic> Get()
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                var ingredientes = from ing in bd.ingrediente select new { ing.id, ing.nome, ing.estoque, ing.id_categoria, nomeCategoria = ing.categoria.nome, ing.id_medida, nomeMedida = ing.medida.nome};
                //nomeCargo = user.cargo.nome
                return ingredientes.ToList();
            }
        }

        // GET: api/Ingrediente/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ingrediente
        public string Post([FromBody]ingrediente ing)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                bd.ingrediente.Add(ing);
                bd.SaveChanges();
                return "postado com sucesso!";
            }
        }

        // PUT: api/Ingrediente/5
        public string Put(int id, [FromBody]ingrediente ing)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                ingrediente alterar = bd.ingrediente.Find(id);
                alterar.nome = ing.nome;
                alterar.id_categoria = ing.id_categoria;
                alterar.estoque = ing.estoque;
                alterar.id_medida = ing.id_medida;
                bd.SaveChanges();
                return "alterado com sucesso";
            }
        }

        // DELETE: api/Ingrediente/5
        public string Delete(int id)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                bd.ingrediente.Remove(bd.ingrediente.Find(id));
                bd.SaveChanges();
                return "Deletado com sucesso!";
            }
        }
    }
}
