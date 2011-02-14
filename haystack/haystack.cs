using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace haystack
{
    public partial class haystack : Form
    {
        public bool DEBUG = false;

        public Random random = new Random();
        
        public int remain;
        public string lastSearchEngine;
        public string lastQuery;

        public const int TIME_MIN = 15;
        public const int TIME_MAX = 900;

        public haystack()
        {
            InitializeComponent();
            timerSearch.Stop();
            timerSecond.Stop();
        }

        public string BuildQuery(string WordListFile, int MaxWords)
        {
            string Query = null;

            FileStream FS = new FileStream(WordListFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader SR = new StreamReader(FS);

            string text = SR.ReadToEnd();

            Regex RE = new Regex("\n", RegexOptions.Multiline);
            MatchCollection matches = RE.Matches(text);

            int numSearchTerms = random.Next(1, MaxWords);

            for (int i = 0; i < numSearchTerms; i++)
            {
                string temp = null;
                SR.DiscardBufferedData();
                SR.BaseStream.Position = random.Next(0, (int)SR.BaseStream.Length);
                temp = SR.ReadLine();
                temp = SR.ReadLine();

                Query += temp + " ";
            }

            SR.Close();
            FS.Close();

            return Query.Trim();
        }

        public void SendSearchQuery(string SearchEngine, string Query)
        {
            string Parameters = null;
            string url = null;

            Query = Query.Trim();

            switch (SearchEngine)
            {
                case "Google":
                    Parameters = "hl=en";
                    Parameters += "&q=" + Query;
                    Parameters += "&btnG=Google+Search";

                    url = "http://www.google.com/search?" + Parameters;
                    break;

                case "Ask":
                    Parameters = "q=" + Query;
                    Parameters += "&search=search";
                    Parameters += "&qsrc=0";
                    Parameters += "&o=0";
                    Parameters += "&1=dir";

                    url = "http://www.ask.com/web?" + Parameters;
                    break;

                case "Yahoo":
                    Parameters = "p=" + Query;
                    Parameters += "&fr=yfp-t-501";
                    Parameters += "&toggle=1";
                    Parameters += "&cop=mss";
                    Parameters += "&ei=UTF-8";

                    url = "http://search.yahoo.com/search?" + Parameters;
                    break;

                case "AltaVista":
                    Parameters = "itag=ody";
                    Parameters += "&q=" + Query;
                    Parameters += "&kgs=1";
                    Parameters += "&kls=0";

                    url = "http://www.altavista.com/web/results?" + Parameters;
                    break;

                case "Live Search":
                    Parameters = "q=" + Query;
                    Parameters += "&go=";
                    Parameters += "&form=QBHP";

                    url = "http://search.live.com/results.aspx?" + Parameters;
                    break;

                case "metacrawler":
                    url = "http://www.metacrawler.com/info.metac/search/web/" + Query;
                    break;

                case "Excite":
                    url = "http://msxml.excite.com/info.xcite/search/web/" + Query.Replace(" ", "%2B");
                    break;

                case "Answers.com":
                    url = "http://www.answers.com/" + Query;
                    break;

                case "WebMD":
                    Parameters = "query=" + Query;
                    Parameters += "&sourceType=undefined";

                    url = "http://www.webmd.com/search/search_results/default.aspx?" + Parameters;
                    break;
            }

            WebResponse response = GetResponse(url);
            if (response == null)
                return;

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string content = reader.ReadToEnd();

            lastSearchEngine = SearchEngine;
            lastQuery = Query;

            if (DEBUG)
            {
                StreamWriter os = new StreamWriter(Environment.GetEnvironmentVariable("TEMP") + @"\haystack_out.html");
                os.Write(content);
                os.Close();
                System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe", "file:///" + Environment.GetEnvironmentVariable("TEMP").Replace("\\", "/") + "/haystack_out.html");
            }
        }

        private WebResponse GetResponse(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.AllowAutoRedirect = false;
                request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                return request.GetResponse();
            }
            // Catch exception if trying to set a restricted header.
            catch (ArgumentException e)
            {
                MessageBox.Show("ArgumentException is thrown. Message is: " + e.Message);
                return null;
            }
        }

        private void buttonToggle_Click(object sender, EventArgs e)
        {
            if (!timerSearch.Enabled)
            {
                if (listSelected.Items.Count <= 0)
                {
                    MessageBox.Show("You must select at least one search engine to use.");
                    return;
                }

                buttonToggle.Text = "Stop Burying";
                timerSearch.Interval = random.Next(TIME_MIN, TIME_MAX) * 1000;
                remain = timerSearch.Interval;
                timerSearch.Start();
                timerSecond.Start();
            }
            else
            {
                buttonToggle.Text = "Start Burying";
                labelRemain.Text = "Next search in: Idle";
                timerSearch.Stop();
                timerSecond.Stop();
            }
        }

        private void timerSearch_Tick(object sender, EventArgs e)
        {
            timerSearch.Interval = random.Next(TIME_MIN, TIME_MAX) * 1000;
            remain = timerSearch.Interval;

            int engine = random.Next(0, listSelected.Items.Count);
            SendSearchQuery(listSelected.Items[engine].ToString(), BuildQuery("wordlist", 15));

            labelLastSearchEngine.Text = "Last Search Engine: " + lastSearchEngine;
            textBoxLastQuery.Text = lastQuery;
        }

        private void timerSecond_Tick(object sender, EventArgs e)
        {
            remain -= 1000;
            labelRemain.Text = "Next search in: " + (remain / 1000) / 60 + "m" + (remain / 1000) % 60 + "s";
            labelRemain.Refresh();

            if (this.WindowState == FormWindowState.Minimized)
                notifyIcon.Text = "haystack (next: " + (remain / 1000) / 60 + "m" + (remain / 1000) % 60 + "s) : left = restore / right = exit";
        }

        private void haystack_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Application.Exit();
            }
            else
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
        }

        private void haystack_Load(object sender, EventArgs e)
        {
            listAvailable.Items.Add("Google");
            listAvailable.Items.Add("Ask");
            listAvailable.Items.Add("Yahoo");
            listAvailable.Items.Add("AltaVista");
            listAvailable.Items.Add("Live Search");
            listAvailable.Items.Add("metacrawler");
            listAvailable.Items.Add("Excite");
            listAvailable.Items.Add("Answers.com");
            listAvailable.Items.Add("WebMD");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (listAvailable.SelectedIndex >= 0)
            {
                listSelected.Items.Add(listAvailable.SelectedItem.ToString());
                listAvailable.Items.RemoveAt(listAvailable.SelectedIndex);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listSelected.SelectedIndex >= 0)
            {
                listAvailable.Items.Add(listSelected.SelectedItem.ToString());
                listSelected.Items.RemoveAt(listSelected.SelectedIndex);
            }
        }

        private void listAvailable_DoubleClick(object sender, EventArgs e)
        {
            if (listAvailable.Items.Count > 0)
            {
                listSelected.Items.Add(listAvailable.SelectedItem.ToString());
                listAvailable.Items.RemoveAt(listAvailable.SelectedIndex);
            }
        }

        private void listSelected_DoubleClick(object sender, EventArgs e)
        {
            if (listSelected.Items.Count > 0)
            {
                listAvailable.Items.Add(listSelected.SelectedItem.ToString());
                listSelected.Items.RemoveAt(listSelected.SelectedIndex);
            }
        }
    }
}
