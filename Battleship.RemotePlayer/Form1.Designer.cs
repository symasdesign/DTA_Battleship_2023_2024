namespace Battleship.RemotePlayer {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btnShot = new Button();
            numX = new NumericUpDown();
            numY = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            lblLog = new Label();
            btnConnect = new Button();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numY).BeginInit();
            SuspendLayout();
            // 
            // btnShot
            // 
            btnShot.Enabled = false;
            btnShot.Location = new Point(78, 152);
            btnShot.Name = "btnShot";
            btnShot.Size = new Size(120, 23);
            btnShot.TabIndex = 0;
            btnShot.Text = "Shot";
            btnShot.UseVisualStyleBackColor = true;
            btnShot.Click += btnShot_Click;
            // 
            // numX
            // 
            numX.Location = new Point(78, 69);
            numX.Name = "numX";
            numX.Size = new Size(120, 23);
            numX.TabIndex = 1;
            // 
            // numY
            // 
            numY.Location = new Point(78, 109);
            numY.Name = "numY";
            numY.Size = new Size(120, 23);
            numY.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 71);
            label1.Name = "label1";
            label1.Size = new Size(14, 15);
            label1.TabIndex = 3;
            label1.Text = "X";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 111);
            label2.Name = "label2";
            label2.Size = new Size(14, 15);
            label2.TabIndex = 4;
            label2.Text = "Y";
            // 
            // lblLog
            // 
            lblLog.Location = new Point(257, 69);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(531, 106);
            lblLog.TabIndex = 5;
            lblLog.Text = "lblLog";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(202, 19);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(120, 23);
            btnConnect.TabIndex = 6;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(80, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 7;
            textBox1.Text = "127.0.0.1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 194);
            Controls.Add(textBox1);
            Controls.Add(btnConnect);
            Controls.Add(lblLog);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numY);
            Controls.Add(numX);
            Controls.Add(btnShot);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numY).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnShot;
        private NumericUpDown numX;
        private NumericUpDown numY;
        private Label label1;
        private Label label2;
        private Label lblLog;
        private Button btnConnect;
        private TextBox textBox1;
    }
}
