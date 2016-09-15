using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CCWin;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Xml;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace SoftReg
{
    public partial class Form1 : Skin_Mac
    {
        public Form1()
        {
            InitializeComponent();

            
        }
        SoftReg softReg = new SoftReg();





        public string md5(string str)
        {
            MD5 m = new MD5CryptoServiceProvider();
            byte[] s = m.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str));
            return BitConverter.ToString(s);
        }

        public string xxm(string urlpath,string path,string nodepath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string ActivityId = "";
            try
            {
                xmlDoc.Load(@urlpath);
                //xmlDoc.Load(@"");
                //读取Activity节点下的数据。SelectSingleNode匹配第一个Activity节点  
                // XmlNode root = xmlDoc.SelectSingleNode("/root/result");//当节点Workflow带有属性是，使用SelectSingleNode无法读取     
                XmlNode root = xmlDoc.SelectSingleNode(path);
                ActivityId = (root.SelectSingleNode(nodepath)).InnerText;
                
                
            }
            catch (Exception e)
            {
                MessageBox.Show("网络是否连接"); //显示错误信息  
            }
            return ActivityId;

        }

        public string HttpPost(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            //request.Headers.Add("User_Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.4 (KHTML, like Gecko) Chrome/22.0.1229.79 Safari/537.4");
            //request.Headers["User-Agent"] = "onlyhuiyuan";
            //request.Headers.Add("User-Agent", "onlyhuiyuan");
            //request.Headers.Add("clientmarket", "1");
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
           string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

        private void GetMachineCode(object sender, EventArgs e)
        {
            //string result = "zzz2188185";
            //string bytes = md5(result);
            
            string MachineStr = softReg.GetMNum();//磁盘信息

            string urlpath = "http://api.k780.com:88/?app=life.time&appkey=10003&sign=b59bc3ef6191eb9f747dd4e83c99f2a4&format=xml";
            string path = "/root/result";
            string nodepath = "timestamp";
            string erre = xxm(urlpath, path, nodepath);
            int ti = Convert.ToInt32(erre);
            //if (erre == "") {  }
            //else { ti = Convert.ToInt32(erre); }//当前时间
            //int timeupdate = ti;
            //int timeupdate = ti - 18000;
            //MessageBox.Show(timeupdate.ToString());
            //string Ps = MachineStr + bytes.Replace("-", "");

            string urlrs = "http://www.nandada.com/";
            if(!(RB_aqy.Checked || RB_yk.Checked || RB_mg.Checked || RB_sh.Checked) ){ MessageBox.Show("请选择一项"); }
            else{
                if (HttpPost(urlrs + "exit.php", "MachineStr=" + MachineStr) == "no") {
                    //HttpPost(urlrs + "inser.php", "MachineStr=" + MachineStr);
                    if (RB_aqy.Checked)
                    {
                        string urlpath2 = urlrs + "xmlaqy.php";
                        string path2 = "/users/user";
                        string nodepath2 = "name";
                        string aqy_zh = xxm(urlpath2, path2, nodepath2);
                        MachineCode.SkinTxt.Text = aqy_zh;
                        //HttpPost(urlrs + "d.php", "MachineStr=" + MachineStr);
                        if (aqy_zh == "")
                        {
                            MessageBox.Show("领取更多账号，点击加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                        }

                    }

                    else if (RB_yk.Checked)
                    {
                        string urlpath2 = urlrs + "xmlyk.php";
                        string path2 = "/users/user";
                        string nodepath2 = "name";
                        string aqy_zh = xxm(urlpath2, path2, nodepath2);
                        MachineCode.SkinTxt.Text = aqy_zh;
                        //HttpPost(urlrs + "d.php", "MachineStr=" + MachineStr);
                        if (aqy_zh == "")
                        {
                            MessageBox.Show("领取更多账号，点击加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                        }

                    }

                    else if (RB_mg.Checked)
                    {
                        string urlpath2 = urlrs + "xmlmg.php";
                        string path2 = "/users/user";
                        string nodepath2 = "name";
                        string aqy_zh = xxm(urlpath2, path2, nodepath2);
                        MachineCode.SkinTxt.Text = aqy_zh;
                        //HttpPost(urlrs + "d.php", "MachineStr=" + MachineStr);
                        if (aqy_zh == "")
                        {
                            MessageBox.Show("领取更多账号，点击加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                        }

                    }
                    else if (RB_sh.Checked)
                    {
                        string urlpath2 = urlrs + "xmlsh.php";
                        string path2 = "/users/user";
                        string nodepath2 = "name";
                        string aqy_zh = xxm(urlpath2, path2, nodepath2);
                        MachineCode.SkinTxt.Text = aqy_zh;
                        //HttpPost(urlrs + "d.php", "MachineStr=" + MachineStr);
                        if (aqy_zh == "")
                        {
                            MessageBox.Show("领取更多账号，点击加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                        }

                    }

                }
                else {
                    string urlpath2 = urlrs + "timeinfo.php?MachineStr=" + MachineStr;
                    string pathu = "/users/user";
                    string nodepathu = "name";
                    string erre2 = xxm(urlpath2, pathu, nodepathu);
                    int ti2 = Convert.ToInt32(erre2);
                    if (ti - ti2 > 18000)
                    {
                        if (RB_aqy.Checked)
                        {
                            string urlpathaqy = urlrs + "xmlaqy.php?MachineStr=" + MachineStr;
                            string pathaqy = "/users/user";
                            string nodepathaqy = "name";
                            string aqy_zh = xxm(urlpathaqy, pathaqy, nodepathaqy);
                            MachineCode.SkinTxt.Text = aqy_zh;
                            Thread.Sleep(3000);
                            MessageBox.Show("点击链接加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            if (aqy_zh == "")
                            {
                                MessageBox.Show("领取更多账号，点击加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                                System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            }
                            //HttpPost(urlrs + "d.php", "MachineStr=" + MachineStr);
                        }

                        else if (RB_yk.Checked)
                        {
                            string urlpathyk = urlrs + "xmlyk.php?MachineStr=" + MachineStr;
                            string pathyk = "/users/user";
                            string nodepathyk = "name";
                            string aqy_zh = xxm(urlpathyk, pathyk, nodepathyk);
                            MachineCode.SkinTxt.Text = aqy_zh;
                            //HttpPost(urlrs + "d.php", "MachineStr=" + MachineStr);
                            Thread.Sleep(3000);
                            MessageBox.Show("点击链接加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            if (aqy_zh == "")
                            {
                                MessageBox.Show("领取更多账号，点击加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                                System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            }
                        }

                        else if (RB_mg.Checked)
                        {
                            string urlpathmg = urlrs + "xmlmg.php?MachineStr=" + MachineStr;
                            string pathmg = "/users/user";
                            string nodepathmg = "name";
                            string aqy_zh = xxm(urlpathmg, pathmg, nodepathmg);
                            MachineCode.SkinTxt.Text = aqy_zh;
                            // HttpPost(urlrs + "d.php", "MachineStr=" + MachineStr);
                            Thread.Sleep(3000);
                            MessageBox.Show("点击链接加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            if (aqy_zh == "")
                            {
                                MessageBox.Show("领取更多账号，点击加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                                System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            }
                        }
                        else if (RB_sh.Checked)
                        {
                            string urlpathsh = urlrs + "xmlsh.php?MachineStr=" + MachineStr;
                            string pathsh = "/users/user";
                            string nodepathsh = "name";
                            string aqy_zh = xxm(urlpathsh, pathsh, nodepathsh);
                            MachineCode.SkinTxt.Text = aqy_zh;
                            //HttpPost(urlrs + "d.php", "MachineStr=" + MachineStr);
                            Thread.Sleep(3000);
                            MessageBox.Show("点击链接加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            if (aqy_zh == "")
                            {
                                MessageBox.Show("领取更多账号，点击加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                                System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            }
                        }

                    }
                    else { MessageBox.Show("请五个小时候再获取"); }

                }
            }

            //string urlpath= "http://api.k780.com:88/?app=life.time&appkey=10003&sign=b59bc3ef6191eb9f747dd4e83c99f2a4&format=xml";
            //string path = "/root/result";
            //string nodepath = "timestamp";
            //string erre = xxm(urlpath, path, nodepath);
            //int ti = 0;
            //if (erre == "") { MessageBox.Show("网络是否连接"); }
            //else{ti = Convert.ToInt32(erre); }

            //int timeupdate = ti - 18000;
            //MessageBox.Show(timeupdate.ToString());
            //string result = "zzz2188185";
            //string bytes = md5(result);
            //string MachineStr = softReg.GetMNum();
            //string Ps = MachineStr + bytes.Replace("-", "");


        }


        private void MachineCode_SkinTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string urlrs = "http://www.nandada.com/";
            string urlpathmg = urlrs + "update.php";
            string pathmg = "/users/user";
            string nodepathmg = "name";
            string aqy_zh = xxm(urlpathmg, pathmg, nodepathmg);
            //MachineCode.SkinTxt.Text = aqy_zh;
            if(aqy_zh=="update"){

                Process.Start("update.exe");
                Application.Exit();

            }
            
        }
    }
}
