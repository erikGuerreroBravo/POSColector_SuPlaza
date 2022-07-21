// Decompiled with JetBrains decompiler
// Type: POSColector.DAO.compra_articuloDAO
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
  public class compra_articuloDAO : pos_colector
  {
    public order_detail insertPurchase(compra_articulo ca)
    {
      pos_colector.ExecuteSQL(string.Format("INSERT INTO compra_articulo(id_compra, cod_barras, num_articulo, cant_cja, cant_pza, precio_compra, no_captura, no_entrega) VALUES('{0}','{1}',{2},{3},{4},{5},0,0)", (object) ca.id_compra, (object) ca.item.cod_barras, (object) this.getLastNumberItem(ca.id_compra), (object) ca.getCantidadCja(), (object) ca.getCantidadPza(), (object) ca.precio_compra));
      return new order_detail()
      {
        cod_barras = ca.item.cod_barras,
        descripcion = ca.item.descripcion,
        cant_cja = ca.getCantidadCja(),
        cant_pza = ca.getCantidadPza(),
        unidad = ca.medida
      };
    }

    public order_detail insert(compra_articulo ca)
    {
      pos_colector.ExecuteSQL(string.Format("INSERT INTO compra_articulo(id_compra, cod_barras, num_articulo, cant_cja, cant_pza, precio_compra, no_captura, no_entrega) VALUES('{0}','{1}',{2},{3},{4},{5},0,0)", (object) ca.id_compra, (object) ca.item.cod_asociado, (object) this.getLastNumberItem(ca.id_compra), (object) ca.getCantidadCja(), (object) ca.getCantidadPza(), (object) ca.precio_compra));
      return new order_detail()
      {
        cod_barras = ca.item.cod_asociado,
        descripcion = ca.item.descripcion,
        cant_cja = ca.getCantidadCja(),
        cant_pza = ca.getCantidadPza(),
        unidad = ca.medida
      };
    }

    private long getLastNumberItem(Guid id_compra)
    {
      SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT CASE WHEN MAX(num_articulo) IS NULL THEN 1 ELSE (MAX(num_articulo) + 1) END num_articulo FROM compra_articulo WHERE id_compra='{0}'", (object) id_compra.ToString()));
      return ((DbDataReader) data).Read() ? long.Parse(((DbDataReader) data)["num_articulo"].ToString()) : 0L;
    }

    public void deleteLastItemPurchase(Guid id_compra) => pos_colector.ExecuteSQL(string.Format("DELETE FROM compra_articulo WHERE id_compra='{0}' AND num_articulo=(SELECT MAX(num_articulo) FROM compra_articulo WHERE id_compra='{0}')", (object) id_compra.ToString()));

    public List<order_detail> getPurchaseDetail(Guid id_compra)
    {
      List<order_detail> orderDetailList = new List<order_detail>();
      SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT ca.cod_barras,a.descripcion,ca.cant_cja,ca.cant_pza FROM compra_articulo ca INNER JOIN articulo a ON ca.cod_barras=a.cod_barras WHERE id_compra='{0}' ORDER BY ca.num_articulo", (object) id_compra));
      while (((DbDataReader) data).Read())
        orderDetailList.Add(new order_detail()
        {
          cod_barras = ((DbDataReader) data)["cod_barras"].ToString(),
          descripcion = ((DbDataReader) data)["descripcion"].ToString(),
          cant_cja = Decimal.Parse(((DbDataReader) data)["cant_cja"].ToString()),
          cant_pza = Decimal.Parse(((DbDataReader) data)["cant_pza"].ToString())
        });
      return orderDetailList.Count > 0 ? orderDetailList : (List<order_detail>) null;
    }
  }
}
