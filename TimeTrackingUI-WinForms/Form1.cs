using System;
using System.Configuration;
using System.Windows.Forms;
using TimeTrackingLib;

namespace TimeTrackingUI_WinForms
{
    public partial class Form1 : Form
    {
        private ITimeTracking _timeTracking;
        private CheckBox _activeButton = null;
        private readonly string TTP = ConfigurationManager.AppSettings["DataPath"];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _timeTracking = new TimeTracking(TTP);
            _timeTracking.TimeAccountListChanged += SetupTimeAccountButtons;
            SetupTimeAccountButtons();
            _timeTracking.Switch(_activeButton.Tag as ITimeAccount);
            timerSession.Start();
        }

        private void SetupTimeAccountButtons()
        {
            while (panelTimeAccounts.Controls.Count > 0)
            {
                panelTimeAccounts.Controls.Remove(panelTimeAccounts.Controls[0]);
            }

            int buttonCount = 1;

            foreach (ITimeAccount account in _timeTracking.Accounts.Active)
            {
                CheckBox button = CreateButton(buttonCount, $"{buttonCount}\n{account.Name}");
                button.Tag = account;
                if ((_timeTracking.CurrentSession != null &&
                    account.Equals(_timeTracking.CurrentSession.Account)) || buttonCount == 1)
                {
                    _activeButton = button;
                }

                button.Click += TimeAccountAcctivate;
                panelTimeAccounts.Controls.Add(button);
                buttonCount++;
            }
            _activeButton.Checked = true;

        }

        private CheckBox CreateButton(int no, string name)
        {
            var button = new CheckBox();
            button.Appearance = Appearance.Button;
            button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            button.Location = new System.Drawing.Point(91, 345);
            button.Name = $"taButton{no}";
            button.Size = new System.Drawing.Size(82, 82);
            button.Text = name;
            button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            button.UseVisualStyleBackColor = true;
            button.TabStop = false;
            return button;
        }

        private void TimeAccountAcctivate(object sender, EventArgs e)
        {
            var button = sender as CheckBox;
            if (!button.Checked)
            {
                button.Checked = true;
                return; // prevent unchecking
            }

            ITimeAccount account = button.Tag as ITimeAccount;
            if (_timeTracking.Switch(account))
            {
                _activeButton.Checked = false;
                _activeButton = button;
            }
            ShowCommenting(!(_activeButton.Tag is BreakAccount));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timeTracking.Dispose();
        }

        private void bttTimeAccountAdd_Click(object sender, EventArgs e)
        {
            string accountName = Prompt.ShowDialog("Time Account Name:", "Working Time Tracking");
            _timeTracking.AddAccount(accountName);
        }

        private void timerSession_Tick(object sender, EventArgs e)
        {
            ITrackingSession session = _timeTracking.CurrentSession;
            lblSessionStart.Text = $"Started: {session.Start.ToString("HH:mm:ss")}";
            TimeSpan duration = DateTime.Now - session.Start;
            lblSessionDuration.Text = $"Duration: {duration.Hours.ToString("00")}:{duration.Minutes.ToString("00")}:{duration.Seconds.ToString("00")}";
        }

        private void bttAddComment_Click(object sender, EventArgs e)
        {
            if (txtComment.Text.Length > 0)
            {
                string comment = $"{DateTime.Now.ToString("HH:mm:ss >")} {txtComment.Text}";
                _timeTracking.CurrentSession.Comments.Add(comment);
                listComments.Items.Add(comment);
                txtComment.Text = string.Empty;
            }
        }

        private void listComments_KeyDown(object sender, KeyEventArgs e)
        {
            if (listComments.SelectedIndex > -1)
            {
                listComments.Items.RemoveAt(listComments.SelectedIndex);
                _timeTracking.CurrentSession.Comments.Clear();
                foreach (string comment in listComments.Items)
                {
                    _timeTracking.CurrentSession.Comments.Add(comment);
                }
            }
        }

        private void txtComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttAddComment_Click(null, EventArgs.Empty);
            }
        }

        private void ShowCommenting(bool show)
        {
            txtComment.Visible =
            listComments.Visible =
            bttAddComment.Visible = show;
        }
    }
}
