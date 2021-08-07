
namespace AsyncSocketServer
{
    partial class Form1
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
            this.AcceptConnection = new System.Windows.Forms.Button();
            this.sendAllBtn = new System.Windows.Forms.Button();
            this.msgLabel = new System.Windows.Forms.Label();
            this.msgBox = new System.Windows.Forms.TextBox();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AcceptConnection
            // 
            this.AcceptConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcceptConnection.Location = new System.Drawing.Point(12, 341);
            this.AcceptConnection.Name = "AcceptConnection";
            this.AcceptConnection.Size = new System.Drawing.Size(266, 87);
            this.AcceptConnection.TabIndex = 0;
            this.AcceptConnection.Text = "Accept Incoming Connection";
            this.AcceptConnection.UseVisualStyleBackColor = true;
            this.AcceptConnection.Click += new System.EventHandler(this.AcceptConnection_Click);
            // 
            // sendAllBtn
            // 
            this.sendAllBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendAllBtn.Location = new System.Drawing.Point(284, 341);
            this.sendAllBtn.Name = "sendAllBtn";
            this.sendAllBtn.Size = new System.Drawing.Size(144, 87);
            this.sendAllBtn.TabIndex = 1;
            this.sendAllBtn.Text = "&Send All";
            this.sendAllBtn.UseVisualStyleBackColor = true;
            this.sendAllBtn.Click += new System.EventHandler(this.sendAllBtn_Click);
            // 
            // msgLabel
            // 
            this.msgLabel.AutoSize = true;
            this.msgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgLabel.Location = new System.Drawing.Point(487, 341);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(231, 29);
            this.msgLabel.TabIndex = 2;
            this.msgLabel.Text = "Enter you message: ";
            // 
            // msgBox
            // 
            this.msgBox.Location = new System.Drawing.Point(481, 373);
            this.msgBox.Name = "msgBox";
            this.msgBox.Size = new System.Drawing.Size(237, 22);
            this.msgBox.TabIndex = 3;
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(449, 401);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(316, 27);
            this.btnStopServer.TabIndex = 4;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Location = new System.Drawing.Point(12, 27);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(776, 279);
            this.txtConsole.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.btnStopServer);
            this.Controls.Add(this.msgBox);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.sendAllBtn);
            this.Controls.Add(this.AcceptConnection);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AcceptConnection;
        private System.Windows.Forms.Button sendAllBtn;
        private System.Windows.Forms.Label msgLabel;
        private System.Windows.Forms.TextBox msgBox;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.TextBox txtConsole;
    }
}

