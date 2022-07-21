// Decompiled with JetBrains decompiler
// Type: POSColector.DAO.inventarioDAO
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
  public class inventarioDAO : pos_colector
  {
    public bool existInventario(Guid id_inventario) => ((DbDataReader) pos_colector.GetData(string.Format("SELECT id_inventario_fisico FROM inventario_fisico WHERE id_inventario_fisico='{0}'", (object) id_inventario.ToString()))).Read();

    public inventario_articulo insert(inventario_articulo ia)
    {
      pos_colector.ExecuteSQL(string.Format("INSERT INTO inventario_captura(id_inventario_fisico,num_captura,cod_barras,fecha_captura,cant_cja,cant_pza) VALUES('{0}',{1},'{2}',GETDATE(),{3},{4})", (object) ia.id_inventario, (object) this.getLastItemNumber(ia.id_inventario), (object) ia.item.cod_asociado, (object) ia.getCantidadCja(), (object) ia.getCantidadPza()));
      return new inventario_articulo()
      {
        cod_barras = ia.item.cod_asociado,
        descripcion = ia.item.descripcion,
        cant_cja = ia.medida.tipo.Equals("anexo") ? ia.cantidad : 0M,
        cant_pza = ia.medida.tipo.Equals("principal") ? ia.cantidad : ia.medida.cantidad_um * ia.cantidad,
        medida = ia.medida
      };
    }

    public long getLastItemNumber(Guid InventoryID)
    {
      SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT CASE WHEN MAX(num_captura) IS NULL THEN 1 ELSE (MAX(num_captura) + 1) END num_captura FROM inventario_captura WHERE id_inventario_fisico='{0}'", (object) InventoryID));
      return ((DbDataReader) data).Read() ? long.Parse(((DbDataReader) data)["num_captura"].ToString()) : 0L;
    }

    public List<inventario> getInventories()
    {
      List<inventario> inventarioList = new List<inventario>();
      inventarioList.Add(new inventario()
      {
        id_inventario = new Guid(),
        razon_social = "--INVENTARIOS--"
      });
      SqlCeDataReader data = pos_colector.GetData("SELECT fi.id_inventario_fisico, fi.id_proveedor, fi.[user_name], p.razon_social FROM inventario_fisico fi INNER JOIN proveedor p ON fi.id_proveedor=p.id_proveedor");
      while (((DbDataReader) data).Read())
        inventarioList.Add(new inventario()
        {
          id_inventario = new Guid(((DbDataReader) data)["id_inventario_fisico"].ToString()),
          id_proveedor = new Guid(((DbDataReader) data)["id_proveedor"].ToString()),
          razon_social = ((DbDataReader) data)["razon_social"].ToString()
        });
      return inventarioList.Count > 0 ? inventarioList : (List<inventario>) null;
    }

    public List<inventario_articulo> getInventoryDetail(Guid id_inventario)
    {
      SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT i.cod_barras,a.descripcion,i.cant_cja,i.cant_pza FROM inventario_captura i INNER JOIN articulo a ON i.cod_barras=a.cod_barras WHERE i.id_inventario_fisico='{0}' ORDER BY i.num_captura", (object) id_inventario));
      List<inventario_articulo> inventarioArticuloList = new List<inventario_articulo>();
      while (((DbDataReader) data).Read())
        inventarioArticuloList.Add(new inventario_articulo()
        {
          cod_barras = ((DbDataReader) data)["cod_barras"].ToString(),
          descripcion = ((DbDataReader) data)["descripcion"].ToString(),
          cant_cja = Decimal.Parse(((DbDataReader) data)["cant_cja"].ToString()),
          cant_pza = Decimal.Parse(((DbDataReader) data)["cant_pza"].ToString())
        });
      return inventarioArticuloList.Count > 0 ? inventarioArticuloList : (List<inventario_articulo>) null;
    }

    public void deleteInventory(Guid id_inventario)
    {
      pos_colector.ExecuteSQL(string.Format("DELETE FROM inventario_captura WHERE id_inventario_fisico='{0}'", (object) id_inventario));
      pos_colector.ExecuteSQL(string.Format("DELETE FROM inventario_fisico WHERE id_inventario_fisico='{0}'", (object) id_inventario));
    }
  }
}
