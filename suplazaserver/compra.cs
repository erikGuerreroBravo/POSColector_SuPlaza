// Decompiled with JetBrains decompiler
// Type: POSColector.suplazaserver.compra
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace POSColector.suplazaserver
{
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/SyncPOS.domain")]
  public class compra
  {
    private bool canceladaField;
    private bool canceladaFieldSpecified;
    private DateTime fecha_cancelacionField;
    private bool fecha_cancelacionFieldSpecified;
    private string fecha_compraField;
    private string id_compraField;
    private string id_pedidoField;
    private string id_proveedorField;
    private short no_entradaField;
    private bool no_entradaFieldSpecified;
    private string no_facturaField;
    private string observacionesField;

    public bool cancelada
    {
      get => this.canceladaField;
      set => this.canceladaField = value;
    }

    [XmlIgnore]
    public bool canceladaSpecified
    {
      get => this.canceladaFieldSpecified;
      set => this.canceladaFieldSpecified = value;
    }

    public DateTime fecha_cancelacion
    {
      get => this.fecha_cancelacionField;
      set => this.fecha_cancelacionField = value;
    }

    [XmlIgnore]
    public bool fecha_cancelacionSpecified
    {
      get => this.fecha_cancelacionFieldSpecified;
      set => this.fecha_cancelacionFieldSpecified = value;
    }

    [XmlElement(IsNullable = true)]
    public string fecha_compra
    {
      get => this.fecha_compraField;
      set => this.fecha_compraField = value;
    }

    [XmlElement(IsNullable = true)]
    public string id_compra
    {
      get => this.id_compraField;
      set => this.id_compraField = value;
    }

    [XmlElement(IsNullable = true)]
    public string id_pedido
    {
      get => this.id_pedidoField;
      set => this.id_pedidoField = value;
    }

    [XmlElement(IsNullable = true)]
    public string id_proveedor
    {
      get => this.id_proveedorField;
      set => this.id_proveedorField = value;
    }

    public short no_entrada
    {
      get => this.no_entradaField;
      set => this.no_entradaField = value;
    }

    [XmlIgnore]
    public bool no_entradaSpecified
    {
      get => this.no_entradaFieldSpecified;
      set => this.no_entradaFieldSpecified = value;
    }

    [XmlElement(IsNullable = true)]
    public string no_factura
    {
      get => this.no_facturaField;
      set => this.no_facturaField = value;
    }

    [XmlElement(IsNullable = true)]
    public string observaciones
    {
      get => this.observacionesField;
      set => this.observacionesField = value;
    }
  }
}
