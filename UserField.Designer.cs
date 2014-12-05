namespace SeaFightGame
{
    partial class VisualField
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userFild = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // userFild
            // 
            this.userFild.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.userFild.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userFild.Location = new System.Drawing.Point(20, 20);
            this.userFild.Name = "userFild";
            this.userFild.Size = new System.Drawing.Size(162, 162);
            this.userFild.TabIndex = 0;
            this.userFild.Paint += new System.Windows.Forms.PaintEventHandler(this.userFiled_Paint);
            this.userFild.MouseClick += new System.Windows.Forms.MouseEventHandler(this.userFild_MouseClick);
            // 
            // VisualField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userFild);
            this.Name = "VisualField";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(202, 202);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel userFild;
    }
}
