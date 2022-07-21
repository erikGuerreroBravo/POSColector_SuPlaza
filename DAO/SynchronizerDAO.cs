// Decompiled with JetBrains decompiler
// Type: POSColector.DAO.SynchronizerDAO
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using POSColector.suplazaserver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.Linq;

namespace POSColector.DAO
{
  public class SynchronizerDAO : pos_colector
  {
    private string dateInitial = "01/05/2017 07:00:00";

    public static int count { set; get; }

    public void syncProveedores()
    {
      SynchronizerDAO.count = 0;
      List<proveedor> list = Enumerable.ToList<proveedor>((IEnumerable<proveedor>) new SyncCatalogos().getProveedores(this.getLastChangeDateTimeProvider()));
      if (list.Count > 0)
      {
        SynchronizerDAO.count += list.Count;
        foreach (proveedor proveedor in list)
        {
          SqlCeCommand sqlCeCommand = new SqlCeCommand(new proveedorDAO().exist(new Guid(proveedor.id_proveedor)) ? "UPDATE proveedor SET rfc=@rfc,razon_social=@razon_social,fecha_registro=@fecha_registro,estatus=@estatus WHERE id_proveedor=@id_proveedor" : "INSERT INTO proveedor(id_proveedor,rfc,razon_social,fecha_registro,estatus) VALUES(@id_proveedor,@rfc,@razon_social,@fecha_registro,@estatus)", pos_colector.getConnection());
          ((DbParameter) sqlCeCommand.Parameters.Add("@id_proveedor", SqlDbType.UniqueIdentifier)).Value = (object) proveedor.id_proveedor;
          ((DbParameter) sqlCeCommand.Parameters.Add("@rfc", SqlDbType.NVarChar)).Value = (object) proveedor.rfc;
          ((DbParameter) sqlCeCommand.Parameters.Add("@razon_social", SqlDbType.NVarChar)).Value = (object) proveedor.razon_social;
          ((DbParameter) sqlCeCommand.Parameters.Add("@estatus", SqlDbType.NVarChar)).Value = (object) proveedor.estatus;
          ((DbParameter) sqlCeCommand.Parameters.Add("@fecha_registro", SqlDbType.DateTime)).Value = (object) proveedor.last_change_datetime;
          ((DbCommand) sqlCeCommand).CommandType = CommandType.Text;
          ((DbCommand) sqlCeCommand).ExecuteNonQuery();
          ((Component) sqlCeCommand).Dispose();
          GC.Collect();
        }
      }
      list.Clear();
      GC.Collect();
    }

    public void syncArticulos()
    {
      List<articulo> list = Enumerable.ToList<articulo>((IEnumerable<articulo>) new SyncCatalogos().getArticulos(this.getLastChangeDateTimeItems()));
      if (list.Count > 0)
      {
        SynchronizerDAO.count += list.Count;
        foreach (articulo articulo in list)
        {
          SqlCeCommand sqlCeCommand = new SqlCeCommand(new articuloDAO().exist(articulo.cod_barras) ? "UPDATE articulo SET cod_asociado=@cod_asociado,id_clasificacion=@id_clasificacion,cod_interno=@cod_interno,descripcion=@descripcion,descripcion_corta=@descripcion_corta,cantidad_um=@cantidad_um,id_unidad=@id_unidad,id_proveedor=@id_proveedor,precio_compra=@precio_compra,utilidad=@utilidad,precio_venta=@precio_venta,tipo_articulo=@tipo_articulo,iva=@iva,articulo_disponible=@articulo_disponible,fecha_registro=@fecha_registro,visible=@visible,last_update_inventory=@last_update_inventory WHERE cod_barras=@cod_barras" : "INSERT INTO articulo(cod_barras,cod_asociado,id_clasificacion,cod_interno,descripcion,descripcion_corta,cantidad_um,id_unidad,id_proveedor,precio_compra,utilidad,precio_venta,tipo_articulo,iva,articulo_disponible,fecha_registro,visible,last_update_inventory,stock,stock_min,stock_max,kit,puntos,cve_producto) \r\nVALUES(@cod_barras,@cod_asociado,@id_clasificacion,@cod_interno,@descripcion,@descripcion_corta,@cantidad_um,@id_unidad,@id_proveedor,@precio_compra,@utilidad,@precio_venta,@tipo_articulo,@iva,@articulo_disponible,@fecha_registro,@visible,@last_update_inventory,0,0,0,0,0,'0')", pos_colector.getConnection());
          ((DbParameter) sqlCeCommand.Parameters.Add("@cod_barras", SqlDbType.NVarChar)).Value = (object) articulo.cod_barras;
          ((DbParameter) sqlCeCommand.Parameters.Add("@cod_asociado", SqlDbType.NVarChar)).Value = (object) articulo.cod_asociado ?? (object) DBNull.Value;
          ((DbParameter) sqlCeCommand.Parameters.Add("@id_clasificacion", SqlDbType.BigInt)).Value = (object) articulo.id_clasificacion;
          ((DbParameter) sqlCeCommand.Parameters.Add("@cod_interno", SqlDbType.NVarChar)).Value = (object) articulo.cod_interno ?? (object) DBNull.Value;
          ((DbParameter) sqlCeCommand.Parameters.Add("@descripcion", SqlDbType.NVarChar)).Value = (object) articulo.descripcion;
          ((DbParameter) sqlCeCommand.Parameters.Add("@descripcion_corta", SqlDbType.NVarChar)).Value = (object) articulo.descripcion_corta;
          ((DbParameter) sqlCeCommand.Parameters.Add("@cantidad_um", SqlDbType.Decimal)).Value = (object) articulo.cantidad_um;
          ((DbParameter) sqlCeCommand.Parameters.Add("@id_unidad", SqlDbType.UniqueIdentifier)).Value = (object) articulo.id_unidad;
          ((DbParameter) sqlCeCommand.Parameters.Add("@id_proveedor", SqlDbType.UniqueIdentifier)).Value = (object) articulo.id_proveedor;
          ((DbParameter) sqlCeCommand.Parameters.Add("@precio_compra", SqlDbType.Decimal)).Value = (object) articulo.precio_compra;
          ((DbParameter) sqlCeCommand.Parameters.Add("@utilidad", SqlDbType.Decimal)).Value = (object) articulo.utilidad;
          ((DbParameter) sqlCeCommand.Parameters.Add("@precio_venta", SqlDbType.Decimal)).Value = (object) articulo.precio_venta;
          ((DbParameter) sqlCeCommand.Parameters.Add("@tipo_articulo", SqlDbType.NVarChar)).Value = (object) articulo.tipo_articulo;
          ((DbParameter) sqlCeCommand.Parameters.Add("@iva", SqlDbType.Decimal)).Value = (object) articulo.iva;
          ((DbParameter) sqlCeCommand.Parameters.Add("@articulo_disponible", SqlDbType.Bit)).Value = (object) articulo.articulo_disponible;
          ((DbParameter) sqlCeCommand.Parameters.Add("@fecha_registro", SqlDbType.DateTime)).Value = (object) articulo.fecha_registro;
          ((DbParameter) sqlCeCommand.Parameters.Add("@visible", SqlDbType.Bit)).Value = (object) articulo.visible;
          ((DbParameter) sqlCeCommand.Parameters.Add("@last_update_inventory", SqlDbType.DateTime)).Value = (object) articulo.last_update_inventory;
          ((DbCommand) sqlCeCommand).CommandType = CommandType.Text;
          ((DbCommand) sqlCeCommand).ExecuteNonQuery();
          ((Component) sqlCeCommand).Dispose();
          GC.Collect();
        }
      }
      list.Clear();
      GC.Collect();
    }

    public void syncUnidades()
    {
      List<unidad_medida> list = Enumerable.ToList<unidad_medida>((IEnumerable<unidad_medida>) new SyncCatalogos().getUnidades(this.getLastChangeDateTimeUnits()));
      if (list.Count > 0)
      {
        SynchronizerDAO.count += list.Count;
        foreach (unidad_medida unidadMedida in list)
        {
          SqlCeCommand sqlCeCommand = new SqlCeCommand(new unidad_medidaDAO().exist(new Guid(unidadMedida.id_unidad)) ? "UPDATE unidad_medida SET descripcion=@descripcion,fecha_registro=@fecha_registro WHERE id_unidad=@id_unidad" : "INSERT INTO unidad_medida(id_unidad,descripcion,fecha_registro) VALUES(@id_unidad,@descripcion,@fecha_registro)", pos_colector.getConnection());
          ((DbParameter) sqlCeCommand.Parameters.Add("@id_unidad", SqlDbType.UniqueIdentifier)).Value = (object) unidadMedida.id_unidad;
          ((DbParameter) sqlCeCommand.Parameters.Add("@descripcion", SqlDbType.NVarChar)).Value = (object) unidadMedida.descripcion;
          ((DbParameter) sqlCeCommand.Parameters.Add("@fecha_registro", SqlDbType.DateTime)).Value = (object) unidadMedida.fecha_registro;
          ((DbCommand) sqlCeCommand).CommandType = CommandType.Text;
          ((DbCommand) sqlCeCommand).ExecuteNonQuery();
          ((Component) sqlCeCommand).Dispose();
          GC.Collect();
        }
      }
      list.Clear();
      GC.Collect();
    }

    public void syncUsuarios()
    {
      List<usuario> list = Enumerable.ToList<usuario>((IEnumerable<usuario>) new SyncCatalogos().getUsuarios(this.getLastChangeDateTimeUsers()));
      if (list.Count > 0)
      {
        SynchronizerDAO.count += list.Count;
        foreach (usuario usuario in list)
        {
          SqlCeCommand sqlCeCommand = new SqlCeCommand(new usuarioDAO().existUser(usuario.user_name) ? "UPDATE usuario SET password=@password, tipo_usuario=@tipo_usuario, enable=@enable, fecha_registro=@fecha_registro WHERE user_name=@user_name" : "INSERT INTO usuario(user_name,password,tipo_usuario,enable,fecha_registro) VALUES(@user_name,@password,@tipo_usuario,@enable,@fecha_registro)", pos_colector.getConnection());
          ((DbParameter) sqlCeCommand.Parameters.Add("@user_name", SqlDbType.NVarChar)).Value = (object) usuario.user_name;
          ((DbParameter) sqlCeCommand.Parameters.Add("@password", SqlDbType.NVarChar)).Value = (object) usuario.password;
          ((DbParameter) sqlCeCommand.Parameters.Add("@tipo_usuario", SqlDbType.NVarChar)).Value = (object) usuario.tipo_usuario;
          ((DbParameter) sqlCeCommand.Parameters.Add("@enable", SqlDbType.Bit)).Value = (object) usuario.enable;
          ((DbParameter) sqlCeCommand.Parameters.Add("@fecha_registro", SqlDbType.DateTime)).Value = (object) usuario.fecha_registro;
          ((DbCommand) sqlCeCommand).CommandType = CommandType.Text;
          ((DbCommand) sqlCeCommand).ExecuteNonQuery();
          ((Component) sqlCeCommand).Dispose();
          GC.Collect();
        }
      }
      list.Clear();
      GC.Collect();
    }

    public void syncPermisosUsuarios()
    {
      List<usuario_permiso> list = Enumerable.ToList<usuario_permiso>((IEnumerable<usuario_permiso>) new SyncCatalogos().getPermisosUsuarios(this.getLastChangeDateTimeUsuarioPermiso()));
      if (list.Count > 0)
      {
        SynchronizerDAO.count += list.Count;
        foreach (usuario_permiso usuarioPermiso in list)
        {
          SqlCeCommand sqlCeCommand = new SqlCeCommand(new usuarioDAO().existPermision(usuarioPermiso.user_name, usuarioPermiso.id_permiso) ? "UPDATE usuario_permiso SET valor_num=@valor_num,fecha_registro=@fecha_registro WHERE user_name=@user_name AND id_permiso=@id_permiso" : "INSERT INTO usuario_permiso(user_name,id_permiso,valor_num,fecha_registro) VALUES(@user_name,@id_permiso,@valor_num,@fecha_registro)", pos_colector.getConnection());
          ((DbParameter) sqlCeCommand.Parameters.Add("@user_name", SqlDbType.NVarChar)).Value = (object) usuarioPermiso.user_name;
          ((DbParameter) sqlCeCommand.Parameters.Add("@id_permiso", SqlDbType.NVarChar)).Value = (object) usuarioPermiso.id_permiso;
          ((DbParameter) sqlCeCommand.Parameters.Add("@valor_num", SqlDbType.Decimal)).Value = (object) usuarioPermiso.valor_num ?? (object) DBNull.Value;
          ((DbParameter) sqlCeCommand.Parameters.Add("@fecha_registro", SqlDbType.DateTime)).Value = (object) usuarioPermiso.fecha_registro;
          ((DbCommand) sqlCeCommand).CommandType = CommandType.Text;
          ((DbCommand) sqlCeCommand).ExecuteNonQuery();
          ((Component) sqlCeCommand).Dispose();
          GC.Collect();
        }
      }
      list.Clear();
      GC.Collect();
    }

    public void syncPedidosDiferecia()
    {
      List<pedido_articulo> list = Enumerable.ToList<pedido_articulo>((IEnumerable<pedido_articulo>) new SyncCatalogos().GetOrderDetailUpdate(this.getLastChangeDateTimeOrdersDetail()));
      if (list.Count > 0)
      {
        SynchronizerDAO.count += list.Count;
        foreach (pedido_articulo pedidoArticulo in list)
        {
          if (new pedido_articuloDAO().existOrderItem(new Guid(pedidoArticulo.id_pedido), pedidoArticulo.no_articulo))
          {
            SqlCeCommand sqlCeCommand = new SqlCeCommand("UPDATE orden_articulo SET cod_barras=@cod_barras,cod_anexo=@cod_anexo,cantidad=@cantidad,precio_articulo=@precio_articulo,por_surtir=@por_surtir,por_surtir_pzas=@por_surtir_pzas,fecha_registro=@fecha_registro WHERE id_pedido=@id_pedido AND no_articulo=@no_articulo", pos_colector.getConnection());
            ((DbParameter) sqlCeCommand.Parameters.Add("@id_pedido", SqlDbType.UniqueIdentifier)).Value = (object) pedidoArticulo.id_pedido;
            ((DbParameter) sqlCeCommand.Parameters.Add("@no_articulo", SqlDbType.SmallInt)).Value = (object) pedidoArticulo.no_articulo;
            ((DbParameter) sqlCeCommand.Parameters.Add("@cod_barras", SqlDbType.NVarChar)).Value = (object) pedidoArticulo.cod_barras;
            ((DbParameter) sqlCeCommand.Parameters.Add("@cod_anexo", SqlDbType.NVarChar)).Value = (object) pedidoArticulo.cod_anexo;
            ((DbParameter) sqlCeCommand.Parameters.Add("@cantidad", SqlDbType.Decimal)).Value = (object) pedidoArticulo.cantidad;
            ((DbParameter) sqlCeCommand.Parameters.Add("@precio_articulo", SqlDbType.Decimal)).Value = (object) pedidoArticulo.precio_articulo;
            ((DbParameter) sqlCeCommand.Parameters.Add("@por_surtir", SqlDbType.Decimal)).Value = (object) pedidoArticulo.por_surtir;
            ((DbParameter) sqlCeCommand.Parameters.Add("@por_surtir_pzas", SqlDbType.Decimal)).Value = (object) pedidoArticulo.por_surtir_pzas;
            ((DbParameter) sqlCeCommand.Parameters.Add("@fecha_registro", SqlDbType.DateTime)).Value = (object) pedidoArticulo.fecha_registro;
            ((DbCommand) sqlCeCommand).CommandType = CommandType.Text;
            ((DbCommand) sqlCeCommand).ExecuteNonQuery();
            ((Component) sqlCeCommand).Dispose();
            GC.Collect();
          }
        }
      }
      list.Clear();
      GC.Collect();
    }

    public void syncPedidos(string date)
    {
      SynchronizerDAO.count = 0;
      this.syncPedidosDiferecia();
      List<pedido> list1 = Enumerable.ToList<pedido>((IEnumerable<pedido>) new SyncCatalogos().GetOrders(date));
      if (list1.Count > 0)
      {
        SynchronizerDAO.count = list1.Count;
        foreach (pedido pedido in list1)
        {
          SqlCeCommand sqlCeCommand1 = new SqlCeCommand(new pedidoDAO().existOrder(new Guid(pedido.id_pedido)) ? "UPDATE orden SET num_pedido=@num_pedido, fecha_pedido=@fecha_pedido, id_proveedor=@id_proveedor, status_pedido=@status_pedido, fecha_registro=@fecha_registro WHERE id_pedido=@id_pedido" : "INSERT INTO orden(id_pedido,num_pedido,fecha_pedido,id_proveedor,status_pedido,fecha_registro) VALUES(@id_pedido,@num_pedido,@fecha_pedido,@id_proveedor,@status_pedido,@fecha_registro)", pos_colector.getConnection());
          ((DbParameter) sqlCeCommand1.Parameters.Add("@id_pedido", SqlDbType.UniqueIdentifier)).Value = (object) pedido.id_pedido;
          ((DbParameter) sqlCeCommand1.Parameters.Add("@num_pedido", SqlDbType.BigInt)).Value = (object) pedido.num_pedido;
          ((DbParameter) sqlCeCommand1.Parameters.Add("@fecha_pedido", SqlDbType.DateTime)).Value = (object) pedido.fecha_pedido;
          ((DbParameter) sqlCeCommand1.Parameters.Add("@id_proveedor", SqlDbType.UniqueIdentifier)).Value = (object) pedido.id_proveedor;
          ((DbParameter) sqlCeCommand1.Parameters.Add("@status_pedido", SqlDbType.NVarChar)).Value = (object) pedido.status_pedido;
          ((DbParameter) sqlCeCommand1.Parameters.Add("@fecha_registro", SqlDbType.DateTime)).Value = (object) pedido.fecha_registro;
          ((DbCommand) sqlCeCommand1).CommandType = CommandType.Text;
          ((DbCommand) sqlCeCommand1).ExecuteNonQuery();
          ((Component) sqlCeCommand1).Dispose();
          SqlCeCommand sqlCeCommand2 = (SqlCeCommand) null;
          List<pedido_articulo> list2 = Enumerable.ToList<pedido_articulo>((IEnumerable<pedido_articulo>) new SyncCatalogos().GetOrderDetail(pedido.id_pedido));
          foreach (pedido_articulo pedidoArticulo in list2)
          {
            SqlCeCommand sqlCeCommand3 = new SqlCeCommand(new pedido_articuloDAO().existOrderItem(new Guid(pedidoArticulo.id_pedido), pedidoArticulo.no_articulo) ? "UPDATE orden_articulo SET cod_barras=@cod_barras,cod_anexo=@cod_anexo,cantidad=@cantidad,precio_articulo=@precio_articulo,por_surtir=@por_surtir,por_surtir_pzas=@por_surtir_pzas,fecha_registro=@fecha_registro WHERE id_pedido=@id_pedido AND no_articulo=@no_articulo" : "INSERT INTO orden_articulo(id_pedido,no_articulo,cod_barras,cod_anexo,cantidad,precio_articulo,por_surtir,por_surtir_pzas,fecha_registro) VALUES(@id_pedido,@no_articulo,@cod_barras,@cod_anexo,@cantidad,@precio_articulo,@por_surtir,@por_surtir_pzas,@fecha_registro)", pos_colector.getConnection());
            ((DbParameter) sqlCeCommand3.Parameters.Add("@id_pedido", SqlDbType.UniqueIdentifier)).Value = (object) pedidoArticulo.id_pedido;
            ((DbParameter) sqlCeCommand3.Parameters.Add("@no_articulo", SqlDbType.SmallInt)).Value = (object) pedidoArticulo.no_articulo;
            ((DbParameter) sqlCeCommand3.Parameters.Add("@cod_barras", SqlDbType.NVarChar)).Value = (object) pedidoArticulo.cod_barras;
            ((DbParameter) sqlCeCommand3.Parameters.Add("@cod_anexo", SqlDbType.NVarChar)).Value = (object) pedidoArticulo.cod_anexo;
            ((DbParameter) sqlCeCommand3.Parameters.Add("@cantidad", SqlDbType.Decimal)).Value = (object) pedidoArticulo.cantidad;
            ((DbParameter) sqlCeCommand3.Parameters.Add("@precio_articulo", SqlDbType.Decimal)).Value = (object) pedidoArticulo.precio_articulo;
            ((DbParameter) sqlCeCommand3.Parameters.Add("@por_surtir", SqlDbType.Decimal)).Value = (object) pedidoArticulo.por_surtir;
            ((DbParameter) sqlCeCommand3.Parameters.Add("@por_surtir_pzas", SqlDbType.Decimal)).Value = (object) pedidoArticulo.por_surtir_pzas;
            ((DbParameter) sqlCeCommand3.Parameters.Add("@fecha_registro", SqlDbType.DateTime)).Value = (object) pedidoArticulo.fecha_registro;
            ((DbCommand) sqlCeCommand3).CommandType = CommandType.Text;
            ((DbCommand) sqlCeCommand3).ExecuteNonQuery();
            ((Component) sqlCeCommand3).Dispose();
            sqlCeCommand2 = (SqlCeCommand) null;
            GC.Collect();
          }
          list2.Clear();
          GC.Collect();
        }
      }
      list1.Clear();
      GC.Collect();
    }

    public void syncDowloadInventory(string date)
    {
      SynchronizerDAO.count = 0;
      List<inventario_fisico> list = Enumerable.ToList<inventario_fisico>((IEnumerable<inventario_fisico>) new SyncCatalogos().GetInventarios(date));
      if (list.Count > 0)
      {
        SynchronizerDAO.count = list.Count;
        foreach (inventario_fisico inventarioFisico in list)
        {
          SqlCeCommand sqlCeCommand = new SqlCeCommand(new inventarioDAO().existInventario(new Guid(inventarioFisico.id_inventario_fisico)) ? "UPDATE inventario_fisico SET id_proveedor=@id_proveedor,user_name=@user_name,fecha_ini=@fecha_ini,fecha_fin=@fecha_fin,fecha_registro=@fecha_registro WHERE id_inventario_fisico=@id_inventario_fisico" : "INSERT INTO inventario_fisico(id_inventario_fisico,id_proveedor,user_name,fecha_ini,fecha_fin,fecha_registro) VALUES(@id_inventario_fisico,@id_proveedor,@user_name,@fecha_ini,@fecha_fin,@fecha_registro)", pos_colector.getConnection());
          ((DbParameter) sqlCeCommand.Parameters.Add("@id_inventario_fisico", SqlDbType.UniqueIdentifier)).Value = (object) inventarioFisico.id_inventario_fisico;
          ((DbParameter) sqlCeCommand.Parameters.Add("@id_proveedor", SqlDbType.UniqueIdentifier)).Value = (object) inventarioFisico.id_proveedor;
          ((DbParameter) sqlCeCommand.Parameters.Add("@user_name", SqlDbType.NVarChar)).Value = (object) inventarioFisico.user_name;
          ((DbParameter) sqlCeCommand.Parameters.Add("@fecha_ini", SqlDbType.DateTime)).Value = (object) inventarioFisico.fecha_ini;
          ((DbParameter) sqlCeCommand.Parameters.Add("@fecha_fin", SqlDbType.DateTime)).Value = (object) inventarioFisico.fecha_fin ?? (object) DBNull.Value;
          ((DbParameter) sqlCeCommand.Parameters.Add("@fecha_registro", SqlDbType.DateTime)).Value = (object) inventarioFisico.fecha_registro;
          ((DbCommand) sqlCeCommand).CommandType = CommandType.Text;
          ((DbCommand) sqlCeCommand).ExecuteNonQuery();
          ((Component) sqlCeCommand).Dispose();
          GC.Collect();
        }
      }
      list.Clear();
      GC.Collect();
    }

    public void syncCompras()
    {
      SynchronizerDAO.count = 0;
      SqlCeCommand selectCommand1 = new SqlCeCommand("SELECT id_compra,id_proveedor,CONVERT(nvarchar,fecha_compra,121) fecha_compra,id_pedido FROM compra WHERE upload=0 ORDER BY fecha_compra", pos_colector.getConnection());
      DataTable dataTable1 = new DataTable();
      ((DbDataAdapter) new SqlCeDataAdapter(selectCommand1)).Fill(dataTable1);
      SyncCatalogos syncCatalogos = new SyncCatalogos();
      foreach (DataRow row1 in (InternalDataCollectionBase) dataTable1.Rows)
      {
        compra c = new compra();
        c.id_compra = row1["id_compra"].ToString();
        c.id_proveedor = row1["id_proveedor"] != DBNull.Value ? row1["id_proveedor"].ToString() : (string) null;
        c.fecha_compra = row1["fecha_compra"].ToString();
        c.id_pedido = row1["id_pedido"] != DBNull.Value ? row1["id_pedido"].ToString() : (string) null;
        bool flag1;
        bool flag2;
        syncCatalogos.CreatePurchase(c, out flag1, out flag2);
        if (!flag1)
          throw new Exception("No se insertó la Compra");
        DataTable dataTable2 = new DataTable();
        SqlCeCommand selectCommand2 = new SqlCeCommand("SELECT id_compra,cod_barras,num_articulo,cant_cja,cant_pza,precio_compra,no_captura,no_entrega FROM compra_articulo WHERE id_compra=@id_compra", pos_colector.getConnection());
        ((DbParameter) selectCommand2.Parameters.Add("@id_compra", SqlDbType.UniqueIdentifier)).Value = (object) new Guid(c.id_compra);
        ((DbDataAdapter) new SqlCeDataAdapter(selectCommand2)).Fill(dataTable2);
        foreach (DataRow row2 in (InternalDataCollectionBase) dataTable2.Rows)
        {
          syncCatalogos.CreatePurchaseDetail(new compra_articulo()
          {
            id_compra = row2["id_compra"].ToString(),
            cod_barras = row2["cod_barras"].ToString(),
            num_articulo = row2["num_articulo"].ToString(),
            cant_cja = row2["cant_cja"].ToString(),
            cant_pza = row2["cant_pza"].ToString(),
            precio_compra = row2["precio_compra"].ToString(),
            no_captura = "0",
            no_entrega = "0"
          }, out flag1, out flag2);
          if (!flag1)
            throw new Exception("No se insertaron los Artículos de la Compra");
        }
        dataTable2.Clear();
        dataTable2.Dispose();
        if (flag1)
        {
          SqlCeCommand sqlCeCommand = new SqlCeCommand("UPDATE compra SET upload=1 WHERE id_compra=@id_compra", pos_colector.getConnection());
          ((DbParameter) sqlCeCommand.Parameters.Add("@id_compra", SqlDbType.UniqueIdentifier)).Value = (object) new Guid(row1["id_compra"].ToString());
          ((DbCommand) sqlCeCommand).ExecuteNonQuery();
          ((Component) sqlCeCommand).Dispose();
        }
        GC.Collect();
      }
      SynchronizerDAO.count = dataTable1.Rows.Count;
      dataTable1.Clear();
      dataTable1.Dispose();
      GC.Collect();
    }

    public void syncUploadInventario()
    {
      SynchronizerDAO.count = 0;
      SqlCeCommand selectCommand = new SqlCeCommand("SELECT id_captura,id_inventario_fisico,num_captura,cod_barras,CONVERT(nvarchar,fecha_captura,121) fecha_captura,cant_cja,cant_pza FROM inventario_captura WHERE upload=0 ORDER BY fecha_captura", pos_colector.getConnection());
      DataTable dataTable = new DataTable();
      ((DbDataAdapter) new SqlCeDataAdapter(selectCommand)).Fill(dataTable);
      SyncCatalogos syncCatalogos = new SyncCatalogos();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        bool SetInventariosResult;
        syncCatalogos.SetInventarios(new inventario_captura()
        {
          id_captura = row["id_captura"].ToString(),
          id_inventario_fisico = row["id_inventario_fisico"].ToString(),
          num_captura = row["num_captura"].ToString(),
          cod_barras = row["cod_barras"].ToString(),
          fecha_captura = row["fecha_captura"].ToString(),
          cant_cja = row["cant_cja"].ToString(),
          cant_pza = row["cant_pza"].ToString()
        }, out SetInventariosResult, out bool _);
        if (!SetInventariosResult)
          throw new Exception("No se subieron correctamente los Inventarios");
        SqlCeCommand sqlCeCommand = new SqlCeCommand("UPDATE inventario_captura SET upload=1 WHERE id_inventario_fisico=@id_inventario_fisico AND num_captura=@num_captura AND cod_barras=@cod_barras", pos_colector.getConnection());
        ((DbParameter) sqlCeCommand.Parameters.Add("@id_inventario_fisico", SqlDbType.UniqueIdentifier)).Value = (object) new Guid(row["id_inventario_fisico"].ToString());
        ((DbParameter) sqlCeCommand.Parameters.Add("@num_captura", SqlDbType.BigInt)).Value = (object) long.Parse(row["num_captura"].ToString());
        ((DbParameter) sqlCeCommand.Parameters.Add("@cod_barras", SqlDbType.NVarChar)).Value = (object) row["cod_barras"].ToString();
        ((DbCommand) sqlCeCommand).ExecuteNonQuery();
        ((Component) sqlCeCommand).Dispose();
        GC.Collect();
      }
      SynchronizerDAO.count = dataTable.Rows.Count;
      dataTable.Clear();
      dataTable.Dispose();
      GC.Collect();
    }

    private string getLastChangeDateTimeItems()
    {
      SqlCeDataReader data = pos_colector.GetData("SELECT TOP(1) CONVERT(nvarchar,fecha_registro,121) fecha_registro FROM articulo ORDER BY fecha_registro DESC");
      return ((DbDataReader) data).Read() ? ((DbDataReader) data)["fecha_registro"].ToString() : this.dateInitial;
    }

    private string getLastChangeDateTimeProvider()
    {
      SqlCeDataReader data = pos_colector.GetData("SELECT TOP(1) CONVERT(nvarchar,fecha_registro,121) fecha_registro FROM proveedor ORDER BY fecha_registro DESC");
      return ((DbDataReader) data).Read() ? ((DbDataReader) data)["fecha_registro"].ToString() : this.dateInitial;
    }

    private string getLastChangeDateTimeUnits()
    {
      SqlCeDataReader data = pos_colector.GetData("SELECT TOP(1) CONVERT(nvarchar,fecha_registro,121) fecha_registro FROM unidad_medida ORDER BY fecha_registro DESC");
      return ((DbDataReader) data).Read() ? ((DbDataReader) data)["fecha_registro"].ToString() : this.dateInitial;
    }

    private string getLastChangeDateTimeUsers()
    {
      SqlCeDataReader data = pos_colector.GetData("SELECT TOP(1) CONVERT(nvarchar,fecha_registro,121) fecha_registro FROM usuario ORDER BY fecha_registro DESC");
      return ((DbDataReader) data).Read() ? ((DbDataReader) data)["fecha_registro"].ToString() : this.dateInitial;
    }

    private string getLastChangeDateTimeUsuarioPermiso()
    {
      SqlCeDataReader data = pos_colector.GetData("SELECT TOP(1) CONVERT(nvarchar,fecha_registro,121) fecha_registro FROM usuario_permiso ORDER BY fecha_registro DESC");
      return ((DbDataReader) data).Read() ? ((DbDataReader) data)["fecha_registro"].ToString() : this.dateInitial;
    }

    public static string getLastChangeDateTimeOrders()
    {
      SqlCeDataReader data = pos_colector.GetData("SELECT TOP(1) CONVERT(nvarchar,fecha_registro,121) fecha_registro FROM orden ORDER BY fecha_registro DESC");
      return ((DbDataReader) data).Read() ? ((DbDataReader) data)["fecha_registro"].ToString() : (string) null;
    }

    private string getLastChangeDateTimeOrdersDetail()
    {
      SqlCeDataReader data = pos_colector.GetData("SELECT TOP(1) CONVERT(nvarchar,fecha_registro,121) fecha_registro FROM orden_articulo ORDER BY fecha_registro DESC");
      return ((DbDataReader) data).Read() ? ((DbDataReader) data)["fecha_registro"].ToString() : this.dateInitial;
    }

    public static string getLastChangeDateTimeInventarios()
    {
      SqlCeDataReader data = pos_colector.GetData("SELECT TOP(1) CONVERT(nvarchar,fecha_registro,121) fecha_registro FROM inventario_fisico ORDER BY fecha_registro DESC");
      return ((DbDataReader) data).Read() ? ((DbDataReader) data)["fecha_registro"].ToString() : (string) null;
    }
  }
}
