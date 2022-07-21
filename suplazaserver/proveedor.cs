// Decompiled with JetBrains decompiler
// Type: POSColector.suplazaserver.proveedor
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
  public class proveedor
  {
    private string estatusField;
    private string id_proveedorField;
    private DateTime last_change_datetimeField;
    private bool last_change_datetimeFieldSpecified;
    private string razon_socialField;
    private string rfcField;

    [XmlElement(IsNullable = true)]
    public string estatus
    {
      get => this.estatusField;
      set => this.estatusField = value;
    }

    public string id_proveedor
    {
      get => this.id_proveedorField;
      set => this.id_proveedorField = value;
    }

    public DateTime last_change_datetime
    {
      get => this.last_change_datetimeField;
      set => this.last_change_datetimeField = value;
    }

    [XmlIgnore]
    public bool last_change_datetimeSpecified
    {
      get => this.last_change_datetimeFieldSpecified;
      set => this.last_change_datetimeFieldSpecified = value;
    }

    [XmlElement(IsNullable = true)]
    public string razon_social
    {
      get => this.razon_socialField;
      set => this.razon_socialField = value;
    }

    [XmlElement(IsNullable = true)]
    public string rfc
    {
      get => this.rfcField;
      set => this.rfcField = value;
    }
  }
}
