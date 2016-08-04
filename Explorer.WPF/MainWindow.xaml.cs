using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using Path = System.IO.Path;

namespace Explorer.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, Uri> _pages = new Dictionary<string, Uri>();

        public MainWindow()
        {
            InitializeComponent();
            ResourceDictionary dict = this.Resources.MergedDictionaries[0];
            XmlDataProvider xmlProvider = (XmlDataProvider)dict["sectionProvider"];
            XDocument xdoc = GetXmlForExamples();
            xmlProvider.Document = ToXmlDocument(xdoc);
        }

        private void TvMain_OnMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            XmlElement xe = (XmlElement)tvMain.SelectedItem;
            if (xe != null)
            {
                if (xe.Name == "Topic")
                {
                    XmlAttribute xa = xe.Attributes["Type"];
                    string location = xa.Value;
                    //Explorer.WPF.Examples.TeachYourselfWPF
                    //Type d = Type.GetType("Explorer.WPF.Examples.TeachYourselfWPF.FontViewer");
                    Type d = Type.GetType(location);
                    object k = Activator.CreateInstance(d);
                    ((Window)k).Show();

                }
            }

        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            XmlElement xe = (XmlElement)tvMain.SelectedItem;
            if (xe.Name == "Topic")
            {
                XmlAttribute xa = xe.Attributes["UriLocation"];
                string location = xa.Value;
                if (!_pages.ContainsKey(location))
                {
                    _pages[location] = new Uri(location, UriKind.RelativeOrAbsolute);
                }

                frameHost.Source = _pages[location];
            }
        }

        private XmlDocument ToXmlDocument(XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;            
        }

        private XDocument GetXmlForExamples()
        {
            
            XElement root = new XElement("Sections");
            XDocument doc = new XDocument(root);
            // get list of directories
            DirectoryInfo dirInfo = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);
            string dirLocation = Path.Combine(dirInfo.Parent.Parent.Parent.FullName, "Examples");
            string rootNamespace = ConfigurationManager.AppSettings["Rootnamespace"];
            string []dirs  = Directory.GetDirectories(dirLocation);
            foreach (string s in dirs)
            {
                // C:\internalprojects\projectlocker\Explorer.WPF\Examples\Styles
                string folderName = s.Substring(s.LastIndexOf(@"\")+1);
                string targetNamespace = rootNamespace + "." + folderName;
                XElement xe = new XElement("WPFSection",
                                           new XAttribute("SectionTitle", folderName));
                string[] fileNames = Directory.GetFiles(s);
                //filename: C:\internalprojects\projectlocker\Explorer.WPF\Examples\Styles\stylebasics.xaml
                // need to get: examples\styles\stylebasics.xaml
                foreach (var f in fileNames)
                {
                    //ignoring all .cs
                    if (Path.GetExtension(f) == ".xaml")
                    {
                        XElement topic = new XElement("Topic",
                                                      new XAttribute("Title", Path.GetFileNameWithoutExtension(f)),
                                                      new XAttribute("Type", targetNamespace + "." + Path.GetFileNameWithoutExtension(f)));
                        xe.Add(topic);
                    }
                }
                root.Add(xe);
            }
            return doc;
        }
    }
}
