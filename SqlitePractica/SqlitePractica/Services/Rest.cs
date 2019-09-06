

namespace SqlitePractica.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    public class Rest
    {
        string url = "http://cibomarket.somee.com/api/";
        HttpClient client;

        public async Task<T> Get<T>(string tabla, string id)
        {
            try
            {
                client = new HttpClient();
                var response = await client.GetAsync(url + tabla + "/" + id);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
                }
            }
            catch (Exception)
            {
                return default(T);
                throw;
            }
            return default(T);
        }

        public async Task<List<T>> GetAll<T>(string tabla)
        {
            try
            {
                client = new HttpClient();
                var response = await client.GetAsync(url + tabla);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(jsonString);
                }
            }
            catch (Exception)
            {
                return default(List<T>);
            }
            return default(List<T>);
        }

        public async Task<T> Post<T>(string tabla, T obj)
        {
            try
            {
                client = new HttpClient();
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url + tabla, content);
                if (response.IsSuccessStatusCode)
                {
                    return obj;
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception)
            {
                return default(T);
                throw;
            }

        }
        public async Task<T> Put<T>(string tabla, T obj, string id)
        {

            try
            {
                client = new HttpClient();
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(url + tabla + "/" + id, content);
                return obj;
            }
            catch (Exception)
            {
                return default(T);
                throw;
            }
        }

        public async Task<bool> Delete(string table, string id)
        {
            try
            {
                client = new HttpClient();
                var response = await client.DeleteAsync(url + table + "/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
    }
}
