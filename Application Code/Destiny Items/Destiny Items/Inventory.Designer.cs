namespace Destiny_Items
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            lblForm2Display = new Label();
            SuspendLayout();
            // 
            // lblForm2Display
            // 
            lblForm2Display.AutoSize = true;
            lblForm2Display.Font = new Font("OCR A Extended", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblForm2Display.Location = new Point(11, 9);
            lblForm2Display.Margin = new Padding(2, 0, 2, 0);
            lblForm2Display.Name = "lblForm2Display";
            lblForm2Display.Size = new Size(0, 23);
            lblForm2Display.TabIndex = 21;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1013, 613);
            Controls.Add(lblForm2Display);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblForm2Display;
    }
}