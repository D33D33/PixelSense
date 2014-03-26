namespace tuto_fenetre
{
    partial class Form1
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_myTestButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_myTestButton
            // 
            this.m_myTestButton.Location = new System.Drawing.Point(60, 43);
            this.m_myTestButton.Name = "m_myTestButton";
            this.m_myTestButton.Size = new System.Drawing.Size(175, 34);
            this.m_myTestButton.TabIndex = 0;
            this.m_myTestButton.Text = "tu pense que oui?";
            this.m_myTestButton.UseVisualStyleBackColor = true;
            this.m_myTestButton.Click += new System.EventHandler(this.m_myTestButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "tu pense que non?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_myTestButton);
            this.Name = "Form1";
            this.Text = "Caroline t\'aime?";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_myTestButton;
        private System.Windows.Forms.Button button1;
    }
}

