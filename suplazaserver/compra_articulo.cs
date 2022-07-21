// Decompiled with JetBrains decompiler
// Type: POSColector.suplazaserver.compra_articulo
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace POSColector.suplazaserver
{
  [DebuggerStepThrough]
  [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/SyncPOS.domain")]
  [DesignerCategory("code")]
  public class compra_articulo
  {
    private string cant_cjaField;
    private string cant_pzaField;
    private string cod_barrasField;
    private string id_compraField;
    private string no_capturaField;
    private string no_entregaField;
    private string num_articuloField;
    private string precio_compraField;

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
    public string id_compra
    {
      get => this.id_compraField;
      set => this.id_compraField = value;
    }

    [XmlElement(IsNullable = true)]
    public string no_captura
    {
      get => this.no_capturaField;
      set => this.no_capturaField = value;
    }

    [XmlElement(IsNullable = true)]
    public string no_entrega
    {
      get => this.no_entregaField;
      set => this.no_entregaField = value;
    }

    [XmlElement(IsNullable = true)]
    public string num_articulo
    {
      get => this.num_articuloField;
      set => this.num_articuloField = value;
    }

    [XmlElement(IsNullable = true)]
    public string precio_compra
    {
      get => this.precio_compraField;
      set => this.precio_compraField = value;
    }
  }
}
