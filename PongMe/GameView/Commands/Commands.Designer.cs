namespace GameView.Resources
{
    partial class Commands
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
            this.GBCom = new System.Windows.Forms.GroupBox();
            this.LLaunch = new System.Windows.Forms.Label();
            this.LPause = new System.Windows.Forms.Label();
            this.LTl = new System.Windows.Forms.Label();
            this.Pause = new System.Windows.Forms.Label();
            this.GBCom.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBCom
            // 
            this.GBCom.Controls.Add(this.Pause);
            this.GBCom.Controls.Add(this.LTl);
            this.GBCom.Controls.Add(this.LPause);
            this.GBCom.Controls.Add(this.LLaunch);
            this.GBCom.Location = new System.Drawing.Point(27, 149);
            this.GBCom.Name = "GBCom";
            this.GBCom.Size = new System.Drawing.Size(231, 136);
            this.GBCom.TabIndex = 1;
            this.GBCom.TabStop = false;
            this.GBCom.Text = "Common";
            this.GBCom.Enter += new System.EventHandler(this.GBPlr_Enter);
            // 
            // LLaunch
            // 
            this.LLaunch.AutoSize = true;
            this.LLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLaunch.Location = new System.Drawing.Point(117, 39);
            this.LLaunch.Name = "LLaunch";
            this.LLaunch.Size = new System.Drawing.Size(58, 24);
            this.LLaunch.TabIndex = 1;
            this.LLaunch.Text = "undef";
            // 
            // LPause
            // 
            this.LPause.AutoSize = true;
            this.LPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPause.Location = new System.Drawing.Point(117, 92);
            this.LPause.Name = "LPause";
            this.LPause.Size = new System.Drawing.Size(58, 24);
            this.LPause.TabIndex = 2;
            this.LPause.Text = "undef";
            // 
            // LTl
            // 
            this.LTl.AutoSize = true;
            this.LTl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTl.Location = new System.Drawing.Point(19, 43);
            this.LTl.Name = "LTl";
            this.LTl.Size = new System.Drawing.Size(62, 20);
            this.LTl.TabIndex = 3;
            this.LTl.Text = "Launch";
            // 
            // Pause
            // 
            this.Pause.AutoSize = true;
            this.Pause.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pause.Location = new System.Drawing.Point(20, 96);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(50, 18);
            this.Pause.TabIndex = 4;
            this.Pause.Text = "Pause";
            // 
            // Commands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.GBCom);
            this.Name = "Commands";
            this.Size = new System.Drawing.Size(505, 317);
            this.Load += new System.EventHandler(this.Commands_Load);
            this.GBCom.ResumeLayout(false);
            this.GBCom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GBCom;
        private System.Windows.Forms.Label LLaunch;
        private System.Windows.Forms.Label Pause;
        private System.Windows.Forms.Label LTl;
        private System.Windows.Forms.Label LPause;

    }
}
