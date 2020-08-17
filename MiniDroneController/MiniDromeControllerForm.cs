using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniDroneController
{
    public partial class MiniDromeControllerForm : Form
    {
        private bool isUpMouseDown = false;
        private bool isLeftMouseDown = false;
        private bool isDownMouseDown = false;
        private bool isRightMouseDown = false;
        private bool isForwardMouseDown = false;
        private bool isTurnLeftMouseDown = false;
        private bool isBackwardMouseDown = false;
        private bool isTurnRightMouseDown = false;

        public MiniDromeControllerForm()
        {
            InitializeComponent();
            richTextBoxResults.Text += "WELCOME TO MINIDRONE! \n\n";
        }

        // Set Results async
        delegate void SetResultsDelegate(string text);

        private void SetResults(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.richTextBoxResults.InvokeRequired)
            {
                SetResultsDelegate d = new SetResultsDelegate(SetResults);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBoxResults.Text += text;
                this.richTextBoxResults.Text += "\n";
            }
        }

        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            isUpMouseDown = true;

            var task = new Task(() => {
                //Keep firing the API
                while (isUpMouseDown)
                {
                    SendCommand("UP");
                }
            });
            task.Start();
        }

        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            isLeftMouseDown = true;

            var task = new Task(() => {
                //Keep firing the API
                while (isLeftMouseDown)
                {
                    SendCommand("LEFT");
                }
            });
            task.Start();
        }

        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            isLeftMouseDown = false;
        }

        private void btnUp_MouseUp(object sender, MouseEventArgs e)
        {
            isUpMouseDown = false;
        }

        private void btnDown_MouseDown(object sender, MouseEventArgs e)
        {
            isDownMouseDown = true;

            var task = new Task(() => {
                //Keep firing the API
                while (isDownMouseDown)
                {
                    SendCommand("DOWN");
                }
            });
            task.Start();
        }

        private void btnDown_MouseUp(object sender, MouseEventArgs e)
        {
            isDownMouseDown = false;
        }

        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            isRightMouseDown = true;

            var task = new Task(() => {
                //Keep firing the API
                while (isRightMouseDown)
                {
                    SendCommand("RIGHT");
                }
            });
            task.Start();
        }

        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            isRightMouseDown = false;
        }

        private void btnForward_MouseDown(object sender, MouseEventArgs e)
        {
            isForwardMouseDown = true;

            var task = new Task(() => {
                //Keep firing the API
                while (isForwardMouseDown)
                {
                    SendCommand("FORWARD");
                }
            });
            task.Start();
        }

        private void btnForward_MouseUp(object sender, MouseEventArgs e)
        {
            isForwardMouseDown = false;
        }

        private void btnTurnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            isTurnLeftMouseDown = true;

            var task = new Task(() => {
                //Keep firing the API
                while (isTurnLeftMouseDown)
                {
                    SendCommand("TURNLEFT");
                }
            });
            task.Start();
        }

        private void btnTurnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            isTurnLeftMouseDown = false;
        }

        private void btnBackward_MouseDown(object sender, MouseEventArgs e)
        {
            isBackwardMouseDown = true;

            var task = new Task(() => {
                //Keep firing the API
                while (isBackwardMouseDown)
                {
                    SendCommand("BACKWARD");
                }
            });
            task.Start();
        }

        private void btnBackward_MouseUp(object sender, MouseEventArgs e)
        {
            isBackwardMouseDown = false;
        }

        private void btnTurnRight_MouseDown(object sender, MouseEventArgs e)
        {
            isTurnRightMouseDown = true;

            var task = new Task(() => {
                //Keep firing the API
                while (isTurnRightMouseDown)
                {
                    SendCommand("TURNRIGHT");
                }
            });
            task.Start();
        }

        private void btnTurnRight_MouseUp(object sender, MouseEventArgs e)
        {
            isTurnRightMouseDown = false;
        }

        private void SendCommand(string command) {
            var url = "http://" + txtDroneIp.Text + "/sendcommand?command=" + command;
            SetResults("[" + DateTime.Now.ToLongTimeString() + "]: " + url);

            // Call Rest API
            var request = HttpWebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = 500;
            try
            {
                var response = request.GetResponse();
                SetResults(response.ToString());
            }
            catch (Exception ex)
            {
                SetResults(ex.ToString());
            }
        }

        
    }
}
