using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;

namespace VideoPoker.Model
{
    /// <summary>
    /// 保存機能付きモデル抽象
    /// </summary>
    /// <remarks>
    /// データを保存・復元したいモデルの基底クラスです。
    /// </remarks>
    [DataContract]
    public abstract class SerializableModel : BaseModel
    {
        [IgnoreDataMember]
        private static Func<string, string> JsonPath = (v) => { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, v) + ".json"; };

        // 自身をJsonファイルへ変換する関数
        public void Serialize()
        {
            Serialize(this.GetType().Name);
        }

        public void Serialize(string fileName)
        {
            var serializer = new DataContractJsonSerializer(this.GetType());
            using (var fs = new FileStream(SerializableModel.JsonPath(fileName), FileMode.Create))
                serializer.WriteObject(fs, this);
        }

        // Jsonファイルを指定された型に変換する関数
        public static T Deserialize<T>()
        {
            return Deserialize<T>(typeof(T).Name);
        }

        public static T Deserialize<T>(string fileName)
        {
            try {
                string json;
                var serializer = new DataContractJsonSerializer(typeof(T));
                using (var sr = new StreamReader(SerializableModel.JsonPath(fileName)))
                    json = sr.ReadToEnd();
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                    return (T)serializer.ReadObject(ms);

            } catch (Exception) {
                return default(T);
            }
        }
    }
}
