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

namespace UnZip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //// 1 zip isimlerini tut
            //// 2 zip isimlerini string in içine ata 
            //   -- 2016 veya 2017 yazınca 2016-2017 klasorunu çıkarsın
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void selectFile()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    System.Windows.Forms.MessageBox.Show($"Seçilen klasör: {fbd.SelectedPath}");
                label1.Text = fbd.SelectedPath;
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            selectFile();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string[] dosyaadi = Directory.GetFiles(label1.Text); // array list başlangıç yoluna bakıyor ve şarta ait klasörün bilgisini alıyor.
                                                                     // listBox1.Items.Add(dosyaadi[i].ToString()); // şarta ait dosyaların yolu ve adı lixtbox aracına yazdırılıyor...
                foreach (var zip in dosyaadi) // dosyaadi değişkeninin içindeki dosyaları zip e ata .
                {
                    string def = new DirectoryInfo(zip).Name;
                    //bool intSring = dosyaadi.Any(char.IsDigit);
                    if (zip.Contains(label1.Text))
                    {
                        if (zip.Contains(".xml"))
                        {
                            File.Delete(zip);
                        }

                        listBox1.Items.Add(def);

                        if (zip.Contains(".zip") || zip.Contains(".rar"))// eğer dosya uzantısı " rar " ise dosyayı çıkar. 
                        {
                            Process p = new Process();
                            //p.StartInfo.UseShellExecute = false;
                            p.StartInfo = new ProcessStartInfo("Winrar.exe", " e " + zip + " " + label1.Text);
                            p.Start();
                            p.WaitForExit();
                        }

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(" İŞLEM GERÇEKLEŞTİRİLEMEDİ !");
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
