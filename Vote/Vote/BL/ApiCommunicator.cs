using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Vote.Model;

namespace Vote.BL
{
    public class ApiCommunicator
    {
        private readonly HttpClient _client;

        public ApiCommunicator()
        {
            _client = new HttpClient { BaseAddress = new Uri("http://80.211.151.64:45675") };
        }

        public async Task<bool> SendVote(Model.Vote vote)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(vote));
                var response = await _client.PostAsync("/votes", content);
                var json = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> NewCandidate(Model.Candidate candidate)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(candidate));
                var response = await _client.PostAsync("/candidates", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<bool> NewPsi(Model.District district)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(district));
                var response = await _client.PostAsync("/districts", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Candidate>> GetCandidates()
        {
            try
            {
                var response = await _client.GetAsync("/candidates");
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Candidate>>(json);  
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ObservableCollection<Model.District>> GetDistrict()
        {
            try
            {
                var response = await _client.GetAsync("/districts");
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ObservableCollection<Model.District>>(json);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
