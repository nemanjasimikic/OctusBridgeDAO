using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OctusBridgeDAO.Models;
using System.Text;

namespace OctusBridgeDAO.Controllers
{
#pragma warning disable CS1591
    [Route("proposals")]
    [ApiController]
    public class ProposalsController : ControllerBase
    {

        private readonly HttpClient _httpClient = new HttpClient();
        private readonly IConfiguration _configuration;
        public ProposalsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// Get proposals overview.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("overview")]
        public async Task<IActionResult> Overview()
        {
            try
            {
                var baseUrl = _configuration["BaseUrl"];
                string apiEndpoint = ConstructRightUrl(baseUrl, $"proposals/overview");
                var response = await _httpClient.GetAsync(apiEndpoint);
                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<ProposalsOverviewModel>(responseStream);
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get proposals data.
        /// </summary>
        /// <param name="model">Proposals Search Model</param>
        /// <returns></returns>
        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> Search([FromBody] ProposalsSearchModel model)
        {
            try
            {
                var baseUrl = _configuration["BaseUrl"];
                string json = System.Text.Json.JsonSerializer.Serialize(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                string apiEndpoint = ConstructRightUrl(baseUrl, $"proposals/search");
                HttpResponseMessage response = await _httpClient.PostAsync(apiEndpoint, data);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProposalsSearchResponseModel>(jsonResponse);
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
