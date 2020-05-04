using System;
using System.Windows.Forms;
using SomeProject.Library.Client;
using SomeProject.Library;

namespace SomeProject.TcpClient
{
    public partial class ClientAn : Form
    {
        public ClientAn()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Кнопка отправки сообщения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMsgBtnClick(object sender, EventArgs e)
        {
            Client client = new Client();
            if (textBox.Text != "")
            {
                OperationResult res = client.SendMessageToServer(textBox.Text);
                if (res.Result == Result.OK)
                {
                    textBox.Text = "";
                    // MessageBox.Show("Message was sent succefully!","Success");
                    Messages.Text += res.Message + Environment.NewLine;
                }
                else
                {
                    // MessageBox.Show("Cannot send the message to the server.","Exeption");
                    Messages.Text += "!!! " + res.Message + Environment.NewLine;
                }
                timer.Interval = 2000;
                timer.Start();
            }
            else MessageBox.Show("Write a message!","Exeption");
        }
        /// <summary>
        /// таймер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimerTick(object sender, EventArgs e)
        {
            timer.Stop();
        }
        /// <summary>
        ///  отправка файла на сервер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Client client = new Client();
                var res = client.SendFileToServer(fileDialog.FileName);
                if (res.Result == Result.OK)
                {
                    Messages.Text += res.Message + Environment.NewLine;
                    // MessageBox.Show("File was sent succefully!","Success!");
                }
                else
                {
                    //MessageBox.Show("Cannot send the file to the server.","Exeption");
                    Messages.Text += "!!! " + res.Message + Environment.NewLine;
                }
 
                timer.Interval = 2000;
                timer.Start();
            }
        }

    }
}
