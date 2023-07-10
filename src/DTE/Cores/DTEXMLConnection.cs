using DTE.Domains;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DTE.Cores
{
    public class DTEXMLConnection : DataBindingBase45
    {

        private readonly string fileName = "connections";
        public DTEXMLConnection()
        {
            ConnectionDeserialize();
        }

        public void ConnectionDeserialize()
        {
            if (File.Exists(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<TreeViewModel>));
                StreamReader reader = new StreamReader(fileName);
                Connections = (ObservableCollection<TreeViewModel>)serializer.Deserialize(reader);
                reader.Close();
            }

        }
        public void ConnectionSerialize()
        {
            XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<TreeViewModel>));
            TextWriter writer = new StreamWriter(fileName);
            ser.Serialize(writer, Connections);
            writer.Close();
        }

        ObservableCollection<TreeViewModel> _connections = new ObservableCollection<TreeViewModel>();
        public ObservableCollection<TreeViewModel> Connections
        {
            get
            {
                return _connections;
            }

            set
            {
                _connections = value;
                OnPropertyChanged();
            }
        }

    
    }
}
