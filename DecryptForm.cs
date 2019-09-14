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

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            saveFileDialog1.ShowDialog();
            // countinue in next
        }

        public void setProgress(int progress)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(setProgress), new object[] { progress });
                return;
            }
            progressBar1.Value = progress;
        }
        public void setColor(Color color)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Color>(setColor), new object[] { color });
                return;
            }
            progressBar1.BackColor = color;
        }

        async void doSomthingAsych()
        {
            try
            {
                FileStream data = (FileStream)openFileDialog1.OpenFile();

                setProgress(2);
                Stream encrypted = aes.Decrypt(data);
                setProgress(4);
                FileStream s = (FileStream)saveFileDialog1.OpenFile();
                setProgress(6);
                encrypted.CopyTo(s);

                encrypted.Close();
                data.Close();
                s.Close();
                setProgress(10);
            }
            catch (Exception ex)
            {
                setColor(Color.Red);
                appedConsole($"Error: {ex.ToString()}\n");
            }
        }

        public void appedConsole(string s)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(appedConsole), new object[] { s });
                return;
            }
            debugConsole.AppendText(s);
        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            progressBar1.BackColor = Color.Green;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 10;
            Task.Run(new Action(doSomthingAsych));
        }
    }
}
