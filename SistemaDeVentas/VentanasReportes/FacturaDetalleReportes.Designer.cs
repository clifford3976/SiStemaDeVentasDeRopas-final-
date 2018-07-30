namespace SistemaDeVentas.VentanasReportes
{
    partial class FacturaDetalleReportes
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
            this.FacturadetalleViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // FacturadetalleViewer
            // 
            this.FacturadetalleViewer.ActiveViewIndex = -1;
            this.FacturadetalleViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FacturadetalleViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.FacturadetalleViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FacturadetalleViewer.Location = new System.Drawing.Point(0, 0);
            this.FacturadetalleViewer.Name = "FacturadetalleViewer";
            this.FacturadetalleViewer.Size = new System.Drawing.Size(800, 450);
            this.FacturadetalleViewer.TabIndex = 0;
            this.FacturadetalleViewer.Load += new System.EventHandler(this.FacturadetalleViewer_Load);
            // 
            // FacturaDetalleReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FacturadetalleViewer);
            this.Name = "FacturaDetalleReportes";
            this.Text = "FacturaDetalleReportes";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer FacturadetalleViewer;
    }
}