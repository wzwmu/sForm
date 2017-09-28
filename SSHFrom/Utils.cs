using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SSHFrom
{
    public class Utils
    {
        public static void Serialize(string fileName,Object obj)
        {
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {
                BinaryFormatter binFormat = new BinaryFormatter();//创建二进制序列化器
                binFormat.Serialize(fStream, obj);
            }
        }
        public static Object Deserialize(string fileName)
        {
            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                Object obj = binFormat.Deserialize(fStream);//反序列化对象
                return obj;
            } 
        }
    }
}
