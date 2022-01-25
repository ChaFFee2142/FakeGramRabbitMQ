using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RabbitMQChat
{
    public partial class userChat : UserControl
    {
        public event EventHandler<string> onMessageSent;
        public event EventHandler<string> onChatSelected;

        private string _currentUserName;
        public string CurrentUserName
        {
            get { return _currentUserName; }
            set { _currentUserName = value; }
        }
        
        public string currentUserName;
        myDBConnection con = new myDBConnection();
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt;

        private const int EM_SETCUEBANNER = 0x1501;

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        public userChat(string currentUserName)
        {
            InitializeComponent();
            textBox1.GotFocus += onFocus;
            textBox1.LostFocus += onDefocus;
            _currentUserName = currentUserName;
            con.Connect();
        }
        public void onFocus(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter text here...")
            {
                textBox1.Text = "";
            }
        }
        public void onDefocus(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter text here...";
            }
        }
        private void userChat_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            listBox1.Visible = false;
            textBox1.Visible = false;
            listBox1.Items.Clear();
            try
            {
                con.cn.Open();
                cmd = new MySqlCommand(string.Format("SELECT username FROM users WHERE username!=\"{0}\"", _currentUserName), con.cn);
                cmd.ExecuteNonQuery();
                da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    listView1.Items.Add(dr[0].ToString());
                }
                con.cn.Close();
            }
            catch (Exception ex)
            {
                con.cn.Close();
                MessageBox.Show(ex.Message);
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="Enter text here...")
            {
            onMessageSent?.Invoke(this, textBox1.Text);
            textBox1.Text = "Enter text here...";
            }
        }

        public void ReceiveMessage(Message message, string currentSelectedChat)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                if(message.Author == currentSelectedChat || message.Author == _currentUserName)
                {
                listBox1.Items.Add(message.Author + ": " + Encoding.UTF8.GetString(message.Text,0, message.Text.Length));

                }
            }));
        }

        public void LoadMessageHistory(string chatName)
        {
            MySqlDataReader reader = myDBConnection.LoadMessageHistory(chatName);
            while (reader.Read())
            {
                Message message = JsonConvert.DeserializeObject<Message>(reader.GetString(0));
                listBox1.Items.Add(message.Author + ": " + Encoding.UTF8.GetString(message.Text, 0, message.Text.Length));
            }



        }


        public void ClearChat()
        {
            listBox1.Items.Clear();
        }

        public void EnableSendButton()
        {
            button3.Enabled = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count != 0)
            {
            listBox1.Visible = true;
            textBox1.Visible = true;
            onChatSelected?.Invoke(this, listView1.SelectedItems[listView1.SelectedItems.Count - 1].Text);
            }
        }
    }
}
