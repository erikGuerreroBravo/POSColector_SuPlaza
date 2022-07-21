// Decompiled with JetBrains decompiler
// Type: POSColector.ViewForms.PurchasesFreeForm
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
  public class PurchasesFreeForm : Form
  {
    private IContainer components = (IContainer) null;
    private MainMenu mnuPurchase;
    private MenuItem mnuExitPurchase;
    private Panel pnlPurchasesOrder;
    private Button cmdStart;
    private Button cmdAdd;
    private TextBox txtBarCode;
    private TextBox txtCantidad;
    private TextBox txtDescription;
    private ComboBox cboUM;
    private Label label6;
    private Label label5;
    private Label label3;
    private ListView lstOrderDetail;
    private ColumnHeader cod_barras;
    private ColumnHeader descripcion;
    private ColumnHeader cant_cja;
    private ColumnHeader cant_pzs;
    private ColumnHeader capture;
    private ComboBox comboBox1;
    private List<order_detail> orderDetail;

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
      this.lstOrderDetail = new ListView();
      this.cod_barras = new ColumnHeader();
      this.descripcion = new ColumnHeader();
      this.cant_cja = new ColumnHeader();
      this.cant_pzs = new ColumnHeader();
      this.capture = new ColumnHeader();
      this.cmdStart = new Button();
      this.cmdAdd = new Button();
      this.txtBarCode = new TextBox();
      this.txtCantidad = new TextBox();
      this.txtDescription = new TextBox();
      this.cboUM = new ComboBox();
      this.label6 = new Label();
      this.label5 = new Label();
      this.label3 = new Label();
      this.comboBox1 = new ComboBox();
      this.pnlPurchasesOrder.SuspendLayout();
      this.SuspendLayout();
      this.mnuPurchase.MenuItems.Add(this.mnuExitPurchase);
      this.mnuExitPurchase.Text = "Salir";
      this.mnuExitPurchase.Click += new EventHandler(this.mnuExitPurchase_Click);
      this.pnlPurchasesOrder.Controls.Add((Control) this.lstOrderDetail);
      this.pnlPurchasesOrder.Controls.Add((Control) this.cmdStart);
      this.pnlPurchasesOrder.Controls.Add((Control) this.cmdAdd);
      this.pnlPurchasesOrder.Controls.Add((Control) this.txtBarCode);
      this.pnlPurchasesOrder.Controls.Add((Control) this.txtCantidad);
      this.pnlPurchasesOrder.Controls.Add((Control) this.txtDescription);
      this.pnlPurchasesOrder.Controls.Add((Control) this.cboUM);
      this.pnlPurchasesOrder.Controls.Add((Control) this.label6);
      this.pnlPurchasesOrder.Controls.Add((Control) this.label5);
      this.pnlPurchasesOrder.Controls.Add((Control) this.label3);
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
      this.lstOrderDetail.Location = new Point(3, 70);
      this.lstOrderDetail.Name = "lstOrderDetail";
      this.lstOrderDetail.Size = new Size(233, 169);
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
      this.cmdStart.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.cmdStart.Location = new Point(154, 2);
      this.cmdStart.Name = "cmdStart";
      this.cmdStart.Size = new Size(82, 20);
      this.cmdStart.TabIndex = 8;
      this.cmdStart.Text = "Iniciar captura";
      this.cmdStart.Click += new EventHandler(this.cmdStart_Click);
      this.cmdAdd.Enabled = false;
      this.cmdAdd.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.cmdAdd.Location = new Point(191, 47);
      this.cmdAdd.Name = "cmdAdd";
      this.cmdAdd.Size = new Size(43, 20);
      this.cmdAdd.TabIndex = 8;
      this.cmdAdd.Text = "Anexar";
      this.cmdAdd.Click += new EventHandler(this.cmdAdd_Click);
      this.txtBarCode.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.txtBarCode.Location = new Point(37, 2);
      this.txtBarCode.MaxLength = 15;
      this.txtBarCode.Name = "txtBarCode";
      this.txtBarCode.Size = new Size(115, 19);
      this.txtBarCode.TabIndex = 4;
      this.txtBarCode.KeyDown += new KeyEventHandler(this.txtBarCode_KeyDown);
      this.txtBarCode.KeyPress += new KeyPressEventHandler(this.txtBarCode_KeyPress);
      this.txtCantidad.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.txtCantidad.Location = new Point(37, 47);
      this.txtCantidad.MaxLength = 7;
      this.txtCantidad.Name = "txtCantidad";
      this.txtCantidad.Size = new Size(75, 19);
      this.txtCantidad.TabIndex = 4;
      this.txtCantidad.KeyDown += new KeyEventHandler(this.txtCantidad_KeyDown);
      this.txtCantidad.KeyPress += new KeyPressEventHandler(this.txtCantidad_KeyPress);
      this.txtDescription.BackColor = SystemColors.ControlLight;
      this.txtDescription.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.txtDescription.Location = new Point(37, 25);
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.ReadOnly = true;
      this.txtDescription.Size = new Size(198, 19);
      this.txtDescription.TabIndex = 4;
      this.cboUM.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.cboUM.Location = new Point(114, 47);
      this.cboUM.Name = "cboUM";
      this.cboUM.Size = new Size(75, 19);
      this.cboUM.TabIndex = 1;
      this.label6.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.label6.Location = new Point(5, 48);
      this.label6.Name = "label6";
      this.label6.Size = new Size(41, 20);
      this.label6.Text = "Cant:";
      this.label5.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.label5.Location = new Point(5, 26);
      this.label5.Name = "label5";
      this.label5.Size = new Size(41, 20);
      this.label5.Text = "Desc:";
      this.label3.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.label3.Location = new Point(5, 3);
      this.label3.Name = "label3";
      this.label3.Size = new Size(41, 20);
      this.label3.Text = "C.B.:";
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
      this.Name = nameof (PurchasesFreeForm);
      this.Text = "Compra Libre";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.PurchasesForm_Load);
      this.Closing += new CancelEventHandler(this.PurchasesForm_Closing);
      this.pnlPurchasesOrder.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private Guid id_compra { set; get; }

    private pedido order { set; get; }

    private articulo item { set; get; }

    public PurchasesFreeForm() => this.InitializeComponent();

    private void PurchasesForm_Load(object sender, EventArgs e)
    {
    }

    private void cmdStart_Click(object sender, EventArgs e)
    {
      try
      {
        this.id_compra = Guid.NewGuid();
        new compraDAO().insert(compraDAO.Purchase.Free, new compra()
        {
          id_compra = this.id_compra,
          fecha_compra = DateTime.Now
        });
        this.orderDetail = new List<order_detail>();
        this.cmdAdd.Enabled = true;
        this.cmdStart.Enabled = false;
        this.txtBarCode.Focus();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Compra por Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        switch (e.KeyCode)
        {
          case Keys.F5:
            if (this.lstOrderDetail.Items.Count <= 0)
              break;
            this.txtBarCode.Text = this.lstOrderDetail.Items[this.lstOrderDetail.Items.Count - 1].Text;
            break;
          case Keys.F10:
            if (this.lstOrderDetail.Items.Count <= 0)
              throw new Exception("No hay registros por eliminar");
            new compra_articuloDAO().deleteLastItemPurchase(this.id_compra);
            this.orderDetail.RemoveAt(this.orderDetail.Count - 1);
            this.lstOrderDetail.Items.RemoveAt(this.lstOrderDetail.Items.Count - 1);
            break;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Compra por Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
    {
      try
      {
        if (e.KeyChar != '\r')
          return;
        if (this.id_compra.Equals(new Guid()))
          throw new Exception("Debe iniciar la captura");
        this.item = new articuloDAO().getArticulo(this.txtBarCode.Text.Trim(), 1);
        this.txtDescription.Text = this.item != null ? this.item.descripcion : throw new Exception("El artículo no existe");
        ((ListControl) this.cboUM).DataSource = (object) new articuloDAO().getUnidadesMedida(this.item.cod_asociado);
        this.txtCantidad.Focus();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Compra por Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void cmdAdd_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.cmdAdd.Enabled)
          return;
        if (this.item == null)
        {
          this.txtBarCode.Focus();
          throw new Exception("Debe ingresar un código");
        }
        if (this.txtCantidad.Text.Trim().Length == 0)
        {
          this.txtCantidad.Focus();
          throw new Exception("Debe ingresar una cantidad");
        }
        this.orderDetail.Add(new compra_articuloDAO().insert(new compra_articulo()
        {
          id_compra = this.id_compra,
          item = this.item,
          cantidad = Decimal.Parse(this.txtCantidad.Text.Trim()),
          precio_compra = this.item.precio_compra,
          medida = (unidad_articulo) this.cboUM.SelectedItem
        }));
        this.showOrderDetail();
        this.newInput();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Compra por Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void showOrderDetail()
    {
      this.lstOrderDetail.Items.Clear();
      foreach (order_detail orderDetail in this.orderDetail)
        this.lstOrderDetail.Items.Add(new ListViewItem(new string[4]
        {
          orderDetail.cod_barras,
          orderDetail.descripcion,
          orderDetail.cant_cja.ToString("G9"),
          orderDetail.cant_pza.ToString("G9")
        }));
    }

    private void newInput()
    {
      this.item = (articulo) null;
      this.txtBarCode.Text = "";
      this.txtDescription.Text = "";
      this.txtCantidad.Text = "";
      ((ListControl) this.cboUM).DataSource = (object) null;
      this.txtBarCode.Focus();
    }

    private void ResetForm()
    {
      this.cmdAdd.Enabled = false;
      this.cmdStart.Enabled = true;
      this.txtBarCode.Text = "";
      this.txtDescription.Text = "";
      this.txtCantidad.Text = "";
      ((ListControl) this.cboUM).DataSource = (object) null;
      this.lstOrderDetail.Items.Clear();
      this.id_compra = new Guid();
    }

    private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (((ListControl) this.cboUM).DataSource != null)
      {
        if (((unidad_articulo) this.cboUM.SelectedItem).descripcion.Equals("Kg") || ((unidad_articulo) this.cboUM.SelectedItem).descripcion.Equals("Gms"))
          e.Handled = !char.IsNumber(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b';
        else
          e.Handled = !char.IsNumber(e.KeyChar) && e.KeyChar != '\b';
      }
      else
        e.Handled = true;
    }

    private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Return:
          this.cmdAdd_Click(sender, (EventArgs) e);
          return;
        case Keys.F1:
          if (this.txtCantidad.Text.Equals(""))
          {
            this.txtCantidad.Text = "-";
            break;
          }
          if (this.txtCantidad.Text.Length > 1)
          {
            this.txtCantidad.Text = "-" + this.txtCantidad.Text.Replace("-", "");
            break;
          }
          break;
      }
      this.txtCantidad.Focus();
      this.txtCantidad.SelectionStart = this.txtCantidad.Text.Length;
    }

    private void mnuExitPurchase_Click(object sender, EventArgs e) => this.Close();

    private void PurchasesForm_Closing(object sender, CancelEventArgs e)
    {
      if (MessageBox.Show("Desea salir?", "Compra abierta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        e.Cancel = false;
      else
        e.Cancel = true;
    }
  }
}
