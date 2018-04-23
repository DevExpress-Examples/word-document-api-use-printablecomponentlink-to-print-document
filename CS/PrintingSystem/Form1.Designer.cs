namespace RichEdit_PrintingSystem
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_PrintFromServer = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btn_PrintFromServer
            // 
            this.btn_PrintFromServer.Location = new System.Drawing.Point(180, 50);
            this.btn_PrintFromServer.Name = "btn_PrintFromServer";
            this.btn_PrintFromServer.Size = new System.Drawing.Size(146, 23);
            this.btn_PrintFromServer.TabIndex = 2;
            this.btn_PrintFromServer.Text = "Load and Print";
            this.btn_PrintFromServer.Click += new System.EventHandler(this.btn_PrintFromServer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 130);
            this.Controls.Add(this.btn_PrintFromServer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_PrintFromServer;
    }
}

