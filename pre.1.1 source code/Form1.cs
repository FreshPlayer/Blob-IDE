﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Printing;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace WordCat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Int for ln & col
        int line;
        int column;

        //Strings
        string version = "1";
        string Path = "";

            //Search and replace strings
            string search_string;

        //Checkbox Bool

        string acc_tab = "true";
        string det_links = "false";
        string read_only = "false";
        string word_wrap = "false";

        //EDITOR ACTIONS

        /*(Clear Contextmenu Button)*/


            private void cutToolStripButton_contextMenu_Click(object sender, EventArgs e)
            {
                richTextBox1.Cut();
            }

            private void copyToolStripButton_contextMenu_Click(object sender, EventArgs e)
            {
                richTextBox1.Copy();
            }

            private void pasteToolStripButton_contextMenu_Click(object sender, EventArgs e)
            {
                richTextBox1.Paste();
            }

            private void undoToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.Undo();
            }

            private void redoToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.Redo();
            }

            private void cutToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.Cut();
            }

            private void copyToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.Copy();
            }

            private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.Paste();
            }

            private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.SelectAll();
            }
        //EDITOR ACTIONS.


        //FORM1
            private void Form1_Load(object sender, EventArgs e)
            {
                timer1.Start();

                this.Text = "WordCat " + version;

                font_label.Text = "Font : " + richTextBox1.Font.Name;


                //Read Checkboxes
                StreamReader sr = new StreamReader(Application.StartupPath + "\\Data\\settings\\checkboxes.txt");
                acc_tab = sr.ReadLine();
                det_links = sr.ReadLine();
                read_only = sr.ReadLine();
                word_wrap = sr.ReadLine();
                sr.Close();

                    if(acc_tab == "True")
                    {

                        checkBox_acc_tab.Checked = true;
                
                    }
                    if (det_links == "True")
                    {

                        checkBox_detectURLS.Checked = true;
                        richTextBox1.DetectUrls = true;

                    }
                    if (read_only == "True")
                    {

                        checkBox_readOnly.Checked = true;

                    }
                    if (word_wrap == "True")
                    {

                        checkBox_wordWrap.Checked = true;

                    }



                    else if (acc_tab == "False")
                    {

                        checkBox_acc_tab.Checked = false;
                        richTextBox1.AcceptsTab = false;

                    }
                    else if (det_links == "False")
                    {

                        checkBox_detectURLS.Checked = false;
                        richTextBox1.DetectUrls = false; 

                    }
                    else if (read_only == "False")
                    {

                        checkBox_readOnly.Checked = false;

                    }
                    else if (word_wrap == "False")
                    {

                         checkBox_wordWrap.Checked = false;

                    }

            }

            private void exitToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Data\\settings\\checkboxes.txt");
                sw.WriteLine(checkBox_acc_tab.Checked);
                sw.WriteLine(checkBox_detectURLS.Checked);
                sw.WriteLine(checkBox_readOnly.Checked);
                sw.WriteLine(checkBox_wordWrap.Checked);
                sw.Close();
            }

        //FORM1.

        //LINK ITEMS / LABELS
            private void githubToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Process.Start("https://github.com/FreshPlayer/WordCat/wiki");
            }

            private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Process.Start("https://www.freshplayeryt.com/WordCat/");
            }   

        //LINK ITEMS / LABELS.

        //MENU STRIP

            private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
            {
                MessageBox.Show("About : \n\nProgrammed By : FreshPlayer_ YT\nCopyright : © FreshPlayer_YT 2021\n\n THIS SOFTWARE IS OPEN SOURCE", "About WordCat", MessageBoxButtons.OK);
            }


            private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                Process.Start("https://github.com/FreshPlayer/WordCat/blob/ROOT/HELP.md");
            }


            private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                search_and_replace sar1 = new search_and_replace(this);
                sar1.Show();
            }

            private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
            {
                ColorDialog cd = new ColorDialog();

                if (cd.ShowDialog() == DialogResult.OK)
                {

                    richTextBox1.ForeColor = cd.Color;

                }
            }

            private void timeToolStripMenuItem_Click(object sender, EventArgs e)
            {

                DateTime dt = DateTime.Now;
                richTextBox1.AppendText(dt.ToString("h:mm:ss tt"));

            }

            private void dateToolStripMenuItem_Click(object sender, EventArgs e)
            {

                DateTime dt = DateTime.Now;
                richTextBox1.AppendText(dt.ToString("d"));

            }

        //MENU STRIP.



        //CHECKBOXES
        private void checkBox_acc_tab_CheckedChanged(object sender, EventArgs e)
            {
                if(checkBox_acc_tab.Checked == true)
                {

                    richTextBox1.AcceptsTab = true;

                }
                if (checkBox_acc_tab.Checked == false)
                {

                    richTextBox1.AcceptsTab = false;

                }
            }

            private void checkBox_detectURLS_CheckedChanged(object sender, EventArgs e)
            {
                if (checkBox_detectURLS.Checked == true)
                {

                    richTextBox1.DetectUrls = true;

                }
                if (checkBox_detectURLS.Checked == false)
                {

                    richTextBox1.DetectUrls = false;

                }
            }

            private void checkBox_readOnly_CheckedChanged(object sender, EventArgs e)
            {
                if (checkBox_readOnly.Checked == true)
                {

                    richTextBox1.ReadOnly = true;

                }
                if (checkBox_readOnly.Checked == false)
                {

                    richTextBox1.ReadOnly = false;

                }
            }

            private void checkBox_wordWrap_CheckedChanged(object sender, EventArgs e)
            {
                if (checkBox_wordWrap.Checked == true)
                {

                    richTextBox1.WordWrap = true;

                }
                if (checkBox_wordWrap.Checked == false)
                {

                    richTextBox1.WordWrap = false;

                }
            }
        //CHECKBOXES.






        //EDITOR ZOOM

            private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
            {
                float currentSize;
                currentSize = richTextBox1.Font.Size;
                currentSize += 2.0F;
                richTextBox1.Font = new Font(richTextBox1.Font.Name, currentSize, richTextBox1.Font.Style, richTextBox1.Font.Unit);
            }

            private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
            {
                float currentSize = 1.0f;
                currentSize = richTextBox1.Font.Size;
                currentSize -= 2.0F;
                if (currentSize >= 1.0)
                {
                    richTextBox1.Font = new Font(richTextBox1.Font.Name, currentSize, richTextBox1.Font.Style, richTextBox1.Font.Unit);
                }
                else if (currentSize <= 1.0)
                {

                    MessageBox.Show("Reached Minimum Size!", "WordCat " + version, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }


        //EDITOR ZOOM.

        //DIALOG


            private void button1_Click(object sender, EventArgs e)
            {
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {

                    richTextBox1.Font = fontDialog1.Font;

                    font_label.Text = "Font : " + richTextBox1.Font.Name;


                }


            }

            private void newToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (MessageBox.Show("Are you sure?\nAll unsaved changes will be lost!", "WordCat " + version, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    this.Text = "WordCat " + version + " - New File (Unsaved File)";
                    richTextBox1.Clear();

                    Path = "";

                }
            }

            private void openToolStripMenuItem_Click(object sender, EventArgs e)
            {
                openFileDialog1.Filter = "Text-File|*.txt|All Files|*.*";
                openFileDialog1.FileName = "";
                

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    string file_content = sr.ReadToEnd();
                    richTextBox1.Text = file_content;

                }
            }

        //DIALOG.


        //Printing
            private void printToolStripButton_Click(object sender, EventArgs e)
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }

            private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }

            private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
            {
                e.Graphics.DrawString(richTextBox1.Text, new Font(richTextBox1.Font.Name, richTextBox1.Font.Size, richTextBox1.Font.Style), Brushes.Black, new Point(10, 10));
            }
       //Printing.

       //SAVING
            private void saveToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (Path == String.Empty)
                {

                    DialogResult saveResult = saveFileDialog1.ShowDialog();

                    if (saveResult == DialogResult.OK)
                    {

                        Path = saveFileDialog1.FileName;

                        try
                        {

                            StreamWriter SaveStremWriter = new StreamWriter(Path);
                            SaveStremWriter.Write(richTextBox1.Text);
                            SaveStremWriter.Close();

                            this.Text = "WordCat " + version + " - " + Path;



                        }
                        catch (IOException ioe)
                        {

                            MessageBox.Show("Error Saving File : " + ioe.Message, "WordCat", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }

                }
                else
                {

                    try
                    {

                        StreamWriter SaveStremWriter = new StreamWriter(Path);
                        SaveStremWriter.Write(richTextBox1.Text);
                        SaveStremWriter.Close();

                        this.Text = "WordCat " + version + " - " + Path;



                    }
                    catch (IOException ioe)
                    {

                        MessageBox.Show("Error Saving File : " + ioe.Message, "WordCat", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }


            }

            private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
            {

                DialogResult saveResult = saveFileDialog1.ShowDialog();

                if (saveResult == DialogResult.OK)
                {

                    Path = saveFileDialog1.FileName;

                    try
                    {

                        StreamWriter SaveStremWriter = new StreamWriter(Path);
                        SaveStremWriter.Write(richTextBox1.Text);
                        SaveStremWriter.Close();

                        this.Text = "WordCat " + version + " - " + Path;



                    }
                    catch (IOException ioe)
                    {

                        MessageBox.Show("Error Saving File : " + ioe.Message, "WordCat " + version, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }


            }


        //SAVING.

        //METHODS


            public int find(string find_content)
            {
                
                
                Match m = Regex.Match(richTextBox1.Text, find_content);

                int originalIndex = richTextBox1.SelectionStart;
                int originalLength = richTextBox1.SelectionLength;


                
                richTextBox1.SelectionStart = m.Index;
                richTextBox1.SelectionLength = m.Length;
                richTextBox1.SelectionColor = Color.White;
                richTextBox1.SelectionBackColor = Color.Orange;

                this.Refresh();

                return originalIndex;

            }

            public int replace(string replace_content)
            {

                richTextBox1.SelectionColor = Color.Black;
                richTextBox1.SelectionBackColor = Color.White;
            //richTextBox1.SelectedText.Replace(replace_content);
                richTextBox1.SelectedText = replace_content;

            return 1;
              //Method must return a value. why? dont ask me, ask mircosoft!

            }



            
            public bool search_and_select(string search_content)
            {

                bool return_value = false;

                string keywords = search_content;
                MatchCollection keywordMatches = Regex.Matches(richTextBox1.Text, keywords);

                int originalIndex = richTextBox1.SelectionStart;
                int originalLength = richTextBox1.SelectionLength;


                richTextBox1.SelectionStart = 0;
                richTextBox1.SelectionLength = richTextBox1.Text.Length;
                richTextBox1.SelectionBackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));

                foreach (Match m in keywordMatches)
                {
                    richTextBox1.SelectionStart = m.Index;
                    richTextBox1.SelectionLength = m.Length;
                    richTextBox1.SelectionColor = Color.White;
                    richTextBox1.SelectionBackColor = Color.LimeGreen;

                    return_value = true;
                }

                richTextBox1.SelectionStart = originalIndex;
                richTextBox1.SelectionLength = originalLength;
                richTextBox1.SelectionBackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));

                return return_value;

            }

        //METHODS.

        


        private void timer1_Tick(object sender, EventArgs e)
        {
            line = 1 + richTextBox1.GetLineFromCharIndex(richTextBox1.GetFirstCharIndexOfCurrentLine());
            column = 1 + richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexOfCurrentLine();
            lineAndColumn_label.Text = "Ln : " + line + " | Col : " + column;
        }


    }
}