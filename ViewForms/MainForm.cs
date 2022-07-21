// Decompiled with JetBrains decompiler
// Type: POSColector.ViewForms.MainForm
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using POSColector.DAO;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace POSColector.ViewForms
{
  public class MainForm : Form
  {
    private IContainer components = (IContainer) null;
    private MainMenu mnuMain;
    private MenuItem mnuExit;
    private Label lblDateTimeNow;
    private Timer tmrNow;
    private MenuItem mnuStart;
    private MenuItem mnuPurchases;
    private MenuItem menuItem3;
    private MenuItem mnuSeparate1;
    private MenuItem mnuPurchaseOrder;
    private MenuItem mnuQueryByPedido;
    private MenuItem menuItem2;
    private MenuItem mnuSeparate2;
    private MenuItem mnuFreePurchase;
    private MenuItem mnuQueryFreePurchase;
    private MenuItem menuItem1;
    private MenuItem mnuInventory;
    private MenuItem mnuCaptureInventory;
    private MenuItem mnuQueryInventory;
    private MenuItem mnuSynchronization;
    private MenuItem mnuCatalogos;
    private MenuItem menuItem4;
    private MenuItem mnuDownload;
    private MenuItem mnuUpload;
    private MenuItem menuItem7;
    private MenuItem mnuDownloadInventory;
    private MenuItem mnuLoadInventory;

    public string msgCatalogos { set; get; }

    public string msgPedidos { set; get; }

    public string msgInventarios { set; get; }

    public static string lastDate { set; get; }

    public MainForm() => this.InitializeComponent();

    private void mnuPurchaseOrder_Click(object sender, EventArgs e)
    {
      try
      {
        new PurchasesForm().Show();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Compra por pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void mnuFreePurchase_Click(object sender, EventArgs e)
    {
      try
      {
        new PurchasesFreeForm().Show();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Compra abierta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void mnuExit_Click(object sender, EventArgs e) => this.Close();

    private void MainForm_Closing(object sender, CancelEventArgs e) => e.Cancel = MessageBox.Show("Desea salir?", "Compra abierta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes;

    private void mnuCaptureInventory_Click(object sender, EventArgs e)
    {
      try
      {
        new InventoryForm().Show();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Compra abierta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void mnuQueryByPedido_Click(object sender, EventArgs e)
    {
      try
      {
        new ShowPurchasesForm(ShowPurchasesForm.PurchaseMethod.ByOrder).Show();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Compras por Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void mnuQueryFreePurchase_Click(object sender, EventArgs e)
    {
      try
      {
        new ShowPurchasesForm(ShowPurchasesForm.PurchaseMethod.Free).Show();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Compras Abiertas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void mnuQueryInventory_Click(object sender, EventArgs e)
    {
      try
      {
        new ShowInventoryForm().Show();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Consultar Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void tmrNow_Tick(object sender, EventArgs e) => this.lblDateTimeNow.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt");

    private void mnuCatalogos_Click_1(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      try
      {
        SynchronizerDAO synchronizerDao = new SynchronizerDAO();
        synchronizerDao.syncProveedores();
        synchronizerDao.syncUnidades();
        synchronizerDao.syncArticulos();
        synchronizerDao.syncUsuarios();
        synchronizerDao.syncPermisosUsuarios();
        GC.Collect();
        int num = (int) MessageBox.Show(string.Format("Descargó {0} registro de Catálogos Principales.", (object) SynchronizerDAO.count));
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Sincronización de Catálogos Principales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
      Cursor.Current = Cursors.Default;
    }

    private void mnuDownload_Click(object sender, EventArgs e)
    {
      MainForm.lastDate = SynchronizerDAO.getLastChangeDateTimeOrders();
      if (MainForm.lastDate == null && new GetDateForm("Pedidos").ShowDialog() != DialogResult.Cancel)
        return;
      Cursor.Current = Cursors.WaitCursor;
      try
      {
        new SynchronizerDAO().syncPedidos(MainForm.lastDate);
        GC.Collect();
        int num = (int) MessageBox.Show(string.Format("Descargó {0} registros de Pedidos.", (object) SynchronizerDAO.count));
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Sincronización de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
      Cursor.Current = Cursors.Default;
    }

    private void mnuUpload_Click(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      try
      {
        new SynchronizerDAO().syncCompras();
        GC.Collect();
        int num = (int) MessageBox.Show(string.Format("Subió {0} registro de Compras.", (object) SynchronizerDAO.count));
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Sincronización de Compras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
      Cursor.Current = Cursors.Default;
    }

    private void mnuSyncInventory_Click(object sender, EventArgs e)
    {
      MainForm.lastDate = SynchronizerDAO.getLastChangeDateTimeInventarios();
      if (MainForm.lastDate == null && new GetDateForm("Inventarios").ShowDialog() != DialogResult.Cancel)
        return;
      Cursor.Current = Cursors.WaitCursor;
      try
      {
        new SynchronizerDAO().syncDowloadInventory(MainForm.lastDate);
        GC.Collect();
        int num = (int) MessageBox.Show(string.Format("Descargó {0} registro de Inventarios Abiertos.", (object) SynchronizerDAO.count));
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Sincronización de Inventarios Abiertos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
      Cursor.Current = Cursors.Default;
    }

    private void mnuLoadInventory_Click(object sender, EventArgs e)
    {
      try
      {
        new SynchronizerDAO().syncUploadInventario();
        GC.Collect();
        int num = (int) MessageBox.Show(string.Format("Subió {0} registro de Inventarios Capturados.", (object) SynchronizerDAO.count));
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Sincronización de Inventarios Capturados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.mnuMain = new MainMenu();
      this.mnuStart = new MenuItem();
      this.mnuPurchases = new MenuItem();
      this.menuItem3 = new MenuItem();
      this.mnuSeparate1 = new MenuItem();
      this.mnuPurchaseOrder = new MenuItem();
      this.mnuQueryByPedido = new MenuItem();
      this.menuItem2 = new MenuItem();
      this.mnuSeparate2 = new MenuItem();
      this.mnuFreePurchase = new MenuItem();
      this.mnuQueryFreePurchase = new MenuItem();
      this.menuItem1 = new MenuItem();
      this.mnuInventory = new MenuItem();
      this.mnuCaptureInventory = new MenuItem();
      this.mnuQueryInventory = new MenuItem();
      this.mnuSynchronization = new MenuItem();
      this.mnuCatalogos = new MenuItem();
      this.menuItem4 = new MenuItem();
      this.mnuDownload = new MenuItem();
      this.mnuUpload = new MenuItem();
      this.menuItem7 = new MenuItem();
      this.mnuDownloadInventory = new MenuItem();
      this.mnuLoadInventory = new MenuItem();
      this.mnuExit = new MenuItem();
      this.lblDateTimeNow = new Label();
      this.tmrNow = new Timer();
      this.SuspendLayout();
      this.mnuMain.MenuItems.Add(this.mnuStart);
      this.mnuMain.MenuItems.Add(this.mnuExit);
      this.mnuStart.MenuItems.Add(this.mnuPurchases);
      this.mnuStart.MenuItems.Add(this.mnuInventory);
      this.mnuStart.MenuItems.Add(this.mnuSynchronization);
      this.mnuStart.Text = "Inicio";
      this.mnuPurchases.MenuItems.Add(this.menuItem3);
      this.mnuPurchases.MenuItems.Add(this.mnuSeparate1);
      this.mnuPurchases.MenuItems.Add(this.mnuPurchaseOrder);
      this.mnuPurchases.MenuItems.Add(this.mnuQueryByPedido);
      this.mnuPurchases.MenuItems.Add(this.menuItem2);
      this.mnuPurchases.MenuItems.Add(this.mnuSeparate2);
      this.mnuPurchases.MenuItems.Add(this.mnuFreePurchase);
      this.mnuPurchases.MenuItems.Add(this.mnuQueryFreePurchase);
      this.mnuPurchases.MenuItems.Add(this.menuItem1);
      this.mnuPurchases.Text = "Compras";
      this.menuItem3.Text = "-";
      this.mnuSeparate1.Enabled = false;
      this.mnuSeparate1.Text = "-- POR PEDIDO --";
      this.mnuPurchaseOrder.Text = "Capturar";
      this.mnuPurchaseOrder.Click += new EventHandler(this.mnuPurchaseOrder_Click);
      this.mnuQueryByPedido.Text = "Consultar";
      this.mnuQueryByPedido.Click += new EventHandler(this.mnuQueryByPedido_Click);
      this.menuItem2.Text = "-";
      this.mnuSeparate2.Enabled = false;
      this.mnuSeparate2.Text = "-- ABIERTA --";
      this.mnuFreePurchase.Text = "Capturar";
      this.mnuFreePurchase.Click += new EventHandler(this.mnuFreePurchase_Click);
      this.mnuQueryFreePurchase.Text = "Consultar";
      this.mnuQueryFreePurchase.Click += new EventHandler(this.mnuQueryFreePurchase_Click);
      this.menuItem1.Text = "-";
      this.mnuInventory.MenuItems.Add(this.mnuCaptureInventory);
      this.mnuInventory.MenuItems.Add(this.mnuQueryInventory);
      this.mnuInventory.Text = "Inventario";
      this.mnuCaptureInventory.Text = "Capturar";
      this.mnuCaptureInventory.Click += new EventHandler(this.mnuCaptureInventory_Click);
      this.mnuQueryInventory.Text = "Consultar";
      this.mnuQueryInventory.Click += new EventHandler(this.mnuQueryInventory_Click);
      this.mnuSynchronization.MenuItems.Add(this.mnuCatalogos);
      this.mnuSynchronization.MenuItems.Add(this.menuItem4);
      this.mnuSynchronization.MenuItems.Add(this.mnuDownload);
      this.mnuSynchronization.MenuItems.Add(this.mnuUpload);
      this.mnuSynchronization.MenuItems.Add(this.menuItem7);
      this.mnuSynchronization.MenuItems.Add(this.mnuDownloadInventory);
      this.mnuSynchronization.MenuItems.Add(this.mnuLoadInventory);
      this.mnuSynchronization.Text = "Sincronizar";
      this.mnuCatalogos.Text = "Catálogos Principales";
      this.mnuCatalogos.Click += new EventHandler(this.mnuCatalogos_Click_1);
      this.menuItem4.Text = "-";
      this.mnuDownload.Text = "Pedidos";
      this.mnuDownload.Click += new EventHandler(this.mnuDownload_Click);
      this.mnuUpload.Text = "Compras";
      this.mnuUpload.Click += new EventHandler(this.mnuUpload_Click);
      this.menuItem7.Text = "-";
      this.mnuDownloadInventory.Text = "Inventarios Abiertos";
      this.mnuDownloadInventory.Click += new EventHandler(this.mnuSyncInventory_Click);
      this.mnuLoadInventory.Text = "Inventarios Realizados";
      this.mnuLoadInventory.Click += new EventHandler(this.mnuLoadInventory_Click);
      this.mnuExit.Text = "Salir";
      this.mnuExit.Click += new EventHandler(this.mnuExit_Click);
      this.lblDateTimeNow.Font = new Font("Tahoma", 10f, FontStyle.Bold);
      this.lblDateTimeNow.Location = new Point(3, 221);
      this.lblDateTimeNow.Name = "lblDateTimeNow";
      this.lblDateTimeNow.Size = new Size(232, 20);
      this.lblDateTimeNow.Text = "01/01/2016 01:00:00";
      this.lblDateTimeNow.TextAlign = ContentAlignment.TopCenter;
      this.tmrNow.Enabled = true;
      this.tmrNow.Interval = 1000;
      this.tmrNow.Tick += new EventHandler(this.tmrNow_Tick);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.AutoScroll = true;
      ((Control) this).ClientSize = new Size(638, 455);
      this.Controls.Add((Control) this.lblDateTimeNow);
      this.MaximizeBox = false;
      this.Menu = this.mnuMain;
      this.MinimizeBox = false;
      this.Name = nameof (MainForm);
      this.Text = "POS Colector v3.5 :: Su Plaza de Actopan";
      this.WindowState = FormWindowState.Maximized;
      this.Closing += new CancelEventHandler(this.MainForm_Closing);
      this.ResumeLayout(false);
    }
  }
}
