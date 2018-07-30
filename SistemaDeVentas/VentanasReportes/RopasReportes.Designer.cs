namespace SistemaDeVentas.VentanasReportes
{
    partial class RopasReportes
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
            this.RopasViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RopasViewer
            // 
            this.RopasViewer.ActiveViewIndex = -1;
            this.RopasViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RopasViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.RopasViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RopasViewer.Location = new System.Drawing.Point(0, 0);
            this.RopasViewer.Name = "RopasViewer";
            this.RopasViewer.Size = new System.Drawing.Size(800, 450);
            this.RopasViewer.TabIndex = 0;
            this.RopasViewer.Load += new System.EventHandler(this.RopasViewer_Load);
            // 
            // RopasReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RopasViewer);
            this.Name = "RopasReportes";
            this.Text = "RopasReportes";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RopasViewer;
    }
}