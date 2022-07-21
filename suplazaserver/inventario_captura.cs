// Decompiled with JetBrains decompiler
// Type: POSColector.suplazaserver.inventario_captura
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace POSColector.suplazaserver
{
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/SyncPOS.domain")]
  public class inventario_captura
  {
    private string cant_cjaField;
    private string cant_pzaField;
    private string cod_barrasField;
    private string fecha_capturaField;
    private string id_capturaField;
    private string id_inventario_fisicoField;
    private string num_capturaField;

    [XmlElement(IsNullable = true)]
    public string cant_cja
    {
      get => this.cant_cjaField;
      set => this.cant_cjaField = value;
    }

    [XmlElement(IsNullable = true)]
    public string cant_pza
    {
      get => this.cant_pzaField;
      set => this.cant_pzaField = value;
    }

    [XmlElement(IsNullable = true)]
    public string cod_barras
    {
      get => this.cod_barrasField;
      set => this.cod_barrasField = value;
    }

    [XmlElement(IsNullable = true)]
    public string fecha_captura
    {
      get => this.fecha_capturaField;
      set => this.fecha_capturaField = value;
    }

    [XmlElement(IsNullable = true)]
    public string id_captura
    {
      get => this.id_capturaField;
      set => this.id_capturaField = value;
    }

    [XmlElement(IsNullable = true)]
    public string id_inventario_fisico
    {
      get => this.id_inventario_fisicoField;
      set => this.id_inventario_fisicoField = value;
    }

    [XmlElement(IsNullable = true)]
    public string num_captura
    {
      get => this.num_capturaField;
      set => this.num_capturaField = value;
    }
  }
}
