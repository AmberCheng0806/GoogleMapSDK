namespace GoogleMapSDK.UI.WinForms.Components.Reviews
{
    partial class Reviews
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
            headerPanel = new Panel();
            StarLab = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            RatingLab = new Label();
            ReviewsPanel = new FlowLayoutPanel();
            headerPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(flowLayoutPanel1);
            headerPanel.Controls.Add(RatingLab);
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(24, 16, 24, 16);
            headerPanel.Size = new Size(728, 84);
            headerPanel.TabIndex = 3;
            // 
            // StarLab
            // 
            StarLab.AutoSize = true;
            StarLab.Font = new Font("Segoe UI", 16F);
            StarLab.ForeColor = Color.FromArgb(251, 188, 5);
            StarLab.Location = new Point(3, 0);
            StarLab.Name = "StarLab";
            StarLab.Size = new Size(155, 45);
            StarLab.TabIndex = 0;
            StarLab.Text = "★★★★★";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(StarLab);
            flowLayoutPanel1.Location = new Point(132, 16);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(167, 62);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // RatingLab
            // 
            RatingLab.AutoSize = true;
            RatingLab.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            RatingLab.ForeColor = Color.FromArgb(32, 33, 36);
            RatingLab.Location = new Point(24, 16);
            RatingLab.Name = "RatingLab";
            RatingLab.Size = new Size(102, 70);
            RatingLab.TabIndex = 1;
            RatingLab.Text = "4.5";
            // 
            // ReviewsPanel
            // 
            ReviewsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ReviewsPanel.AutoScroll = true;
            ReviewsPanel.BackColor = Color.FromArgb(245, 246, 248);
            ReviewsPanel.FlowDirection = FlowDirection.TopDown;
            ReviewsPanel.Location = new Point(0, 84);
            ReviewsPanel.Name = "ReviewsPanel";
            ReviewsPanel.Padding = new Padding(24, 16, 24, 16);
            ReviewsPanel.Size = new Size(728, 759);
            ReviewsPanel.TabIndex = 0;
            ReviewsPanel.WrapContents = false;
            // 
            // Reviews
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 248);
            Controls.Add(ReviewsPanel);
            Controls.Add(headerPanel);
            Name = "Reviews";
            Size = new Size(728, 843);
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        private FlowLayoutPanel ReviewsPanel;
        private Label RatingLab;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label StarLab;
        private Panel headerPanel;
    }
}