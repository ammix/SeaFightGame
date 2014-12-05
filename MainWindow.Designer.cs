namespace SeaFightGame
{
    partial class MainWindow
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
            this.player2Field = new SeaFightGame.VisualField();
            this.player1Field = new SeaFightGame.VisualField();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(283, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Game Menu";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // player2Field
            // 
            this.player2Field.DataField = null;
            this.player2Field.Location = new System.Drawing.Point(328, 47);
            this.player2Field.Name = "player2Field";
            this.player2Field.Padding = new System.Windows.Forms.Padding(20);
            this.player2Field.Size = new System.Drawing.Size(303, 303);
            this.player2Field.TabIndex = 1;
            // 
            // player1Field
            // 
            this.player1Field.DataField = null;
            this.player1Field.Location = new System.Drawing.Point(12, 47);
            this.player1Field.Name = "player1Field";
            this.player1Field.Padding = new System.Windows.Forms.Padding(20);
            this.player1Field.Size = new System.Drawing.Size(303, 303);
            this.player1Field.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(639, 438);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.player2Field);
            this.Controls.Add(this.player1Field);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Sea Fight Game";
            this.ResumeLayout(false);

        }

        #endregion

        private VisualField player1Field;
        private VisualField player2Field;
        private System.Windows.Forms.Button button1;

    }
}

