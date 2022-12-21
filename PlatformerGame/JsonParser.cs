using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlatformerGame
{
    internal class JsonParser
    {
        static JObject jObject;
        static string currentMapPath;

        public static void GetObjectFromMap(string mapPath)
        {
            currentMapPath = mapPath;

            StreamReader mapReader = File.OpenText(@"..\..\..\content\" + currentMapPath);
            JsonTextReader jsonMapReader = new JsonTextReader(mapReader);
            jObject = JObject.Load(jsonMapReader);
        }

        public static Rectangle GetRectangle(string fileName, string propertyName)
        {
            if (jObject == null || currentMapPath == null || currentMapPath != fileName)
            {
                GetObjectFromMap(fileName);
            }
            JObject obj = (JObject)jObject.GetValue(propertyName);
            return SetRectangle(obj);
        }

        public static List<Rectangle> GetRectangleList(string fileName, string propertyName)
        {
            if (jObject == null || currentMapPath == null || currentMapPath != fileName)
            {
                GetObjectFromMap(fileName);
            }
            List<Rectangle> rectList = new List<Rectangle>();
            JArray arrayObj = (JArray)jObject.GetValue(propertyName);
            for (int i = 0; i < arrayObj.Count; i++)
            {
                JObject obj = (JObject)arrayObj[i];
                Rectangle rect = SetRectangle(obj);
                rectList.Add(rect);
            }
            return rectList;
        }

        private static Rectangle SetRectangle(JObject obj)
        {
            int x = Convert.ToInt32(obj.GetValue("positionX"));
            int y = Convert.ToInt32(obj.GetValue("positionY"));
            int height = Convert.ToInt32(obj.GetValue("height"));
            int width = Convert.ToInt32(obj.GetValue("width"));
            Rectangle rectangle = new Rectangle(x, y, width, height);
            return rectangle;
        }

        //public static void WriteJsonToFile(string filename, List<GameObject> objectList)
        //{
        //    JArray enemyArray = new JArray();
        //    JArray platformsArray = new JArray();
        //    JObject bigobj = new JObject();

        //    JArray array = new JArray();
        //    for (int i = 0; i < objectList.Count; i++)
        //    {
        //        if (objectList[i] is Platform)
        //        {
        //            JObject obj = CreateObject(objectList[i].Hitbox);
        //            platformsArray.Add(obj);
        //        }
        //        else if (objectList[i] is Entity)
        //        {
        //            JObject obj = CreateObject(objectList[i].Hitbox);
        //            bigobj.Add("entity", obj);
        //        }
        //        else if (objectList[i] is Player)
        //        {
        //            JObject obj = CreateObject(objectList[i].Hitbox);
        //            bigobj.Add("player", obj);
        //        }
        //    }
        //    bigobj.Add("enemy", enemyArray);
        //    bigobj.Add("platform", platformsArray);
        //    System.Diagnostics.Debug.WriteLine(bigobj.ToString());
        //    File.WriteAllText(filename, bigobj.ToString());
        //}

        private static JObject CreateObject(Rectangle rect)
        {
            JObject obj = new JObject();
            obj.Add("positionX", rect.X);
            obj.Add("positionY", rect.Y);
            obj.Add("height", rect.Height);
            obj.Add("width", rect.Width);
            return obj;
        }


    }
}
