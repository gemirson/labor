using labor.Application.Command.Brands.Changess;
using labor.Application.Command.Brands.Delete;
using labor.Application.Command.Brands.Register;
using labor.Application.Command.Brands.Result;
using labor.Application.Queries.Brands;
using labor.Application.ViewModel;
using labor.Domain.Notifications;
using labor.Web.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace labor.Web.Controllers
{
    [Route("api/v1/brand")]
    public class BrandController : Controller
    {
        private readonly IBrandRegister _brandRegister;
        private readonly IBrandChange _brandChanges;
        private readonly IBrandDelete _brandDelete;
        private readonly NotificationContext _notificationContext;
        private readonly IBrandQueries _brandQueries;

        public BrandController(IBrandRegister brandRegister, IBrandChange brandChanges, IBrandDelete brandDelete, NotificationContext notificationContext, IBrandQueries brandQueries)
        {
            _brandRegister = brandRegister;
            _brandChanges = brandChanges;
            _brandDelete = brandDelete;
            _notificationContext = notificationContext;
            _brandQueries = brandQueries;
        }

        [HttpGet("{Id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> FindAsync(int Id)
        {
            var result = await _brandQueries.Get(Id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("brand")]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> BrandAllAsync()
        {
            var result = await _brandQueries.GetAll();

            if ((result.Count == 0) | (result == null)) return NotFound();

            return Ok(result);
        }


        [HttpPost]
        [Route("brand/Register")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> RegisterAsync([FromBody] BrandRequest brandRequest)
        {
            var result = await _brandRegister.Handler(new BrandViewModel { Name = brandRequest.Name }, _notificationContext);

            if (result == null) return UnprocessableEntity();

            return Created("",result);
        }

        [HttpPut("{Id}")]
        [Route("brand/Changes")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> BrandChangesAsync(int Id ,[FromBody] BrandRequest brandRequest)
        {
            return Ok(await _brandChanges.Handler(new BrandViewModel { Id = Id, Name = brandRequest.Name }, _notificationContext));
        }

        [HttpDelete("{Id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BrandResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> BrandDeleteAsync(int Id)
        {
            var result = await _brandDelete.Handler(Id);

            if (result == 0) return NotFound();

            return Ok(result);
        }


        
    }
}