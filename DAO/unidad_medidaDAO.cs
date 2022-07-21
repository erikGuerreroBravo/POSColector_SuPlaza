// Decompiled with JetBrains decompiler
// Type: POSColector.DAO.unidad_medidaDAO
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using POSColector.Entities;
using System;
using System.Data.Common;
using System.Data.SqlServerCe;

namespace POSColector.DAO
{
  public class unidad_medidaDAO : pos_colector
  {
    public bool exist(Guid id_unidad) => ((DbDataReader) pos_colector.GetData(string.Format("SELECT id_unidad, descripcion FROM unidad_medida WHERE id_unidad='{0}'", (object) id_unidad.ToString()))).Read();

    public unidad_medida getUnidadMedida(Guid id_unidad)
    {
      SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT id_unidad, descripcion FROM unidad_medida WHERE id_unidad='{0}'", (object) id_unidad.ToString()));
      if (!((DbDataReader) data).Read())
        return (unidad_medida) null;
      return new unidad_medida()
      {
        id_unidad = new Guid(((DbDataReader) data)[nameof (id_unidad)].ToString()),
        descripcion = ((DbDataReader) data)["descripcion"].ToString()
      };
    }

    public unidad_medida getUnidadMedida(string barCode)
    {
      SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT a.id_unidad, um.descripcion FROM articulo a INNER JOIN unidad_medida um ON a.id_unidad=um.id_unidad WHERE a.cod_barras='{0}'", (object) barCode));
      if (!((DbDataReader) data).Read())
        return (unidad_medida) null;
      return new unidad_medida()
      {
        id_unidad = new Guid(((DbDataReader) data)["id_unidad"].ToString()),
        descripcion = ((DbDataReader) data)["descripcion"].ToString()
      };
    }
  }
}
