// Decompiled with JetBrains decompiler
// Type: POSColector.DAO.pedido_articuloDAO
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using POSColector.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Linq;

namespace POSColector.DAO
{
  public class pedido_articuloDAO : pos_colector
  {
    public bool existOrderItem(Guid id_pedido, short no_articulo) => ((DbDataReader) pos_colector.GetData(string.Format("SELECT id_pedido, no_articulo FROM orden_articulo WHERE id_pedido='{0}' AND no_articulo={1}", (object) id_pedido.ToString(), (object) no_articulo))).Read();

    public articulo getArticuloPedido(string find, pedido orden, int count)
    {
      SqlCeDataReader data = pos_colector.GetData(string.Format("SELECT ord.cod_barras,COALESCE(ord.cod_anexo,a.cod_barras) cod_anexo,a.descripcion,a.id_unidad,a.cantidad_um,a.precio_compra,a.tipo_articulo,a.id_proveedor,COALESCE(ord.cantidad,0.000) cantidad,COALESCE(ord.por_surtir,0.000) por_surtir FROM articulo a JOIN (SELECT oa.cod_barras,oa.cod_anexo,cantidad,por_surtir FROM orden o JOIN orden_articulo oa ON o.id_pedido=oa.id_pedido AND o.id_pedido='{0}' JOIN articulo a ON (a.tipo_articulo='principal' OR a.tipo_articulo='asociado') AND (oa.cod_barras=a.cod_barras OR oa.cod_barras=a.cod_asociado) WHERE a.cod_barras='{1}' OR a.cod_interno='{1}') ord ON a.cod_barras=ord.cod_barras WHERE a.id_proveedor='{2}'", (object) orden.id_pedido, (object) find, (object) orden.id_proveedor));
      if (((DbDataReader) data).Read())
        return new articulo()
        {
          cod_barras = ((DbDataReader) data)["cod_barras"].ToString(),
          cod_asociado = ((DbDataReader) data)["cod_anexo"].ToString() ?? (string) null,
          descripcion = ((DbDataReader) data)["descripcion"].ToString(),
          id_unidad = new Guid(((DbDataReader) data)["id_unidad"].ToString()),
          cantidad_um = Decimal.Parse(((DbDataReader) data)["cantidad_um"].ToString()),
          precio_compra = Decimal.Parse(((DbDataReader) data)["precio_compra"].ToString()),
          tipo_articulo = ((DbDataReader) data)["tipo_articulo"].ToString(),
          id_proveedor = new Guid(((DbDataReader) data)["id_proveedor"].ToString()),
          cant_pedida = Decimal.Parse(((DbDataReader) data)["cantidad"].ToString()),
          por_surtir = Decimal.Parse(((DbDataReader) data)["por_surtir"].ToString())
        };
      return count != 0 ? this.getArticuloPedido(string.Format("0{0}", (object) find), orden, --count) : (articulo) null;
    }

    public List<unidad_articulo> getUnidadesMedida(articulo a)
    {
      List<unidad_articulo> unidadesMedida = new List<unidad_articulo>();
      unidadesMedida.AddRange((IEnumerable<unidad_articulo>) new articuloDAO().getUnidadesAnexos(a.cod_barras));
      articulo articulo = new articuloDAO().getArticulo(a.cod_barras, 1);
      unidad_medida unidadMedida = new unidad_medidaDAO().getUnidadMedida(articulo.id_unidad);
      unidadesMedida.Add(new unidad_articulo()
      {
        id_unidad = unidadMedida.id_unidad,
        descripcion = unidadMedida.descripcion,
        cantidad_um = articulo.cantidad_um,
        tipo = "principal"
      });
      Enumerable.OrderBy<unidad_articulo, string>((IEnumerable<unidad_articulo>) unidadesMedida, (Func<unidad_articulo, string>) (u => u.descripcion));
      return unidadesMedida;
    }
  }
}
