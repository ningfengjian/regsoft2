namespace SoftReg
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.MachineCode = new CCWin.SkinControl.SkinTextBox();
            this.BaseText = new CCWin.SkinControl.SkinWaterTextBox();
            this.RB_aqy = new System.Windows.Forms.RadioButton();
            this.RB_yk = new System.Windows.Forms.RadioButton();
            this.RB_mg = new System.Windows.Forms.RadioButton();
            this.RB_sh = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.MachineCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(14, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "账号密码";
            // 
            // skinButton1
            // 
            this.skinButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = global::SoftReg.Properties.Resources.SkinButtonDownBack;
            this.skinButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton1.Location = new System.Drawing.Point(167, 178);
            this.skinButton1.MouseBack = global::SoftReg.Properties.Resources.SkinButtonMouseBack;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = global::SoftReg.Properties.Resources.SkinButtonNormlBack;
            this.skinButton1.Size = new System.Drawing.Size(83, 34);
            this.skinButton1.TabIndex = 3;
            this.skinButton1.Text = "获取账号";
            this.skinButton1.UseVisualStyleBackColor = false;
            this.skinButton1.Click += new System.EventHandler(this.GetMachineCode);
            // 
            // MachineCode
            // 
            this.MachineCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MachineCode.BackColor = System.Drawing.Color.Transparent;
            this.MachineCode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MachineCode.Icon = null;
            this.MachineCode.IconIsButton = false;
            this.MachineCode.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.MachineCode.Location = new System.Drawing.Point(77, 50);
            this.MachineCode.Margin = new System.Windows.Forms.Padding(0);
            this.MachineCode.MinimumSize = new System.Drawing.Size(28, 28);
            this.MachineCode.MouseBack = null;
            this.MachineCode.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.MachineCode.Name = "MachineCode";
            this.MachineCode.NormlBack = null;
            this.MachineCode.Padding = new System.Windows.Forms.Padding(5);
            this.MachineCode.Size = new System.Drawing.Size(373, 28);
            // 
            // MachineCode.BaseText
            // 
            this.MachineCode.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MachineCode.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MachineCode.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.MachineCode.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.MachineCode.SkinTxt.Name = "BaseText";
            this.MachineCode.SkinTxt.Size = new System.Drawing.Size(363, 18);
            this.MachineCode.SkinTxt.TabIndex = 0;
            this.MachineCode.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.MachineCode.SkinTxt.WaterText = "点击\"获取账号\"生成账号";
            this.MachineCode.SkinTxt.TextChanged += new System.EventHandler(this.MachineCode_SkinTxt_TextChanged);
            this.MachineCode.TabIndex = 4;
            // 
            // BaseText
            // 
            this.BaseText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BaseText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseText.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.BaseText.Location = new System.Drawing.Point(5, 5);
            this.BaseText.Name = "BaseText";
            this.BaseText.Size = new System.Drawing.Size(363, 18);
            this.BaseText.TabIndex = 0;
            this.BaseText.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.BaseText.WaterText = "点击\"生成注册码\"生成注册码";
            // 
            // RB_aqy
            // 
            this.RB_aqy.AutoSize = true;
            this.RB_aqy.Location = new System.Drawing.Point(87, 98);
            this.RB_aqy.Name = "RB_aqy";
            this.RB_aqy.Size = new System.Drawing.Size(59, 16);
            this.RB_aqy.TabIndex = 9;
            this.RB_aqy.TabStop = true;
            this.RB_aqy.Text = "爱奇艺";
            this.RB_aqy.UseVisualStyleBackColor = true;
            // 
            // RB_yk
            // 
            this.RB_yk.AutoSize = true;
            this.RB_yk.Location = new System.Drawing.Point(263, 98);
            this.RB_yk.Name = "RB_yk";
            this.RB_yk.Size = new System.Drawing.Size(71, 16);
            this.RB_yk.TabIndex = 10;
            this.RB_yk.TabStop = true;
            this.RB_yk.Text = "优酷土豆";
            this.RB_yk.UseVisualStyleBackColor = true;
            // 
            // RB_mg
            // 
            this.RB_mg.AutoSize = true;
            this.RB_mg.Location = new System.Drawing.Point(87, 130);
            this.RB_mg.Name = "RB_mg";
            this.RB_mg.Size = new System.Drawing.Size(53, 16);
            this.RB_mg.TabIndex = 11;
            this.RB_mg.TabStop = true;
            this.RB_mg.Text = " 芒果";
            this.RB_mg.UseVisualStyleBackColor = true;
            // 
            // RB_sh
            // 
            this.RB_sh.AutoSize = true;
            this.RB_sh.Location = new System.Drawing.Point(263, 130);
            this.RB_sh.Name = "RB_sh";
            this.RB_sh.Size = new System.Drawing.Size(47, 16);
            this.RB_sh.TabIndex = 12;
            this.RB_sh.TabStop = true;
            this.RB_sh.Text = "搜狐";
            this.RB_sh.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "说明：账号一人一个账号，账号每5小时只能领取一次！";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 282);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RB_sh);
            this.Controls.Add(this.RB_mg);
            this.Controls.Add(this.RB_yk);
            this.Controls.Add(this.RB_aqy);
            this.Controls.Add(this.MachineCode);
            this.Controls.Add(this.skinButton1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "各大视频网站VIP账号密码获取器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MachineCode.ResumeLayout(false);
            this.MachineCode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinButton skinButton1;
        private CCWin.SkinControl.SkinTextBox MachineCode;
        private CCWin.SkinControl.SkinWaterTextBox BaseText;
        private System.Windows.Forms.RadioButton RB_aqy;
        private System.Windows.Forms.RadioButton RB_yk;
        private System.Windows.Forms.RadioButton RB_mg;
        private System.Windows.Forms.RadioButton RB_sh;
        private System.Windows.Forms.Label label3;
    }
}

