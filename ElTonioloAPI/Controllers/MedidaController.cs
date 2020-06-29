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
    public class MedidaController : ApiController
    {
        // GET: api/Medida
        public IEnumerable<dynamic> Get()
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                var medidas = from med in bd.medida select new { med.id, med.nome, med.qnt_sabores };
                //nomeCargo = user.cargo.nome
                return medidas.ToList();
            }
        }

        // GET: api/Medida/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Medida
        public string Post([FromBody]medida med)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                bd.medida.Add(med);
                bd.SaveChanges();
                return "postado com sucesso!";
            }
        }

        // PUT: api/Medida/5
        public string Put(int id, [FromBody]medida med)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                medida alterar = bd.medida.Find(id);
                alterar.nome = med.nome;
                alterar.qnt_sabores = med.qnt_sabores;
                bd.SaveChanges();
                return "alterado com sucesso";
            }
        }

        // DELETE: api/Medida/5
        public string Delete(int id)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                bd.medida.Remove(bd.medida.Find(id));
                bd.SaveChanges();
                return "Deletado com sucesso!";
            }
        }
    }
}
