// Decompiled with JetBrains decompiler
// Type: POSColector.DAO.compraDAO
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
  public class compraDAO : pos_colector
  {
    public void insert(compraDAO.Purchase p, compra c)
    {
      string sqlCommand = "";
      switch (p)
      {
        case compraDAO.Purchase.ByOrder:
          sqlCommand = string.Format("INSERT INTO compra(id_compra,id_proveedor,fecha_compra,id_pedido,cancelada,no_entrada) VALUES('{0}','{1}',GETDATE(),'{2}',0,0)", (object) c.id_compra, (object) c.id_proveedor, (object) c.id_pedido);
          break;
        case compraDAO.Purchase.Free:
          sqlCommand = string.Format("INSERT INTO compra(id_compra,fecha_compra,cancelada,no_entrada) VALUES('{0}',GETDATE(),0,0)", (object) c.id_compra);
          break;
      }
      pos_colector.ExecuteSQL(sqlCommand);
    }

    public List<compra> getListComprasCap(Guid id_pedido)
    {
      List<compra> compraList = new List<compra>();
      compraList.Add(new compra()
      {
        id_compra = new Guid(),
        num_compra = "--CAPTURAS--"
      });
      SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT c.id_compra FROM compra c WHERE c.id_pedido='{0}' ORDER BY c.fecha_compra", (object) id_pedido));
      int num = 1;
      while (((DbDataReader) data).Read())
        compraList.Add(new compra()
        {
          id_compra = new Guid(((DbDataReader) data)["id_compra"].ToString()),
          num_compra = num++.ToString()
        });
      return compraList.Count > 1 ? compraList : (List<compra>) null;
    }

    public List<compra> getComprasPorPedido(Guid id_pedido)
    {
      List<compra> compraList = new List<compra>();
      SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT c.id_compra FROM compra c WHERE c.id_pedido='{0}' ORDER BY c.fecha_compra", (object) id_pedido));
      int num = 1;
      while (((DbDataReader) data).Read())
        compraList.Add(new compra()
        {
          id_compra = new Guid(((DbDataReader) data)["id_compra"].ToString()),
          num_compra = num++.ToString()
        });
      return compraList.Count > 0 ? compraList : (List<compra>) null;
    }

    public List<compra> getComprasAbiertasCap()
    {
      List<compra> compraList = new List<compra>();
      compraList.Add(new compra()
      {
        id_compra = new Guid(),
        num_compra = "--CAPTURAS--"
      });
      SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT c.id_compra FROM compra c WHERE c.id_pedido IS NULL ORDER BY c.fecha_compra"));
      int num = 1;
      while (((DbDataReader) data).Read())
        compraList.Add(new compra()
        {
          id_compra = new Guid(((DbDataReader) data)["id_compra"].ToString()),
          num_compra = num++.ToString()
        });
      return compraList.Count > 1 ? compraList : (List<compra>) null;
    }

    public void deletePurchase(Guid id_compra)
    {
      pos_colector.ExecuteSQL(string.Format("DELETE FROM compra_articulo WHERE id_compra='{0}'", (object) id_compra));
      pos_colector.ExecuteSQL(string.Format("DELETE FROM compra WHERE id_compra='{0}'", (object) id_compra));
    }

    public enum Purchase
    {
      ByOrder,
      Free,
    }
  }
}
