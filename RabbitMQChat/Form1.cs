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
using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;

namespace RabbitMQChat
{
    public partial class Form1 : Form
    {
        private static Form1 _instance;
        public static Form1 Instance
        {
            get { 
                if( _instance == null )
                    _instance = new Form1();
                return _instance;
            }
        }



        private Sender _sender = null;
        private Receiver _receiver = null;
        private userLogin _userLogin = null;
        private userChat _userChat = null;
        

        private string _currentUserName;
        private string _currentOpenedChat;
        private string _currentSelectedUser;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();
            
        }

        public Panel Content
        {
            get { return mainContainer; }
            set { mainContainer = value; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _instance = this;
            _userLogin = new userLogin();
            mainContainer.Controls.Add(_userLogin);
            _userLogin.onLogin += HandleLogin;
            myMenuStrip.BackColor = Color.FromArgb(31, 41, 54);
        }

        private void HandleLogin(object sender, string username)
        {
            _currentUserName = username;
            _userChat = new userChat(username);
            mainContainer.Controls.Add(_userChat);
            _userChat.onMessageSent += HandleMessageSend;
            _userChat.onChatSelected += HandleChatSelection;
            _sender = new Sender(username);
            _receiver = new Receiver(username);
            _receiver.onMessageReceived += HandleMessageReceived;
            label1.Text = _currentUserName;
        }

        private void HandleChatSelection(object sender, string selectedChat)
        {
            _userChat.EnableSendButton();
            _userChat.ClearChat();
            string chatName = string.Empty;
            if(!myDBConnection.DoesChatExist(_currentUserName, selectedChat, out chatName))
            {
                chatName = myDBConnection.CreateChatRoom(_currentUserName, selectedChat);
            }
            if(chatName !=null)
            {
                _userChat.LoadMessageHistory(chatName);
            }
            RabbitMQUtility.DeclareQueueExchange(_sender.Channel, chatName, "fanout");
            RabbitMQUtility.BindExchangeToQueue(_sender.Channel, chatName, _sender.User);
            _currentOpenedChat = chatName;
            _currentSelectedUser = selectedChat;
            label2.Text = selectedChat;
            
        }

        private void HandleMessageSend(object sender, string messageText)
        {
            _sender.SendMessage(messageText, _currentOpenedChat);
        }

        private void HandleMessageReceived(object sender, Message message)
        {
            _userChat.ReceiveMessage(message, _currentSelectedUser);
        }

        private void myMenuStrip_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
