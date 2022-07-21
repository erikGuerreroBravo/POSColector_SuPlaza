// Decompiled with JetBrains decompiler
// Type: POSColector.Properties.Resources
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace POSColector.Properties
{
  internal class Resources
  {
    private static ResourceManager _resMgr;
    private static CultureInfo _resCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static ResourceManager ResourceManager
    {
      get
      {
        if (POSColector.Properties.Resources._resMgr == null)
          POSColector.Properties.Resources._resMgr = new ResourceManager("POSColector.Properties.Resources", typeof (POSColector.Properties.Resources).Assembly);
        return POSColector.Properties.Resources._resMgr;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static CultureInfo Culture
    {
      get => POSColector.Properties.Resources._resCulture;
      set => POSColector.Properties.Resources._resCulture = value;
    }
  }
}
