namespace Ontwikkelopdracht_Game
{
    partial class DebugView
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPathfinding = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstPathfinding = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblRotation = new System.Windows.Forms.Label();
            this.lblHealth = new System.Windows.Forms.Label();
            this.chkTracking = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabPathfinding.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPathfinding);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(538, 267);
            this.tabControl.TabIndex = 0;
            // 
            // tabPathfinding
            // 
            this.tabPathfinding.Controls.Add(this.panel1);
            this.tabPathfinding.Location = new System.Drawing.Point(4, 22);
            this.tabPathfinding.Name = "tabPathfinding";
            this.tabPathfinding.Size = new System.Drawing.Size(530, 241);
            this.tabPathfinding.TabIndex = 0;
            this.tabPathfinding.Text = "Pathfinding";
            this.tabPathfinding.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lstPathfinding);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 241);
            this.panel1.TabIndex = 0;
            // 
            // lstPathfinding
            // 
            this.lstPathfinding.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstPathfinding.FormattingEnabled = true;
            this.lstPathfinding.Location = new System.Drawing.Point(0, 0);
            this.lstPathfinding.Name = "lstPathfinding";
            this.lstPathfinding.Size = new System.Drawing.Size(190, 241);
            this.lstPathfinding.TabIndex = 0;
            this.lstPathfinding.SelectedIndexChanged += new System.EventHandler(this.lstPathfinding_SelectedIndexChanged);
            this.lstPathfinding.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstPathfinding_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkTracking);
            this.panel2.Controls.Add(this.lblHealth);
            this.panel2.Controls.Add(this.lblRotation);
            this.panel2.Controls.Add(this.lblHeight);
            this.panel2.Controls.Add(this.lblWidth);
            this.panel2.Controls.Add(this.lblY);
            this.panel2.Controls.Add(this.lblX);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(190, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 241);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Width:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Height:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Rotation:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Health:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Options:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(95, 4);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(24, 13);
            this.lblX.TabIndex = 7;
            this.lblX.Text = "lblX";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(95, 17);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(24, 13);
            this.lblY.TabIndex = 8;
            this.lblY.Text = "lblY";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(95, 30);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(45, 13);
            this.lblWidth.TabIndex = 9;
            this.lblWidth.Text = "lblWidth";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(95, 43);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(48, 13);
            this.lblHeight.TabIndex = 10;
            this.lblHeight.Text = "lblHeight";
            // 
            // lblRotation
            // 
            this.lblRotation.AutoSize = true;
            this.lblRotation.Location = new System.Drawing.Point(95, 56);
            this.lblRotation.Name = "lblRotation";
            this.lblRotation.Size = new System.Drawing.Size(57, 13);
            this.lblRotation.TabIndex = 11;
            this.lblRotation.Text = "lblRotation";
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Location = new System.Drawing.Point(95, 69);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(48, 13);
            this.lblHealth.TabIndex = 12;
            this.lblHealth.Text = "lblHealth";
            // 
            // chkTracking
            // 
            this.chkTracking.AutoSize = true;
            this.chkTracking.Location = new System.Drawing.Point(98, 85);
            this.chkTracking.Name = "chkTracking";
            this.chkTracking.Size = new System.Drawing.Size(68, 17);
            this.chkTracking.TabIndex = 13;
            this.chkTracking.Text = "Tracking";
            this.chkTracking.UseVisualStyleBackColor = true;
            this.chkTracking.CheckedChanged += new System.EventHandler(this.chkTracking_CheckedChanged);
            // 
            // DebugView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 267);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(1366, 0);
            this.Name = "DebugView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DebugView";
            this.tabControl.ResumeLayout(false);
            this.tabPathfinding.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPathfinding;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lstPathfinding;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkTracking;
        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.Label lblRotation;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label label7;
    }
}