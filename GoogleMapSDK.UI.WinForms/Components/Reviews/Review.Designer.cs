namespace GoogleMapSDK.UI.WinForms.Components.Reviews
{
    partial class Review
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            AuthorNameLab = new Label();
            publishTimeLab = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            StarLab = new Label();
            RatingLab = new Label();
            ReviewTextLab = new Label();
            divider = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(232, 234, 237);
            pictureBox1.Location = new Point(20, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(48, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // AuthorNameLab
            // 
            AuthorNameLab.AutoSize = true;
            AuthorNameLab.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            AuthorNameLab.ForeColor = Color.FromArgb(32, 33, 36);
            AuthorNameLab.Location = new Point(80, 15);
            AuthorNameLab.Name = "AuthorNameLab";
            AuthorNameLab.Size = new Size(59, 30);
            AuthorNameLab.TabIndex = 1;
            AuthorNameLab.Text = "名字";
            // 
            // publishTimeLab
            // 
            publishTimeLab.AutoSize = true;
            publishTimeLab.Font = new Font("Segoe UI", 8.5F);
            publishTimeLab.ForeColor = Color.FromArgb(95, 99, 104);
            publishTimeLab.Location = new Point(80, 44);
            publishTimeLab.Name = "publishTimeLab";
            publishTimeLab.Size = new Size(78, 23);
            publishTimeLab.TabIndex = 5;
            publishTimeLab.Text = "發布時間";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(StarLab);
            flowLayoutPanel1.Controls.Add(RatingLab);
            flowLayoutPanel1.Location = new Point(80, 68);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(151, 30);
            flowLayoutPanel1.TabIndex = 2;
            flowLayoutPanel1.WrapContents = false;
            // 
            // StarLab
            // 
            StarLab.AutoSize = true;
            StarLab.Font = new Font("Segoe UI", 11F);
            StarLab.ForeColor = Color.FromArgb(251, 188, 5);
            StarLab.Location = new Point(3, 0);
            StarLab.Margin = new Padding(3, 0, 8, 0);
            StarLab.Name = "StarLab";
            StarLab.Size = new Size(103, 30);
            StarLab.TabIndex = 0;
            StarLab.Text = "★★★★★";
            // 
            // RatingLab
            // 
            RatingLab.AutoSize = true;
            RatingLab.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            RatingLab.ForeColor = Color.FromArgb(95, 99, 104);
            RatingLab.Location = new Point(114, 3);
            RatingLab.Margin = new Padding(0, 3, 0, 0);
            RatingLab.Name = "RatingLab";
            RatingLab.Size = new Size(37, 25);
            RatingLab.TabIndex = 3;
            RatingLab.Text = "5.0";
            // 
            // ReviewTextLab
            // 
            ReviewTextLab.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ReviewTextLab.Font = new Font("Segoe UI", 10F);
            ReviewTextLab.ForeColor = Color.FromArgb(60, 64, 67);
            ReviewTextLab.Location = new Point(20, 104);
            ReviewTextLab.MaximumSize = new Size(460, 0);
            ReviewTextLab.Name = "ReviewTextLab";
            ReviewTextLab.Size = new Size(460, 60);
            ReviewTextLab.TabIndex = 4;
            ReviewTextLab.Text = "評論內容會顯示在這裡，支援自動換行，方便閱讀較長的評論文字。";
            // 
            // divider
            // 
            divider.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            divider.BackColor = Color.FromArgb(232, 234, 237);
            divider.Location = new Point(0, 198);
            divider.Name = "divider";
            divider.Size = new Size(500, 1);
            divider.TabIndex = 6;
            // 
            // Review
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(divider);
            Controls.Add(ReviewTextLab);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(publishTimeLab);
            Controls.Add(AuthorNameLab);
            Controls.Add(pictureBox1);
            Margin = new Padding(0, 0, 0, 12);
            MinimumSize = new Size(400, 0);
            Name = "Review";
            Padding = new Padding(0, 0, 0, 16);
            Size = new Size(500, 199);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label AuthorNameLab;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label RatingLab;
        private Label ReviewTextLab;
        private Label publishTimeLab;
        private Label StarLab;
        private Panel divider;
    }
}