using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyApp
{
    public static class HttpExtensions
    {
        /// <summary>
        /// Read an HttpContent object as a stream and then convert it to an object
        /// asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static async Task<T> ReadAsObjectAsync<T>(this HttpContent content)
        {
            using (Stream s = await content.ReadAsStreamAsync())
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                return new JsonSerializer().Deserialize<T>(reader);
            }
        }
    }
}
