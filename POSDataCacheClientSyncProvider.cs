// Decompiled with JetBrains decompiler
// Type: POSColector.POSDataCacheClientSyncProvider
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using Microsoft.Synchronization.Data.SqlServerCe;
using System.IO;
using System.Reflection;

namespace POSColector
{
  public class POSDataCacheClientSyncProvider : SqlCeClientSyncProvider
  {
    public POSDataCacheClientSyncProvider() => this.ConnectionString = "Data Source=" + Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), "pos_colector.sdf");

    public POSDataCacheClientSyncProvider(string connectionString) => this.ConnectionString = connectionString;
  }
}
