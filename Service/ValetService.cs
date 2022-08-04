using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Interview.Model;

namespace Interview
{
    public class ValetService : IValetService
    {
        private readonly HttpClient client;
        public ValetService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<ValetResponse> GetObervationsByDate(string startDate, string endDate)
        {
            try
            {
                // url can be retrieved from config instead of hard coding here.
                var url = $"/valet/observations/FXUSDCAD,AVG.INTWO?start_date={startDate}&end_date={endDate}";
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<ValetResponse>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}