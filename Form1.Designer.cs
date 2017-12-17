namespace MazeGenerator
{
    partial class Form1
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
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.RestartBt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox
            // 
            this.imageBox.BackColor = System.Drawing.Color.Black;
            this.imageBox.Location = new System.Drawing.Point(12, 42);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(502, 502);
            this.imageBox.TabIndex = 0;
            this.imageBox.TabStop = false;
            // 
            // RestartBt
            // 
            this.RestartBt.Location = new System.Drawing.Point(183, 13);
            this.RestartBt.Name = "RestartBt";
            this.RestartBt.Size = new System.Drawing.Size(75, 23);
            this.RestartBt.TabIndex = 1;
            this.RestartBt.Text = "Restart";
            this.RestartBt.UseVisualStyleBackColor = true;
            this.RestartBt.Click += new System.EventHandler(this.RestartBt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.Controls.Add(this.RestartBt);
            this.Controls.Add(this.imageBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.Button RestartBt;
    }
}

