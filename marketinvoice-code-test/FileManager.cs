//Author: Niall Ferguson 
//Date:19/08/2013
//Class containing methods for reading file in JSON format, deserializing then serializing and writing back to file
//as well as moving files between folders.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace Niall_Ferguson_Test
{
    class FileManager
    {
        //read all files in statetest folder and sub folders, deserialize them and add to list        
        public static List<Fruit> readFile()
        {
            Fruit fruit1 = new Fruit();
            string jsonObject;
            string fldr = @"..\..\StateTest\";

            List<Fruit> fruitList = new List<Fruit>();

            //search through all files in folder and suber folder with .txt extension and deseralize from JSON format
            foreach (string file in Directory.EnumerateFiles(fldr, "*.txt", SearchOption.AllDirectories))
            {
                using (StreamReader strReader = new StreamReader(file))
                {
                    while ((jsonObject = strReader.ReadLine()) != null)
                    {
                        Fruit deserializedFruit = JsonConvert.DeserializeObject<Fruit>(jsonObject);
                        fruitList.Add(deserializedFruit);
                    }//end while
                }//end using    
            }//end foreach

            return fruitList;

        }//end method

        //seralize and write fruit objects back into file in the new folder according to its status
        public static void writeFruit(Fruit fruitIn)
        {
            string fldr = @"..\..\StateTest\" + fruitIn.DeliveryState + "\\" + fruitIn.Name + ".txt";
            string seralisedFruit = JsonConvert.SerializeObject(fruitIn);
            StreamWriter strWriter = new StreamWriter(fldr);
            strWriter.Write(seralisedFruit);
            strWriter.Close();
        }//end method

        //copy file into processed folder of previous state
        public static void processed(Fruit fruitIn)
        {
            fruitIn.DeliveryState = fruitIn.DeliveryState - 1;
            string destFile = @"..\..\StateTest\" + fruitIn.DeliveryState + "\\Processed\\" + fruitIn.Name + ".txt";
            string fldr = @"..\..\StateTest\" + fruitIn.DeliveryState + "\\" + fruitIn.Name + ".txt";

            System.IO.File.Move(fldr, destFile);
            fruitIn.DeliveryState = fruitIn.DeliveryState + 1;

            //if fruit is in delivered state move into processed folder
            if (fruitIn.DeliveryState == DeliveryState.Delivered)
            {
                string destFileDelivered = @"..\..\StateTest\" + fruitIn.DeliveryState + "\\Processed\\" + fruitIn.Name + ".txt";
                string fldrDelivered = @"..\..\StateTest\" + fruitIn.DeliveryState + "\\" + fruitIn.Name + ".txt";

                System.IO.File.Move(fldrDelivered, destFileDelivered);
            }//end if
        }//end method    
    }//end class
}//end namespace
