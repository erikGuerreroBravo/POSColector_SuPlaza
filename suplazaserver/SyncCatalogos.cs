// Decompiled with JetBrains decompiler
// Type: POSColector.suplazaserver.SyncCatalogos
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace POSColector.suplazaserver
{
  [WebServiceBinding(Name = "BasicHttpBinding_ISyncCatalogos", Namespace = "http://tempuri.org/")]
  [DesignerCategory("code")]
  [DebuggerStepThrough]
  public class SyncCatalogos : SoapHttpClientProtocol
  {
    public SyncCatalogos() => this.Url = "http://169.254.184.74:8732/SyncPOS.SyncCatalogos.svc";

    [SoapDocumentMethod("http://tempuri.org/ISyncCatalogos/getUnidades", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal)]
    [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/SyncPOS.domain")]
    [return: XmlArray(IsNullable = true)]
    public unidad_medida[] getUnidades([XmlElement(IsNullable = true)] string lastChangeDateTime) => (unidad_medida[]) this.Invoke(nameof (getUnidades), new object[1]
    {
      (object) lastChangeDateTime
    })[0];

    public IAsyncResult BegingetUnidades(
      string lastChangeDateTime,
      AsyncCallback callback,
      object asyncState)
    {
      return this.BeginInvoke("getUnidades", new object[1]
      {
        (object) lastChangeDateTime
      }, callback, asyncState);
    }

    public unidad_medida[] EndgetUnidades(IAsyncResult asyncResult) => (unidad_medida[]) this.EndInvoke(asyncResult)[0];

    [SoapDocumentMethod("http://tempuri.org/ISyncCatalogos/getProveedores", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal)]
    [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/SyncPOS.domain")]
    [return: XmlArray(IsNullable = true)]
    public proveedor[] getProveedores([XmlElement(IsNullable = true)] string lastChangeDateTime) => (proveedor[]) this.Invoke(nameof (getProveedores), new object[1]
    {
      (object) lastChangeDateTime
    })[0];

    public IAsyncResult BegingetProveedores(
      string lastChangeDateTime,
      AsyncCallback callback,
      object asyncState)
    {
      return this.BeginInvoke("getProveedores", new object[1]
      {
        (object) lastChangeDateTime
      }, callback, asyncState);
    }

    public proveedor[] EndgetProveedores(IAsyncResult asyncResult) => (proveedor[]) this.EndInvoke(asyncResult)[0];

    [SoapDocumentMethod("http://tempuri.org/ISyncCatalogos/getArticulos", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal)]
    [return: XmlArray(IsNullable = true)]
    [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/SyncPOS.domain")]
    public articulo[] getArticulos([XmlElement(IsNullable = true)] string lastChangeDateTime) => (articulo[]) this.Invoke(nameof (getArticulos), new object[1]
    {
      (object) lastChangeDateTime
    })[0];

    public IAsyncResult BegingetArticulos(
      string lastChangeDateTime,
      AsyncCallback callback,
      object asyncState)
    {
      return this.BeginInvoke("getArticulos", new object[1]
      {
        (object) lastChangeDateTime
      }, callback, asyncState);
    }

    public articulo[] EndgetArticulos(IAsyncResult asyncResult) => (articulo[]) this.EndInvoke(asyncResult)[0];

    [SoapDocumentMethod("http://tempuri.org/ISyncCatalogos/getUsuarios", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal)]
    [return: XmlArray(IsNullable = true)]
    [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/SyncPOS.domain")]
    public usuario[] getUsuarios([XmlElement(IsNullable = true)] string lastChangeDateTime) => (usuario[]) this.Invoke(nameof (getUsuarios), new object[1]
    {
      (object) lastChangeDateTime
    })[0];

    public IAsyncResult BegingetUsuarios(
      string lastChangeDateTime,
      AsyncCallback callback,
      object asyncState)
    {
      return this.BeginInvoke("getUsuarios", new object[1]
      {
        (object) lastChangeDateTime
      }, callback, asyncState);
    }

    public usuario[] EndgetUsuarios(IAsyncResult asyncResult) => (usuario[]) this.EndInvoke(asyncResult)[0];

    [SoapDocumentMethod("http://tempuri.org/ISyncCatalogos/getPermisosUsuarios", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal)]
    [return: XmlArray(IsNullable = true)]
    [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/SyncPOS.domain")]
    public usuario_permiso[] getPermisosUsuarios([XmlElement(IsNullable = true)] string lastChangeDateTime) => (usuario_permiso[]) this.Invoke(nameof (getPermisosUsuarios), new object[1]
    {
      (object) lastChangeDateTime
    })[0];

    public IAsyncResult BegingetPermisosUsuarios(
      string lastChangeDateTime,
      AsyncCallback callback,
      object asyncState)
    {
      return this.BeginInvoke("getPermisosUsuarios", new object[1]
      {
        (object) lastChangeDateTime
      }, callback, asyncState);
    }

    public usuario_permiso[] EndgetPermisosUsuarios(IAsyncResult asyncResult) => (usuario_permiso[]) this.EndInvoke(asyncResult)[0];

    [SoapDocumentMethod("http://tempuri.org/ISyncCatalogos/GetOrders", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal)]
    [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/SyncPOS.domain")]
    [return: XmlArray(IsNullable = true)]
    public pedido[] GetOrders([XmlElement(IsNullable = true)] string lastChangeDateTime) => (pedido[]) this.Invoke(nameof (GetOrders), new object[1]
    {
      (object) lastChangeDateTime
    })[0];

    public IAsyncResult BeginGetOrders(
      string lastChangeDateTime,
      AsyncCallback callback,
      object asyncState)
    {
      return this.BeginInvoke("GetOrders", new object[1]
      {
        (object) lastChangeDateTime
      }, callback, asyncState);
    }

    public pedido[] EndGetOrders(IAsyncResult asyncResult) => (pedido[]) this.EndInvoke(asyncResult)[0];

    [SoapDocumentMethod("http://tempuri.org/ISyncCatalogos/GetOrderDetail", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal)]
    [return: XmlArray(IsNullable = true)]
    [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/SyncPOS.domain")]
    public pedido_articulo[] GetOrderDetail(string id_pedido) => (pedido_articulo[]) this.Invoke(nameof (GetOrderDetail), new object[1]
    {
      (object) id_pedido
    })[0];

    public IAsyncResult BeginGetOrderDetail(
      string id_pedido,
      AsyncCallback callback,
      object asyncState)
    {
      return this.BeginInvoke("GetOrderDetail", new object[1]
      {
        (object) id_pedido
      }, callback, asyncState);
    }

    public pedido_articulo[] EndGetOrderDetail(IAsyncResult asyncResult) => (pedido_articulo[]) this.EndInvoke(asyncResult)[0];

    [SoapDocumentMethod("http://tempuri.org/ISyncCatalogos/GetOrderDetailUpdate", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal)]
    [return: XmlArray(IsNullable = true)]
    [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/SyncPOS.domain")]
    public pedido_articulo[] GetOrderDetailUpdate([XmlElement(IsNullable = true)] string lastChangeDateTime) => (pedido_articulo[]) this.Invoke(nameof (GetOrderDetailUpdate), new object[1]
    {
      (object) lastChangeDateTime
    })[0];

    public IAsyncResult BeginGetOrderDetailUpdate(
      string lastChangeDateTime,
      AsyncCallback callback,
      object asyncState)
    {
      return this.BeginInvoke("GetOrderDetailUpdate", new object[1]
      {
        (object) lastChangeDateTime
      }, callback, asyncState);
    }

    public pedido_articulo[] EndGetOrderDetailUpdate(IAsyncResult asyncResult) => (pedido_articulo[]) this.EndInvoke(asyncResult)[0];

    [SoapDocumentMethod("http://tempuri.org/ISyncCatalogos/GetInventarios", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal)]
    [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/SyncPOS.domain")]
    [return: XmlArray(IsNullable = true)]
    public inventario_fisico[] GetInventarios([XmlElement(IsNullable = true)] string lastChangeDateTime) => (inventario_fisico[]) this.Invoke(nameof (GetInventarios), new object[1]
    {
      (object) lastChangeDateTime
    })[0];

    public IAsyncResult BeginGetInventarios(
      string lastChangeDateTime,
      AsyncCallback callback,
      object asyncState)
    {
      return this.BeginInvoke("GetInventarios", new object[1]
      {
        (object) lastChangeDateTime
      }, callback, asyncState);
    }

    public inventario_fisico[] EndGetInventarios(IAsyncResult asyncResult) => (inventario_fisico[]) this.EndInvoke(asyncResult)[0];

    [SoapDocumentMethod("http://tempuri.org/ISyncCatalogos/SetInventarios", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal)]
    public void SetInventarios(
      [XmlElement(IsNullable = true)] inventario_captura p,
      out bool SetInventariosResult,
      [XmlIgnore] out bool SetInventariosResultSpecified)
    {
      object[] objArray = this.Invoke(nameof (SetInventarios), new object[1]
      {
        (object) p
      });
      SetInventariosResult = (bool) objArray[0];
      SetInventariosResultSpecified = (bool) objArray[1];
    }

    public IAsyncResult BeginSetInventarios(
      inventario_captura p,
      AsyncCallback callback,
      object asyncState)
    {
      return this.BeginInvoke("SetInventarios", new object[1]
      {
        (object) p
      }, callback, asyncState);
    }

    public void EndSetInventarios(
      IAsyncResult asyncResult,
      out bool SetInventariosResult,
      out bool SetInventariosResultSpecified)
    {
      object[] objArray = this.EndInvoke(asyncResult);
      SetInventariosResult = (bool) objArray[0];
      SetInventariosResultSpecified = (bool) objArray[1];
    }

    [SoapDocumentMethod("http://tempuri.org/ISyncCatalogos/CreatePurchase", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal)]
    public void CreatePurchase(
      [XmlElement(IsNullable = true)] compra c,
      out bool CreatePurchaseResult,
      [XmlIgnore] out bool CreatePurchaseResultSpecified)
    {
      object[] objArray = this.Invoke(nameof (CreatePurchase), new object[1]
      {
        (object) c
      });
      CreatePurchaseResult = (bool) objArray[0];
      CreatePurchaseResultSpecified = (bool) objArray[1];
    }

    public IAsyncResult BeginCreatePurchase(
      compra c,
      AsyncCallback callback,
      object asyncState)
    {
      return this.BeginInvoke("CreatePurchase", new object[1]
      {
        (object) c
      }, callback, asyncState);
    }

    public void EndCreatePurchase(
      IAsyncResult asyncResult,
      out bool CreatePurchaseResult,
      out bool CreatePurchaseResultSpecified)
    {
      object[] objArray = this.EndInvoke(asyncResult);
      CreatePurchaseResult = (bool) objArray[0];
      CreatePurchaseResultSpecified = (bool) objArray[1];
    }

    [SoapDocumentMethod("http://tempuri.org/ISyncCatalogos/CreatePurchaseDetail", ParameterStyle = SoapParameterStyle.Wrapped, RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal)]
    public void CreatePurchaseDetail(
      [XmlElement(IsNullable = true)] compra_articulo p,
      out bool CreatePurchaseDetailResult,
      [XmlIgnore] out bool CreatePurchaseDetailResultSpecified)
    {
      object[] objArray = this.Invoke(nameof (CreatePurchaseDetail), new object[1]
      {
        (object) p
      });
      CreatePurchaseDetailResult = (bool) objArray[0];
      CreatePurchaseDetailResultSpecified = (bool) objArray[1];
    }

    public IAsyncResult BeginCreatePurchaseDetail(
      compra_articulo p,
      AsyncCallback callback,
      object asyncState)
    {
      return this.BeginInvoke("CreatePurchaseDetail", new object[1]
      {
        (object) p
      }, callback, asyncState);
    }

    public void EndCreatePurchaseDetail(
      IAsyncResult asyncResult,
      out bool CreatePurchaseDetailResult,
      out bool CreatePurchaseDetailResultSpecified)
    {
      object[] objArray = this.EndInvoke(asyncResult);
      CreatePurchaseDetailResult = (bool) objArray[0];
      CreatePurchaseDetailResultSpecified = (bool) objArray[1];
    }
  }
}
