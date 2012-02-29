namespace DiffCreate
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
            this.btnGetLandCover = new System.Windows.Forms.Button();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBottom = new System.Windows.Forms.TextBox();
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.chkDebug = new System.Windows.Forms.CheckBox();
            this.btnGetElevation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetLandCover
            // 
            this.btnGetLandCover.Location = new System.Drawing.Point(448, 35);
            this.btnGetLandCover.Name = "btnGetLandCover";
            this.btnGetLandCover.Size = new System.Drawing.Size(158, 42);
            this.btnGetLandCover.TabIndex = 1;
            this.btnGetLandCover.Text = "Get Landcover Map";
            this.btnGetLandCover.UseVisualStyleBackColor = true;
            this.btnGetLandCover.Click += new System.EventHandler(this.btnGetLandCover_Click);
            // 
            // txtLeft
            // 
            this.txtLeft.Location = new System.Drawing.Point(42, 57);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(153, 20);
            this.txtLeft.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Left";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Top";
            // 
            // txtTop
            // 
            this.txtTop.Location = new System.Drawing.Point(164, 22);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(153, 20);
            this.txtTop.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Right";
            // 
            // txtRight
            // 
            this.txtRight.Location = new System.Drawing.Point(262, 53);
            this.txtRight.Name = "txtRight";
            this.txtRight.Size = new System.Drawing.Size(153, 20);
            this.txtRight.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Bottom";
            // 
            // txtBottom
            // 
            this.txtBottom.Location = new System.Drawing.Point(164, 83);
            this.txtBottom.Name = "txtBottom";
            this.txtBottom.Size = new System.Drawing.Size(153, 20);
            this.txtBottom.TabIndex = 9;
            // 
            // rtxtLog
            // 
            this.rtxtLog.Location = new System.Drawing.Point(14, 138);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.Size = new System.Drawing.Size(592, 487);
            this.rtxtLog.TabIndex = 11;
            this.rtxtLog.Text = "";
            // 
            // chkDebug
            // 
            this.chkDebug.AutoSize = true;
            this.chkDebug.Location = new System.Drawing.Point(457, 12);
            this.chkDebug.Name = "chkDebug";
            this.chkDebug.Size = new System.Drawing.Size(82, 17);
            this.chkDebug.TabIndex = 12;
            this.chkDebug.Text = "Debug Print";
            this.chkDebug.UseVisualStyleBackColor = true;
            this.chkDebug.CheckedChanged += new System.EventHandler(this.chkDebug_CheckedChanged);
            // 
            // btnGetElevation
            // 
            this.btnGetElevation.Location = new System.Drawing.Point(447, 83);
            this.btnGetElevation.Name = "btnGetElevation";
            this.btnGetElevation.Size = new System.Drawing.Size(158, 42);
            this.btnGetElevation.TabIndex = 13;
            this.btnGetElevation.Text = "Get Elevation Map";
            this.btnGetElevation.UseVisualStyleBackColor = true;
            this.btnGetElevation.Click += new System.EventHandler(this.btnGetElevation_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 637);
            this.Controls.Add(this.btnGetElevation);
            this.Controls.Add(this.chkDebug);
            this.Controls.Add(this.rtxtLog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBottom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLeft);
            this.Controls.Add(this.btnGetLandCover);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetLandCover;
        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBottom;
        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.CheckBox chkDebug;
        private System.Windows.Forms.Button btnGetElevation;
    }
}

