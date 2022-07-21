// Decompiled with JetBrains decompiler
// Type: POSColector.Program
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using POSColector.ViewForms;
using System;
using System.Windows.Forms;

namespace POSColector
{
  internal static class Program
  {
    [MTAThread]
    private static void Main() => Application.Run((Form) new MainForm());
  }
}
