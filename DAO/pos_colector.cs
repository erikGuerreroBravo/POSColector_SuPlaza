// Decompiled with JetBrains decompiler
// Type: POSColector.DAO.pos_colector
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using System.Data.Common;
using System.Data.SqlServerCe;
using System.IO;
using System.Reflection;

namespace POSColector.DAO
{
  public class pos_colector
  {
    private static SqlCeConnection cnx;
    private static string stringConnection = "Data Source =" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\pos_colector.sdf;";

    public static SqlCeConnection getConnection()
    {
      if (pos_colector.cnx == null)
      {
        pos_colector.cnx = new SqlCeConnection(pos_colector.stringConnection);
        ((DbConnection) pos_colector.cnx).Open();
      }
      return pos_colector.cnx;
    }

    public static SqlCeDataReader GetData(string sqlCommand) => new SqlCeCommand(sqlCommand, pos_colector.getConnection()).ExecuteReader();

    public static void ExecuteSQL(string sqlCommand) => ((DbCommand) new SqlCeCommand(sqlCommand, pos_colector.getConnection())).ExecuteNonQuery();

    public static void BeginTrans() => pos_colector.getConnection().BeginTransaction();

    public void CleanSync()
    {
    }
  }
}
