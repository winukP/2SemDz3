using NotficationApp.Classes;
using NotficationApp.Interfaces;
using Serilog;
using Serilog.Core;

namespace NotficationApp
{
    public partial class MainForm : Form
    {
        private readonly ILoggerService Logger;
        private readonly List<INotificationService> AvailableServices;
        private bool isDiscoCancelled = false;

        public MainForm(ILoggerService logger, IEnumerable<INotificationService> services)
        {
            InitializeComponent();
            Logger = logger;
            AvailableServices = services.ToList();
            SubscribeToEvents();
            SetupComboBox();
        }

        private void SetupComboBox()
        {
            var names = AvailableServices.Select(s => s.Name).ToArray();
            cmbServices.Items.AddRange(names);
        }

        private void SubscribeToEvents()
        {
            Logger.OnLogReceived += delegate (string msg)
            {
                rtbLogs.AppendText(msg + Environment.NewLine);
                rtbLogs.ScrollToCaret();
            };
        }

        private void ResetUI()
        {
            isDiscoCancelled = true;
            this.BackColor = SystemColors.Control;

            rtbLogs.BackColor = Color.White;
            rtbLogs.ForeColor = Color.Black;
            rtbLogs.BorderStyle = BorderStyle.Fixed3D;

            txtMessage.BackColor = Color.White;
            txtMessage.ForeColor = Color.Black;
            txtMessage.BorderStyle = BorderStyle.Fixed3D;

            lblChannel.ForeColor = SystemColors.ControlText;
            lblLog.ForeColor = SystemColors.ControlText;
            lblMessage.ForeColor = SystemColors.ControlText;
            lblName.ForeColor = SystemColors.ControlText;

            btnSend.BackColor = SystemColors.Control;
            btnSend.ForeColor = SystemColors.ControlText;
            btnSend.UseVisualStyleBackColor = true;

            cmbServices.FlatStyle = FlatStyle.Standard;
            cmbServices.BackColor = Color.White;
            cmbServices.ForeColor = Color.Black;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            string selectedServiceName = cmbServices.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(message))
            {
                Logger.LogError("Попытка отправки пустого сообщения");
                MessageBox.Show("Попытка отправки пустого сообщения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var service = AvailableServices.FirstOrDefault(s => s.Name == selectedServiceName);
            if (service == null)
            {
                Logger.LogWarning("Пользователь не выбрал сервис уведомлений перед отправкой.");
                MessageBox.Show("Выберите тип уведомления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (message == "777")
            {
                ResetUI();
                isDiscoCancelled = false;
                Logger.LogSecret("!!! ВНИМАНИЕ: АКТИВИРОВАН РЕЖИМ ДИСКОТЕКИ !!!");
                MessageBox.Show("!!! ВЫ ВЫБИЛИ ДЖЕКПОТ !!!", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Color originalColor = this.BackColor;
                Color[] discoColors = { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Purple };
                for (int i = 0; i < 1000; i++)
                {
                    foreach (var color in discoColors)
                    {
                        if (isDiscoCancelled) break;
                        this.BackColor = color;
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }
                }
                if (!isDiscoCancelled)
                {
                    this.BackColor = SystemColors.Control;
                    MessageBox.Show("ДИСКОТКЕА завершилась", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtMessage.Clear();
                txtMessage.Focus();
                return;
            }

            if (message == "666")
            {
                ResetUI();
                isDiscoCancelled = true;
                Logger.LogSecret("ВНИМАНИЕ: Активирован протокол 13. Система переходит в скрытый режим.");

                this.BackColor = Color.Black;
                rtbLogs.BackColor = Color.FromArgb(20, 20, 20); 
                rtbLogs.ForeColor = Color.Red;

                txtMessage.BackColor = Color.Black;  
                txtMessage.ForeColor = Color.Red; 
                
                lblChannel.ForeColor = Color.Red;
                lblLog.ForeColor = Color.Red;
                lblMessage.ForeColor = Color.Red;
                lblName.ForeColor = Color.Red;

                btnSend.ForeColor = Color.Red;
                btnSend.BackColor = Color.FromArgb(20, 20, 20);

                cmbServices.FlatStyle = FlatStyle.Flat;
                cmbServices.BackColor = Color.Black;
                cmbServices.ForeColor = Color.Red;
                MessageBox.Show("Вы потревожили систему...", "Протокол 13", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMessage.Clear();
                txtMessage.Focus();
                return;
            }

            if (message.ToLower() == "сброс")
            {
                ResetUI();
                Logger.LogSecret("Все визуальные параметры сброшены.");
                txtMessage.Clear();
                txtMessage.Focus();
                return;
            }
            try
            {
                var senderService = new NotificationSender(service);
                senderService.Send(message);
                txtMessage.Clear();
                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка в {service.Name}: {ex.Message}");
                MessageBox.Show($"Не удалось отправить: {ex.Message}", "Ошибка сервиса", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
