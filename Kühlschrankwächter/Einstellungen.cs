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
using System.Xml;

namespace Kühlschrankwächter
{
    public partial class Einstellungen : Form
    {
        public Einstellungen()
        {
            InitializeComponent();
        }

        private void buttonUserDataSave_Click(object sender, EventArgs e)
        {
            using (XmlWriter writer = XmlWriter.Create("user.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Settings");


                writer.WriteElementString("Name", textBoxUsername.Text);
                writer.WriteElementString("Email", textBoxEmail.Text);
                writer.WriteElementString("Fridgename", textBoxFridgename.Text);
                writer.WriteEndElement();

                writer.WriteEndDocument();
            }
        }

        private void Einstellungen_Load(object sender, EventArgs e)
        {
            using (XmlReader xmlReader = new XmlTextReader("user.xml"))
            {
                string element = "";
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        element = xmlReader.Name;
                    }
                    else if (xmlReader.NodeType == XmlNodeType.Text)
                    {
                        switch (element)
                        {
                            case "Name":
                                textBoxUsername.Text = xmlReader.Value;
                                break;
                            case "Email":
                                textBoxEmail.Text = xmlReader.Value;
                                break;
                            case "Fridgename":
                                textBoxFridgename.Text = xmlReader.Value;
                                break;
                        }
                    }
                }
            }
        }
    }
}
