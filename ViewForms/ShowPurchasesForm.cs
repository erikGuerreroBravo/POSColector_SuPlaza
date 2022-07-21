// Decompiled with JetBrains decompiler
// Type: POSColector.ViewForms.ShowPurchasesForm
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using POSColector.DAO;
using POSColector.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace POSColector.ViewForms
{
  public class ShowPurchasesForm : Form
  {
    private IContainer components = (IContainer) null;
    private MainMenu mnuPurchase;
    private MenuItem mnuExitPurchase;
    private Panel pnlPurchasesOrder;
    private TextBox txtProvider;
    private ComboBox cboOrder;
    private Label label2;
    private Label label1;
    private ListView lstOrderDetail;
    private ColumnHeader cod_barras;
    private ColumnHeader descripcion;
    private ColumnHeader cant_cja;
    private ColumnHeader cant_pzs;
    private ColumnHeader capture;
    private ComboBox comboBox1;
    private ComboBox cboCaptura;
    private Label label3;
    private MenuItem mnuDelete;
    private MenuItem mnuDeleteOrder;
    private MenuItem mnuDeletePurchase;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.mnuPurchase = new MainMenu();
      this.mnuDelete = new MenuItem();
      this.mnuDeleteOrder = new MenuItem();
      this.mnuDeletePurchase = new MenuItem();
      this.mnuExitPurchase = new MenuItem();
      this.pnlPurchasesOrder = new Panel();
      this.lstOrderDetail = new ListView();
      this.cod_barras = new ColumnHeader();
      this.descripcion = new ColumnHeader();
      this.cant_cja = new ColumnHeader();
      this.cant_pzs = new ColumnHeader();
      this.capture = new ColumnHeader();
      this.txtProvider = new TextBox();
      this.cboCaptura = new ComboBox();
      this.cboOrder = new ComboBox();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.comboBox1 = new ComboBox();
      this.pnlPurchasesOrder.SuspendLayout();
      this.SuspendLayout();
      this.mnuPurchase.MenuItems.Add(this.mnuDelete);
      this.mnuPurchase.MenuItems.Add(this.mnuExitPurchase);
      this.mnuDelete.MenuItems.Add(this.mnuDeleteOrder);
      this.mnuDelete.MenuItems.Add(this.mnuDeletePurchase);
      this.mnuDelete.Text = "Eliminar";
      this.mnuDeleteOrder.Text = "Pedido";
      this.mnuDeleteOrder.Click += new EventHandler(this.mnuDeleteOrder_Click);
      this.mnuDeletePurchase.Text = "Compra";
      this.mnuDeletePurchase.Click += new EventHandler(this.mnuDeletePurchase_Click);
      this.mnuExitPurchase.Text = "Salir";
      this.mnuExitPurchase.Click += new EventHandler(this.mnuExitPurchase_Click);
      this.pnlPurchasesOrder.Controls.Add((Control) this.lstOrderDetail);
      this.pnlPurchasesOrder.Controls.Add((Control) this.txtProvider);
      this.pnlPurchasesOrder.Controls.Add((Control) this.cboCaptura);
      this.pnlPurchasesOrder.Controls.Add((Control) this.cboOrder);
      this.pnlPurchasesOrder.Controls.Add((Control) this.label3);
      this.pnlPurchasesOrder.Controls.Add((Control) this.label2);
      this.pnlPurchasesOrder.Controls.Add((Control) this.label1);
      this.pnlPurchasesOrder.Dock = DockStyle.Fill;
      this.pnlPurchasesOrder.Location = new Point(0, 0);
      this.pnlPurchasesOrder.Name = "pnlPurchasesOrder";
      this.pnlPurchasesOrder.Size = new Size(238, 242);
      this.lstOrderDetail.Columns.Add(this.cod_barras);
      this.lstOrderDetail.Columns.Add(this.descripcion);
      this.lstOrderDetail.Columns.Add(this.cant_cja);
      this.lstOrderDetail.Columns.Add(this.cant_pzs);
      this.lstOrderDetail.Columns.Add(this.capture);
      this.lstOrderDetail.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.lstOrderDetail.Location = new Point(3, 48);
      this.lstOrderDetail.Name = "lstOrderDetail";
      this.lstOrderDetail.Size = new Size(232, 191);
      this.lstOrderDetail.TabIndex = 16;
      this.lstOrderDetail.View = View.Details;
      this.cod_barras.Text = "Código";
      this.cod_barras.Width = 80;
      this.descripcion.Text = "Descripción";
      this.descripcion.Width = 130;
      this.cant_cja.Text = "Cja";
      this.cant_cja.TextAlign = HorizontalAlignment.Center;
      this.cant_cja.Width = 40;
      this.cant_pzs.Text = "Pza";
      this.cant_pzs.TextAlign = HorizontalAlignment.Center;
      this.cant_pzs.Width = 60;
      this.capture.Text = "Captura";
      this.capture.Width = 0;
      this.txtProvider.BackColor = Color.FromArgb(224, 224, 224);
      this.txtProvider.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.txtProvider.Location = new Point(35, 25);
      this.txtProvider.Name = "txtProvider";
      this.txtProvider.ReadOnly = true;
      this.txtProvider.Size = new Size(201, 19);
      this.txtProvider.TabIndex = 4;
      this.cboCaptura.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.cboCaptura.Location = new Point(148, 2);
      this.cboCaptura.Name = "cboCaptura";
      this.cboCaptura.Size = new Size(89, 19);
      this.cboCaptura.TabIndex = 1;
      this.cboCaptura.SelectedIndexChanged += new EventHandler(this.cboCaptura_SelectedIndexChanged);
      this.cboOrder.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.cboOrder.Location = new Point(35, 2);
      this.cboOrder.Name = "cboOrder";
      this.cboOrder.Size = new Size(85, 19);
      this.cboOrder.TabIndex = 1;
      this.cboOrder.SelectedIndexChanged += new EventHandler(this.cboOrder_SelectedIndexChanged);
      this.label3.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.label3.Location = new Point(121, 4);
      this.label3.Name = "label3";
      this.label3.Size = new Size(26, 20);
      this.label3.Text = "Cap:";
      this.label2.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.label2.Location = new Point(7, 26);
      this.label2.Name = "label2";
      this.label2.Size = new Size(41, 20);
      this.label2.Text = "Pro:";
      this.label1.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.label1.Location = new Point(7, 3);
      this.label1.Name = "label1";
      this.label1.Size = new Size(41, 20);
      this.label1.Text = "Ped:";
      this.comboBox1.Location = new Point(0, 0);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(100, 23);
      this.comboBox1.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.AutoScroll = true;
      ((Control) this).ClientSize = new Size(238, 242);
      this.Controls.Add((Control) this.pnlPurchasesOrder);
      this.MaximizeBox = false;
      this.Menu = this.mnuPurchase;
      this.MinimizeBox = false;
      this.Name = nameof (ShowPurchasesForm);
      this.Text = "Compra por Pedido";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.PurchasesForm_Load);
      this.Closing += new CancelEventHandler(this.PurchasesForm_Closing);
      this.pnlPurchasesOrder.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public string option { set; get; }

    public ShowPurchasesForm(ShowPurchasesForm.PurchaseMethod p)
    {
      this.InitializeComponent();
      switch (p)
      {
        case ShowPurchasesForm.PurchaseMethod.ByOrder:
          this.cboOrder.Visible = true;
          this.txtProvider.Visible = true;
          this.label1.Visible = true;
          this.label2.Visible = true;
          this.lstOrderDetail.Location.Offset(3, 52);
          this.lstOrderDetail.Height = 217;
          ((ListControl) this.cboOrder).DataSource = (object) new pedidoDAO().getListPedidosCap();
          this.option = "Compra por Pedido";
          break;
        case ShowPurchasesForm.PurchaseMethod.Free:
          this.cboOrder.Visible = false;
          this.txtProvider.Visible = false;
          this.label1.Visible = false;
          this.label2.Visible = false;
          this.lstOrderDetail.Location.Offset(3, 27);
          this.lstOrderDetail.Height = 192;
          this.mnuDeleteOrder.Enabled = false;
          ((ListControl) this.cboCaptura).DataSource = (object) new compraDAO().getComprasAbiertasCap();
          this.option = "Compra Abierta";
          break;
      }
    }

    private void PurchasesForm_Load(object sender, EventArgs e)
    {
    }

    private void cboOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.cboOrder.SelectedIndex > 0)
        {
          this.txtProvider.Text = ((pedido) this.cboOrder.SelectedItem).razon_social;
          ((ListControl) this.cboCaptura).DataSource = (object) new compraDAO().getListComprasCap(((pedido) this.cboOrder.SelectedItem).id_pedido);
        }
        else
          this.ResetForm(sender);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Consultar Compras por Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void cboCaptura_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.cboCaptura.SelectedIndex > 0)
          this.showOrderDetail(((compra) this.cboCaptura.SelectedItem).id_compra);
        else
          this.ResetForm(sender);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Consultar Compras por Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void showOrderDetail(Guid id_compra)
    {
      try
      {
        this.lstOrderDetail.Items.Clear();
        List<order_detail> purchaseDetail = new compra_articuloDAO().getPurchaseDetail(id_compra);
        if (purchaseDetail != null)
        {
          foreach (order_detail orderDetail in purchaseDetail)
          {
            ListView.ListViewItemCollection items1 = this.lstOrderDetail.Items;
            string[] items2 = new string[4]
            {
              orderDetail.cod_barras,
              orderDetail.descripcion,
              null,
              null
            };
            string[] strArray1 = items2;
            Decimal num = orderDetail.cant_cja;
            string str1 = num.ToString("G9");
            strArray1[2] = str1;
            string[] strArray2 = items2;
            num = orderDetail.cant_pza;
            string str2 = num.ToString("G9");
            strArray2[3] = str2;
            ListViewItem listViewItem = new ListViewItem(items2);
            items1.Add(listViewItem);
          }
        }
        else
        {
          int num1 = (int) MessageBox.Show("La Captura indicada no tiene artículos", "Consultar Compras por Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Consultar Compras por Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void ResetForm(object sender)
    {
      if (((Control) sender).Name.Equals("cboOrder"))
      {
        this.txtProvider.Text = "";
        ((ListControl) this.cboCaptura).DataSource = (object) null;
        this.lstOrderDetail.Items.Clear();
      }
      else
        this.lstOrderDetail.Items.Clear();
    }

    private void mnuDeleteOrder_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.cboOrder.SelectedIndex <= 0)
          throw new Exception("Debe elegir un Pedido");
        if (MessageBox.Show("Desea eliminar el Pedido?\n\rEsta acción eliminará todas las compras vinculadas", "Consultar Compras por Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
          return;
        new pedidoDAO().deleteOrder(((pedido) this.cboOrder.SelectedValue).id_pedido);
        ((ListControl) this.cboOrder).DataSource = (object) new pedidoDAO().getListPedidosCap();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Consultar Compras por Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void mnuDeletePurchase_Click(object sender, EventArgs e)
    {
      try
      {
        if (((ListControl) this.cboCaptura).DataSource == null)
          return;
        if (this.cboCaptura.SelectedIndex <= 0)
          throw new Exception("Debe elegir una Compra");
        if (MessageBox.Show("Desea eliminar la Compra?", "Consultar " + this.option, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        {
          new compraDAO().deletePurchase(((compra) this.cboCaptura.SelectedValue).id_compra);
          ((ListControl) this.cboCaptura).DataSource = (object) new compraDAO().getComprasAbiertasCap();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Consultar Compras por Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void mnuExitPurchase_Click(object sender, EventArgs e) => this.Close();

    private void PurchasesForm_Closing(object sender, CancelEventArgs e)
    {
      if (MessageBox.Show("Desea salir?", "Compra abierta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        e.Cancel = false;
      else
        e.Cancel = true;
    }

    public enum PurchaseMethod
    {
      ByOrder,
      Free,
    }
  }
}
