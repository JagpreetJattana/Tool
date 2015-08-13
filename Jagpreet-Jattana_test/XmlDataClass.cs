using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Jagpreet_Jattana_test
{
    class XmlDataClass
    {
       public String A, B;
        public XmlDataClass(int a,int b) {

            this.A = a.ToString();
            this.B = b.ToString();
        }
        public static XDocument createData()
        {

         /*   XDocument playerData = new XDocument(
                new XDeclaration("1.0", "utf8", "yes"),
                new XComment("Creating XML file for the records of booking cancellations"),
                new XElement("ABCPark",

                new XElement("Both A",
                    new XAttribute("Name", "Booth A"),
                            new XAttribute("Shelters","asd" ),
                new XElement("Both B",
                    new XAttribute("Name", "Both B"),
                            new XAttribute("Shelters", "asd"))


                )
            );*/

            XDocument playerData = new XDocument(
             new XDeclaration("1.0", "utf8", "yes"),
             new XComment("Creating XML file"),
             new XElement("ABCPark",

             new XElement("Booth",
                 new XElement("Name", "Booth A"),
                 
                 new XElement("Shelter","")),
             new XElement("Booth",
                 new XElement("Name", "Booth B"),
               
                 new XElement("Shelter",""))


             )
         );

            return playerData;
        
        
        }

        public static void SaveDataToFile(string filename)
        {
            XDocument document = createData();
            document.Save(filename);
        }





    }
}
