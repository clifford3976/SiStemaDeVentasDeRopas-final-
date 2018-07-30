namespace SistemaDeVentas.VentanasReportes
{
    partial class EntradaRopasReportes
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
            this.EntradaRopasViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // EntradaRopasViewer
            // 
            this.EntradaRopasViewer.ActiveViewIndex = -1;
            this.EntradaRopasViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EntradaRopasViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.EntradaRopasViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntradaRopasViewer.Location = new System.Drawing.Point(0, 0);
            this.EntradaRopasViewer.Name = "EntradaRopasViewer";
            this.EntradaRopasViewer.Size = new System.Drawing.Size(800, 450);
            this.EntradaRopasViewer.TabIndex = 0;
            this.EntradaRopasViewer.Load += new System.EventHandler(this.EntradaRopasViewer_Load);
            // 
            // EntradaRopasReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EntradaRopasViewer);
            this.Name = "EntradaRopasReportes";
            this.Text = "EntradaRopasReportes";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer EntradaRopasViewer;
    }
}