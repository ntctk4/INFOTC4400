using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ntctk4PlainTextEditorV1
{
    class TextDoc
    {
        public String text { get; set; }

        public void Load(String text, String fileName)
        {
            try
            {
                StreamReader srl = new StreamReader(fileName);

                this.text = srl.ReadToEnd();

                srl.Close();
            }
            catch(IOException ex)
            {
                Console.Write(ex.Message);
                this.text = "Failed to load in the file";
            }
        }

        public void Save(String textToSave, string file)
        {
            try
            {
                StreamWriter srl = new StreamWriter(file);

                srl.Write(textToSave);

                srl.Close();
            }
            catch(IOException ex)
            {
                Console.Write(ex.Message);
                this.text = "Failed to Save text";
            }
        }

    }
}
