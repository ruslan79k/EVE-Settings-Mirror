using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EVE_SettingsMirror
{
    public partial class Form1 : Form
    {
        readonly XElement _xElement;
        private readonly string[] _files;
        public Form1()
        {
            InitializeComponent();
            try
            {
                _xElement = XElement.Load("EVE_SettingsMirror.xml");
                var xElement = _xElement.Element("SampleUser");
                if (xElement != null)
                {
                    textBox_User.Text = xElement.Value;
                    if (xElement.Value != string.Empty && !File.Exists(xElement.Value)) textBox_User.Text = string.Empty;
                }

                xElement = _xElement.Element("SampleChar");
                if (xElement != null)
                {
                    textBox_Char.Text = xElement.Value;
                    if (xElement.Value != string.Empty && !File.Exists(xElement.Value)) textBox_Char.Text = string.Empty;
                }
            }
            catch (Exception)
            {
                _xElement = new XElement("r");
            }


            #region чтение папок настроек игры и вывод в меню

            string pathEve = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                @"CCP\EVE\");
            var f = Directory.GetFiles(pathEve, "core_public__.yaml", SearchOption.AllDirectories);
            foreach (var path in f)
            {
                var folder = Path.GetDirectoryName(path);
                if (folder != null)
                {
                    var directoryInfo = new DirectoryInfo(folder);
                    ToolStripItem item = new ToolStripMenuItem("Open folder: " + directoryInfo.Name);
                    item.Tag = folder;
                    contextMenuStrip1.Items.Add(item);
                }
            }

            #endregion

            _files = Directory.GetFiles(Application.StartupPath, "*.dat", SearchOption.TopDirectoryOnly);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();

            foreach (string fPath in _files)
            {
                string fileName = Path.GetFileName(fPath);

                if (fileName == textBox_Char.Text || fileName == textBox_User.Text) continue;

                if (fileName != null)
                {
                    Regex regex = new Regex(@"(user_|char_)(\d+)");
                    Match match = regex.Match(fileName);
                    while (match.Success)
                    {
                        if (textBox_User.Text != string.Empty && match.Groups[1].Value == "user_")
                        {
                            File.Copy(Path.Combine(Application.StartupPath, textBox_User.Text), fPath, true);
                            listBoxLog.Items.Add(fileName);
                        }
                        if (textBox_Char.Text != string.Empty && match.Groups[1].Value == "char_")
                        {
                            File.Copy(Path.Combine(Application.StartupPath, textBox_Char.Text), fPath, true);
                            listBoxLog.Items.Add(fileName);
                        }

                        match = match.NextMatch();
                    }
                }
            }
        }

        private void Save(object sender, FormClosingEventArgs e)
        {
            if (textBox_Char.Text != string.Empty || textBox_User.Text != string.Empty)
            {
                _xElement.SetElementValue("SampleUser", textBox_User.Text);
                _xElement.SetElementValue("SampleChar", textBox_Char.Text);
                _xElement.Save("EVE_SettingsMirror.xml");
            }
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            tb.Text = tb.Text.Trim().Replace(" ", string.Empty);
        }

        private void donate_ISK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Donate ISK in the game can be addressed to: x989\n" +
                             "Пожертвовать ISK можно в игре на имя: x989");
        }


        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Process.Start(e.ClickedItem.Tag.ToString());
        }

      
    }
}
