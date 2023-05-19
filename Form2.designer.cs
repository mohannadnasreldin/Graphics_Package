using System.Windows.Forms;

namespace Graphics_Package
{
    partial class Form2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.angleUpDown = new System.Windows.Forms.NumericUpDown();
            this.testButton = new System.Windows.Forms.Button();
            this.translationRd = new System.Windows.Forms.RadioButton();
            this.scaleRd = new System.Windows.Forms.RadioButton();
            this.rotationRd = new System.Windows.Forms.RadioButton();
            this.transformLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.yUpDown = new System.Windows.Forms.NumericUpDown();
            this.xLabel = new System.Windows.Forms.Label();
            this.xUpDown = new System.Windows.Forms.NumericUpDown();
            this.shearingRd = new System.Windows.Forms.RadioButton();
            this.reflectionRd = new System.Windows.Forms.RadioButton();
            this.reflectX = new System.Windows.Forms.CheckBox();
            this.reflectY = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.angleUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(225, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 390);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(546, 441);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "P1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(546, 463);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "P2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 281);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Angle";
            // 
            // angleUpDown
            // 
            this.angleUpDown.DecimalPlaces = 2;
            this.angleUpDown.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.angleUpDown.Location = new System.Drawing.Point(119, 280);
            this.angleUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.angleUpDown.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.angleUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.angleUpDown.Name = "angleUpDown";
            this.angleUpDown.Size = new System.Drawing.Size(62, 20);
            this.angleUpDown.TabIndex = 24;
            this.angleUpDown.TabStop = false;
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(86, 328);
            this.testButton.Margin = new System.Windows.Forms.Padding(2);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(106, 25);
            this.testButton.TabIndex = 23;
            this.testButton.Text = "ACTION!!";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // translationRd
            // 
            this.translationRd.AutoSize = true;
            this.translationRd.Location = new System.Drawing.Point(119, 95);
            this.translationRd.Margin = new System.Windows.Forms.Padding(2);
            this.translationRd.Name = "translationRd";
            this.translationRd.Size = new System.Drawing.Size(73, 17);
            this.translationRd.TabIndex = 22;
            this.translationRd.Text = "translation";
            this.translationRd.UseVisualStyleBackColor = true;
            this.translationRd.CheckedChanged += new System.EventHandler(this.translationRd_CheckedChanged);
            // 
            // scaleRd
            // 
            this.scaleRd.AutoSize = true;
            this.scaleRd.Location = new System.Drawing.Point(119, 56);
            this.scaleRd.Margin = new System.Windows.Forms.Padding(2);
            this.scaleRd.Name = "scaleRd";
            this.scaleRd.Size = new System.Drawing.Size(50, 17);
            this.scaleRd.TabIndex = 21;
            this.scaleRd.Text = "scale";
            this.scaleRd.UseVisualStyleBackColor = true;
            this.scaleRd.CheckedChanged += new System.EventHandler(this.scaleRd_CheckedChanged);
            // 
            // rotationRd
            // 
            this.rotationRd.AutoSize = true;
            this.rotationRd.Location = new System.Drawing.Point(119, 37);
            this.rotationRd.Margin = new System.Windows.Forms.Padding(2);
            this.rotationRd.Name = "rotationRd";
            this.rotationRd.Size = new System.Drawing.Size(60, 17);
            this.rotationRd.TabIndex = 20;
            this.rotationRd.Text = "rotation";
            this.rotationRd.UseVisualStyleBackColor = true;
            this.rotationRd.CheckedChanged += new System.EventHandler(this.rotationRd_CheckedChanged);
            // 
            // transformLabel
            // 
            this.transformLabel.AutoSize = true;
            this.transformLabel.Location = new System.Drawing.Point(98, 12);
            this.transformLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.transformLabel.Name = "transformLabel";
            this.transformLabel.Size = new System.Drawing.Size(81, 13);
            this.transformLabel.TabIndex = 19;
            this.transformLabel.Text = "Transform Type";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(101, 254);
            this.yLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(14, 13);
            this.yLabel.TabIndex = 18;
            this.yLabel.Text = "Y";
            // 
            // yUpDown
            // 
            this.yUpDown.DecimalPlaces = 2;
            this.yUpDown.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.yUpDown.Location = new System.Drawing.Point(119, 252);
            this.yUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.yUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.yUpDown.Name = "yUpDown";
            this.yUpDown.Size = new System.Drawing.Size(62, 20);
            this.yUpDown.TabIndex = 17;
            this.yUpDown.TabStop = false;
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(101, 225);
            this.xLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(14, 13);
            this.xLabel.TabIndex = 16;
            this.xLabel.Text = "X";
            // 
            // xUpDown
            // 
            this.xUpDown.DecimalPlaces = 2;
            this.xUpDown.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.xUpDown.Location = new System.Drawing.Point(119, 224);
            this.xUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.xUpDown.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.xUpDown.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.xUpDown.Name = "xUpDown";
            this.xUpDown.Size = new System.Drawing.Size(62, 20);
            this.xUpDown.TabIndex = 15;
            this.xUpDown.TabStop = false;
            // 
            // shearingRd
            // 
            this.shearingRd.AutoSize = true;
            this.shearingRd.Location = new System.Drawing.Point(119, 77);
            this.shearingRd.Margin = new System.Windows.Forms.Padding(2);
            this.shearingRd.Name = "shearingRd";
            this.shearingRd.Size = new System.Drawing.Size(51, 17);
            this.shearingRd.TabIndex = 26;
            this.shearingRd.Text = "shear";
            this.shearingRd.UseVisualStyleBackColor = true;
            this.shearingRd.CheckedChanged += new System.EventHandler(this.shearingRd_CheckedChanged);
            // 
            // reflectionRd
            // 
            this.reflectionRd.AutoSize = true;
            this.reflectionRd.Location = new System.Drawing.Point(38, 152);
            this.reflectionRd.Margin = new System.Windows.Forms.Padding(2);
            this.reflectionRd.Name = "reflectionRd";
            this.reflectionRd.Size = new System.Drawing.Size(68, 17);
            this.reflectionRd.TabIndex = 27;
            this.reflectionRd.Text = "reflection";
            this.reflectionRd.UseVisualStyleBackColor = true;
            this.reflectionRd.CheckedChanged += new System.EventHandler(this.reflectionRd_CheckedChanged);
            // 
            // reflectX
            // 
            this.reflectX.AutoSize = true;
            this.reflectX.Location = new System.Drawing.Point(119, 136);
            this.reflectX.Name = "reflectX";
            this.reflectX.Size = new System.Drawing.Size(69, 17);
            this.reflectX.TabIndex = 28;
            this.reflectX.Text = "on X-axis";
            this.reflectX.UseVisualStyleBackColor = true;
            // 
            // reflectY
            // 
            this.reflectY.AutoSize = true;
            this.reflectY.Location = new System.Drawing.Point(119, 170);
            this.reflectY.Name = "reflectY";
            this.reflectY.Size = new System.Drawing.Size(69, 17);
            this.reflectY.TabIndex = 29;
            this.reflectY.Text = "on Y-axis";
            this.reflectY.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 489);
            this.Controls.Add(this.reflectY);
            this.Controls.Add(this.reflectX);
            this.Controls.Add(this.reflectionRd);
            this.Controls.Add(this.shearingRd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.angleUpDown);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.translationRd);
            this.Controls.Add(this.scaleRd);
            this.Controls.Add(this.rotationRd);
            this.Controls.Add(this.transformLabel);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.yUpDown);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.xUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.Text = "Transformations";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Transformations_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.angleUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel panel1;
        private Label label2;
        private Label label3;
        private Label label1;
        private NumericUpDown angleUpDown;
        private Button testButton;
        private RadioButton translationRd;
        private RadioButton scaleRd;
        private RadioButton rotationRd;
        private Label transformLabel;
        private Label yLabel;
        private NumericUpDown yUpDown;
        private Label xLabel;
        private NumericUpDown xUpDown;
        private RadioButton shearingRd;
        private RadioButton reflectionRd;
        private CheckBox reflectX;
        private CheckBox reflectY;
    }
}