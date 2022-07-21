// Decompiled with JetBrains decompiler
// Type: POSColector.DAO.usuarioDAO
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using System.Data.Common;

namespace POSColector.DAO
{
  public class usuarioDAO : pos_colector
  {
    public bool existUser(string user_name) => ((DbDataReader) pos_colector.GetData(string.Format("SELECT user_name FROM usuario WHERE user_name='{0}'", (object) user_name))).Read();

    public bool existPermision(string user_name, string id_permiso) => ((DbDataReader) pos_colector.GetData(string.Format("SELECT user_name FROM usuario_permiso WHERE user_name='{0}' AND id_permiso='{1}'", (object) user_name, (object) id_permiso))).Read();

    public bool AuthorizerUser(string password) => ((DbDataReader) pos_colector.GetData(string.Format("SELECT u.[user_name] FROM usuario u INNER JOIN usuario_permiso up ON u.[user_name]=up.[user_name] WHERE u.[password]='{0}' AND up.id_permiso='pos_colector'", (object) password))).Read();
  }
}
