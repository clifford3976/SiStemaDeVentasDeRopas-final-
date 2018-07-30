namespace SistemaDeVentas.VentanasReportes
{
    partial class FacturasReportes
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
            this.FacturasViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // FacturasViewer
            // 
            this.FacturasViewer.ActiveViewIndex = -1;
            this.FacturasViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FacturasViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.FacturasViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FacturasViewer.Location = new System.Drawing.Point(0, 0);
            this.FacturasViewer.Name = "FacturasViewer";
            this.FacturasViewer.Size = new System.Drawing.Size(800, 450);
            this.FacturasViewer.TabIndex = 0;
            this.FacturasViewer.Load += new System.EventHandler(this.FacturasViewer_Load);
            // 
            // FacturasReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FacturasViewer);
            this.Name = "FacturasReportes";
            this.Text = "FacturasReportes";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer FacturasViewer;
    }
}