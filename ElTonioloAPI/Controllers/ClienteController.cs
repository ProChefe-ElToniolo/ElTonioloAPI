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
    [EnableCors(origins:"htpp://localhost:8080", headers:"*", methods:"*")]
    public class ClienteController : ApiController
    {
        pro_chefeEntities bd = new pro_chefeEntities();
        // GET: api/Cliente
        public IEnumerable<dynamic> Get()
        {
            var clientes = from cli in bd.cliente select new { cli.id, cli.nome, cli.logradouro, cli.numero, cli.telefone, cli.cpf, cli.cep, cli.complemento, cli.bairro, cli.uf, cli.cidade };
            return clientes;
        }

        // GET: api/Cliente/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cliente
        public string Post([FromBody]cliente cliente)
        {
            bd.cliente.Add(cliente);
            bd.SaveChanges();
            return "Salvo com sucesso";
        }

        // PUT: api/Cliente/5
        public string Put(int id, [FromBody]cliente cliente)
        {
            cliente alterar = bd.cliente.Find(id);
            alterar.nome = cliente.nome;
            alterar.logradouro = cliente.logradouro;
            alterar.numero = cliente.numero;
            alterar.telefone = cliente.telefone;
            alterar.cpf = cliente.cpf;
            alterar.cep = cliente.cep;
            alterar.complemento = cliente.complemento;
            alterar.bairro = cliente.bairro;
            alterar.uf = cliente.uf;
            alterar.cidade = cliente.cidade;
            bd.SaveChanges();
            return "Alterado com sucesso";
        }

        // DELETE: api/Cliente/5
        public string Delete(int id)
        {
            bd.cliente.Remove(bd.cliente.Find(id));
            bd.SaveChanges();
            return "Deletado com sucesso";
        }
    }
}
