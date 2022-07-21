// Decompiled with JetBrains decompiler
// Type: POSColector.ViewForms.SecureForm
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
  public class SecureForm : Form
  {
    private IContainer components = (IContainer) null;
    private MainMenu mainMenu1;
    private TextBox txtPassword;
    private Label label1;
    private Button cmdAuth;
    private Button cmbCancelar;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.mainMenu1 = new MainMenu();
      this.txtPassword = new TextBox();
      this.label1 = new Label();
      this.cmdAuth = new Button();
      this.cmbCancelar = new Button();
      this.SuspendLayout();
      this.txtPassword.Location = new Point(3, 33);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new Size(220, 23);
      this.txtPassword.TabIndex = 0;
      this.label1.Location = new Point(4, 7);
      this.label1.Name = "label1";
      this.label1.Size = new Size(149, 20);
      this.label1.Text = "Ingrese su contraseña:";
      this.cmdAuth.Location = new Point(26, 69);
      this.cmdAuth.Name = "cmdAuth";
      this.cmdAuth.Size = new Size(72, 20);
      this.cmdAuth.TabIndex = 2;
      this.cmdAuth.Text = "Autorizar";
      this.cmdAuth.Click += new EventHandler(this.cmdAuth_Click);
      this.cmbCancelar.Location = new Point(117, 69);
      this.cmbCancelar.Name = "cmbCancelar";
      this.cmbCancelar.Size = new Size(72, 20);
      this.cmbCancelar.TabIndex = 2;
      this.cmbCancelar.Text = "Cancelar";
      this.cmbCancelar.Click += new EventHandler(this.cmbCancelar_Click);
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      ((Control) this).ClientSize = new Size(226, 101);
      this.ControlBox = false;
      this.Controls.Add((Control) this.cmbCancelar);
      this.Controls.Add((Control) this.cmdAuth);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.txtPassword);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (SecureForm);
      this.Text = nameof (SecureForm);
      this.ResumeLayout(false);
    }

    public SecureForm() => this.InitializeComponent();

    private void cmdAuth_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.txtPassword.Text.Trim().Length == 0)
        {
          this.txtPassword.Focus();
          throw new Exception("Debe ingresar el password");
        }
        if (!new usuarioDAO().AuthorizerUser(this.txtPassword.Text.Trim()))
          throw new Exception("La constraseña no es valida");
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Compra por Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        this.txtPassword.SelectAll();
      }
    }

    private void cmbCancelar_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }
  }
}
