using FrameworkExamples.Entities;
using FrameworkExamples.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FrameworkExamples
{
    /*
     * Serialization is a concept of persisting the object into a file instead of the data of the object.
     * The object itself will be stored and retrieved back to the same state fro which it was saved.
     * Unlike the typical File IO, here we save the object and retrieve the object. There will no scope for seeking the contents of the file.
     * In serialization, the whole object gets stored or nothing. Helps in IPC mechanisms where the objects are transfered as saved states and retrieved at the other side as the same object. 
     * .NET has 4 ways of serialization: Binary, XML, Soap and JSON(C# 7).
     * Every serialization concept has 3 things: what, where and how.
     * What to serialize: objects of a.NET Class that have attribute called Serializable.
     * Where to serialize: File locations predefined or set by the user. 
     * How to serialize: Any of the formats mentioned above. 
     * In XML serialization, we should have public classes.XMl is prefered if U want the data to be available across platforms.
     * todo: U should implement the ICustomerRepo interface into a class called XmlCustomerRepo and provide all the functionalities. Using the factory pattern, U should load the appropriate implementor and run the program.
     * Binary Serialization is obselete in .NET CORE.
    */
    internal class Ex09Serialization
    {
        static void Main(string[] args)
        {
            testForBinarySerialization();
            testForXmlSerialization();
            testForJsonSerialization();
        }

        /// <summary>
        /// Wrapper function to show the example of Serialization and Deserialization using JSON Format. 
        /// </summary>
        private static void testForJsonSerialization()
        {
            jsonSerialization();
            //jsonDeSerialization();
        }

        /// <summary>
        /// Example for JSON Deserialization. 
        /// </summary>
        private static void jsonDeSerialization()
        {
            AppSettings.Initialize();
            var file = AppSettings.Configuration["FileOptions:JsonFile"];

            var content = File.ReadAllText(file);
            var student = JsonSerializer.Deserialize<Student>(content);
            Console.WriteLine(student.Name);
        }

        /// <summary>
        /// Example for JSON serialization. 
        /// </summary>
        private static void jsonSerialization()
        {
            //what
            var student = new Student
            {
                Id = 1, Name ="Shyam", Address ="Hassan"
            };

            //How
            var jsonString = JsonSerializer.Serialize(student);
            Console.WriteLine(jsonString);
            //save the jsonString to the file taken from the Config..
            AppSettings.Initialize();
            var file = AppSettings.Configuration["FileOptions:JsonFile"];
            File.WriteAllText(file, jsonString);
        }

        /// <summary>
        /// Wrapper function to show the example of Serialization and Deserialization using XML Format. 
        /// </summary>
        private static void testForXmlSerialization()
        {
            xmlSerialization();
            XmlDeserialization();
        }

        /// <summary>
        /// Example to Deserialize XML Data
        /// </summary>
        private static void XmlDeserialization()
        {
            AppSettings.Initialize();
            var file = AppSettings.Configuration["FileOptions:XmlFile"];
            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);

            var formatter = new XmlSerializer(typeof(Student));
            var student = formatter.Deserialize(fs) as Student;
            Console.WriteLine(student.Name);
            fs.Close();
        }

        /// <summary>
        /// Example on serializing the object as XML. Make the object's class public for XML serialization
        /// </summary>
        private static void xmlSerialization()
        {
            Student student = new Student { Id = 11, Address = "Mysore", Name = "Phaniraj" };
            //where to serialize: File location. 
            AppSettings.Initialize();
            var file = AppSettings.Configuration["FileOptions:XmlFile"];
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);
            //Binary serialization

            var formatter = new XmlSerializer(typeof(Student));
            formatter.Serialize(fs, student);
            fs.Close();
        }

        /// <summary>
        /// Example on Binary Serialization. It is obselete in .NET CORE. U should try this example in .NET Framework. 
        /// </summary>
        private static void testForBinarySerialization()
        {
            ////what: the object of Student class
            //Student student = new Student { Id = 11, Address = "Mysore", Name = "Keshav" };
            ////where to serialize: File location. 
            //AppSettings.Initialize();
            //var file = AppSettings.Configuration["FileOptions:BinaryFile"];
            //FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);
            ////Binary serialization

            //var formatter = new BinaryFormatter();
            //formatter.Serialize(fs, student);
            //fs.Close();
        }
    }
}
