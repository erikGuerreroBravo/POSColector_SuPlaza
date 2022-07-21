// Decompiled with JetBrains decompiler
// Type: POSColector.ViewForms.GetDateForm
// Assembly: POSColector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6CD0DAF4-4625-4490-9619-1BA7488F3BF0
// Assembly location: D:\Respaldo Su_Plaza_Actopan\PosColector\POSColector.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace POSColector.ViewForms
{
  public class GetDateForm : Form
  {
    private IContainer components = (IContainer) null;
    private MainMenu mainMenu1;
    private DateTimePicker dtpDateSync;
    private Button cmdGetDate;
    private Label lblTitleWindow;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.mainMenu1 = new MainMenu();
      this.dtpDateSync = new DateTimePicker();
      this.cmdGetDate = new Button();
      this.lblTitleWindow = new Label();
      this.SuspendLayout();
      this.dtpDateSync.Location = new Point(5, 29);
      this.dtpDateSync.Name = "dtpDateSync";
      this.dtpDateSync.Size = new Size(218, 24);
      this.dtpDateSync.TabIndex = 0;
      this.cmdGetDate.Location = new Point(62, 63);
      this.cmdGetDate.Name = "cmdGetDate";
      this.cmdGetDate.Size = new Size(97, 20);
      this.cmdGetDate.TabIndex = 1;
      this.cmdGetDate.Text = "Sincronizar";
      this.cmdGetDate.Click += new EventHandler(this.cmdGetDate_Click);
      this.lblTitleWindow.Location = new Point(5, 6);
      this.lblTitleWindow.Name = "lblTitleWindow";
      this.lblTitleWindow.Size = new Size(214, 20);
      this.lblTitleWindow.Text = "Sincronizar a partir de...";
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      ((Control) this).ClientSize = new Size(228, 95);
      this.Controls.Add((Control) this.lblTitleWindow);
      this.Controls.Add((Control) this.cmdGetDate);
      this.Controls.Add((Control) this.dtpDateSync);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (GetDateForm);
      this.Text = "Asistente para sincronizar";
      this.Closing += new CancelEventHandler(this.GetDateForm_Closing);
      this.ResumeLayout(false);
    }

    public GetDateForm(string catalogo)
    {
      this.InitializeComponent();
      this.lblTitleWindow.Text = string.Format("Sincronizar {0}, a partir de...", (object) catalogo);
    }

    private void cmdGetDate_Click(object sender, EventArgs e)
    {
      MainForm.lastDate = string.Format("{0} 00:00:00", (object) this.dtpDateSync.Value.ToShortDateString().ToString());
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void GetDateForm_Closing(object sender, CancelEventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }
  }
}
