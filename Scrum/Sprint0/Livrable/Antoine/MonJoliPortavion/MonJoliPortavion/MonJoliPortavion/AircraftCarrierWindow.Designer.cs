namespace MonJoliPortavion
{
    partial class AircraftCarrierWindow
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
            this.currentAction = new System.Windows.Forms.Button();
            this.AttackAction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // currentAction
            // 
            this.currentAction.BackColor = System.Drawing.Color.LavenderBlush;
            this.currentAction.Location = new System.Drawing.Point(12, 12);
            this.currentAction.Name = "currentAction";
            this.currentAction.Size = new System.Drawing.Size(177, 39);
            this.currentAction.TabIndex = 0;
            this.currentAction.Text = "Sail";
            this.currentAction.UseVisualStyleBackColor = false;
            this.currentAction.Click += new System.EventHandler(this.currentAction_Click);
            // 
            // AttackAction
            // 
            this.AttackAction.BackColor = System.Drawing.Color.LavenderBlush;
            this.AttackAction.Location = new System.Drawing.Point(12, 80);
            this.AttackAction.Name = "AttackAction";
            this.AttackAction.Size = new System.Drawing.Size(177, 38);
            this.AttackAction.TabIndex = 1;
            this.AttackAction.Text = "Attack";
            this.AttackAction.UseVisualStyleBackColor = false;
            this.AttackAction.Click += new System.EventHandler(this.AttackAction_Click);
            // 
            // AircraftCarrierWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(293, 195);
            this.Controls.Add(this.AttackAction);
            this.Controls.Add(this.currentAction);
            this.Name = "AircraftCarrierWindow";
            this.Text = "AircraftCarrier";
            this.Load += new System.EventHandler(this.AircraftCarrierWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button currentAction;
        private System.Windows.Forms.Button AttackAction;
    }
}