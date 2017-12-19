using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace DelegateMethod
{
    /// <summary>
    /// Cmd 的摘要说明。
    /// </summary>

    public class Cmd
    {
        private Process proc = null;
 //       private DelegateMsgInfo AppendMsg;
        /// <summary>
        /// 构造方法
        /// </summary>
        public Cmd(/*DelegateMsgInfo AppendMsgHandler*/)
        {
            proc = new Process();
            /*AppendMsg = AppendMsgHandler;*/
        }

      

        private void cmd_exited(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 执行CMD语句
        /// </summary>
        /// <param name="cmd">要执行的CMD命令</param>
        public string RunCmd(string cmd)
        {
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = cmd;

            proc.StartInfo.CreateNoWindow = false;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;

            //proc.OutputDataReceived += new DataReceivedEventHandler(p_outPutReceived);

            proc.EnableRaisingEvents = true;
            proc.Exited += new EventHandler(cmd_exited);
            proc.Start();
//            proc.BeginOutputReadLine();

            proc.StandardInput.WriteLine(cmd);
            proc.StandardInput.WriteLine("exit");
            
            
            //string outStrLine = proc.StandardOutput.ReadLine();

            //Console.WriteLine(outStrLine);
            string outStr = proc.StandardOutput.ReadToEnd();
            //          string outStr = "Successfully";
            
            proc.Close();

            
            return outStr;
        }

        public string RunNewCmd(string cmd)
        {
            proc.StartInfo.FileName = "cmd.exe";
            //            proc.StartInfo.Arguments = cmd;

            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;

            //proc.OutputDataReceived += new DataReceivedEventHandler(p_outPutReceived);

            proc.EnableRaisingEvents = true;
            proc.Exited += new EventHandler(cmd_exited);
            proc.Start();
            //            proc.BeginOutputReadLine();

            proc.StandardInput.WriteLine(cmd);
            proc.StandardInput.WriteLine("exit");


            //string outStrLine = proc.StandardOutput.ReadLine();

            //Console.WriteLine(outStrLine);
            string outStr = proc.StandardOutput.ReadToEnd();
            //          string outStr = "Successfully";

            proc.Close();


            return outStr;
        }

        /// <summary>
        /// 打开软件并执行命令
        /// </summary>
        /// <param name="programName">软件路径加名称（.exe文件）</param>
        /// <param name="cmd">要执行的命令</param>
        public void RunProgram(string programName, string cmd)
        {
            Process proc = new Process();
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = programName;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            if (cmd.Length != 0)
            {
                proc.StandardInput.WriteLine(cmd);
            }
            proc.Close();
        }
        /// <summary>
        /// 打开软件
        /// </summary>
        /// <param name="programName">软件路径加名称（.exe文件）</param>
        public void RunProgram(string programName)
        {
            this.RunProgram(programName, "");
        }
    }
}
