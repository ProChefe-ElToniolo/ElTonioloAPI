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
    public class UsuarioController : ApiController
    {
        pro_chefeEntities bd = new pro_chefeEntities();
        // GET: api/Usuario
        public IEnumerable<dynamic> Get()
        {
            var usuarios = from user in bd.usuario select new { user.id, user.nome, user.email, user.senha, user.tipo_usuario };
            return usuarios;
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        public string Post([FromBody]usuario user)
        {
            bd.usuario.Add(user);
            bd.SaveChanges();
            return "Salvo com sucesso";
        }

        // PUT: api/Usuario/5
        public string Put(int id, [FromBody]usuario user)
        {
            usuario alterar = bd.usuario.Find(id);
            alterar.nome = user.nome;
            alterar.email = user.email;
            alterar.senha = user.senha;
            alterar.tipo_usuario = user.tipo_usuario;
            bd.SaveChanges();
            return "alterado com sucesso";
        }

        // DELETE: api/Usuario/5
        public string Delete(int id)
        {
            bd.usuario.Remove(bd.usuario.Find(id));
            bd.SaveChanges();
            return "Deletado com sucesso";
        }
    }
}
