﻿// Decompiled with JetBrains decompiler
// Type: POSColector.Entities.compra
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using System;

namespace POSColector.Entities
{
  public class compra
  {
    public Guid id_compra { set; get; }

    public string num_compra { set; get; }

    public Guid id_proveedor { set; get; }

    public DateTime fecha_compra { set; get; }

    public Guid id_pedido { set; get; }

    public short no_entrada { set; get; }

    public override string ToString() => string.Format(this.num_compra);
  }
}
