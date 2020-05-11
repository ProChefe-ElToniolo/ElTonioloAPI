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
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class IngredienteController : ApiController
    {
        pro_chefeEntities bd = new pro_chefeEntities();
        // GET: api/Ingrediente
        public IEnumerable<dynamic> Get()
        {
            var ingredientes = from ing in bd.ingrediente select new { ing.id, ing.nome };
            return ingredientes;
        }

        // GET: api/Ingrediente/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ingrediente
        public string Post([FromBody]ingrediente ing)
        {
            bd.ingrediente.Add(ing);
            bd.SaveChanges();
            return "postado com sucesso!";
        }

        // PUT: api/Ingrediente/5
        public string Put(int id, [FromBody]ingrediente ing)
        {
            ingrediente alterar = bd.ingrediente.Find(id);
            alterar.nome = ing.nome;
            bd.SaveChanges();
            return "alterado com sucesso";
        }

        // DELETE: api/Ingrediente/5
        public string Delete(int id)
        {
            bd.ingrediente.Remove(bd.ingrediente.Find(id));
            bd.SaveChanges();
            return "Deletado com sucesso!";
        }
    }
}