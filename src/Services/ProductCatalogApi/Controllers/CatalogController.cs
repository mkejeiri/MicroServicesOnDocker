using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProductCatalogApi.Domain.Repository;

namespace ProductCatalogApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IOptionsSnapshot<AppSettings> _settings;

        public CatalogController(ICatalogRepository catalogRepository, IOptionsSnapshot<AppSettings> settings)
        {
            _catalogRepository = catalogRepository;
            _settings = settings;
            //string externalBaseUrl = _settings.Value.ExternalBaseUrl;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Types() => Ok(await _catalogRepository.GetCatalogTypes());

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items() => Ok(await _catalogRepository.GetCatalogItems());
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Brands() => Ok(await _catalogRepository.GetCatalogBrands());
    }
}