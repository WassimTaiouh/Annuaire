using System;
using System.Collections.Generic;
using System.Linq;

namespace Annuaire // Note: actual namespace depends on the project name.
{
    public class Program
    {
        //met le contenu du xml dans MyDocuments
        static String path= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"//contacts.xml"; //Met le fichier dans Mes documents
        //Ecrire du XML
        public static void WriteXML(List<Contact> contacts)
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(List<Contact>));

            System.IO.FileStream file= System.IO.File.Create(path);
            writer.Serialize(file, contacts);
            file.Close();
        }
        //Lire du XML
        public static void ReadXML()
        {
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(List<Contact>));
            
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            List<Contact> contacts = (List<Contact>)reader.Deserialize(file);
            file.Close();

            foreach(Contact c in contacts)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public static void Main(string[] args)
        {
            List<Contact> contacts= new List<Contact>(); //Déclare la liste
            contacts.Add(new Contact("Joe", "0710203040"));
            contacts.Add(new Contact("Ali", "0612233445"));
            WriteXML(contacts); //Créer les contact
            ReadXML(); //Sauvegarde et lecture
            Console.ReadKey(true); //tant que j'appuie pas sur une touche, le programme s'arrête pas
        }
    }
}