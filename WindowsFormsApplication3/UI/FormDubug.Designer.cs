namespace WindowsFormsApplication3
{
    partial class Form2
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ok_A1 = new System.Windows.Forms.Button();
            this.btn_ok_H12 = new System.Windows.Forms.Button();
            this.btn_ok_A2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTrim = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 18F);
            this.button1.Location = new System.Drawing.Point(146, 68);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "左";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 18F);
            this.button2.Location = new System.Drawing.Point(399, 68);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "右";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 18F);
            this.button3.Location = new System.Drawing.Point(270, 14);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 50);
            this.button3.TabIndex = 2;
            this.button3.Text = "上";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("宋体", 18F);
            this.button4.Location = new System.Drawing.Point(270, 129);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 50);
            this.button4.TabIndex = 3;
            this.button4.Text = "下";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(46, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(609, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "模板位置信息调试，通过按钮移动板条，分别确定对角两个点的位置";
            // 
            // btn_ok_A1
            // 
            this.btn_ok_A1.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_ok_A1.Location = new System.Drawing.Point(48, 337);
            this.btn_ok_A1.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ok_A1.Name = "btn_ok_A1";
            this.btn_ok_A1.Size = new System.Drawing.Size(110, 60);
            this.btn_ok_A1.TabIndex = 5;
            this.btn_ok_A1.Text = "A1孔位置确认";
            this.btn_ok_A1.UseVisualStyleBackColor = true;
            this.btn_ok_A1.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_ok_H12
            // 
            this.btn_ok_H12.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_ok_H12.Location = new System.Drawing.Point(328, 337);
            this.btn_ok_H12.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ok_H12.Name = "btn_ok_H12";
            this.btn_ok_H12.Size = new System.Drawing.Size(110, 60);
            this.btn_ok_H12.TabIndex = 6;
            this.btn_ok_H12.Text = "A1对角孔位置确认";
            this.btn_ok_H12.UseVisualStyleBackColor = true;
            this.btn_ok_H12.Click += new System.EventHandler(this.button6_Click);
            // 
            // btn_ok_A2
            // 
            this.btn_ok_A2.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_ok_A2.Location = new System.Drawing.Point(179, 337);
            this.btn_ok_A2.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ok_A2.Name = "btn_ok_A2";
            this.btn_ok_A2.Size = new System.Drawing.Size(110, 60);
            this.btn_ok_A2.TabIndex = 7;
            this.btn_ok_A2.Text = "A2孔位置确认";
            this.btn_ok_A2.UseVisualStyleBackColor = true;
            this.btn_ok_A2.Click += new System.EventHandler(this.btn_ok_A2_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(482, 337);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(110, 60);
            this.button5.TabIndex = 8;
            this.button5.Text = "重新调试";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.Location = new System.Drawing.Point(627, 337);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(110, 60);
            this.button6.TabIndex = 9;
            this.button6.Text = "调试完成";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTrim);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(48, 101);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(689, 187);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "校准控制";
            // 
            // cbTrim
            // 
            this.cbTrim.AutoSize = true;
            this.cbTrim.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbTrim.Location = new System.Drawing.Point(594, 25);
            this.cbTrim.Margin = new System.Windows.Forms.Padding(2);
            this.cbTrim.Name = "cbTrim";
            this.cbTrim.Size = new System.Drawing.Size(70, 24);
            this.cbTrim.TabIndex = 4;
            this.cbTrim.Text = "微调";
            this.cbTrim.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbname);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(48, 38);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(689, 59);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "板条名称";
            // 
            // tbname
            // 
            this.tbname.Location = new System.Drawing.Point(189, 27);
            this.tbname.Margin = new System.Windows.Forms.Padding(2);
            this.tbname.Name = "tbname";
            this.tbname.Size = new System.Drawing.Size(491, 21);
            this.tbname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(23, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "请输入板条名称";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btn_ok_A2);
            this.Controls.Add(this.btn_ok_H12);
            this.Controls.Add(this.btn_ok_A1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "模板位置调试";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ok_A1;
        private System.Windows.Forms.Button btn_ok_H12;
        private System.Windows.Forms.Button btn_ok_A2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbTrim;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbname;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}