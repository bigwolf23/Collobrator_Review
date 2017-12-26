using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Collobrator_update
{
    public class DelegateMsgInfo
    {
        public delegate void addCmdInfo(string strMsg);
        public addCmdInfo AppendCmdInfo;
    }
    public class DisplayData
    {
        public string FilePath { get; set; }
        public string strFileConvertSuccess { get; set; }
        public string strDecription { get; set; }
    }

    public class GetCc_Command
    {
        public static string strCollobarate_new_cmd = "ccollab addversions new";
        //public static string strCollobarate_cmd = "ipconfig";
        public static string strNew_keyword = "New review created: Review #";
        public static string strCheckIn_keyword = "CHECKEDIN";
        public static string strCheckOut_keyword = "CheckedOut:";

        public static string strSuccess_Flg = @"successful";
        public static string strSuccess_Return = @"Success";
        public static string strFail_Return = @"Fail";

        public DelegateMsgInfo AppendMsg;

        public string strCcFilePath { get; set; }
        public string strCcMapPath{ get; set; }

        public void getClearCaseFilePath(ref List<string> strFileListOut)
        {
            //string ClearcaseFilePath = ClearCaseFilePath.Text;
            //strFilePath = @"G:\Project\My_Source\Collobrater_update\Review_content\update.2017-12-07T103338+0800.updt";
            if (File.Exists(strCcFilePath))
            {
                getClearCaseFileList(strCcFilePath, ref strFileListOut);
            }
        }

        private bool isHaveCheckOutInKeyWord(string strLine)
        {
            if (strLine.Contains(strCheckOut_keyword) && strLine.Contains(strCheckIn_keyword))
            {
                return true;
            }
            return false;
        }

        public void getClearCaseFileList(string ClearcaseFilePath, ref List<string> strFileList)
        {
            FileStream fs = new FileStream(ClearcaseFilePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            while (sr.Peek() >= 0)
            {
                string strLine = sr.ReadLine();
                if (isHaveCheckOutInKeyWord(strLine))
                {
                    strFileList.Add(strLine);
                }
            }
            sr.Close();
            fs.Close();
        }

        public void getReviewID(string strCmdReturn, ref string strNewReviewId)
        {
            if (strCmdReturn.Contains(strNew_keyword))
            {
                int nIndex = strCmdReturn.IndexOf(strNew_keyword) + strNew_keyword.Length;

                strNewReviewId = strCmdReturn.Substring(nIndex, 6);
            }
        }

        public void getCommandLine(string strInput,string strReviewId,out string strFileFormatAll)
        {
            string strNewPath;
            string strOldPath;

            getFilePathByClearCaseResult(strInput, out strNewPath, out strOldPath);

            strFileFormatAll = @"ccollab addversions " +
                strReviewId + @"  " + "\"" +
                strNewPath + "\"" + @"  " + "\"" +
                strOldPath + "\"";
        }

        public bool getNewReviewFilePath(string strReviewId, List<string> strFileList, ref List<DisplayData> FileFullPaths)
        {
            string strNewReviewId = strReviewId;
            bool bFirstCmd = true;
            foreach (string strTemp in strFileList)
            {
                string strFileFormatAll;
                string strCmdReturn = @"";

                getCommandLine(strTemp, strNewReviewId, out strFileFormatAll);
                if (bFirstCmd)
                {
                    strCmdReturn = runCmd(strFileFormatAll);
                    getReviewID(strCmdReturn, ref strNewReviewId);
                }

                if (false == addNewDispData(bFirstCmd, strCmdReturn, strFileFormatAll, ref FileFullPaths))
                {
                    break;
                }

                // if the new process ,this will set false.
                bFirstCmd = false;

            }
            return true;
        }


        public bool getOldReviewFilePath(string strReviewId, List<string> strFileList, ref List<DisplayData> FileFullPaths)
        {
            foreach (string strTemp in strFileList)
            {
                string strFileFormatAll;

                getCommandLine(strTemp, strReviewId, out strFileFormatAll);

                if (false == addNewDispData(false, @"", strFileFormatAll, ref FileFullPaths))
                {
                    break;
                }
            }
            return true;
        }


        public string runCmd(string strCmd)
        {
            Cmd c = new Cmd(AppendMsg);
            string strCmdReturn = c.RunCmd(strCmd);
            AppendMsg.AppendCmdInfo(strCmdReturn);

            return strCmdReturn;
            
        }

        public string ReturnSucessOrFail(string strCmdReturn)
        {
            if (strCmdReturn.Contains(strSuccess_Flg))
            {
                return strSuccess_Return;
            }

            return strFail_Return;
        }

        public bool addNewDispData(bool bNewReview,string strNewResult,string strCmd,ref List<DisplayData> FileFullPaths)
        {
            DisplayData temp = new DisplayData();
            temp.FilePath = strCmd;
            temp.strFileConvertSuccess = strFail_Return;
            if (bNewReview == false)
            {
                //if one file commit failed ,the process is abort.
                string strCmdReturn = runCmd(strCmd);
                temp.strFileConvertSuccess = ReturnSucessOrFail(strCmdReturn);
            }
            else
            {
                temp.strFileConvertSuccess = ReturnSucessOrFail(strNewResult);
            }

            //@"ccollab addversions ";
            FileFullPaths.Add(temp);

            if (temp.strFileConvertSuccess == strFail_Return)
            {
                return false;
            }
 
            return true;
        }

        public void getFilePathByClearCaseResult(string strResult, out string strNewPath, out string strOldPath)
        {
            int nCheckinWordPos = strResult.IndexOf(strCheckIn_keyword, 0);
            string strFilePathOld = strResult.Substring(25, nCheckinWordPos - 25);
            

            if (strFilePathOld.Contains(@" \main\int_"))
            {
                strFilePathOld = strFilePathOld.Replace(@" \main\int_", @"@@\main\int_");
            }
            else
            {
                int nPos = strFilePathOld.LastIndexOf(@"\main\");
                strFilePathOld = strFilePathOld.Remove(nPos - 1);
                strFilePathOld = strFilePathOld + @"@@\main\int_10.00.00_dae\0";
            }

            int nFileVerInClearCasePos = strFilePathOld.LastIndexOf(@"\");
            string strFileVerInClearCase = strFilePathOld.Substring(nFileVerInClearCasePos + 1);
            int nFileVerOld = int.Parse(strFileVerInClearCase);
            int nFileVerNew = nFileVerOld + 1;

            strFilePathOld = strCcMapPath + strFilePathOld;
            //strFilePathOld = @"Z:\" + strFilePathOld;

            string strFilePathNew = strFilePathOld;
            nFileVerInClearCasePos = strFilePathNew.LastIndexOf(@"\");
            strFilePathNew = strFilePathNew.Remove(nFileVerInClearCasePos + 1);
            strFilePathNew = strFilePathNew + Convert.ToString(nFileVerNew);

            strNewPath = strFilePathNew;
            strOldPath = strFilePathOld;
        }


    }
}
