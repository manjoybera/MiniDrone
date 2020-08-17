namespace MiniDroneController
{
    partial class MiniDromeControllerForm
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
            this.richTextBoxResults = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnBackward = new System.Windows.Forms.Button();
            this.btnTurnLeft = new System.Windows.Forms.Button();
            this.btnTurnRight = new System.Windows.Forms.Button();
            this.txtDroneIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBoxResults
            // 
            this.richTextBoxResults.Location = new System.Drawing.Point(12, 36);
            this.richTextBoxResults.Name = "richTextBoxResults";
            this.richTextBoxResults.Size = new System.Drawing.Size(776, 241);
            this.richTextBoxResults.TabIndex = 0;
            this.richTextBoxResults.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Console";
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(118, 295);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(60, 60);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "UP";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseDown);
            this.btnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseUp);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(118, 432);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(60, 60);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "DOWN";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseDown);
            this.btnDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseUp);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(30, 363);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(60, 60);
            this.btnLeft.TabIndex = 4;
            this.btnLeft.Text = "LEFT";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseDown);
            this.btnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseUp);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(202, 363);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(60, 60);
            this.btnRight.TabIndex = 5;
            this.btnRight.Text = "RIGHT";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseDown);
            this.btnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseUp);
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(600, 295);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(60, 60);
            this.btnForward.TabIndex = 6;
            this.btnForward.Text = "FORWARD";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnForward_MouseDown);
            this.btnForward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnForward_MouseUp);
            // 
            // btnBackward
            // 
            this.btnBackward.Location = new System.Drawing.Point(600, 432);
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(60, 60);
            this.btnBackward.TabIndex = 7;
            this.btnBackward.Text = "BACKWARD";
            this.btnBackward.UseVisualStyleBackColor = true;
            this.btnBackward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBackward_MouseDown);
            this.btnBackward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnBackward_MouseUp);
            // 
            // btnTurnLeft
            // 
            this.btnTurnLeft.Location = new System.Drawing.Point(497, 363);
            this.btnTurnLeft.Name = "btnTurnLeft";
            this.btnTurnLeft.Size = new System.Drawing.Size(60, 60);
            this.btnTurnLeft.TabIndex = 8;
            this.btnTurnLeft.Text = "TURN LEFT";
            this.btnTurnLeft.UseVisualStyleBackColor = true;
            this.btnTurnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTurnLeft_MouseDown);
            this.btnTurnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnTurnLeft_MouseUp);
            // 
            // btnTurnRight
            // 
            this.btnTurnRight.Location = new System.Drawing.Point(696, 363);
            this.btnTurnRight.Name = "btnTurnRight";
            this.btnTurnRight.Size = new System.Drawing.Size(60, 60);
            this.btnTurnRight.TabIndex = 9;
            this.btnTurnRight.Text = "TURN RIGHT";
            this.btnTurnRight.UseVisualStyleBackColor = true;
            this.btnTurnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTurnRight_MouseDown);
            this.btnTurnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnTurnRight_MouseUp);
            // 
            // txtDroneIp
            // 
            this.txtDroneIp.Location = new System.Drawing.Point(340, 316);
            this.txtDroneIp.Name = "txtDroneIp";
            this.txtDroneIp.Size = new System.Drawing.Size(100, 20);
            this.txtDroneIp.TabIndex = 10;
            this.txtDroneIp.Text = "192.168.4.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Drone IP";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 540);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDroneIp);
            this.Controls.Add(this.btnTurnRight);
            this.Controls.Add(this.btnTurnLeft);
            this.Controls.Add(this.btnBackward);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxResults);
            this.Name = "Form1";
            this.Text = "MiniDroneController";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnBackward;
        private System.Windows.Forms.Button btnTurnLeft;
        private System.Windows.Forms.Button btnTurnRight;
        private System.Windows.Forms.TextBox txtDroneIp;
        private System.Windows.Forms.Label label2;
    }
}

