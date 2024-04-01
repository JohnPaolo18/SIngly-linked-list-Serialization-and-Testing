using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Assignment3.Utility;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers(ILinkedListADT users, string fileName)
        {
            //DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            //using (FileStream stream = File.Create(fileName))
            //{
            //    serializer.WriteObject(stream, users);
            //}
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.Create(fileName))
            {
                formatter.Serialize(stream, users);
            }
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        //public static ILinkedListADT DeserializeUsers(string fileName)
        //{
        //    DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
        //    using (FileStream stream = File.OpenRead(fileName))
        //    {
        //        return (ILinkedListADT)serializer.ReadObject(stream);
        //    }
        //}
        public static SLL DeserializeUsers(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenRead(fileName))
            {
                return (SLL)formatter.Deserialize(stream);
            }
        }
    }
}
