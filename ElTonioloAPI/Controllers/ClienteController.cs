﻿using ElTonioloAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ElTonioloAPI.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class ClienteController : ApiController
    {
        // GET: api/Cliente
        public IEnumerable<dynamic> Get()
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                var clientes = from cli in bd.cliente select new { cli.email, cli.senha, cli.id, cli.nome, cli.logradouro, cli.numero, cli.telefone, cli.cpf, cli.cep, cli.complemento, cli.bairro, cli.uf, cli.cidade };
                return clientes.ToList();
            }
        }

        // GET: api/Cliente/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cliente
        public string Post([FromBody]cliente cliente)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                bd.cliente.Add(cliente);
                bd.SaveChanges();
                return "Salvo com sucesso";
            }
        }

        // PUT: api/Cliente/5
        public string Put(int id, [FromBody]cliente cliente)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
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
                alterar.email = cliente.email;
                alterar.senha = cliente.email;
                bd.SaveChanges();
                return "Alterado com sucesso";
            }
        }

        // DELETE: api/Cliente/5
        public string Delete(int id)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                bd.cliente.Remove(bd.cliente.Find(id));
                bd.SaveChanges();
                return "Deletado com sucesso";
            }
        }
    }
}
