namespace Destiny_Items
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            lblLoreDisplay = new Label();
            pbUno = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbUno).BeginInit();
            SuspendLayout();
            // 
            // lblLoreDisplay
            // 
            lblLoreDisplay.BackColor = Color.Transparent;
            lblLoreDisplay.Font = new Font("OCR A Extended", 10.125F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblLoreDisplay.Location = new Point(11, 97);
            lblLoreDisplay.Margin = new Padding(2, 0, 2, 0);
            lblLoreDisplay.Name = "lblLoreDisplay";
            lblLoreDisplay.Size = new Size(1011, 437);
            lblLoreDisplay.TabIndex = 103;
            // 
            // pbUno
            // 
            pbUno.Location = new Point(11, 12);
            pbUno.Name = "pbUno";
            pbUno.Size = new Size(100, 82);
            pbUno.SizeMode = PictureBoxSizeMode.Zoom;
            pbUno.TabIndex = 104;
            pbUno.TabStop = false;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1033, 635);
            Controls.Add(pbUno);
            Controls.Add(lblLoreDisplay);
            Name = "Form4";
            Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)pbUno).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblLoreDisplay;
        private PictureBox pbUno;
    }
}