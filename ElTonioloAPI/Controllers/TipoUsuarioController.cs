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
    [EnableCors(origins:"http://localhost:8080", headers:"*", methods:"*")]
    public class TipoUsuarioController : ApiController
    {
        // GET: api/TipoUsuario
        public IEnumerable<dynamic> Get()
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                var tipoUsuario = from tpUser in bd.tipo_usuario select new { tpUser.id, tpUser.nome };
                return tipoUsuario.ToList(); 
            }
        }

        // GET: api/TipoUsuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TipoUsuario
        public string Post([FromBody]tipo_usuario tpUser)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                bd.tipo_usuario.Add(tpUser);
                bd.SaveChanges();
                return "salvo com sucesso";
            }
        }

        // PUT: api/TipoUsuario/5
        public string Put(int id, [FromBody]tipo_usuario tpUser)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                tipo_usuario alterar = bd.tipo_usuario.Find(id);
                alterar.nome = tpUser.nome;
                bd.SaveChanges();
                return "Alterado com sucesso";
            }
        }

        // DELETE: api/TipoUsuario/5
        public string Delete(int id)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                tipo_usuario remover = bd.tipo_usuario.Find(id);
                bd.tipo_usuario.Remove(remover);
                bd.SaveChanges();
                return "Deletado com sucesso";
            }
        }
    }
}
