namespace NotficationApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblName = new Label();
            rtbLogs = new RichTextBox();
            lblLog = new Label();
            lblMessage = new Label();
            txtMessage = new TextBox();
            lblChannel = new Label();
            cmbServices = new ComboBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Top;
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 15F);
            lblName.Location = new Point(247, 9);
            lblName.Name = "lblName";
            lblName.Size = new Size(284, 35);
            lblName.TabIndex = 0;
            lblName.Text = "Отправка уведомления";
            // 
            // rtbLogs
            // 
            rtbLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbLogs.Location = new Point(476, 96);
            rtbLogs.Name = "rtbLogs";
            rtbLogs.ReadOnly = true;
            rtbLogs.Size = new Size(312, 342);
            rtbLogs.TabIndex = 2;
            rtbLogs.Text = "";
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.Font = new Font("Segoe UI", 11F);
            lblLog.Location = new Point(476, 64);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(137, 25);
            lblLog.TabIndex = 3;
            lblLog.Text = "Журнал логов:";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 11F);
            lblMessage.Location = new Point(12, 64);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(180, 25);
            lblMessage.TabIndex = 4;
            lblMessage.Text = "Ввести сообщение:";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 96);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(439, 27);
            txtMessage.TabIndex = 5;
            // 
            // lblChannel
            // 
            lblChannel.AutoSize = true;
            lblChannel.Font = new Font("Segoe UI", 11F);
            lblChannel.Location = new Point(12, 139);
            lblChannel.Name = "lblChannel";
            lblChannel.Size = new Size(138, 25);
            lblChannel.TabIndex = 6;
            lblChannel.Text = "Выбор канала:";
            // 
            // cmbServices
            // 
            cmbServices.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServices.FormattingEnabled = true;
            cmbServices.Location = new Point(12, 173);
            cmbServices.Name = "cmbServices";
            cmbServices.Size = new Size(138, 28);
            cmbServices.TabIndex = 7;
            // 
            // btnSend
            // 
            btnSend.Font = new Font("Segoe UI", 9F);
            btnSend.Location = new Point(357, 135);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 8;
            btnSend.Text = "Отправить";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSend);
            Controls.Add(cmbServices);
            Controls.Add(lblChannel);
            Controls.Add(txtMessage);
            Controls.Add(lblMessage);
            Controls.Add(lblLog);
            Controls.Add(rtbLogs);
            Controls.Add(lblName);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private RichTextBox rtbLogs;
        private Label lblLog;
        private Label lblMessage;
        private TextBox txtMessage;
        private Label lblChannel;
        private ComboBox cmbServices;
        private Button btnSend;
    }
}
