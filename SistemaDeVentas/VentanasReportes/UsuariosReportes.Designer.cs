﻿namespace SistemaDeVentas.VentanasReportes
{
    partial class UsuariosReportes
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
            this.UsuariosViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // UsuariosViewer
            // 
            this.UsuariosViewer.ActiveViewIndex = -1;
            this.UsuariosViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsuariosViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.UsuariosViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsuariosViewer.Location = new System.Drawing.Point(0, 0);
            this.UsuariosViewer.Name = "UsuariosViewer";
            this.UsuariosViewer.Size = new System.Drawing.Size(800, 450);
            this.UsuariosViewer.TabIndex = 0;
            this.UsuariosViewer.Load += new System.EventHandler(this.UsuariosViewer_Load);
            // 
            // UsuariosReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UsuariosViewer);
            this.Name = "UsuariosReportes";
            this.Text = "UsuariosReportes";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer UsuariosViewer;
    }
}