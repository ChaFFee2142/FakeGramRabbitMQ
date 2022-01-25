using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQChat
{
    class myDBConnection
    {
        public MySqlConnection cn;

        public void Connect()
        {
            cn = new MySqlConnection("Datasource=127.0.0.1;username=root;password=;database=fakegramdb");
        }
        private static MySqlConnection CreateConnection()
        {
            return new MySqlConnection("Datasource=127.0.0.1;username=root;password=;database=fakegramdb");
            
        }

        public static void SaveMessageToDB(string channel, string message)
        {
            MySqlConnection conn = CreateConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO messageHistory VALUES(null, '{0}', '{1}')",channel, message), conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static bool DoesChatExist(string sourceUser, string destinationUser, out string chatName)
        {
            MySqlConnection conn = CreateConnection();
            conn.Open();

            chatName = string.Empty;
            MySqlCommand cmd = new MySqlCommand(string.Format("SELECT roomName FROM chatrooms WHERE roomName='{0}_{1}' OR roomName='{1}_{0}'",sourceUser, destinationUser), conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader mySqlDataReader = cmd.ExecuteReader();
            bool isRoomPresent = false;

            while (mySqlDataReader.Read())
            {
                isRoomPresent = mySqlDataReader.GetString(0) != null;
                chatName = mySqlDataReader.GetString(0);
            }

            mySqlDataReader.Close();
            mySqlDataReader.Dispose();
            conn.Close();
            return isRoomPresent;
        }

        public static MySqlDataReader LoadMessageHistory(string ChatName)
        {
            MySqlConnection conn = CreateConnection();
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(String.Format("SELECT message FROM messagehistory WHERE channel='{0}'",ChatName), conn);
            


            return cmd.ExecuteReader();
        }
        public static string CreateChatRoom(string sourceUser, string DestinationUser)
        {
            MySqlConnection conn = CreateConnection();
            conn.Open();
            
            string chatName = string.Empty;
            chatName = sourceUser + "_" + DestinationUser;

            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO chatRooms VALUES (null, '{0}')", chatName), conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return chatName;

        }
    }
}
