// Decompiled with JetBrains decompiler
// Type: POSColector.ViewForms.ShowInventoryForm
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
  public class ShowInventoryForm : Form
  {
    private IContainer components = (IContainer) null;
    private MainMenu mnuPurchase;
    private MenuItem mnuExitPurchase;
    private Panel pnlPurchasesOrder;
    private TextBox txtDescription;
    private Label label5;
    private ListView lstOrderDetail;
    private ColumnHeader cod_barras;
    private ColumnHeader descripcion;
    private ColumnHeader cant_cja;
    private ColumnHeader cant_pzs;
    private ColumnHeader capture;
    private ComboBox comboBox1;
    private Label label1;
    private ComboBox cboInventory;
    private Button cmdDeleteInventory;
    private List<inventario_articulo> inventoryDetail;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.mnuPurchase = new MainMenu();
      this.mnuExitPurchase = new MenuItem();
      this.pnlPurchasesOrder = new Panel();
      this.cmdDeleteInventory = new Button();
      this.label1 = new Label();
      this.lstOrderDetail = new ListView();
      this.cod_barras = new ColumnHeader();
      this.descripcion = new ColumnHeader();
      this.cant_cja = new ColumnHeader();
      this.cant_pzs = new ColumnHeader();
      this.capture = new ColumnHeader();
      this.txtDescription = new TextBox();
      this.cboInventory = new ComboBox();
      this.label5 = new Label();
      this.comboBox1 = new ComboBox();
      this.pnlPurchasesOrder.SuspendLayout();
      this.SuspendLayout();
      this.mnuPurchase.MenuItems.Add(this.mnuExitPurchase);
      this.mnuExitPurchase.Text = "Salir";
      this.mnuExitPurchase.Click += new EventHandler(this.mnuExitPurchase_Click);
      this.pnlPurchasesOrder.Controls.Add((Control) this.cmdDeleteInventory);
      this.pnlPurchasesOrder.Controls.Add((Control) this.label1);
      this.pnlPurchasesOrder.Controls.Add((Control) this.lstOrderDetail);
      this.pnlPurchasesOrder.Controls.Add((Control) this.txtDescription);
      this.pnlPurchasesOrder.Controls.Add((Control) this.cboInventory);
      this.pnlPurchasesOrder.Controls.Add((Control) this.label5);
      this.pnlPurchasesOrder.Dock = DockStyle.Fill;
      this.pnlPurchasesOrder.Location = new Point(0, 0);
      this.pnlPurchasesOrder.Name = "pnlPurchasesOrder";
      this.pnlPurchasesOrder.Size = new Size(638, 455);
      this.cmdDeleteInventory.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.cmdDeleteInventory.Location = new Point(132, 26);
      this.cmdDeleteInventory.Name = "cmdDeleteInventory";
      this.cmdDeleteInventory.Size = new Size(103, 19);
      this.cmdDeleteInventory.TabIndex = 18;
      this.cmdDeleteInventory.Text = "Eliminar Inventario";
      this.cmdDeleteInventory.Click += new EventHandler(this.cmdDeleteInventory_Click);
      this.label1.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.label1.Location = new Point(5, 4);
      this.label1.Name = "label1";
      this.label1.Size = new Size(32, 20);
      this.label1.Text = "Prov:";
      this.lstOrderDetail.Columns.Add(this.cod_barras);
      this.lstOrderDetail.Columns.Add(this.descripcion);
      this.lstOrderDetail.Columns.Add(this.cant_cja);
      this.lstOrderDetail.Columns.Add(this.cant_pzs);
      this.lstOrderDetail.Columns.Add(this.capture);
      this.lstOrderDetail.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.lstOrderDetail.Location = new Point(3, 48);
      this.lstOrderDetail.Name = "lstOrderDetail";
      this.lstOrderDetail.Size = new Size(233, 192);
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
      this.txtDescription.BackColor = SystemColors.ControlLight;
      this.txtDescription.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.txtDescription.Location = new Point(39, 26);
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.ReadOnly = true;
      this.txtDescription.Size = new Size(91, 19);
      this.txtDescription.TabIndex = 4;
      this.txtDescription.Text = "0.00";
      this.cboInventory.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.cboInventory.Location = new Point(39, 3);
      this.cboInventory.Name = "cboInventory";
      this.cboInventory.Size = new Size(197, 19);
      this.cboInventory.TabIndex = 4;
      this.cboInventory.SelectedIndexChanged += new EventHandler(this.cboInventory_SelectedIndexChanged);
      this.label5.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.label5.Location = new Point(5, 27);
      this.label5.Name = "label5";
      this.label5.Size = new Size(32, 20);
      this.label5.Text = "Pzas:";
      this.comboBox1.Location = new Point(0, 0);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(100, 23);
      this.comboBox1.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.AutoScroll = true;
      ((Control) this).ClientSize = new Size(638, 455);
      this.Controls.Add((Control) this.pnlPurchasesOrder);
      this.MaximizeBox = false;
      this.Menu = this.mnuPurchase;
      this.MinimizeBox = false;
      this.Name = nameof (ShowInventoryForm);
      this.Text = "Consultar Inventario";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.PurchasesForm_Load);
      this.Closing += new CancelEventHandler(this.PurchasesForm_Closing);
      this.pnlPurchasesOrder.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public ShowInventoryForm() => this.InitializeComponent();

    private void PurchasesForm_Load(object sender, EventArgs e) => ((ListControl) this.cboInventory).DataSource = (object) new inventarioDAO().getInventories();

    private void cboInventory_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        if (this.cboInventory.SelectedIndex > 0)
        {
          this.inventoryDetail = new inventarioDAO().getInventoryDetail(((inventario) this.cboInventory.SelectedItem).id_inventario);
          if (this.inventoryDetail == null)
            throw new Exception("No hay registros para éste Inventario");
          this.showDetail();
        }
        else
          this.ResetForm();
        this.cmdDeleteInventory.Enabled = this.cboInventory.SelectedIndex > 0;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Consultar Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void showDetail()
    {
      this.lstOrderDetail.Items.Clear();
      Decimal num1 = 0.0M;
      foreach (inventario_articulo inventarioArticulo in this.inventoryDetail)
      {
        ListView.ListViewItemCollection items1 = this.lstOrderDetail.Items;
        string[] items2 = new string[4]
        {
          inventarioArticulo.cod_barras,
          inventarioArticulo.descripcion,
          null,
          null
        };
        string[] strArray1 = items2;
        Decimal num2 = inventarioArticulo.cant_cja;
        string str1 = num2.ToString("G9");
        strArray1[2] = str1;
        string[] strArray2 = items2;
        num2 = inventarioArticulo.cant_pza;
        string str2 = num2.ToString("G9");
        strArray2[3] = str2;
        ListViewItem listViewItem = new ListViewItem(items2);
        items1.Add(listViewItem);
        num1 += inventarioArticulo.cant_pza;
      }
      this.txtDescription.Text = num1.ToString("F2");
    }

    private void ResetForm()
    {
      this.txtDescription.Text = "0.00";
      this.lstOrderDetail.Items.Clear();
      this.inventoryDetail = (List<inventario_articulo>) null;
    }

    private void mnuExitPurchase_Click(object sender, EventArgs e) => this.Close();

    private void PurchasesForm_Closing(object sender, CancelEventArgs e)
    {
      if (MessageBox.Show("Desea salir?", "Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        e.Cancel = false;
      else
        e.Cancel = true;
    }

    private void cmdDeleteInventory_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.cboInventory.SelectedIndex <= 0 || MessageBox.Show("Desea eliminar el inventario?", "Inventarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
          return;
        new inventarioDAO().deleteInventory(((inventario) this.cboInventory.SelectedItem).id_inventario);
        ((ListControl) this.cboInventory).DataSource = (object) new inventarioDAO().getInventories();
        this.ResetForm();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Eliminación de Inventarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }
  }
}
