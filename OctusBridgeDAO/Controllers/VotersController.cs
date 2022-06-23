using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OctusBridgeDAO.Models;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OctusBridgeDAO.Controllers
{
#pragma warning disable CS1591
    [Route("voters")]
    [ApiController]
    public class VotersController : ControllerBase
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly IConfiguration _configuration;
        public VotersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Get proposals with votes data.
        /// </summary>
        /// <param name="voter">Voter</param>
        /// <param name="model">VotersSearchModel</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{voter}/search")]
        public async Task<IActionResult> Search([Required] string voter, [FromBody] VotersSearchModel model)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var baseUrl = _configuration["BaseUrl"];
                string apiEndpoint = ConstructRightUrl(baseUrl, $"voters/{voter}/search");
                HttpResponseMessage response = await _httpClient.PostAsync(apiEndpoint, data);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<VotersSearchResponseModel>(jsonResponse);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get proposals counts.
        /// </summary>
        /// <param name="model">VotersModel</param>
        /// <returns></returns>
        [HttpPost]
        [Route("proposals/count")]
        public async Task<IActionResult> Count([FromBody] VotersModel model)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var baseUrl = _configuration["BaseUrl"];
                string apiEndpoint = ConstructRightUrl(baseUrl, $"voters/proposals/count");
                HttpResponseMessage response = await _httpClient.PostAsync(apiEndpoint, data);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<VotersProposalsCountResponseModel>>(jsonResponse);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get proposals count.
        /// </summary>
        /// <param name="model">VotersProposalsCountSearchModel</param>
        /// <returns></returns>
        [HttpPost]
        [Route("proposals/count/search")]
        public async Task<IActionResult> CountSearch([FromBody] VotersProposalsCountSearchModel model)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var baseUrl = _configuration["BaseUrl"];
                string apiEndpoint = ConstructRightUrl(baseUrl, $"voters/proposals/count/search");
                HttpResponseMessage response = await _httpClient.PostAsync(apiEndpoint, data);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<VotersProposalsCountResponseModel>>(jsonResponse);
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
