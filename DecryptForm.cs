using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileEncrypter
{
    public partial class DecryptForm : Form
    {
        AesCrypter aes;
        public DecryptForm(AesCrypter aesArg)
        {
            InitializeComponent();
            aes = aesArg;
        }

        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            // countinue in OpenFileDialog1_FileOk func
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //generate new key
            AesCrypter.GenerateNewKeyAndIV();
            aes = new AesCrypter();
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            saveFileDialog1.ShowDialog();
            // countinue in next
        }

        async void doSomthingAsych()
        {            
            try
            {
                FileStream data = (FileStream)openFileDialog1.OpenFile();

                progressBar1.Value = 2;
                MemoryStream encrypted = aes.Decrypt(data);
                progressBar1.Value = 4;
                FileStream s = (FileStream)saveFileDialog1.OpenFile();
                progressBar1.Value = 6;
                //encrypted.WriteTo(s);

                encrypted.Close();
                data.Close();
                s.Close();
                progressBar1.Value = 10;
            }
            catch(Exception ex)
            {
                ModifyProgressBarColor.SetState(progressBar1, 2);
                debugConsole.AppendText($"Error: {ex}\n");
            }
        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            ModifyProgressBarColor.SetState(progressBar1, 1);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 10;
            doSomthingAsych();
        }
    }
}
