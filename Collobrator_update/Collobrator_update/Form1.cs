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
using Microsoft.Win32;
using System.Threading;
using System.Xml;

namespace Collobrator_update
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        public void setLogInfo(string strLogInfo)
        {
            Log_info_Edit.AppendText(strLogInfo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            getClearCaseConfig(); 
            Control.CheckForIllegalCrossThreadCalls = false;
            controlShowOrHide(true);
           
        }

        private void getClearCaseConfig()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("ClearCase_Config.xml");
                ClearCaseConfig ad = XmlSerializeUtil.Deserialize(typeof(ClearCaseConfig), xmlDoc.OuterXml) as ClearCaseConfig;

                ClearCase_MapPath.Text = ad.Head.MapDisk;
                ClearCase_Branch.Text = ad.Head.Branchname;
            }catch(Exception ex){

            }

        }


        private void threadProc(object sender)
        {
            allControlEnable(false);
            string strReviewId = sender.ToString();
            List<string> strFileList = new List<string>();
            List<DisplayData> m_pFileFullPaths = new List<DisplayData>();
            bool bReturn = false;
            DelegateMsgInfo delegateMethod = new DelegateMsgInfo();
            delegateMethod.AppendCmdInfo = setLogInfo;

            GetCc_Command Cc_command = new GetCc_Command();
            Cc_command.AppendMsg = delegateMethod;
            Cc_command.strCcFilePath = ClearCaseFilePath.Text;
            Cc_command.strCcMapPath = ClearCase_MapPath.Text;
            Cc_command.strCcBranch = ClearCase_Branch.Text;
            Cc_command.getClearCaseFilePath(ref strFileList);

            if (strReviewId.Length == 6 && radio_NewReview.Checked == false)
            {
                bReturn = Cc_command.getOldReviewFilePath(strReviewId, strFileList, ref m_pFileFullPaths);
            }
            else
            {
                bReturn = Cc_command.getNewReviewFilePath(strReviewId, strFileList, ref m_pFileFullPaths);
            }

            if (bReturn)
            {
                displayDataFalseOrSuccess(m_pFileFullPaths);
                MessageBox.Show(@"Complete");
            }
            allControlEnable(true);
        }



        private void updateReviewFile(string strReviewId)
        {
            Thread thr = new Thread(threadProc);
            thr.IsBackground = true;
            thr.Start(strReviewId);
       
        }

        private bool isCheckUpdate()
        {
            if (ClearCase_MapPath.Text.Length == 0)
            {
                MessageBox.Show(@"Please input ClearCase Map Path!!!");
                return false;
            }

            if (ClearCase_Branch.Text.Length == 0)
            {
                MessageBox.Show(@"Please input ClearCase branch!!!");
                return false;
            }

            
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log_info_Edit.Clear();

            if (false == isCheckUpdate())
            {
                return;
            }

            if(radio_NewReview.Checked == true)
            {
                updateReviewFile(@"new");
            }
            else
            {
				if (ClearCase_ReviewID.Text.Length != 6)
				{
					MessageBox.Show(@"Because this is old review,please input old review ID");
					return false;
				}
			
                updateReviewFile(ClearCase_ReviewID.Text);
            }
        }


        private void allControlEnable(bool bEnable)
        {
            radio_NewReview.Enabled = bEnable;
            radio_OldReview.Enabled = bEnable;
            ClearCase_MapPath.Enabled = bEnable;
            ClearCase_ReviewID.Enabled = bEnable;
            ClearCaseFilePath.Enabled = bEnable;
            seletFile.Enabled = bEnable;
            button_update.Enabled = bEnable;
        }

        private void displayDataFalseOrSuccess(List<DisplayData> strCollobarateFileFormat)
        {
            BindingList<DisplayData> BFileInfo = new BindingList<DisplayData>(strCollobarateFileFormat);
            dataGridView1.DataSource = BFileInfo;
        }

        private void controlShowOrHide(bool bShow)
        {
            if (bShow)
            {
                ClearCase_ReviewID_label.Show();
                ClearCase_ReviewID.Show();
            }
            else
            {
                ClearCase_ReviewID_label.Hide();
                ClearCase_ReviewID.Hide();
            }
        }
        private void radio_NewReview_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_NewReview.Checked == true)
            {
                controlShowOrHide(false);
            }
        }

        private void radio_OldReview_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_OldReview.Checked == true)
            {
                controlShowOrHide(true);
            }
        }

        private void ClearCase_ReviewID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        private void seletFile_Click(object sender, EventArgs e)
        {
            CcCommitFileDlg.ShowDialog();
            ClearCaseFilePath.Text = CcCommitFileDlg.FileName;
            
        }

    }
}
