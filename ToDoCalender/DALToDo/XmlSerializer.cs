using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace DALToDo
{
    public class MyXmlSerializer<T>
    {
        private string fName {  get; set; }
        public MyXmlSerializer()
        {
            fName = "tasktodo.xml";
        }

        public void serialize(List<T> list)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

            using (FileStream outStream = new FileStream(fName, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(outStream, list);
            }
        }

        public List<T> deSerialize()
        {
            try
            {
                XmlSerializer deSerializer = new XmlSerializer(typeof(List<T>));

                using (FileStream inStream = new FileStream(fName, FileMode.Open, FileAccess.Read))
                {
                    List<T> aLista = (List<T>)deSerializer.Deserialize(inStream);
                    return aLista;
                }
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }
    }
}