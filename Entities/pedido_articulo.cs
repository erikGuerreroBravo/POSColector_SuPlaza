// Decompiled with JetBrains decompiler
// Type: POSColector.Entities.pedido_articulo
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using System;

namespace POSColector.Entities
{
  public class pedido_articulo
  {
    public Guid id_pedido { set; get; }

    public articulo item { set; get; }

    public Decimal cantidad { set; get; }
  }
}
