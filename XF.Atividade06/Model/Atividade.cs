using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XF.Atividade06.Util;

namespace XF.Atividade06.Model
{
    public class Atividade
    {
        public int Id { get; set; }
        public string DataCadastro { get; set; }
        public string DataEntrega { get; set; }
        public bool TipoAvaliacao { get; set; }
        public string Descricao { get; set; }
        public int Nota { get; set; }
    }

    public static class AtividadeRepository
    {
        private static IEnumerable<Atividade> atividadesSqlAzure;

        public static async Task<ObservableCollection<Atividade>> GetAtividadesSqlAzureAsync()
        {
            var httpRequest = new HttpClient();
            var stream = await httpRequest.GetStreamAsync(
                "http://xffiap.azurewebsites.net/api/Atividades");

            var atividadeSerializer = new DataContractJsonSerializer(typeof(List<Atividade>));
            atividadesSqlAzure = (List<Atividade>)atividadeSerializer.ReadObject(stream);

            return new ObservableCollection<Atividade>(atividadesSqlAzure);
        }

        public static async Task<bool> PostAtividadeSqlAzureAsync(Atividade atividadeAdd)
        {
            if (atividadeAdd == null) return false;

            var httpRequest = new HttpClient();
            httpRequest.BaseAddress = new Uri("http://xffiap.azurewebsites.net/");
            httpRequest.DefaultRequestHeaders.Accept.Clear();
            httpRequest.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string ativJson = Newtonsoft.Json.JsonConvert.SerializeObject(atividadeAdd);
            var response = await httpRequest.PostAsync("api/Atividades",
                new StringContent(ativJson, System.Text.Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode) return true;

            return false;
        }

        public static async Task<bool> DeleteAtividadeSqlAzureAsync(string ativId)
        {
            if (string.IsNullOrWhiteSpace(ativId)) return false;

            var httpRequest = new HttpClient();
            httpRequest.BaseAddress = new Uri("http://xffiap.azurewebsites.net/");
            httpRequest.DefaultRequestHeaders.Accept.Clear();
            httpRequest.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpRequest.DeleteAsync(string.Format("api/Atividades/{id}", ativId));

            if (response.IsSuccessStatusCode) return true;

            return false;
        }
    }
}
