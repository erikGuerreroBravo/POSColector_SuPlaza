// Decompiled with JetBrains decompiler
// Type: POSColector.Entities.articulo
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using System;

namespace POSColector.Entities
{
  public class articulo
  {
    public string cod_barras { set; get; }

    public string cod_asociado { set; get; }

    public string descripcion { set; get; }

    public Guid id_unidad { set; get; }

    public Decimal cantidad_um { set; get; }

    public Decimal precio_compra { set; get; }

    public string tipo_articulo { set; get; }

    public Guid id_proveedor { set; get; }

    public Decimal cant_pedida { set; get; }

    public Decimal por_surtir { set; get; }
  }
}
