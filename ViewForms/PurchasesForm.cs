// Decompiled with JetBrains decompiler
// Type: POSColector.ViewForms.PurchasesForm
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using POSColector.DAO;
using POSColector.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace POSColector.ViewForms
{
  public class PurchasesForm : Form
  {
    private List<order_detail> orderDetail;
    private IContainer components = (IContainer) null;
    private MainMenu mnuPurchase;
    private MenuItem mnuQueryPurchase;
    private MenuItem mnuExitPurchase;
    private Panel pnlPurchasesOrder;
    private Button cmdStart;
    private Button cmdAdd;
    private TextBox txtCantidadPedida;
    private TextBox txtBarCode;
    private TextBox txtCantidad;
    private TextBox txtDescription;
    private TextBox txtProvider;
    private ComboBox cboUM;
    private ComboBox cboOrder;
    private Label label4;
    private Label label6;
    private Label label5;
    private Label label3;
    private Label label2;
    private Label label1;
    private ListView lstOrderDetail;
    private ColumnHeader cod_barras;
    private ColumnHeader descripcion;
    private ColumnHeader cant_cja;
    private ColumnHeader cant_pzs;
    private ColumnHeader capture;
    private ComboBox comboBox1;

    private Guid id_compra { set; get; }

    private pedido order { set; get; }

    private articulo item { set; get; }

    public PurchasesForm() => this.InitializeComponent();

    private void PurchasesForm_Load(object sender, EventArgs e) => ((ListControl) this.cboOrder).DataSource = (object) new pedidoDAO().getListPedidosAut();

    private void cmdStart_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.cboOrder.SelectedIndex == 0)
          throw new Exception("Debe elegir un pedido.");
        this.id_compra = Guid.NewGuid();
        new compraDAO().insert(compraDAO.Purchase.ByOrder, new compra()
        {
          id_compra = this.id_compra,
          id_pedido = ((pedido) this.cboOrder.SelectedItem).id_pedido,
          fecha_compra = DateTime.Now,
          id_proveedor = ((pedido) this.cboOrder.SelectedItem).id_proveedor
        });
        this.orderDetail = new List<order_detail>();
        this.cmdAdd.Enabled = true;
        this.cmdStart.Enabled = false;
        this.cboOrder.Enabled = false;
        this.txtBarCode.Focus();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Compra por Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
    }

    private void cboOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cboOrder.SelectedIndex != 0)
        this.txtProvider.Text = ((pedido) this.cboOrder.SelectedItem).razon_social;
      else
        this.ResetForm();
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
        if (e.KeyChar == '\r')
        {
          if (this.cboOrder.SelectedIndex == 0)
            throw new Exception("Debe elegir un pedido.");
          Guid idCompra = this.id_compra;
          this.order = (pedido) this.cboOrder.SelectedItem;
          this.item = new pedido_articuloDAO().getArticuloPedido(this.txtBarCode.Text.Trim(), this.order, 1);
          if (this.item == null)
            throw new Exception("El artículo no existe para el pedido actual");
          if (!(this.item.cant_pedida > 0M) && MessageBox.Show("El Articulo no fue Pedido. Desea agregarlo?", "Articulo no Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
          {
            this.txtBarCode.Text = "";
          }
          else
          {
            unidad_medida unidadMedida = new unidad_medidaDAO().getUnidadMedida(this.item.cod_asociado);
            this.txtCantidadPedida.Text = this.item.por_surtir.ToString("G9") + " " + unidadMedida.descripcion;
            this.txtDescription.Text = this.item.descripcion;
            ((ListControl) this.cboUM).DataSource = (object) new pedido_articuloDAO().getUnidadesMedida(this.item);
            this.txtCantidad.Focus();
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Compra por Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        this.txtBarCode.Text = "";
      }
    }

    private void cmdAdd_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.cmdAdd.Enabled)
        {
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
          Decimal num1 = Decimal.Parse(this.txtCantidad.Text.Trim());
          Decimal num2 = this.totalPedido(this.item.cod_barras.Trim(), (unidad_articulo) this.cboUM.SelectedItem, this.item);
          if (num1 > num2)
          {
            if (MessageBox.Show(string.Format("Excedido por {0}. ¿Desea agregar la cantidad?", (object) (num1 - num2).ToString("G9")), "Excedente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
              if (new SecureForm().ShowDialog() != DialogResult.OK)
              {
                this.txtCantidad.SelectAll();
                throw new Exception("Cantidad no autorizada");
              }
            }
            else
            {
              this.newInput();
              return;
            }
          }
          this.orderDetail.Add(new compra_articuloDAO().insertPurchase(new compra_articulo()
          {
            id_compra = this.id_compra,
            item = this.item,
            cantidad = num1,
            precio_compra = this.item.precio_compra,
            medida = (unidad_articulo) this.cboUM.SelectedItem
          }));
          this.showOrderDetail();
          this.newInput();
        }
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
      this.txtCantidadPedida.Text = "";
      this.txtDescription.Text = "";
      this.txtCantidad.Text = "";
      ((ListControl) this.cboUM).DataSource = (object) null;
      this.txtBarCode.Focus();
    }

    private Decimal totalPedido(string barCode, unidad_articulo ua, articulo item) => Enumerable.FirstOrDefault<order_detail>(Enumerable.Where<order_detail>((IEnumerable<order_detail>) this.orderDetail, (Func<order_detail, bool>) (o => o.cod_barras.Equals(barCode)))) != null ? item.por_surtir - Enumerable.FirstOrDefault(Enumerable.Select(Enumerable.GroupBy<order_detail, string>(Enumerable.Where<order_detail>((IEnumerable<order_detail>) this.orderDetail, (Func<order_detail, bool>) (o => o.cod_barras.Equals(barCode))), (Func<order_detail, string>) (o => o.cod_barras)), og =>
    {
      var data = new
      {
        tot = Enumerable.Sum<order_detail>((IEnumerable<order_detail>) og, (Func<order_detail, Decimal>) (o => o.cant_pza))
      };
      return data;
    })).tot / ua.cantidad_um : item.por_surtir;

    private void ResetForm()
    {
      this.cboOrder.SelectedIndex = 0;
      this.cmdAdd.Enabled = false;
      this.cmdStart.Enabled = true;
      this.cboOrder.Enabled = true;
      this.txtProvider.Text = "";
      this.txtBarCode.Text = "";
      this.txtCantidadPedida.Text = "";
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

    private void label2_ParentChanged(object sender, EventArgs e)
    {
    }

    private void txtProvider_TextChanged(object sender, EventArgs e)
    {
    }

    private void label3_ParentChanged(object sender, EventArgs e)
    {
    }

    private void txtBarCode_TextChanged(object sender, EventArgs e)
    {
    }

    private void label4_ParentChanged(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.mnuPurchase = new MainMenu();
      this.mnuQueryPurchase = new MenuItem();
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
      this.txtCantidadPedida = new TextBox();
      this.txtBarCode = new TextBox();
      this.txtCantidad = new TextBox();
      this.txtDescription = new TextBox();
      this.txtProvider = new TextBox();
      this.cboUM = new ComboBox();
      this.cboOrder = new ComboBox();
      this.label4 = new Label();
      this.label6 = new Label();
      this.label5 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.comboBox1 = new ComboBox();
      this.pnlPurchasesOrder.SuspendLayout();
      this.SuspendLayout();
      this.mnuPurchase.MenuItems.Add(this.mnuQueryPurchase);
      this.mnuPurchase.MenuItems.Add(this.mnuExitPurchase);
      this.mnuQueryPurchase.Text = "Ver";
      this.mnuExitPurchase.Text = "Salir";
      this.mnuExitPurchase.Click += new EventHandler(this.mnuExitPurchase_Click);
      this.pnlPurchasesOrder.Controls.Add((Control) this.lstOrderDetail);
      this.pnlPurchasesOrder.Controls.Add((Control) this.cmdStart);
      this.pnlPurchasesOrder.Controls.Add((Control) this.cmdAdd);
      this.pnlPurchasesOrder.Controls.Add((Control) this.txtCantidadPedida);
      this.pnlPurchasesOrder.Controls.Add((Control) this.txtBarCode);
      this.pnlPurchasesOrder.Controls.Add((Control) this.txtCantidad);
      this.pnlPurchasesOrder.Controls.Add((Control) this.txtDescription);
      this.pnlPurchasesOrder.Controls.Add((Control) this.txtProvider);
      this.pnlPurchasesOrder.Controls.Add((Control) this.cboUM);
      this.pnlPurchasesOrder.Controls.Add((Control) this.cboOrder);
      this.pnlPurchasesOrder.Controls.Add((Control) this.label4);
      this.pnlPurchasesOrder.Controls.Add((Control) this.label6);
      this.pnlPurchasesOrder.Controls.Add((Control) this.label5);
      this.pnlPurchasesOrder.Controls.Add((Control) this.label3);
      this.pnlPurchasesOrder.Controls.Add((Control) this.label2);
      this.pnlPurchasesOrder.Controls.Add((Control) this.label1);
      this.pnlPurchasesOrder.Dock = DockStyle.Fill;
      this.pnlPurchasesOrder.Location = new Point(0, 0);
      this.pnlPurchasesOrder.Name = "pnlPurchasesOrder";
      this.pnlPurchasesOrder.Size = new Size(638, 455);
      this.lstOrderDetail.Columns.Add(this.cod_barras);
      this.lstOrderDetail.Columns.Add(this.descripcion);
      this.lstOrderDetail.Columns.Add(this.cant_cja);
      this.lstOrderDetail.Columns.Add(this.cant_pzs);
      this.lstOrderDetail.Columns.Add(this.capture);
      this.lstOrderDetail.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.lstOrderDetail.Location = new Point(3, 113);
      this.lstOrderDetail.Name = "lstOrderDetail";
      this.lstOrderDetail.Size = new Size(232, 126);
      this.lstOrderDetail.TabIndex = 16;
      this.lstOrderDetail.View = View.Details;
      this.cod_barras.Text = "Código";
      this.cod_barras.Width = 58;
      this.descripcion.Text = "Descripción";
      this.descripcion.Width = 108;
      this.cant_cja.Text = "Cja";
      this.cant_cja.TextAlign = HorizontalAlignment.Center;
      this.cant_cja.Width = 31;
      this.cant_pzs.Text = "Pza";
      this.cant_pzs.TextAlign = HorizontalAlignment.Center;
      this.cant_pzs.Width = 31;
      this.capture.Text = "Captura";
      this.capture.Width = 0;
      this.cmdStart.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.cmdStart.Location = new Point(147, 2);
      this.cmdStart.Name = "cmdStart";
      this.cmdStart.Size = new Size(87, 21);
      this.cmdStart.TabIndex = 8;
      this.cmdStart.Text = "Iniciar captura";
      this.cmdStart.Click += new EventHandler(this.cmdStart_Click);
      this.cmdAdd.Enabled = false;
      this.cmdAdd.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.cmdAdd.Location = new Point(187, 91);
      this.cmdAdd.Name = "cmdAdd";
      this.cmdAdd.Size = new Size(47, 19);
      this.cmdAdd.TabIndex = 8;
      this.cmdAdd.Text = "Anexar";
      this.cmdAdd.Click += new EventHandler(this.cmdAdd_Click);
      this.txtCantidadPedida.BackColor = SystemColors.ControlLight;
      this.txtCantidadPedida.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.txtCantidadPedida.Location = new Point(181, 47);
      this.txtCantidadPedida.Name = "txtCantidadPedida";
      this.txtCantidadPedida.ReadOnly = true;
      this.txtCantidadPedida.Size = new Size(53, 19);
      this.txtCantidadPedida.TabIndex = 4;
      this.txtBarCode.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.txtBarCode.Location = new Point(41, 47);
      this.txtBarCode.MaxLength = 15;
      this.txtBarCode.Name = "txtBarCode";
      this.txtBarCode.Size = new Size(89, 19);
      this.txtBarCode.TabIndex = 4;
      this.txtBarCode.TextChanged += new EventHandler(this.txtBarCode_TextChanged);
      this.txtBarCode.KeyDown += new KeyEventHandler(this.txtBarCode_KeyDown);
      this.txtBarCode.KeyPress += new KeyPressEventHandler(this.txtBarCode_KeyPress);
      this.txtCantidad.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.txtCantidad.Location = new Point(41, 91);
      this.txtCantidad.MaxLength = 7;
      this.txtCantidad.Name = "txtCantidad";
      this.txtCantidad.Size = new Size(67, 19);
      this.txtCantidad.TabIndex = 4;
      this.txtCantidad.KeyDown += new KeyEventHandler(this.txtCantidad_KeyDown);
      this.txtCantidad.KeyPress += new KeyPressEventHandler(this.txtCantidad_KeyPress);
      this.txtDescription.BackColor = SystemColors.ControlLight;
      this.txtDescription.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.txtDescription.Location = new Point(41, 69);
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.ReadOnly = true;
      this.txtDescription.Size = new Size(193, 19);
      this.txtDescription.TabIndex = 4;
      this.txtProvider.BackColor = Color.FromArgb(224, 224, 224);
      this.txtProvider.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.txtProvider.Location = new Point(41, 25);
      this.txtProvider.Name = "txtProvider";
      this.txtProvider.ReadOnly = true;
      this.txtProvider.Size = new Size(192, 19);
      this.txtProvider.TabIndex = 4;
      this.txtProvider.TextChanged += new EventHandler(this.txtProvider_TextChanged);
      this.cboUM.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.cboUM.Location = new Point(111, 91);
      this.cboUM.Name = "cboUM";
      this.cboUM.Size = new Size(73, 19);
      this.cboUM.TabIndex = 1;
      this.cboOrder.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.cboOrder.Location = new Point(41, 2);
      this.cboOrder.Name = "cboOrder";
      this.cboOrder.Size = new Size(103, 19);
      this.cboOrder.TabIndex = 1;
      this.cboOrder.SelectedIndexChanged += new EventHandler(this.cboOrder_SelectedIndexChanged);
      this.label4.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.label4.Location = new Point(131, 48);
      this.label4.Name = "label4";
      this.label4.Size = new Size(60, 13);
      this.label4.Text = "Se pidió:";
      this.label4.ParentChanged += new EventHandler(this.label4_ParentChanged);
      this.label6.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.label6.Location = new Point(7, 92);
      this.label6.Name = "label6";
      this.label6.Size = new Size(41, 13);
      this.label6.Text = "Cant:";
      this.label5.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.label5.Location = new Point(7, 70);
      this.label5.Name = "label5";
      this.label5.Size = new Size(41, 13);
      this.label5.Text = "Desc:";
      this.label3.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.label3.Location = new Point(7, 48);
      this.label3.Name = "label3";
      this.label3.Size = new Size(41, 13);
      this.label3.Text = "C.B.:";
      this.label3.ParentChanged += new EventHandler(this.label3_ParentChanged);
      this.label2.Font = new Font("Tahoma", 8f, FontStyle.Regular);
      this.label2.Location = new Point(7, 26);
      this.label2.Name = "label2";
      this.label2.Size = new Size(41, 20);
      this.label2.Text = "Pro:";
      this.label2.ParentChanged += new EventHandler(this.label2_ParentChanged);
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
      ((Control) this).ClientSize = new Size(638, 455);
      this.Controls.Add((Control) this.pnlPurchasesOrder);
      this.MaximizeBox = false;
      this.Menu = this.mnuPurchase;
      this.MinimizeBox = false;
      this.Name = nameof (PurchasesForm);
      this.Text = "Compra por Pedido";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.PurchasesForm_Load);
      this.Closing += new CancelEventHandler(this.PurchasesForm_Closing);
      this.pnlPurchasesOrder.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
