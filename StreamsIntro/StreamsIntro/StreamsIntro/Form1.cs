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

namespace StreamsIntro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            // Lets create a destination backing store stream
            using (Stream fileStream = new FileStream(@"\\R:\AdvancedProgramming\AdvProg.txt", 
                                        FileMode.Open, FileAccess.ReadWrite))
            {
                /*
                 * Note, that if the file we are opening is read-only, we must use
                 * a different constructor--typically one of the 3 or 4 parameter
                 * ones that take a FileAccess enum which should be set to
                 * FileAccess.Read
                 */

                btnOpenFile.Enabled = false;

                DisplayStreamProperties(fileStream);

                // Write just a byte to the stream
                fileStream.WriteByte(42);
                fileStream.WriteByte(42);
                fileStream.WriteByte(42);


                // And now write out byte array
                byte[] primeVals = { 2, 3, 5, 7, 11 };
                fileStream.Write(primeVals, 0, primeVals.Length);

                string msg = $"The stream's current position is now {fileStream.Position}";

                MessageBox.Show(msg, "Stream Position Property");

                /*
                 * Note:  we do not explicitly call Flush() or Close() on the stream. Instead
                 * we rely on the using statement which will implicitly call these on our
                 * behalf.
                 */

                btnReadFile.Enabled = true;
            }
        }

        private void DisplayStreamProperties(Stream fileStream)
        {
            txtStreamProperties.Text = $"Stream CanSeek value is {fileStream.CanSeek}"
                                        + Environment.NewLine +
                                       $"Stream CanWrite value is {fileStream.CanWrite}"
                                        + Environment.NewLine +
                                       $"Stream CanRead value is {fileStream.CanRead}"
                                        + Environment.NewLine +
                                       $"Stream CanTimeout is {fileStream.CanTimeout}"
                                        + Environment.NewLine +
                                       $"Stream's current position is {fileStream.Position}";
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            // Here we create a source backing store
            using (Stream fileStream = new FileStream(@"\\R:\AdvancedProgramming\AdvProg.txt", FileMode.Open, FileAccess.Read))
            {
                // First we read a simple byte from the stream...
                int valueRead = fileStream.ReadByte();
                rtbFileContents.Text = valueRead + Environment.NewLine;

                // ...and now we read the rest of the stream contents into a byte array
                byte[] primeVals = new byte[fileStream.Length - fileStream.Position];
                fileStream.Read(primeVals, 0, primeVals.Length);
                foreach (var prime in primeVals)
                {
                    rtbFileContents.AppendText(prime + Environment.NewLine);
                }
            }
        }
    }
}
