namespace Destiny_Items
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            lblRecommendation = new Label();
            SuspendLayout();
            // 
            // lblRecommendation
            // 
            lblRecommendation.BackColor = Color.Transparent;
            lblRecommendation.Font = new Font("OCR A Extended", 10.125F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblRecommendation.ForeColor = Color.Gold;
            lblRecommendation.Location = new Point(92, 70);
            lblRecommendation.Margin = new Padding(2, 0, 2, 0);
            lblRecommendation.Name = "lblRecommendation";
            lblRecommendation.Size = new Size(783, 403);
            lblRecommendation.TabIndex = 21;
            lblRecommendation.Text = "We recommend using... ";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(998, 571);
            Controls.Add(lblRecommendation);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
        }

        #endregion

        private Label lblRecommendation;
    }
}