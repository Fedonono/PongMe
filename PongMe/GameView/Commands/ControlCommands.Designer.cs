namespace GameView
{
    partial class ControlCommands
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.GBPlr = new System.Windows.Forms.GroupBox();
            this.Ldown = new System.Windows.Forms.Label();
            this.Lup = new System.Windows.Forms.Label();
            this.GBPlr.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBPlr
            // 
            this.GBPlr.Controls.Add(this.Ldown);
            this.GBPlr.Controls.Add(this.Lup);
            this.GBPlr.Location = new System.Drawing.Point(16, 17);
            this.GBPlr.Name = "GBPlr";
            this.GBPlr.Size = new System.Drawing.Size(101, 140);
            this.GBPlr.TabIndex = 0;
            this.GBPlr.TabStop = false;
            this.GBPlr.Text = "Player ";
            // 
            // Ldown
            // 
            this.Ldown.AutoSize = true;
            this.Ldown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ldown.Location = new System.Drawing.Point(23, 89);
            this.Ldown.Name = "Ldown";
            this.Ldown.Size = new System.Drawing.Size(58, 24);
            this.Ldown.TabIndex = 1;
            this.Ldown.Text = "undef";
            // 
            // Lup
            // 
            this.Lup.AutoSize = true;
            this.Lup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lup.Location = new System.Drawing.Point(23, 38);
            this.Lup.Name = "Lup";
            this.Lup.Size = new System.Drawing.Size(58, 24);
            this.Lup.TabIndex = 0;
            this.Lup.Text = "undef";
            // 
            // ControlCommands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.GBPlr);
            this.Name = "ControlCommands";
            this.Size = new System.Drawing.Size(145, 251);
            this.GBPlr.ResumeLayout(false);
            this.GBPlr.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GBPlr;
        private System.Windows.Forms.Label Ldown;
        private System.Windows.Forms.Label Lup;
    }
}
