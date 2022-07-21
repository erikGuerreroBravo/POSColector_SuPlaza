// Decompiled with JetBrains decompiler
// Type: POSColector.DAO.pedidoDAO
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using POSColector.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlServerCe;

namespace POSColector.DAO
{
  public class pedidoDAO : pos_colector
  {
    public bool existOrder(Guid id_pedido) => ((DbDataReader) pos_colector.GetData(string.Format("SELECT id_pedido FROM orden WHERE id_pedido='{0}'", (object) id_pedido.ToString()))).Read();

    public pedido getPedido(Guid id_pedido)
    {
      SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT id_pedido, num_pedido, id_proveedor FROM orden WHERE id_pedido='{0}'", (object) id_pedido.ToString()));
      pedido pedido;
      if (!((DbDataReader) data).Read())
        pedido = (pedido) null;
      else
        pedido = new pedido()
        {
          id_pedido = new Guid(((DbDataReader) data)[nameof (id_pedido)].ToString()),
          num_pedido = ((DbDataReader) data)["num_pedido"].ToString(),
          id_proveedor = new Guid(((DbDataReader) data)["id_proveedor"].ToString())
        };
      return pedido;
    }

    public List<pedido> getListPedidosAut()
    {
      List<pedido> listPedidosAut = new List<pedido>();
      listPedidosAut.Add(new pedido()
      {
        id_pedido = new Guid(),
        num_pedido = "--PEDIDOS--",
        id_proveedor = new Guid()
      });
      SqlCeDataReader data = pos_colector.GetData("SELECT id_pedido, num_pedido, p.id_proveedor, pr.razon_social FROM orden p INNER JOIN proveedor pr ON p.id_proveedor=pr.id_proveedor WHERE status_pedido='autorizado' ORDER BY num_pedido");
      while (((DbDataReader) data).Read())
        listPedidosAut.Add(new pedido()
        {
          id_pedido = new Guid(((DbDataReader) data)["id_pedido"].ToString()),
          num_pedido = ((DbDataReader) data)["num_pedido"].ToString(),
          id_proveedor = new Guid(((DbDataReader) data)["id_proveedor"].ToString()),
          razon_social = ((DbDataReader) data)["razon_social"].ToString()
        });
      return listPedidosAut;
    }

    public List<pedido> getListPedidosCap()
    {
      List<pedido> listPedidosCap = new List<pedido>();
      listPedidosCap.Add(new pedido()
      {
        id_pedido = new Guid(),
        num_pedido = "--PEDIDOS--",
        id_proveedor = new Guid()
      });
      SqlCeDataReader data = pos_colector.GetData("SELECT p.id_pedido,p.num_pedido,pr.razon_social FROM orden p INNER JOIN compra c ON p.id_pedido=c.id_pedido INNER JOIN proveedor pr ON p.id_proveedor=pr.id_proveedor GROUP BY p.id_pedido,p.num_pedido,pr.razon_social ORDER BY p.num_pedido");
      while (((DbDataReader) data).Read())
        listPedidosCap.Add(new pedido()
        {
          id_pedido = new Guid(((DbDataReader) data)["id_pedido"].ToString()),
          num_pedido = ((DbDataReader) data)["num_pedido"].ToString(),
          razon_social = ((DbDataReader) data)["razon_social"].ToString()
        });
      return listPedidosCap;
    }

    public void deleteOrder(Guid id_pedido)
    {
      List<compra> comprasPorPedido = new compraDAO().getComprasPorPedido(id_pedido);
      if (comprasPorPedido != null)
      {
        foreach (compra compra in comprasPorPedido)
        {
          pos_colector.ExecuteSQL(string.Format("DELETE FROM compra_articulo WHERE id_compra='{0}'", (object) compra.id_compra));
          pos_colector.ExecuteSQL(string.Format("DELETE FROM compra WHERE id_compra='{0}'", (object) compra.id_compra));
        }
      }
      pos_colector.ExecuteSQL(string.Format("DELETE FROM orden WHERE id_pedido='{0}'", (object) id_pedido));
    }
  }
}
