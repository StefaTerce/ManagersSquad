namespace ManagerSquad
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelezionaForm = new ReaLTaiizor.Forms.SpaceForm();
            this.SelezionaBtn = new ReaLTaiizor.Controls.DreamButton();
            this.ItemCombo = new ReaLTaiizor.Controls.ForeverComboBox();
            this.SelezionaForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelezionaForm
            // 
            this.SelezionaForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.SelezionaForm.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.SelezionaForm.Controls.Add(this.SelezionaBtn);
            this.SelezionaForm.Controls.Add(this.ItemCombo);
            this.SelezionaForm.Customization = "Kioq/yAgIP8qKir/Kioq/xwcHP/+/v7/Kysr/xkZGf8=";
            this.SelezionaForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelezionaForm.Font = new System.Drawing.Font("Verdana", 8F);
            this.SelezionaForm.Image = null;
            this.SelezionaForm.Location = new System.Drawing.Point(0, 0);
            this.SelezionaForm.MinimumSize = new System.Drawing.Size(261, 61);
            this.SelezionaForm.Movable = true;
            this.SelezionaForm.Name = "SelezionaForm";
            this.SelezionaForm.NoRounding = false;
            this.SelezionaForm.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
            this.SelezionaForm.Sizable = true;
            this.SelezionaForm.Size = new System.Drawing.Size(625, 356);
            this.SelezionaForm.SmartBounds = true;
            this.SelezionaForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.SelezionaForm.TabIndex = 0;
            this.SelezionaForm.Text = "Gestione Squadra";
            this.SelezionaForm.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.SelezionaForm.Transparent = false;
            this.SelezionaForm.Click += new System.EventHandler(this.SelezionaForm_Click);
            // 
            // SelezionaBtn
            // 
            this.SelezionaBtn.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.SelezionaBtn.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.SelezionaBtn.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.SelezionaBtn.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SelezionaBtn.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SelezionaBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelezionaBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.SelezionaBtn.Location = new System.Drawing.Point(327, 147);
            this.SelezionaBtn.Name = "SelezionaBtn";
            this.SelezionaBtn.Size = new System.Drawing.Size(257, 59);
            this.SelezionaBtn.TabIndex = 2;
            this.SelezionaBtn.Text = "Seleziona Squadra";
            this.SelezionaBtn.UseVisualStyleBackColor = true;
            this.SelezionaBtn.Click += new System.EventHandler(this.SelezionaBtn_Click);
            // 
            // ItemCombo
            // 
            this.ItemCombo.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
            this.ItemCombo.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.ItemCombo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ItemCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ItemCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemCombo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.ItemCombo.ForeColor = System.Drawing.Color.White;
            this.ItemCombo.FormattingEnabled = true;
            this.ItemCombo.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.ItemCombo.HoverFontColor = System.Drawing.Color.White;
            this.ItemCombo.ItemHeight = 18;
            this.ItemCombo.Location = new System.Drawing.Point(24, 167);
            this.ItemCombo.Name = "ItemCombo";
            this.ItemCombo.Size = new System.Drawing.Size(235, 24);
            this.ItemCombo.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 356);
            this.Controls.Add(this.SelezionaForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(261, 61);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "themeForm1";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.SelezionaForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.SpaceForm SelezionaForm;
        private ReaLTaiizor.Controls.ForeverComboBox ItemCombo;
        private ReaLTaiizor.Controls.DreamButton SelezionaBtn;
    }
}

