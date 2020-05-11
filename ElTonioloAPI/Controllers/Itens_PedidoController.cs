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
    [EnableCors(origins: "http://localhost:8080", methods:"*", headers:"*")]
    public class Itens_PedidoController : ApiController
    {
        pro_chefeEntities bd = new pro_chefeEntities();
        // GET: api/Itens_Pedido
        public IEnumerable<dynamic> Get()
        {
            var itemPedido = from itens in bd.itens_pedido select new { itens.id_pedido, itens.id_produto, itens.quantidade };
            return itemPedido;
        }

        // GET: api/Itens_Pedido/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Itens_Pedido
        public string Post([FromBody]itens_pedido itemPedido)
        {
            bd.itens_pedido.Add(itemPedido);
            bd.SaveChanges();
            return "Salvo com sucesso";
        }

        // PUT: api/Itens_Pedido/5
        public string Put(int id, [FromBody]itens_pedido itemPedido)
        {
            itens_pedido alterar = bd.itens_pedido.Find(id);
            alterar.id_pedido = itemPedido.id_pedido;
            alterar.id_produto = itemPedido.id_produto;
            alterar.quantidade = itemPedido.quantidade;
            bd.SaveChanges();
            return "Alterado com sucesso";
        }

        // DELETE: api/Itens_Pedido/5
        public string Delete(int id)
        {
            bd.itens_pedido.Remove(bd.itens_pedido.Find(id));
            bd.SaveChanges();
            return "Deletado com sucesso";
        }
    }
}
