using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

namespace AtazaKudeatzailea
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Ataza> Atazak { get; set; } = new();

        private string XmlPath = "..\\..\\..\\Data/tareas.xml";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            KargatuDatuak();
        }

        private void KargatuDatuak()
        {
            if (!File.Exists(XmlPath)) return;
            var xml = XElement.Load(XmlPath);
            foreach (var t in xml.Elements("Tarea"))
            {
                Atazak.Add(new Ataza
                {
                    Titulua = t.Element("Titulua")?.Value,
                    Lehentasuna = t.Element("Lehentasuna")?.Value,
                    AzkenEguna = DateTime.Parse(t.Element("AzkenEguna")?.Value ?? DateTime.Today.ToString()),
                    Egina = (t.Element("Egoera")?.Value ?? "Egin gabe") == "Eginda"
                });
            }
        }

        private void GordeDatuak()
        {
            Directory.CreateDirectory("Data");
            var xml = new XElement("Tareas",
                Atazak.Select(a => new XElement("Tarea",
                    new XAttribute("id", Guid.NewGuid()),
                    new XElement("Titulua", a.Titulua),
                    new XElement("Lehentasuna", a.Lehentasuna),
                    new XElement("AzkenEguna", a.AzkenEguna.ToString("yyyy-MM-dd")),
                    new XElement("Egoera", a.Egina ? "Eginda" : "Egin gabe")
                ))
            );
            xml.Save(XmlPath);
        }

        private void Gehitu_Click(object sender, RoutedEventArgs e)
        {
            var berria = new Ataza
            {
                Titulua = "Ataza berria",
                Lehentasuna = "Baxua",
                AzkenEguna = DateTime.Today,
                Egina = false
            };
            Atazak.Add(berria);
            GordeDatuak();
        }

        private void Editatu_Click(object sender, RoutedEventArgs e)
        {
            if (AtazaZerrenda.SelectedItem is Ataza hautatua)
            {
               if (string.IsNullOrWhiteSpace(hautatua.Titulua))
                {
                    MessageBox.Show("Izenburua derrigorrezkoa da.");
                    return;
                }

               GordeDatuak();
            }
            else
            {
                MessageBox.Show("Ez da atazarik hautatu.");
            }
        }


        private void Ezabatu_Click(object sender, RoutedEventArgs e)
        {
            if (AtazaZerrenda.SelectedItem is Ataza hautatua)
            {
                Atazak.Remove(hautatua);
                GordeDatuak();
            }
        }

        private void Irten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class Ataza
    {
        public string Titulua { get; set; }
        public string Lehentasuna { get; set; }
        public DateTime AzkenEguna { get; set; }
        public bool Egina { get; set; }
        public string Egoera => Egina ? "Eginda" : "Egin gabe";
    }
}