// Decompiled with JetBrains decompiler
// Type: POSColector.suplazaserver.inventario_fisico
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
  public class inventario_fisico
  {
    private string fecha_finField;
    private DateTime fecha_iniField;
    private bool fecha_iniFieldSpecified;
    private DateTime fecha_registroField;
    private bool fecha_registroFieldSpecified;
    private string id_inventario_fisicoField;
    private string id_proveedorField;
    private string user_nameField;

    [XmlElement(IsNullable = true)]
    public string fecha_fin
    {
      get => this.fecha_finField;
      set => this.fecha_finField = value;
    }

    public DateTime fecha_ini
    {
      get => this.fecha_iniField;
      set => this.fecha_iniField = value;
    }

    [XmlIgnore]
    public bool fecha_iniSpecified
    {
      get => this.fecha_iniFieldSpecified;
      set => this.fecha_iniFieldSpecified = value;
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

    public string id_inventario_fisico
    {
      get => this.id_inventario_fisicoField;
      set => this.id_inventario_fisicoField = value;
    }

    public string id_proveedor
    {
      get => this.id_proveedorField;
      set => this.id_proveedorField = value;
    }

    [XmlElement(IsNullable = true)]
    public string user_name
    {
      get => this.user_nameField;
      set => this.user_nameField = value;
    }
  }
}
