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

namespace EXOStacker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void MoveItem(int direction)
        {
            if (lstFilename.SelectedItem == null || lstFilename.SelectedIndex < 0) return; //nothing selected
            int new_idx = lstFilename.SelectedIndex + direction;
            if(new_idx < 0)
            {
                new_idx = lstFilename.Items.Count - 1;
            }
            else if(new_idx >= lstFilename.Items.Count)
            {
                new_idx = 0;
            }
            object selected = lstFilename.SelectedItem;
            lstFilename.Items.Remove(selected);
            lstFilename.Items.Insert(new_idx, selected);
            lstFilename.SetSelected(new_idx, true);
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Filter = "AviUtl EXO(*.exo)|*.exo";
            fileDlg.Multiselect = true;
            fileDlg.Title = "Select AviUtl EXO files";
            if(fileDlg.ShowDialog()==DialogResult.OK)
            {
                lstFilename.BeginUpdate();
                foreach(String file in fileDlg.FileNames)
                {
                    lstFilename.Items.Add(file);
                }
                lstFilename.EndUpdate();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstFilename.Items.Clear();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            lstFilename.Items.Remove(lstFilename.SelectedItem);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            MoveItem(1);
        }

        private void lstFilename_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else 
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lstFilename_DragDrop(object sender, DragEventArgs e)
        {
            String[] ddlist = (String[])(e.Data.GetData(DataFormats.FileDrop, false));
            foreach(String file in ddlist)
            {
                if(file.Contains(".exo") || file.Contains(".EXO"))
                {
                    lstFilename.Items.Add(file);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstFilename.Items.Count <= 0) return; //empty list
            SaveFileDialog sfDlg = new SaveFileDialog();
            sfDlg.AddExtension = true;
            sfDlg.DefaultExt = "exo";
            sfDlg.Filter = "AviUtl EXO(*.exo)|*.exo";
            sfDlg.ValidateNames = true;
            sfDlg.Title = "Save merged EXO";
            if (sfDlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            //Process otherwise
            bool firstfile = true;
            StringBuilder outbuf = new StringBuilder();
            int max_obj = 0;
            int max_layer = 0;
            int max_perfile_layer = 0;
            int max_perfile_obj = 0;
            foreach(String file in lstFilename.Items)
            {
                using (FileStream fs = File.Open(file, FileMode.Open))
                {
                    using (BufferedStream bs = new BufferedStream(fs))
                    {
                        using(StreamReader sr= new StreamReader(bs,Encoding.GetEncoding(932)))//S-JIS
                        {
                            string s = String.Empty;
                            while((s=sr.ReadLine())!= null)
                            {
                                bool isFileHead = s.Equals("[exedit]", StringComparison.OrdinalIgnoreCase);
                                bool isSectionHead = s.StartsWith("[") && s.Contains(']') && !s.Contains('.');
                                bool isSubSectionHead = s.StartsWith("[") && s.EndsWith("]") && s.Contains('.');
                                bool layertag = s.StartsWith("layer=", StringComparison.OrdinalIgnoreCase);
                                bool isWidth, isHeight, isScale, isRate, isAuRate, isAuCh, isLength;
                                isWidth = s.StartsWith("width=");
                                isHeight = s.StartsWith("height=");
                                isRate = s.StartsWith("rate=");
                                isScale = s.StartsWith("scale=");
                                isLength = s.StartsWith("length=");
                                isAuRate = s.StartsWith("audio_rate=");
                                isAuCh = s.StartsWith("audio_ch=");

                                if(!isFileHead && !isSectionHead && !isSubSectionHead && !layertag && !isWidth && !isHeight && !isRate && !isScale && !isLength && !isAuRate && !isAuCh)
                                {
                                    outbuf.AppendLine(s);
                                }
                                else if(isFileHead || isWidth || isHeight || isRate || isScale || isLength || isAuRate || isAuCh)
                                {
                                    if(firstfile)
                                    {
                                        outbuf.AppendLine(s);
                                    }
                                    
                                }
                                else if(layertag)
                                {
                                    int eqsign = s.IndexOf("=");
                                    String str_no = s.Substring(eqsign + 1);
                                    int layer_no = Int32.Parse(str_no);
                                    if(firstfile)
                                    {
                                        outbuf.AppendLine(s);
                                        if(layer_no>max_layer)
                                        {
                                            max_layer = layer_no;
                                            max_perfile_layer = layer_no;
                                        }
                                    }
                                    else
                                    {
                                        int this_layer = layer_no + max_layer;
                                        if(layer_no> max_perfile_layer)
                                        {
                                            max_perfile_layer = layer_no;
                                        }
                                        outbuf.Append("layer=");
                                        outbuf.AppendLine(this_layer.ToString());
                                    }
                                }
                                else if(isSectionHead || isSubSectionHead)
                                {
                                    int substr_len = 0;
                                    if(isSectionHead)
                                    {
                                        substr_len = s.Length - 2;
                                    }
                                    else
                                    {
                                        int dotpos = s.IndexOf('.');
                                        substr_len = dotpos - 1;
                                    }
                                    String secnum_str = s.Substring(1, substr_len);
                                    int section_num = Int32.Parse(secnum_str);
                                    if(firstfile)
                                    {
                                        outbuf.AppendLine(s);
                                        if(section_num> max_perfile_obj)
                                        {
                                            max_perfile_obj = section_num;
                                            max_obj = max_perfile_obj;
                                        }
                                    }
                                    else
                                    {
                                        int this_sec_num = section_num + max_obj;
                                        if(section_num > max_perfile_obj)
                                        {
                                            max_perfile_obj = section_num;
                                        }
                                        outbuf.Append("[");
                                        outbuf.Append(this_sec_num.ToString());
                                        if(isSubSectionHead)
                                        {
                                            outbuf.AppendLine(s.Substring(s.IndexOf('.')));
                                        }
                                        else
                                        {
                                            outbuf.AppendLine("]");
                                        }
                                        
                                    }
                                }
                            }
                            sr.Close();
                        }
                        bs.Close();
                    }
                    fs.Close();
                }
                if(!firstfile)
                {
                    max_layer += max_perfile_layer;
                    max_obj += max_perfile_obj + 1;
                }
                else
                {
                    max_obj++;
                }
                
                max_perfile_layer = 0;
                max_perfile_obj = 0;
                firstfile = false;
            }
            String outfile = sfDlg.FileName;
            using(FileStream ofs = File.Open(outfile, FileMode.Create))
            {
                using(BufferedStream obs= new BufferedStream(ofs))
                {
                    using (StreamWriter osw = new StreamWriter(obs, Encoding.GetEncoding(932)))
                    {
                        osw.Write(outbuf);
                        osw.Flush();
                        osw.Close();
                    }
                    ofs.Close();
                }
                ofs.Close();
                MessageBox.Show("EXO Written!", "DONE");
            }
            
        }

        private void lnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://mavericktse.mooo.com/wordpress/");
        }
        
        
    }
}
