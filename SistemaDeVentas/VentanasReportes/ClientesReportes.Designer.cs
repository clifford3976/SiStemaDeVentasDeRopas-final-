namespace SistemaDeVentas.VentanasReportes
{
    partial class ClientesReportes
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
            if (disposing && (components != null))
            {
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
            this.ClientesViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ClientesViewer
            // 
            this.ClientesViewer.ActiveViewIndex = -1;
            this.ClientesViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ClientesViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ClientesViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientesViewer.Location = new System.Drawing.Point(0, 0);
            this.ClientesViewer.Name = "ClientesViewer";
            this.ClientesViewer.Size = new System.Drawing.Size(800, 450);
            this.ClientesViewer.TabIndex = 0;
            this.ClientesViewer.Load += new System.EventHandler(this.ClientesViewer_Load);
            // 
            // ClientesReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ClientesViewer);
            this.Name = "ClientesReportes";
            this.Text = "ClientesReportes";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ClientesViewer;
    }
}