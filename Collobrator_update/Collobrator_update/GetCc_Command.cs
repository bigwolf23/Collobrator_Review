using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Collobrator_update
{
    public class GetCc_Command
    {
        public static string strCollobarate_new_cmd = "ccollab addversions new";
        //public static string strCollobarate_cmd = "ipconfig";
        public static string strNew_keyword = "New review created: Review #";
        public static string strCheckIn_keyword = "CHECKEDIN";
        public static string strCheckOut_keyword = "CheckedOut:";

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

        public void getClearCaseFileList(string ClearcaseFilePath, ref List<string> strFileList)
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




        public bool getNewReviewFilePath(string strReviewId, List<string> strFileList, ref List<string> FileFullPaths)
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

        public bool getOldReviewFilePath(string strReviewId, List<string> strFileList, ref List<string> FileFullPaths)
        {
            foreach (string strTemp in strFileList)
            {
                string strNewPath;
                string strOldPath;
                string strFileFormatAll;
                getFilePathByClearCaseResult(strTemp, out strNewPath, out strOldPath);

                strFileFormatAll = @"ccollab addversions " +
                    strReviewId + @"  " + "\"" +
                    strNewPath + "\"" + "\"" +
                    strOldPath + "\"";

                //@"ccollab addversions ";
                FileFullPaths.Add(strFileFormatAll);
            }
            return true;
        }

        public void getFilePathByClearCaseResult(string strResult, out string strNewPath, out string strOldPath)
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

            strFilePathOld = strCcMapPath + strFilePathOld;
            //strFilePathOld = @"Z:\" + strFilePathOld;

            string strFilePathNew = strFilePathOld;
            nFileVerInClearCasePos = strFilePathNew.LastIndexOf(@"\");
            strFilePathNew = strFilePathNew.Remove(nFileVerInClearCasePos + 1);
            strFilePathNew = strFilePathNew + Convert.ToString(nFileVerNew);

            strNewPath = strFilePathNew;
            strOldPath = strFilePathOld;
        }

        public string runCmd(string strCmd)
        {
            Cmd c = new Cmd();
            string strCmdReturn = c.RunCmd(strCmd);
            if (strCmdReturn.Contains(@"successful"))
            {
                MessageBox.Show(strCmdReturn);
            }

            return @"Success";
        }
    }
}
