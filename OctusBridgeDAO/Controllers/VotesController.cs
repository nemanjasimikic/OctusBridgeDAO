﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OctusBridgeDAO.Models;
using System.Text;

namespace OctusBridgeDAO.Controllers
{
#pragma warning disable CS1591
    [Route("votes")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly IConfiguration _configuration;
        public VotesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Get votes data.
        /// </summary>
        /// <param name="model">VotesSearchModel</param>
        /// <returns></returns>
        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> Search([FromBody] VotesSearchModel model)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var baseUrl = _configuration["BaseUrl"];
                string apiEndpoint = ConstructRightUrl(baseUrl, $"votes/search");
                HttpResponseMessage response = await _httpClient.PostAsync(apiEndpoint, data);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<VoteSearchResponseModel>(jsonResponse);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #region Helper
        private string ConstructRightUrl(string environment, string apiPathSuffix)
        {
            return environment + "/" + apiPathSuffix;
        }
        #endregion
    }
}
