namespace Ontwikkelopdracht_Game
{
    partial class GameForm
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
            this.imgCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // imgCanvas
            // 
            this.imgCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgCanvas.Location = new System.Drawing.Point(0, 0);
            this.imgCanvas.Name = "imgCanvas";
            this.imgCanvas.Size = new System.Drawing.Size(1350, 729);
            this.imgCanvas.TabIndex = 0;
            this.imgCanvas.TabStop = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.imgCanvas);
            this.Name = "GameForm";
            this.Text = "Game";
            ((System.ComponentModel.ISupportInitialize)(this.imgCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgCanvas;
    }
}

