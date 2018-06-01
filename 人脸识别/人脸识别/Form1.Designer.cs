namespace 人脸识别
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserRemark = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserDept = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserAge = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btn_prtAndAdd = new System.Windows.Forms.Button();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.btn_uplpad = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.imageBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1719, 692);
            this.splitContainer1.SplitterDistance = 883;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btn_uplpad);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.txtUserRemark);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.txtUserDept);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.txtUserAge);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.txtUserName);
            this.splitContainer2.Panel1.Controls.Add(this.btn_prtAndAdd);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.imageBox1);
            this.splitContainer2.Size = new System.Drawing.Size(883, 692);
            this.splitContainer2.SplitterDistance = 73;
            this.splitContainer2.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "备注:";
            // 
            // txtUserRemark
            // 
            this.txtUserRemark.Location = new System.Drawing.Point(269, 42);
            this.txtUserRemark.Name = "txtUserRemark";
            this.txtUserRemark.Size = new System.Drawing.Size(226, 28);
            this.txtUserRemark.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "部门:";
            // 
            // txtUserDept
            // 
            this.txtUserDept.Location = new System.Drawing.Point(269, 7);
            this.txtUserDept.Name = "txtUserDept";
            this.txtUserDept.Size = new System.Drawing.Size(100, 28);
            this.txtUserDept.TabIndex = 5;
            this.txtUserDept.Text = "IT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "年龄:";
            // 
            // txtUserAge
            // 
            this.txtUserAge.Location = new System.Drawing.Point(90, 41);
            this.txtUserAge.Name = "txtUserAge";
            this.txtUserAge.Size = new System.Drawing.Size(100, 28);
            this.txtUserAge.TabIndex = 3;
            this.txtUserAge.Text = "18";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "名字:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(90, 7);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 28);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Text = "testUser";
            // 
            // btn_prtAndAdd
            // 
            this.btn_prtAndAdd.Location = new System.Drawing.Point(501, 3);
            this.btn_prtAndAdd.Name = "btn_prtAndAdd";
            this.btn_prtAndAdd.Size = new System.Drawing.Size(116, 67);
            this.btn_prtAndAdd.TabIndex = 0;
            this.btn_prtAndAdd.Text = "开始";
            this.btn_prtAndAdd.UseVisualStyleBackColor = true;
            this.btn_prtAndAdd.Click += new System.EventHandler(this.btn_prtAndAdd_Click);
            // 
            // imageBox1
            // 
            this.imageBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox1.Location = new System.Drawing.Point(0, 0);
            this.imageBox1.Margin = new System.Windows.Forms.Padding(4);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(883, 615);
            this.imageBox1.TabIndex = 4;
            this.imageBox1.TabStop = false;
            // 
            // imageBox2
            // 
            this.imageBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBox2.Location = new System.Drawing.Point(0, 0);
            this.imageBox2.Margin = new System.Windows.Forms.Padding(4);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(832, 692);
            this.imageBox2.TabIndex = 3;
            this.imageBox2.TabStop = false;
            // 
            // btn_uplpad
            // 
            this.btn_uplpad.Location = new System.Drawing.Point(397, 6);
            this.btn_uplpad.Name = "btn_uplpad";
            this.btn_uplpad.Size = new System.Drawing.Size(98, 30);
            this.btn_uplpad.TabIndex = 9;
            this.btn_uplpad.Text = "上传图片";
            this.btn_uplpad.UseVisualStyleBackColor = true;
            this.btn_uplpad.Click += new System.EventHandler(this.btn_uplpad_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1719, 692);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "人脸识别";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button btn_prtAndAdd;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserRemark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserDept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserAge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btn_uplpad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

