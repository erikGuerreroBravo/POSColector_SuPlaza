// Decompiled with JetBrains decompiler
// Type: POSColector.POSDataCacheSyncAgent
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace POSColector
{
  public class POSDataCacheSyncAgent : SyncAgent
  {
    private POSDataCacheSyncAgent.articuloSyncTable _articuloSyncTable;
    private POSDataCacheSyncAgent.proveedorSyncTable _proveedorSyncTable;
    private POSDataCacheSyncAgent.unidad_medidaSyncTable _unidad_medidaSyncTable;
    private POSDataCacheSyncAgent.usuarioSyncTable _usuarioSyncTable;
    private POSDataCacheSyncAgent.usuario_permisoSyncTable _usuario_permisoSyncTable;

    public POSDataCacheSyncAgent()
    {
      this.InitializeSyncProviders();
      this.InitializeSyncTables();
    }

    public POSDataCacheSyncAgent(object remoteSyncProviderProxy)
    {
      this.InitializeSyncProviders();
      this.InitializeSyncTables();
      this.RemoteProvider = (SyncProvider) new ServerSyncProviderProxy(remoteSyncProviderProxy);
    }

    [DebuggerNonUserCode]
    public POSDataCacheSyncAgent.articuloSyncTable articulo
    {
      get => this._articuloSyncTable;
      set
      {
        ((Collection<SyncTable>) this.Configuration.SyncTables).Remove((SyncTable) this._articuloSyncTable);
        this._articuloSyncTable = value;
        ((Collection<SyncTable>) this.Configuration.SyncTables).Add((SyncTable) this._articuloSyncTable);
      }
    }

    [DebuggerNonUserCode]
    public POSDataCacheSyncAgent.proveedorSyncTable proveedor
    {
      get => this._proveedorSyncTable;
      set
      {
        ((Collection<SyncTable>) this.Configuration.SyncTables).Remove((SyncTable) this._proveedorSyncTable);
        this._proveedorSyncTable = value;
        ((Collection<SyncTable>) this.Configuration.SyncTables).Add((SyncTable) this._proveedorSyncTable);
      }
    }

    [DebuggerNonUserCode]
    public POSDataCacheSyncAgent.unidad_medidaSyncTable unidad_medida
    {
      get => this._unidad_medidaSyncTable;
      set
      {
        ((Collection<SyncTable>) this.Configuration.SyncTables).Remove((SyncTable) this._unidad_medidaSyncTable);
        this._unidad_medidaSyncTable = value;
        ((Collection<SyncTable>) this.Configuration.SyncTables).Add((SyncTable) this._unidad_medidaSyncTable);
      }
    }

    [DebuggerNonUserCode]
    public POSDataCacheSyncAgent.usuarioSyncTable usuario
    {
      get => this._usuarioSyncTable;
      set
      {
        ((Collection<SyncTable>) this.Configuration.SyncTables).Remove((SyncTable) this._usuarioSyncTable);
        this._usuarioSyncTable = value;
        ((Collection<SyncTable>) this.Configuration.SyncTables).Add((SyncTable) this._usuarioSyncTable);
      }
    }

    [DebuggerNonUserCode]
    public POSDataCacheSyncAgent.usuario_permisoSyncTable usuario_permiso
    {
      get => this._usuario_permisoSyncTable;
      set
      {
        ((Collection<SyncTable>) this.Configuration.SyncTables).Remove((SyncTable) this._usuario_permisoSyncTable);
        this._usuario_permisoSyncTable = value;
        ((Collection<SyncTable>) this.Configuration.SyncTables).Add((SyncTable) this._usuario_permisoSyncTable);
      }
    }

    [DebuggerNonUserCode]
    private void InitializeSyncProviders() => this.LocalProvider = (SyncProvider) new POSDataCacheClientSyncProvider();

    [DebuggerNonUserCode]
    private void InitializeSyncTables()
    {
      this._articuloSyncTable = new POSDataCacheSyncAgent.articuloSyncTable();
      this._articuloSyncTable.SyncGroup = new SyncGroup("articuloSyncTableSyncGroup");
      ((Collection<SyncTable>) this.Configuration.SyncTables).Add((SyncTable) this._articuloSyncTable);
      this._proveedorSyncTable = new POSDataCacheSyncAgent.proveedorSyncTable();
      this._proveedorSyncTable.SyncGroup = new SyncGroup("proveedorSyncTableSyncGroup");
      ((Collection<SyncTable>) this.Configuration.SyncTables).Add((SyncTable) this._proveedorSyncTable);
      this._unidad_medidaSyncTable = new POSDataCacheSyncAgent.unidad_medidaSyncTable();
      this._unidad_medidaSyncTable.SyncGroup = new SyncGroup("unidad_medidaSyncTableSyncGroup");
      ((Collection<SyncTable>) this.Configuration.SyncTables).Add((SyncTable) this._unidad_medidaSyncTable);
      this._usuarioSyncTable = new POSDataCacheSyncAgent.usuarioSyncTable();
      this._usuarioSyncTable.SyncGroup = new SyncGroup("usuarioSyncTableSyncGroup");
      ((Collection<SyncTable>) this.Configuration.SyncTables).Add((SyncTable) this._usuarioSyncTable);
      this._usuario_permisoSyncTable = new POSDataCacheSyncAgent.usuario_permisoSyncTable();
      this._usuario_permisoSyncTable.SyncGroup = new SyncGroup("usuario_permisoSyncTableSyncGroup");
      ((Collection<SyncTable>) this.Configuration.SyncTables).Add((SyncTable) this._usuario_permisoSyncTable);
    }

    public class articuloSyncTable : SyncTable
    {
      public articuloSyncTable() => this.InitializeTableOptions();

      [DebuggerNonUserCode]
      private void InitializeTableOptions()
      {
        this.TableName = "articulo";
        this.CreationOption = (TableCreationOption) 3;
      }
    }

    public class proveedorSyncTable : SyncTable
    {
      public proveedorSyncTable() => this.InitializeTableOptions();

      [DebuggerNonUserCode]
      private void InitializeTableOptions()
      {
        this.TableName = "proveedor";
        this.CreationOption = (TableCreationOption) 3;
      }
    }

    public class unidad_medidaSyncTable : SyncTable
    {
      public unidad_medidaSyncTable() => this.InitializeTableOptions();

      [DebuggerNonUserCode]
      private void InitializeTableOptions()
      {
        this.TableName = "unidad_medida";
        this.CreationOption = (TableCreationOption) 3;
      }
    }

    public class usuarioSyncTable : SyncTable
    {
      public usuarioSyncTable() => this.InitializeTableOptions();

      [DebuggerNonUserCode]
      private void InitializeTableOptions()
      {
        this.TableName = "usuario";
        this.CreationOption = (TableCreationOption) 3;
      }
    }

    public class usuario_permisoSyncTable : SyncTable
    {
      public usuario_permisoSyncTable() => this.InitializeTableOptions();

      [DebuggerNonUserCode]
      private void InitializeTableOptions()
      {
        this.TableName = "usuario_permiso";
        this.CreationOption = (TableCreationOption) 3;
      }
    }
  }
}
