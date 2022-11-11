using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Save
{
    public class Text_text
    {
        public string text;
    }
    internal class Saveworld
    {

        public static void gaga(Text_text text, string path)
        {
            text.text = Deserialized(text, path);
            Console.Clear();
            Console.WriteLine("Куда вы хотите сохранит файл?");
            string safeWork = Console.ReadLine();
            string[] word = safeWork.Split(".");
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == "txt")
                {
                    File.WriteAllText(safeWork, text.text);

                }
                if (word[i] == "xml")
                {
                   
                    XmlSerializer xml = new XmlSerializer(typeof(Text_text));
                    using (FileStream fs = new FileStream(safeWork, FileMode.OpenOrCreate))
                    {
                        xml.Serialize(fs, text);
                    }

                }
                if (word[i] == "json")
                {
                    string json = JsonConvert.SerializeObject(text);
                    File.WriteAllText(safeWork, json);
                }
            }
        }
     private static string Deserialized(Text_text text, string path)
        { 
            Console.Clear();
            string error = "Вы неправильно ввели формат";
            string[] word = path.Split(".");
            for (int i = 0; i < word.Length; i++)
            {

                if (word[i] == "xml")
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Text_text));
                    using (FileStream fs = new FileStream(path, FileMode.Open))
                    {
                        Text_text? text_text = (Text_text)xml.Deserialize(fs);
                        return text_text.text;
                    }
                }
                if (word[i] == "json")
                {
                    string result = Convert.ToString(JsonConvert.DeserializeObject(text.text));
                    return result;
                }
                if (word[i] == "txt")
                {
                    return text.text;
                }
                
               
            }
            return error;
        }
    }
   

}
