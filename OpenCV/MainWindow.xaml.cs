using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private object lockObj = new object();
        private ObservableCollection<string> chattingLogList = new ObservableCollection<string>();
        private ObservableCollection<string> userList = new ObservableCollection<string>();
        private ObservableCollection<string> AccessLogList = new ObservableCollection<string>();
        Task connectCheckThread = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConnectCheckLoop()
        {
            while (true)
            {
                foreach (var item in ClientManager.clientDic)
                {
                    try
                    {
                        string sendStringData = "관리자<TEST>";
                        byte[] sendByteData = new byte[sendStringData.Length];
                        sendByteData = Encoding.Default.GetBytes(sendStringData);

                        item.Value.tcpClient.GetStream().Write(sendByteData, 0, sendByteData.Length);
                    }
                    catch (Exception e)
                    {
                        RemoveClient(item.Value);
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private void RemoveClient(ClientData targetClient)
        {
            ClientData? result = null;
            ClientManager.clientDic.TryRemove(targetClient.clientNumber, out result);
            string leavelog = string.Format("[{0}] {1} Leave Server", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", result.clientName));
            ChangeListView(leavelog, StaticDefine.ADD_ACCESS_LIST);
            ChangeListView(result.clientName, StaticDefine.REMOVE_USER_LIST);
        }

        private void ChangeListView(string message, int key)
        {
            switch (key)
            {
                case StaticDefine.ADD_ACCESS_LIST:
                    {
                        Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => 
                        {
                            AccessLogList.Add(message);
                        }));
                        break;
                    }
                case StaticDefine.ADD_CAHTTING_LIST:
                    {
                        Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
                        {
                            chattingLogList.Add(message);
                        }));
                        break;
                    }
                case StaticDefine.ADD_USER_LIST:
                    {
                        Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
                        {
                            userList.Add(message);
                        }));
                        break;
                    }
                case StaticDefine_REMOVE_USER_LIST:
                    {
                        Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
                        {
                            userList.Add(message);
                        }));
                        break;
                    }
                default:
                    break;
            }
        }

        private void MessageParsing(string sender, string message)
        {
            lock (lockObj)
            {
                List<string> msgList = new List<string>();
                string[] msgArray = message.Split('>');

                foreach (var item in msgArray)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        continue;
                    }
                    msgList.Add(item);
                }
                SendMsgToClient(msgList, sender);
            }
        }

        private void SendMsgToClient(List<string> msgList, string sender)
        {
            string parseMessage = "";
            string receiver = "";

            int senderNumber = -1;
            int receiverNumber = -1;

            foreach (var item in msgList)
            {
                string[] splitedMsg = item.Split('<');
                receiver = splitedMsg[0];
                parseMessage = string.Format("{0}<{1}>", sender, splitedMsg[1]);

                if (parseMessage.Contains("<GroupChattingStart>"))
                {
                    string[] groupSplit = receiver.Split('#');

                    foreach (var el in groupSplit)
                    {
                        if (string.IsNullOrEmpty(el))
                            continue;
                        string groupLogMessage = string.Format(@"[{0}] [{1}] -> [{2}] , {3}",
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), groupSplit[0], el, splitedMsg[1]);
                        ChangeListView(groupLogMessage, staticDefine.ADD_CHATTING_LIST);

                        receiverNumber = GetClientNumber(el);

                        parseMessage = string.Format(@"{0}<GroupChattingStart>", receiver);
                        byte[] sendGroupByteData = Encoding.Default.GetBytes(parseMessage);
                        ClientManager.clientDic[receiverNumber].tcpClient.GetStream().Write(sendGroupByteData, 0, sendGroupByteData.Length);
                    }
                    return;
                }

                if (receiver.Contains('#'))
                {
                    string[] groupSplit = receiver.Split('#');

                    foreach (var el in groupSplit)
                    {
                        if (string.IsNullOrEmpty(el)) continue;
                        if (el == groupSplit[0]) continue;
                        string groupLogMessage = string.Format($"[{0}] [{1}] -> [{2}] , {3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            groupSplit[0], el, splitedMsg[1]);
                        ChangeListView(groupLogMessage, StaticDefine.ADD_CHATTING_LIST);
                    }
                }
            }
        }
    }
}
