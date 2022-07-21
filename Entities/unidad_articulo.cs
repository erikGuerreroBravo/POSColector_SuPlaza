// Decompiled with JetBrains decompiler
// Type: POSColector.Entities.unidad_articulo
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using System;

namespace POSColector.Entities
{
  public class unidad_articulo
  {
    public Guid id_unidad { set; get; }

    public string descripcion { set; get; }

    public Decimal cantidad_um { set; get; }

    public string tipo { set; get; }

    public override string ToString() => this.descripcion + "/" + this.cantidad_um.ToString("G9");
  }
}
