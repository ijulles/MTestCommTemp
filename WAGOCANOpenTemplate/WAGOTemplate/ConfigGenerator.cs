using Newtonsoft.Json;
using System.IO;

namespace WAGOTemplate
{
    /// <summary>
    /// 提供把类型序列化到文件或从文件中反序列化的方法
    /// </summary>
    static class ConfigGenerator
    {
        public static void Export(string path,object slaveConfig)//序列化
        {
            JsonSerializer jsonSerializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
                jsonSerializer.Serialize(writer, slaveConfig);
        }

        public static T Import<T>(string path)//反序列化
        {
            JsonSerializer jsonSerializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };
            using (StreamReader sr = new StreamReader(path))
            using (JsonReader reader = new JsonTextReader(sr))
                return jsonSerializer.Deserialize<T>(reader);
        }

        /// <summary>
        /// 把数据序列换到文件中
        /// </summary>
        /// <param name="config">需要序列换的类</param>
        /// <param name="path">要保存的路径</param>
        public static void Export(this object config,string path)
        {
            Export(path, config);
        }

        //public static void Import(this SlaveConfig slaveConfig,string path)
        //{
        //    slaveConfig = Import<SlaveConfig>(path);
        //}
    }
}
