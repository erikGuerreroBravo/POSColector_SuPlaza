// Decompiled with JetBrains decompiler
// Type: POSColector.suplazaserver.articulo
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace POSColector.suplazaserver
{
  [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/SyncPOS.domain")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  public class articulo
  {
    private bool articulo_disponibleField;
    private bool articulo_disponibleFieldSpecified;
    private Decimal cantidad_umField;
    private bool cantidad_umFieldSpecified;
    private string cod_asociadoField;
    private string cod_barrasField;
    private string cod_internoField;
    private string descripcionField;
    private string descripcion_cortaField;
    private DateTime fecha_registroField;
    private bool fecha_registroFieldSpecified;
    private long id_clasificacionField;
    private bool id_clasificacionFieldSpecified;
    private string id_proveedorField;
    private string id_unidadField;
    private Decimal ivaField;
    private bool ivaFieldSpecified;
    private bool kitField;
    private bool kitFieldSpecified;
    private DateTime kit_fecha_finField;
    private bool kit_fecha_finFieldSpecified;
    private DateTime kit_fecha_iniField;
    private bool kit_fecha_iniFieldSpecified;
    private DateTime last_update_inventoryField;
    private bool last_update_inventoryFieldSpecified;
    private Decimal precio_compraField;
    private bool precio_compraFieldSpecified;
    private Decimal precio_ventaField;
    private bool precio_ventaFieldSpecified;
    private short puntosField;
    private bool puntosFieldSpecified;
    private Decimal stockField;
    private bool stockFieldSpecified;
    private Decimal stock_maxField;
    private bool stock_maxFieldSpecified;
    private Decimal stock_minField;
    private bool stock_minFieldSpecified;
    private string tipo_articuloField;
    private Decimal utilidadField;
    private bool utilidadFieldSpecified;
    private bool visibleField;
    private bool visibleFieldSpecified;

    public bool articulo_disponible
    {
      get => this.articulo_disponibleField;
      set => this.articulo_disponibleField = value;
    }

    [XmlIgnore]
    public bool articulo_disponibleSpecified
    {
      get => this.articulo_disponibleFieldSpecified;
      set => this.articulo_disponibleFieldSpecified = value;
    }

    public Decimal cantidad_um
    {
      get => this.cantidad_umField;
      set => this.cantidad_umField = value;
    }

    [XmlIgnore]
    public bool cantidad_umSpecified
    {
      get => this.cantidad_umFieldSpecified;
      set => this.cantidad_umFieldSpecified = value;
    }

    [XmlElement(IsNullable = true)]
    public string cod_asociado
    {
      get => this.cod_asociadoField;
      set => this.cod_asociadoField = value;
    }

    [XmlElement(IsNullable = true)]
    public string cod_barras
    {
      get => this.cod_barrasField;
      set => this.cod_barrasField = value;
    }

    [XmlElement(IsNullable = true)]
    public string cod_interno
    {
      get => this.cod_internoField;
      set => this.cod_internoField = value;
    }

    [XmlElement(IsNullable = true)]
    public string descripcion
    {
      get => this.descripcionField;
      set => this.descripcionField = value;
    }

    [XmlElement(IsNullable = true)]
    public string descripcion_corta
    {
      get => this.descripcion_cortaField;
      set => this.descripcion_cortaField = value;
    }

    public DateTime fecha_registro
    {
      get => this.fecha_registroField;
      set => this.fecha_registroField = value;
    }

    [XmlIgnore]
    public bool fecha_registroSpecified
    {
      get => this.fecha_registroFieldSpecified;
      set => this.fecha_registroFieldSpecified = value;
    }

    public long id_clasificacion
    {
      get => this.id_clasificacionField;
      set => this.id_clasificacionField = value;
    }

    [XmlIgnore]
    public bool id_clasificacionSpecified
    {
      get => this.id_clasificacionFieldSpecified;
      set => this.id_clasificacionFieldSpecified = value;
    }

    public string id_proveedor
    {
      get => this.id_proveedorField;
      set => this.id_proveedorField = value;
    }

    public string id_unidad
    {
      get => this.id_unidadField;
      set => this.id_unidadField = value;
    }

    public Decimal iva
    {
      get => this.ivaField;
      set => this.ivaField = value;
    }

    [XmlIgnore]
    public bool ivaSpecified
    {
      get => this.ivaFieldSpecified;
      set => this.ivaFieldSpecified = value;
    }

    public bool kit
    {
      get => this.kitField;
      set => this.kitField = value;
    }

    [XmlIgnore]
    public bool kitSpecified
    {
      get => this.kitFieldSpecified;
      set => this.kitFieldSpecified = value;
    }

    public DateTime kit_fecha_fin
    {
      get => this.kit_fecha_finField;
      set => this.kit_fecha_finField = value;
    }

    [XmlIgnore]
    public bool kit_fecha_finSpecified
    {
      get => this.kit_fecha_finFieldSpecified;
      set => this.kit_fecha_finFieldSpecified = value;
    }

    public DateTime kit_fecha_ini
    {
      get => this.kit_fecha_iniField;
      set => this.kit_fecha_iniField = value;
    }

    [XmlIgnore]
    public bool kit_fecha_iniSpecified
    {
      get => this.kit_fecha_iniFieldSpecified;
      set => this.kit_fecha_iniFieldSpecified = value;
    }

    public DateTime last_update_inventory
    {
      get => this.last_update_inventoryField;
      set => this.last_update_inventoryField = value;
    }

    [XmlIgnore]
    public bool last_update_inventorySpecified
    {
      get => this.last_update_inventoryFieldSpecified;
      set => this.last_update_inventoryFieldSpecified = value;
    }

    public Decimal precio_compra
    {
      get => this.precio_compraField;
      set => this.precio_compraField = value;
    }

    [XmlIgnore]
    public bool precio_compraSpecified
    {
      get => this.precio_compraFieldSpecified;
      set => this.precio_compraFieldSpecified = value;
    }

    public Decimal precio_venta
    {
      get => this.precio_ventaField;
      set => this.precio_ventaField = value;
    }

    [XmlIgnore]
    public bool precio_ventaSpecified
    {
      get => this.precio_ventaFieldSpecified;
      set => this.precio_ventaFieldSpecified = value;
    }

    public short puntos
    {
      get => this.puntosField;
      set => this.puntosField = value;
    }

    [XmlIgnore]
    public bool puntosSpecified
    {
      get => this.puntosFieldSpecified;
      set => this.puntosFieldSpecified = value;
    }

    public Decimal stock
    {
      get => this.stockField;
      set => this.stockField = value;
    }

    [XmlIgnore]
    public bool stockSpecified
    {
      get => this.stockFieldSpecified;
      set => this.stockFieldSpecified = value;
    }

    public Decimal stock_max
    {
      get => this.stock_maxField;
      set => this.stock_maxField = value;
    }

    [XmlIgnore]
    public bool stock_maxSpecified
    {
      get => this.stock_maxFieldSpecified;
      set => this.stock_maxFieldSpecified = value;
    }

    public Decimal stock_min
    {
      get => this.stock_minField;
      set => this.stock_minField = value;
    }

    [XmlIgnore]
    public bool stock_minSpecified
    {
      get => this.stock_minFieldSpecified;
      set => this.stock_minFieldSpecified = value;
    }

    [XmlElement(IsNullable = true)]
    public string tipo_articulo
    {
      get => this.tipo_articuloField;
      set => this.tipo_articuloField = value;
    }

    public Decimal utilidad
    {
      get => this.utilidadField;
      set => this.utilidadField = value;
    }

    [XmlIgnore]
    public bool utilidadSpecified
    {
      get => this.utilidadFieldSpecified;
      set => this.utilidadFieldSpecified = value;
    }

    public bool visible
    {
      get => this.visibleField;
      set => this.visibleField = value;
    }

    [XmlIgnore]
    public bool visibleSpecified
    {
      get => this.visibleFieldSpecified;
      set => this.visibleFieldSpecified = value;
    }
  }
}
