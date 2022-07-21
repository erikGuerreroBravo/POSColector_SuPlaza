// Decompiled with JetBrains decompiler
// Type: POSColector.DAO.articuloDAO
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using POSColector.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Linq;

namespace POSColector.DAO
{
  public class articuloDAO : pos_colector
  {
    public bool exist(string barCode) => ((DbDataReader) pos_colector.GetData(string.Format("SELECT cod_barras FROM articulo WHERE cod_barras='{0}'", (object) barCode))).Read();

    public articulo getArticulo(string find, int count)
    {
      SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT cod_barras, CASE WHEN cod_asociado IS NULL THEN cod_barras ELSE cod_asociado END cod_asociado, descripcion, id_unidad, cantidad_um, precio_compra, tipo_articulo, id_proveedor FROM articulo WHERE cod_barras='{0}' OR cod_interno='{0}'", (object) find.ToString()));
      if (((DbDataReader) data).Read())
        return new articulo()
        {
          cod_barras = ((DbDataReader) data)["cod_barras"].ToString(),
          cod_asociado = ((DbDataReader) data)["cod_asociado"].ToString(),
          descripcion = ((DbDataReader) data)["descripcion"].ToString(),
          id_unidad = new Guid(((DbDataReader) data)["id_unidad"].ToString()),
          cantidad_um = Decimal.Parse(((DbDataReader) data)["cantidad_um"].ToString()),
          precio_compra = Decimal.Parse(((DbDataReader) data)["precio_compra"].ToString()),
          tipo_articulo = ((DbDataReader) data)["tipo_articulo"].ToString(),
          id_proveedor = new Guid(((DbDataReader) data)["id_proveedor"].ToString())
        };
      return count != 0 ? this.getArticulo(string.Format("0{0}", (object) find), --count) : (articulo) null;
    }

    public List<unidad_articulo> getUnidadesAnexos(string barCode)
    {
      List<unidad_articulo> unidadesAnexos = new List<unidad_articulo>();
      SqlCeCommand selectCommand = new SqlCeCommand(string.Format("SELECT DISTINCT um.id_unidad,um.descripcion,a.cantidad_um,a.tipo_articulo\r\n  FROM articulo a JOIN unidad_medida um ON a.id_unidad=um.id_unidad \r\n  WHERE a.tipo_articulo='anexo' AND um.descripcion='Cja' AND cod_asociado='{0}' ORDER BY cantidad_um DESC", (object) barCode), pos_colector.getConnection());
      DataTable dataTable = new DataTable();
      SqlCeDataAdapter sqlCeDataAdapter = new SqlCeDataAdapter(selectCommand);
      ((DbDataAdapter) sqlCeDataAdapter).Fill(dataTable);
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        unidadesAnexos.Add(new unidad_articulo()
        {
          id_unidad = new Guid(row["id_unidad"].ToString()),
          descripcion = row["descripcion"].ToString(),
          cantidad_um = Decimal.Parse(row["cantidad_um"].ToString()),
          tipo = row["tipo_articulo"].ToString()
        });
      ((Component) sqlCeDataAdapter).Dispose();
      dataTable.Clear();
      dataTable.Dispose();
      ((Component) selectCommand).Dispose();
      GC.Collect();
      return unidadesAnexos;
    }

    public articulo getArticuloByProveedor(string barCode, Guid providerID)
    {
      SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT cod_barras, CASE WHEN cod_asociado IS NULL THEN cod_barras ELSE cod_asociado END cod_asociado, descripcion, id_unidad, cantidad_um, precio_compra, tipo_articulo, id_proveedor FROM articulo WHERE (cod_barras='{0}' OR cod_interno='{0}') AND id_proveedor='{1}'", (object) barCode, (object) providerID));
      articulo articuloByProveedor;
      if (!((DbDataReader) data).Read())
        articuloByProveedor = (articulo) null;
      else
        articuloByProveedor = new articulo()
        {
          cod_barras = ((DbDataReader) data)["cod_barras"].ToString(),
          cod_asociado = ((DbDataReader) data)["cod_asociado"].ToString(),
          descripcion = ((DbDataReader) data)["descripcion"].ToString(),
          id_unidad = new Guid(((DbDataReader) data)["id_unidad"].ToString()),
          cantidad_um = Decimal.Parse(((DbDataReader) data)["cantidad_um"].ToString()),
          precio_compra = Decimal.Parse(((DbDataReader) data)["precio_compra"].ToString()),
          tipo_articulo = ((DbDataReader) data)["tipo_articulo"].ToString(),
          id_proveedor = new Guid(((DbDataReader) data)["id_proveedor"].ToString())
        };
      return articuloByProveedor;
    }

    public articulo getArticuloPrincipal(string cod_barras)
    {
      SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT cod_barras, cod_asociado, descripcion, id_unidad, cantidad_um, precio_compra, tipo_articulo, id_proveedor FROM articulo WHERE cod_barras='{0}' AND tipo_articulo='principal'", (object) cod_barras.ToString()));
      articulo articuloPrincipal;
      if (!((DbDataReader) data).Read())
        articuloPrincipal = (articulo) null;
      else
        articuloPrincipal = new articulo()
        {
          cod_barras = ((DbDataReader) data)[nameof (cod_barras)].ToString(),
          cod_asociado = ((DbDataReader) data)["cod_asociado"].ToString(),
          descripcion = ((DbDataReader) data)["descripcion"].ToString(),
          id_unidad = new Guid(((DbDataReader) data)["id_unidad"].ToString()),
          cantidad_um = Decimal.Parse(((DbDataReader) data)["cantidad_um"].ToString()),
          precio_compra = Decimal.Parse(((DbDataReader) data)["precio_compra"].ToString()),
          tipo_articulo = ((DbDataReader) data)["tipo_articulo"].ToString(),
          id_proveedor = new Guid(((DbDataReader) data)["id_proveedor"].ToString())
        };
      return articuloPrincipal;
    }

    public articulo getArticuloAnexo(string cod_barras)
    {
      SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT cod_barras, cod_asociado, descripcion, id_unidad, cantidad_um, precio_compra, tipo_articulo, id_proveedor FROM articulo WHERE cod_asociado='{0}' AND tipo_articulo='anexo'", (object) cod_barras.ToString()));
      articulo articuloAnexo;
      if (!((DbDataReader) data).Read())
        articuloAnexo = (articulo) null;
      else
        articuloAnexo = new articulo()
        {
          cod_barras = ((DbDataReader) data)[nameof (cod_barras)].ToString(),
          cod_asociado = ((DbDataReader) data)["cod_asociado"].ToString(),
          descripcion = ((DbDataReader) data)["descripcion"].ToString(),
          id_unidad = new Guid(((DbDataReader) data)["id_unidad"].ToString()),
          cantidad_um = Decimal.Parse(((DbDataReader) data)["cantidad_um"].ToString()),
          precio_compra = Decimal.Parse(((DbDataReader) data)["precio_compra"].ToString()),
          tipo_articulo = ((DbDataReader) data)["tipo_articulo"].ToString(),
          id_proveedor = new Guid(((DbDataReader) data)["id_proveedor"].ToString())
        };
      return articuloAnexo;
    }

    public List<articulo> getListArticulos()
    {
      List<articulo> listArticulos = new List<articulo>();
      SqlCeDataReader data = pos_colector.GetData("SELECT cod_barras, cod_asociado, descripcion, id_unidad FROM articulo a");
      while (((DbDataReader) data).Read())
        listArticulos.Add(new articulo()
        {
          cod_barras = ((DbDataReader) data)["cod_barras"].ToString(),
          cod_asociado = ((DbDataReader) data)["cod_asociado"].ToString(),
          descripcion = ((DbDataReader) data)["descripcion"].ToString(),
          id_unidad = new Guid(((DbDataReader) data)["id_unidad"].ToString()),
          cantidad_um = Decimal.Parse(((DbDataReader) data)["cantidad_um"].ToString()),
          precio_compra = Decimal.Parse(((DbDataReader) data)["precio_compra"].ToString()),
          tipo_articulo = ((DbDataReader) data)["tipo_articulo"].ToString()
        });
      return listArticulos;
    }

    public List<articulo> getUnidadesByArticulo(string barCode)
    {
      List<articulo> unidadesByArticulo = new List<articulo>();
      articulo articulo = new articuloDAO().getArticulo(barCode, 1);
      unidadesByArticulo.Add(articulo);
      if (articulo.tipo_articulo.Equals("principal") || articulo.tipo_articulo.Equals("asociado"))
      {
        SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT cod_barras, cod_asociado, descripcion, id_unidad, cantidad_um, precio_compra, tipo_articulo FROM articulo WHERE cod_asociado='{0}' AND tipo_articulo='anexo'", (object) barCode.ToString()));
        if (((DbDataReader) data).Read())
          unidadesByArticulo.Add(new articulo()
          {
            cod_barras = ((DbDataReader) data)["cod_barras"].ToString(),
            cod_asociado = ((DbDataReader) data)["cod_asociado"].ToString(),
            descripcion = ((DbDataReader) data)["descripcion"].ToString(),
            id_unidad = new Guid(((DbDataReader) data)["id_unidad"].ToString()),
            cantidad_um = Decimal.Parse(((DbDataReader) data)["cantidad_um"].ToString()),
            precio_compra = Decimal.Parse(((DbDataReader) data)["precio_compra"].ToString()),
            tipo_articulo = ((DbDataReader) data)["tipo_articulo"].ToString()
          });
      }
      else if (articulo.tipo_articulo.Equals("anexo"))
      {
        SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT cod_barras, cod_asociado, descripcion, id_unidad, cantidad_um, precio_compra, tipo_articulo FROM articulo WHERE cod_barras='{0}' AND tipo_articulo='principal'", (object) barCode.ToString()));
        if (((DbDataReader) data).Read())
          unidadesByArticulo.Add(new articulo()
          {
            cod_barras = ((DbDataReader) data)["cod_barras"].ToString(),
            cod_asociado = ((DbDataReader) data)["cod_asociado"].ToString(),
            descripcion = ((DbDataReader) data)["descripcion"].ToString(),
            id_unidad = new Guid(((DbDataReader) data)["id_unidad"].ToString()),
            cantidad_um = Decimal.Parse(((DbDataReader) data)["cantidad_um"].ToString()),
            precio_compra = Decimal.Parse(((DbDataReader) data)["precio_compra"].ToString()),
            tipo_articulo = ((DbDataReader) data)["tipo_articulo"].ToString()
          });
      }
      return unidadesByArticulo;
    }

    public List<unidad_articulo> getUnidadesMedida(articulo a)
    {
      List<unidad_articulo> unidadesMedida = new List<unidad_articulo>();
      if (a.cod_barras != a.cod_asociado)
      {
        articulo articulo = new articuloDAO().getArticulo(a.cod_asociado, 1);
        unidad_medida unidadMedida = new unidad_medidaDAO().getUnidadMedida(articulo.id_unidad);
        unidadesMedida.Add(new unidad_articulo()
        {
          id_unidad = unidadMedida.id_unidad,
          descripcion = unidadMedida.descripcion,
          cantidad_um = articulo.cantidad_um,
          tipo = articulo.tipo_articulo
        });
      }
      articulo articulo1 = new articuloDAO().getArticulo(a.cod_barras, 1);
      unidad_medida unidadMedida1 = new unidad_medidaDAO().getUnidadMedida(articulo1.id_unidad);
      unidadesMedida.Add(new unidad_articulo()
      {
        id_unidad = unidadMedida1.id_unidad,
        descripcion = unidadMedida1.descripcion,
        cantidad_um = articulo1.cantidad_um,
        tipo = articulo1.tipo_articulo
      });
      Enumerable.OrderBy<unidad_articulo, string>((IEnumerable<unidad_articulo>) unidadesMedida, (Func<unidad_articulo, string>) (u => u.descripcion));
      return unidadesMedida;
    }

    public List<unidad_articulo> getUnidadesMedida(string barCode)
    {
      List<unidad_articulo> unidadesMedida = new List<unidad_articulo>();
      articulo articuloPrincipal = this.getArticuloPrincipal(barCode);
      if (articuloPrincipal == null)
        throw new Exception("Artículo no encontrado");
      unidadesMedida.AddRange((IEnumerable<unidad_articulo>) new articuloDAO().getUnidadesAnexos(articuloPrincipal.cod_barras));
      unidad_medida unidadMedida = new unidad_medidaDAO().getUnidadMedida(articuloPrincipal.id_unidad);
      unidadesMedida.Add(new unidad_articulo()
      {
        id_unidad = unidadMedida.id_unidad,
        descripcion = unidadMedida.descripcion,
        cantidad_um = articuloPrincipal.cantidad_um,
        tipo = articuloPrincipal.tipo_articulo
      });
      return unidadesMedida;
    }
  }
}
