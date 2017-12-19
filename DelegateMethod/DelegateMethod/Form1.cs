using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DelegateMethod
{

    

    public partial class Form1 : Form
    {

        public class delegateClass
        {
            public delegate void addCmdInfo(string a);
            public addCmdInfo AppendCmdInfo;

            public void AppendData()
            {
                //AppendCmdInfo.Invoke()
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void otherclassMethod(string a)
        {
            MessageBox.Show(a);
        }
        public void threadStart(object sender)
        {
            string cmd = sender.ToString();
            Cmd c = new Cmd();
            c.RunTestCmd(cmd);
            MessageBox.Show(@"over");
        }
        //public delegate void ParameterizedThreadStart();
        private void button1_Click(object sender, EventArgs e)
        {

            Thread parameterThread = new Thread(threadStart);
            parameterThread.Name = @"command thread";
            parameterThread.Start(@"Demo.exe");


            //             string strcmd = @"ccollab addversions 115882  "+"\""+
            //                             @"Z:\\FTView_SE\\SLHMI\\Logging\\RsAlarmLogEd\\RsAlarmLogEd.vcxproj@@\\main\\int_10.00.00_dae\\2\" +"\"" + "\"" +
            //                             @"Z:\\FTView_SE\\SLHMI\\Logging\\RsAlarmLogEd\\RsAlarmLogEd.vcxproj@@\\main\\int_10.00.00_dae\\1 " + "\"";

            //string strCmdReturn = c.RunCmd(@"help");
            //c.runcmdwithWindow(@"help");
            

            //             delegateClass dl = new delegateClass();
//             dl.AppendCmdInfo = otherclassMethod;
// 
//             Mao xiaomao = new Mao();
//             dl.AppendCmdInfo += xiaomao.Han;
//             dl.AppendCmdInfo(@"abc");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public class Mao
        {

            public void Han(string a)
            {
                MessageBox.Show(a);
            }
        }
    }
}
