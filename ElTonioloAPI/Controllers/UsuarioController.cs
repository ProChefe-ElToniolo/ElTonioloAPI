using ElTonioloAPI.Models;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ElTonioloAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        //pro_chefeEntities bd = new pro_chefeEntities();
        public IEnumerable<dynamic> Get()
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                var usuarios = from user in bd.usuario select new { user.id, user.nome, user.email, user.senha, user.tipo_usuario };
                return usuarios.ToList();
            }
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        public string Post([FromBody]usuario user)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                bd.usuario.Add(user);
                bd.SaveChanges();
                return "Salvo com sucesso";
            }
        }

        // PUT: api/Usuario/5
        public string Put(int id, [FromBody]usuario user)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                usuario alterar = bd.usuario.Find(id);
                alterar.nome = user.nome;
                alterar.email = user.email;
                alterar.senha = user.senha;
                alterar.tipo_usuario = user.tipo_usuario;
                bd.SaveChanges();
                return "alterado com sucesso";
            }
        }

        // DELETE: api/Usuario/5
        public string Delete(int id)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                bd.usuario.Remove(bd.usuario.Find(id));
                bd.SaveChanges();
                return "Deletado com sucesso";
            }
        }
    }
}
