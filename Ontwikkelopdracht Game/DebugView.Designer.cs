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
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkTracking = new System.Windows.Forms.CheckBox();
            this.lblHealth = new System.Windows.Forms.Label();
            this.lblRotation = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstPathfinding = new System.Windows.Forms.ListBox();
            this.tabTiming = new System.Windows.Forms.TabPage();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.tabMaps = new System.Windows.Forms.TabPage();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPathfinding.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabTiming.SuspendLayout();
            this.tabMaps.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTiming);
            this.tabControl.Controls.Add(this.tabPathfinding);
            this.tabControl.Controls.Add(this.tabMaps);
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
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Location = new System.Drawing.Point(95, 69);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(48, 13);
            this.lblHealth.TabIndex = 12;
            this.lblHealth.Text = "lblHealth";
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
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(95, 43);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(48, 13);
            this.lblHeight.TabIndex = 10;
            this.lblHeight.Text = "lblHeight";
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
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(95, 17);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(24, 13);
            this.lblY.TabIndex = 8;
            this.lblY.Text = "lblY";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Options:";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Rotation:";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Width:";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
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
            // tabTiming
            // 
            this.tabTiming.Controls.Add(this.btnResume);
            this.tabTiming.Controls.Add(this.btnPause);
            this.tabTiming.Location = new System.Drawing.Point(4, 22);
            this.tabTiming.Name = "tabTiming";
            this.tabTiming.Padding = new System.Windows.Forms.Padding(3);
            this.tabTiming.Size = new System.Drawing.Size(530, 241);
            this.tabTiming.TabIndex = 1;
            this.tabTiming.Text = "Timing";
            this.tabTiming.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(8, 6);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 0;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(8, 35);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(75, 23);
            this.btnResume.TabIndex = 1;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // tabMaps
            // 
            this.tabMaps.Controls.Add(this.btnLoad);
            this.tabMaps.Controls.Add(this.btnExport);
            this.tabMaps.Location = new System.Drawing.Point(4, 22);
            this.tabMaps.Name = "tabMaps";
            this.tabMaps.Size = new System.Drawing.Size(530, 241);
            this.tabMaps.TabIndex = 2;
            this.tabMaps.Text = "Maps";
            this.tabMaps.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(8, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export all";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(8, 35);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
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
            this.tabTiming.ResumeLayout(false);
            this.tabMaps.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabTiming;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.TabPage tabMaps;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnLoad;
    }
}