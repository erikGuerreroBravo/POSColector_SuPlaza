// Decompiled with JetBrains decompiler
// Type: POSColector.suplazaserver.pedido_articulo
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
  [DesignerCategory("code")]
  [DebuggerStepThrough]
  public class pedido_articulo
  {
    private Decimal cantidadField;
    private bool cantidadFieldSpecified;
    private string cod_anexoField;
    private string cod_barrasField;
    private DateTime fecha_registroField;
    private bool fecha_registroFieldSpecified;
    private string id_pedidoField;
    private short no_articuloField;
    private bool no_articuloFieldSpecified;
    private Decimal por_surtirField;
    private bool por_surtirFieldSpecified;
    private Decimal por_surtir_pzasField;
    private bool por_surtir_pzasFieldSpecified;
    private Decimal precio_articuloField;
    private bool precio_articuloFieldSpecified;

    public Decimal cantidad
    {
      get => this.cantidadField;
      set => this.cantidadField = value;
    }

    [XmlIgnore]
    public bool cantidadSpecified
    {
      get => this.cantidadFieldSpecified;
      set => this.cantidadFieldSpecified = value;
    }

    [XmlElement(IsNullable = true)]
    public string cod_anexo
    {
      get => this.cod_anexoField;
      set => this.cod_anexoField = value;
    }

    [XmlElement(IsNullable = true)]
    public string cod_barras
    {
      get => this.cod_barrasField;
      set => this.cod_barrasField = value;
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

    public string id_pedido
    {
      get => this.id_pedidoField;
      set => this.id_pedidoField = value;
    }

    public short no_articulo
    {
      get => this.no_articuloField;
      set => this.no_articuloField = value;
    }

    [XmlIgnore]
    public bool no_articuloSpecified
    {
      get => this.no_articuloFieldSpecified;
      set => this.no_articuloFieldSpecified = value;
    }

    public Decimal por_surtir
    {
      get => this.por_surtirField;
      set => this.por_surtirField = value;
    }

    [XmlIgnore]
    public bool por_surtirSpecified
    {
      get => this.por_surtirFieldSpecified;
      set => this.por_surtirFieldSpecified = value;
    }

    public Decimal por_surtir_pzas
    {
      get => this.por_surtir_pzasField;
      set => this.por_surtir_pzasField = value;
    }

    [XmlIgnore]
    public bool por_surtir_pzasSpecified
    {
      get => this.por_surtir_pzasFieldSpecified;
      set => this.por_surtir_pzasFieldSpecified = value;
    }

    public Decimal precio_articulo
    {
      get => this.precio_articuloField;
      set => this.precio_articuloField = value;
    }

    [XmlIgnore]
    public bool precio_articuloSpecified
    {
      get => this.precio_articuloFieldSpecified;
      set => this.precio_articuloFieldSpecified = value;
    }
  }
}
