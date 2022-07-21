// Decompiled with JetBrains decompiler
// Type: POSColector.DAO.proveedorDAO
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using POSColector.Entities;
using System;
using System.Data.Common;
using System.Data.SqlServerCe;

namespace POSColector.DAO
{
  public class proveedorDAO : pos_colector
  {
    public bool exist(Guid id_proveedor) => ((DbDataReader) pos_colector.GetData(string.Format("SELECT id_proveedor FROM proveedor WHERE id_proveedor='{0}'", (object) id_proveedor.ToString()))).Read();

    public proveedor getProveedor(Guid id_proveedor)
    {
      SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT id_proveedor, razon_social FROM proveedor WHERE id_proveedor='{0}'", (object) id_proveedor.ToString()));
      if (!((DbDataReader) data).Read())
        return (proveedor) null;
      return new proveedor()
      {
        id_proveedor = new Guid(((DbDataReader) data)[nameof (id_proveedor)].ToString()),
        razon_social = ((DbDataReader) data)["razon_social"].ToString()
      };
    }

    public void deleteOrderTrash()
    {
    }
  }
}
