// Decompiled with JetBrains decompiler
// Type: POSColector.suplazaserver.pedido
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace POSColector.suplazaserver
{
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/SyncPOS.domain")]
  [DebuggerStepThrough]
  public class pedido
  {
    private DateTime fecha_pedidoField;
    private bool fecha_pedidoFieldSpecified;
    private DateTime fecha_registroField;
    private bool fecha_registroFieldSpecified;
    private string id_pedidoField;
    private string id_proveedorField;
    private long num_pedidoField;
    private bool num_pedidoFieldSpecified;
    private string status_pedidoField;

    public DateTime fecha_pedido
    {
      get => this.fecha_pedidoField;
      set => this.fecha_pedidoField = value;
    }

    [XmlIgnore]
    public bool fecha_pedidoSpecified
    {
      get => this.fecha_pedidoFieldSpecified;
      set => this.fecha_pedidoFieldSpecified = value;
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

    public string id_proveedor
    {
      get => this.id_proveedorField;
      set => this.id_proveedorField = value;
    }

    public long num_pedido
    {
      get => this.num_pedidoField;
      set => this.num_pedidoField = value;
    }

    [XmlIgnore]
    public bool num_pedidoSpecified
    {
      get => this.num_pedidoFieldSpecified;
      set => this.num_pedidoFieldSpecified = value;
    }

    [XmlElement(IsNullable = true)]
    public string status_pedido
    {
      get => this.status_pedidoField;
      set => this.status_pedidoField = value;
    }
  }
}
