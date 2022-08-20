
namespace Tower_defense
{
    partial class Osnovna
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_zacni = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_zacni
            // 
            this.btn_zacni.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btn_zacni.Font = new System.Drawing.Font("Snap ITC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_zacni.Location = new System.Drawing.Point(279, 139);
            this.btn_zacni.Name = "btn_zacni";
            this.btn_zacni.Size = new System.Drawing.Size(214, 96);
            this.btn_zacni.TabIndex = 0;
            this.btn_zacni.Text = "Začni";
            this.btn_zacni.UseVisualStyleBackColor = false;
            this.btn_zacni.Click += new System.EventHandler(this.btn_zacni_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Snap ITC", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(58, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(699, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "ZAKH\'S TOWER DEFENSE";
            // 
            // Osnovna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlueViolet;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_zacni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Osnovna";
            this.Text = "Tower defense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_zacni;
        private System.Windows.Forms.Label label1;
    }
}

