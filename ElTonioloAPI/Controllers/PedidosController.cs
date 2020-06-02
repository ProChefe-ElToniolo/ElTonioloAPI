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
    [EnableCors(origins: "http://localhost:8080", headers:"*", methods:"*")]
    public class PedidosController : ApiController
    {
        // GET: api/Pedidos
        public IEnumerable<dynamic> Get()
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                var pedidos = from ped in bd.pedidos select new { ped.id, ped.id_cliente, ped.id_entregador, ped.processamento };
                return pedidos.ToList();
            }
        }

        // GET: api/Pedidos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pedidos
        public string Post([FromBody]pedidos pedido)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                bd.pedidos.Add(pedido);
                bd.SaveChanges();
                return "Salvo com sucesso";
            }
        }

        // PUT: api/Pedidos/5
        public string Put(int id, [FromBody]pedidos pedido)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                pedidos alterar = bd.pedidos.Find(id);
                alterar.id_entregador = pedido.id_entregador;
                alterar.processamento = pedido.processamento;
                alterar.id_cliente = pedido.id_cliente;
                bd.SaveChanges();
                return "Alterado com sucesso";
            }
        }

        // DELETE: api/Pedidos/5
        public string Delete(int id)
        {
            using (pro_chefeEntities bd = new pro_chefeEntities())
            {
                bd.pedidos.Remove(bd.pedidos.Find(id));
                bd.SaveChanges();
                return "Deletado com sucesso";
            }
        }
    }
}
