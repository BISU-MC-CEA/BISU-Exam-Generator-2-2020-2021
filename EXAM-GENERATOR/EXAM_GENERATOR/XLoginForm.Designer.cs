namespace EXAM_GENERATOR
{
    partial class XLoginForm
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::EXAM_GENERATOR.SplashScreen1), true, true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XLoginForm));
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.hideBtn = new DevExpress.XtraEditors.SimpleButton();
            this.showBtn = new DevExpress.XtraEditors.SimpleButton();
            this.usernameTbx = new DevExpress.XtraEditors.TextEdit();
            this.passCodeTbx = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.hyperlinkLabelControl1 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.statusLbl = new DevExpress.XtraEditors.LabelControl();
            this.lblWarning = new DevExpress.XtraEditors.LabelControl();
            this.capslock_label = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::EXAM_GENERATOR.WaitForm1), true, true, true);
            ((System.ComponentModel.ISupportInitialize)(this.usernameTbx.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passCodeTbx.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Metropolis Dark";
            // 
            // simpleButton1
            // 
            this.simpleButton1.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.Gold;
            this.simpleButton1.Appearance.BackColor2 = System.Drawing.Color.OrangeRed;
            this.simpleButton1.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Lucida Sans Typewriter", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseBorderColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.simpleButton1.Location = new System.Drawing.Point(240, 249);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Sign in";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // hideBtn
            // 
            this.hideBtn.AllowFocus = false;
            this.hideBtn.Appearance.Font = new System.Drawing.Font("Lucida Sans Typewriter", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hideBtn.Appearance.Options.UseFont = true;
            this.hideBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.hideBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hideBtn.Image = ((System.Drawing.Image)(resources.GetObject("hideBtn.Image")));
            this.hideBtn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.hideBtn.Location = new System.Drawing.Point(381, 201);
            this.hideBtn.Name = "hideBtn";
            this.hideBtn.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.hideBtn.Size = new System.Drawing.Size(27, 23);
            this.hideBtn.TabIndex = 1;
            this.hideBtn.Visible = false;
            this.hideBtn.Click += new System.EventHandler(this.hideBtn_Click);
            // 
            // showBtn
            // 
            this.showBtn.AllowFocus = false;
            this.showBtn.Appearance.Font = new System.Drawing.Font("Lucida Sans Typewriter", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showBtn.Appearance.Options.UseFont = true;
            this.showBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.showBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showBtn.Image = ((System.Drawing.Image)(resources.GetObject("showBtn.Image")));
            this.showBtn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.showBtn.Location = new System.Drawing.Point(381, 201);
            this.showBtn.Name = "showBtn";
            this.showBtn.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.showBtn.Size = new System.Drawing.Size(27, 23);
            this.showBtn.TabIndex = 2;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click_1);
            // 
            // usernameTbx
            // 
            this.usernameTbx.Location = new System.Drawing.Point(210, 171);
            this.usernameTbx.Name = "usernameTbx";
            this.usernameTbx.Properties.Appearance.Font = new System.Drawing.Font("Lucida Sans Typewriter", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTbx.Properties.Appearance.Options.UseFont = true;
            this.usernameTbx.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.DarkOrange;
            this.usernameTbx.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.usernameTbx.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.usernameTbx.Size = new System.Drawing.Size(198, 24);
            this.usernameTbx.TabIndex = 0;
            this.usernameTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usernameTbx_KeyDown);
            // 
            // passCodeTbx
            // 
            this.passCodeTbx.Location = new System.Drawing.Point(210, 201);
            this.passCodeTbx.Name = "passCodeTbx";
            this.passCodeTbx.Properties.Appearance.Font = new System.Drawing.Font("Lucida Sans Typewriter", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passCodeTbx.Properties.Appearance.Options.UseFont = true;
            this.passCodeTbx.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.DarkOrange;
            this.passCodeTbx.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.passCodeTbx.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.passCodeTbx.Properties.UseSystemPasswordChar = true;
            this.passCodeTbx.Size = new System.Drawing.Size(165, 24);
            this.passCodeTbx.TabIndex = 1;
            this.passCodeTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passCodeTbx_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Lucida Sans Typewriter", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(123, 174);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 17);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Username:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Lucida Sans Typewriter", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(123, 204);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(81, 17);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Password:";
            // 
            // hyperlinkLabelControl1
            // 
            this.hyperlinkLabelControl1.Appearance.Font = new System.Drawing.Font("Lucida Sans Typewriter", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hyperlinkLabelControl1.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.hyperlinkLabelControl1.Appearance.LinkColor = System.Drawing.Color.DarkOrange;
            this.hyperlinkLabelControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hyperlinkLabelControl1.Location = new System.Drawing.Point(214, 278);
            this.hyperlinkLabelControl1.Name = "hyperlinkLabelControl1";
            this.hyperlinkLabelControl1.Size = new System.Drawing.Size(126, 17);
            this.hyperlinkLabelControl1.TabIndex = 3;
            this.hyperlinkLabelControl1.Text = "Create Account";
            this.hyperlinkLabelControl1.Click += new System.EventHandler(this.hyperlinkLabelControl1_Click);
            // 
            // statusLbl
            // 
            this.statusLbl.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.statusLbl.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.statusLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.statusLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusLbl.Location = new System.Drawing.Point(0, 313);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(131, 14);
            this.statusLbl.TabIndex = 7;
            this.statusLbl.Text = "Status: Not Connected!";
            this.statusLbl.ToolTip = "Change Connection?";
            this.statusLbl.Visible = false;
            this.statusLbl.Click += new System.EventHandler(this.statusLbl_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.Appearance.Font = new System.Drawing.Font("Lucida Sans Typewriter", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblWarning.Location = new System.Drawing.Point(210, 148);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(0, 17);
            this.lblWarning.TabIndex = 8;
            // 
            // capslock_label
            // 
            this.capslock_label.Appearance.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capslock_label.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.capslock_label.Location = new System.Drawing.Point(210, 231);
            this.capslock_label.Name = "capslock_label";
            this.capslock_label.Size = new System.Drawing.Size(105, 12);
            this.capslock_label.TabIndex = 9;
            this.capslock_label.Text = "CAPS LOCK IS ON";
            this.capslock_label.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Lucida Sans Typewriter", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelControl3.Location = new System.Drawing.Point(49, -2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(156, 72);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Exam";
            // 
            // labelControl4
            // 
            this.labelControl4.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.labelControl4.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl4.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Lucida Sans Typewriter", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelControl4.Location = new System.Drawing.Point(133, 67);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(351, 72);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Generator";
            // 
            // XLoginForm
            // 
            this.ActiveGlowColor = System.Drawing.Color.DarkOrange;
            this.Appearance.ForeColor = System.Drawing.Color.Linen;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 327);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.capslock_label);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.hyperlinkLabelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.passCodeTbx);
            this.Controls.Add(this.usernameTbx);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.hideBtn);
            this.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "XLoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign in";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XLoginForm_FormClosing);
            this.Load += new System.EventHandler(this.XLoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usernameTbx.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passCodeTbx.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton hideBtn;
        private DevExpress.XtraEditors.SimpleButton showBtn;
        private DevExpress.XtraEditors.TextEdit usernameTbx;
        private DevExpress.XtraEditors.TextEdit passCodeTbx;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.HyperlinkLabelControl hyperlinkLabelControl1;
        private DevExpress.XtraEditors.LabelControl statusLbl;
        private DevExpress.XtraEditors.LabelControl lblWarning;
        private DevExpress.XtraEditors.LabelControl capslock_label;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
    }
}