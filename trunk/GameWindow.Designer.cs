namespace SeaFightGame
{
    partial class GameWindow
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
            this.button1 = new System.Windows.Forms.Button();
            this.gameMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатиКорабліToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.player1ViewControler = new SeaFightGame.View.Player1ViewControler();
            this.player2ViewControler = new SeaFightGame.View.Player2ViewControler();
            this.gameMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ImageKey = "(none)";
            this.button1.Location = new System.Drawing.Point(283, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ігрове меню";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gameMenu
            // 
            this.gameMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.показатиКорабліToolStripMenuItem});
            this.gameMenu.Name = "contextMenuStrip1";
            this.gameMenu.Size = new System.Drawing.Size(172, 48);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.newGameToolStripMenuItem.Text = "Нова гра";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // показатиКорабліToolStripMenuItem
            // 
            this.показатиКорабліToolStripMenuItem.Name = "показатиКорабліToolStripMenuItem";
            this.показатиКорабліToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.показатиКорабліToolStripMenuItem.Text = "Показати кораблі";
            this.показатиКорабліToolStripMenuItem.Click += new System.EventHandler(this.показатиКорабліToolStripMenuItem_Click);
            // 
            // player1ViewControler1
            // 
            this.player1ViewControler.BackColor = System.Drawing.Color.LightSkyBlue;
            //this.player1ViewControler.Field = null;
            //this.player1ViewControler.Game = null;
            this.player1ViewControler.Location = new System.Drawing.Point(12, 50);
            this.player1ViewControler.Name = "player1ViewControler1";
            this.player1ViewControler.Size = new System.Drawing.Size(300, 300);
            this.player1ViewControler.TabIndex = 3;
            // 
            // player2ViewControler1
            // 
            this.player2ViewControler.BackColor = System.Drawing.Color.LightSkyBlue;
            //this.player2ViewControler.Field = null;
            //this.player2ViewControler.Game = null;
            this.player2ViewControler.Location = new System.Drawing.Point(348, 50);
            this.player2ViewControler.Name = "player2ViewControler1";
            this.player2ViewControler.Size = new System.Drawing.Size(300, 300);
            this.player2ViewControler.TabIndex = 4;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(659, 411);
            this.Controls.Add(this.player2ViewControler);
            this.Controls.Add(this.player1ViewControler);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameWindow";
            this.Text = "Морський бій";
            this.gameMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip gameMenu;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатиКорабліToolStripMenuItem;
        private View.Player1ViewControler player1ViewControler;
        private View.Player2ViewControler player2ViewControler;

    }
}

