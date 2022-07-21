// Decompiled with JetBrains decompiler
// Type: POSColector.Entities.compra_articulo
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using System;

namespace POSColector.Entities
{
  public class compra_articulo
  {
    public Guid id_compra { set; get; }

    public articulo item { set; get; }

    public int num_articulo { set; get; }

    public Decimal cantidad { set; get; }

    public Decimal cant_cja { set; get; }

    public Decimal cant_pzs { set; get; }

    public Decimal precio_compra { set; get; }

    public unidad_articulo medida { set; get; }

    public Decimal getCantidadCja() => this.medida.tipo.Equals("anexo") ? this.cantidad : 0.0M;

    public Decimal getCantidadPza() => this.medida.tipo.Equals("principal") ? this.cantidad : this.cantidad * this.medida.cantidad_um;
  }
}
