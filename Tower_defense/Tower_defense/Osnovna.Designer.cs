
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
            this.SuspendLayout();
            // 
            // btn_zacni
            // 
            this.btn_zacni.Location = new System.Drawing.Point(66, 355);
            this.btn_zacni.Name = "btn_zacni";
            this.btn_zacni.Size = new System.Drawing.Size(94, 29);
            this.btn_zacni.TabIndex = 0;
            this.btn_zacni.Text = "Začni";
            this.btn_zacni.UseVisualStyleBackColor = true;
            this.btn_zacni.Click += new System.EventHandler(this.btn_zacni_Click);
            // 
            // Osnovna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_zacni);
            this.Name = "Osnovna";
            this.Text = "Tower defense";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_zacni;
    }
}

