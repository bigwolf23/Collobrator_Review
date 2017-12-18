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

namespace Collobrator_update
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class DisplayData
        {
            public string FilePath { get; set; }
            public string strFileConvertSuccess { get; set; }
            public string strDecription { get; set; }
        }


        public static string strCollobarate_new_cmd = "ccollab addversions new";
        //public static string strCollobarate_cmd = "ipconfig";
        public static string strNew_keyword = "New review created: Review #";
        public static string strCheckIn_keyword = "CHECKEDIN";
        public static string strCheckOut_keyword = "CheckedOut:";

        private void Form1_Load(object sender, EventArgs e)
        {
            controlShowOrHide(false);
            getClearCaseMap();
        }

        private void getClearCaseMap()
        {
            //HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MountPoints2
            string strMapName;
            RegistryHelper rh = new RegistryHelper();
            strMapName = rh.GetRegistryData(Registry.LocalMachine,
                            @"\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MountPoints2", 
                            @"ClearCase");
            if (strMapName.Length == 0)
            {
                ClearCase_MapPath.Text = @"Z:";
            }
            else
            {
                ClearCase_MapPath.Text = strMapName;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ClearCase_MapPath.Text.Length == 0)
            {
                MessageBox.Show(@"Please input ClearCase_MapPath!!!");
                return;
            }

            if(radio_NewReview.Checked == true)
            {
                updateReviewFile(@"new");
            }
            else
            {
                if (ClearCase_ReviewID.Text.Length == 6 )
                {
                    updateReviewFile(ClearCase_ReviewID.Text);
                }
                else
                {
                    MessageBox.Show(@"Because this is Add to old review,please input old review ID");
                }
            }
        }

        private void getClearCaseFilePath(ref List<string> strFileListOut)
        {
            string ClearcaseFilePath = ClearCaseFilePath.Text;
            //strFilePath = @"G:\Project\My_Source\Collobrater_update\Review_content\update.2017-12-07T103338+0800.updt";
            if (File.Exists(ClearcaseFilePath))
            {
                getClearCaseFileList(ClearcaseFilePath, ref strFileListOut);
            }
        }

        private void getClearCaseFileList(string ClearcaseFilePath,ref List<string> strFileList)
        {
            FileStream fs = new FileStream(ClearcaseFilePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            while (sr.Peek() >= 0)
            {
                string strLine = sr.ReadLine();
                if (strLine.Contains(strCheckOut_keyword) && strLine.Contains(strCheckIn_keyword))
                {
                    strFileList.Add(strLine);
                }
            }
            sr.Close();
            fs.Close();
        }


        private void updateReviewFile(string strReviewId)
        {
            List<string> strFileList = new List<string>();
            List<string> m_pFileFullPaths = new List<string>();
            bool bReturn = false;
            getClearCaseFilePath(ref strFileList);
            if (strReviewId.Length == 6)
            {
                bReturn = getOldReviewFilePath(strReviewId, strFileList, ref m_pFileFullPaths);
            }
            else
            {
                bReturn = getNewReviewFilePath(strReviewId, strFileList, ref m_pFileFullPaths);
            }
            List<DisplayData> m_pDisplayData = new List<DisplayData>();

            foreach (string strTemp in m_pFileFullPaths)
            {
                DisplayData temp = new DisplayData();
                temp.strFileConvertSuccess = "Fail";
                temp.strFileConvertSuccess = runCmd(strTemp);
                m_pDisplayData.Add(temp);
            }
            displayDataFalseOrSuccess(m_pDisplayData);
        }

        private bool getNewReviewFilePath(string strReviewId, List<string> strFileList, ref List<string> FileFullPaths)
        {
            string strFileFormatAll;
            string strNewReviewId = strReviewId;
            bool bFirstCmd = true;
            foreach (string strTemp in strFileList)
            {
                string strNewPath;
                string strOldPath;
                
                getFilePathByClearCaseResult(strTemp, out strNewPath, out strOldPath);

                strFileFormatAll = @"ccollab addversions " +
                    strNewReviewId + @"  " + "\"" +
                    strNewPath + "\"" + "\"" +
                    strOldPath + "\"";
                if (bFirstCmd)
                {
                    Cmd c = new Cmd();
                    string strCmdReturn = c.RunCmd(strFileFormatAll);
                    if (strCmdReturn.Contains(@"successful"))
                    {
                        MessageBox.Show(strCmdReturn);
                    }
                    else
                    {
                        return false;
                    }


                    if (strCmdReturn.Contains(strNew_keyword))
                    {
                        int nIndex = strCmdReturn.IndexOf(strNew_keyword) + strNew_keyword.Length;
                        
                        strNewReviewId = strCmdReturn.Substring(nIndex, 6);
                    }
                }
                
                bFirstCmd = false;

                //@"ccollab addversions ";
                FileFullPaths.Add(strFileFormatAll);
                
            }
            return true;
        }

        private bool getOldReviewFilePath(string strReviewId, List<string> strFileList, ref List<string> FileFullPaths)
        {
            foreach (string strTemp in strFileList)
            {
                string strNewPath;
                string strOldPath;
                string strFileFormatAll;
                getFilePathByClearCaseResult(strTemp, out strNewPath,out strOldPath);

                strFileFormatAll = @"ccollab addversions " +
                    strReviewId + @"  " + "\"" +
                    strNewPath + "\"" + "\"" +
                    strOldPath + "\"";

                //@"ccollab addversions ";
                FileFullPaths.Add(strFileFormatAll);
            }
            return true;
        }

        private void getFilePathByClearCaseResult(string strResult,out string strNewPath,out string strOldPath)
        {
            int nCheckinWordPos = strResult.IndexOf(strCheckIn_keyword, 0);
            string strFilePathOld = strResult.Substring(25, nCheckinWordPos - 25);
            int nFileVerInClearCasePos = strFilePathOld.LastIndexOf(@"\");
            string strFileVerInClearCase = strFilePathOld.Substring(nFileVerInClearCasePos + 1);
            int nFileVerOld = int.Parse(strFileVerInClearCase);
            int nFileVerNew = nFileVerOld + 1;

            if (strFilePathOld.Contains(@" \main\int_"))
            {
                strFilePathOld = strFilePathOld.Replace(@" \main\int_", @"@@\main\int_");
            }
            else
            {
                strFilePathOld = strFilePathOld.Replace(@" \main\1", @"@@\main\int_10.00.00_dae\0");
            }

            strFilePathOld = ClearCase_MapPath.Text + strFilePathOld;
            //strFilePathOld = @"Z:\" + strFilePathOld;

            string strFilePathNew = strFilePathOld;
            nFileVerInClearCasePos = strFilePathNew.LastIndexOf(@"\");
            strFilePathNew = strFilePathNew.Remove(nFileVerInClearCasePos + 1);
            strFilePathNew = strFilePathNew + Convert.ToString(nFileVerNew);

            strNewPath = strFilePathNew;
            strOldPath = strFilePathOld;
        }

//         private void addNewReviewFile(string strReviewId)
//         {
//             List<string> strFileList = new List<string>();
//             List<string> m_pFileFullPaths = new List<string>();
//             getClearCaseFilePath(ref strFileList);
//             getNewReviewFilePath(strReviewId, strFileList, ref m_pFileFullPaths);
//             List<DisplayData> m_pDisplayData = new List<DisplayData>();
// 
//             foreach (string strTemp in m_pFileFullPaths)
//             {
//                 DisplayData temp = new DisplayData();
//                 temp.strFileConvertSuccess = "Fail";
//                 temp.strFileConvertSuccess = runCmd(strTemp);
//                 m_pDisplayData.Add(temp);
//             }
//             displayDataFalseOrSuccess(m_pDisplayData);
//         }
// 
//         private void getColobaratorFilePath(string strReviewId, List<string> strFileList)
//         {
//             List<DisplayData> m_pFileFullPaths = new List<DisplayData>();
//             bool bFistInsert = true;
//             string strReviewIdTemp = strReviewId;
//             foreach (string strTemp in strFileList)
//             {
//                 int nCheckinWordPos = strTemp.IndexOf(strCheckIn_keyword,0);
//                 string strFilePathOld = strTemp.Substring(25,nCheckinWordPos-25);
//                 int nFileVerInClearCasePos = strFilePathOld.LastIndexOf(@"\");
//                 string strFileVerInClearCase = strFilePathOld.Substring(nFileVerInClearCasePos + 1);
//                 int nFileVerOld = int.Parse(strFileVerInClearCase);
//                 int nFileVerNew = nFileVerOld + 1;
// 
//                 strFilePathOld = strFilePathOld.Replace(@" \main\int_", @"@@\main\int_");
//                 strFilePathOld = ClearCase_MapPath.Text + strFilePathOld;
//                 //strFilePathOld = @"Z:\" + strFilePathOld;
// 
//                 string strFilePathNew = strFilePathOld;
//                 nFileVerInClearCasePos = strFilePathNew.LastIndexOf(@"\");
//                 strFilePathNew = strFilePathNew.Remove(nFileVerInClearCasePos+1);
//                 strFilePathNew = strFilePathNew + Convert.ToString(nFileVerNew);
// 
//                 string strFileFormatAll;
//                 bFistInsert = false;
// 
//                 DisplayData temp = new DisplayData();
//                 
//                 temp.strFileConvertSuccess = "Fail";
// 
//                 if (bFistInsert)
//                 {
//                     strFileFormatAll = strCollobarate_new_cmd +
//                     @"  " + "\"" +
//                     strFilePathNew + "\"" + "\"" +
//                     strFilePathOld + "\"";
// 
//                     temp.FilePath = strFileFormatAll;
//                     temp.strFileConvertSuccess = runNewCmd(strFileFormatAll, ref strReviewIdTemp);
//                 }
//                 else
//                 {
//                     strFileFormatAll = @"ccollab addversions " +
//                     strReviewId + @"  " + "\"" +
//                     strFilePathNew + "\"" + "\"" +
//                     strFilePathOld + "\"";
// 
//                     temp.FilePath = strFileFormatAll;
//                     temp.strFileConvertSuccess = runCmd(strFileFormatAll);
//                 }
// 
//                 //@"ccollab addversions ";
//                 m_pFileFullPaths.Add(temp);
//             }
//             displayDataFalseOrSuccess(m_pFileFullPaths);
//         }
// 
//         private string getVersionNo()
//         {
//             string sVersionNo = "";
//             Cmd c = new Cmd();
//             string strCmdReturn = c.RunCmd(strCollobarate_new_cmd);
//             //string strCmdReturn = c.RunCmd(@"ping 192.168.1.1");
//             MessageBox.Show(strCmdReturn);
//             if (strCmdReturn.Contains(strNew_keyword))
//             {
//                 sVersionNo = strCmdReturn.Substring(strNew_keyword.Length, 6);
//             }
//             return sVersionNo;
//         }
//         private string runNewCmd(string strCmd, ref string strVerionId)
//         {
//             Cmd c = new Cmd();
//             string strCmdReturn = c.RunCmd(strCmd);
//             if (strCmdReturn.Contains(@"successful"))
//             {
//                 MessageBox.Show(strCmdReturn);
//             }
//             else
//             {
//                 return @"Fail";
//             }
// 
//             if (strCmdReturn.Contains(strNew_keyword))
//             {
//                 strVerionId = strCmdReturn.Substring(strNew_keyword.Length, 6);
//             }
// 
//             return @"Success";
//         }

        private string runCmd(string strCmd)
        {
            Cmd c = new Cmd();
            string strCmdReturn = c.RunCmd(strCmd);
            if (strCmdReturn.Contains(@"successful"))
            {
                MessageBox.Show(strCmdReturn);
            }

            return @"Success";
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
