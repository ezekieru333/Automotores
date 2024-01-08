using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Automotores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividuoController : ControllerBase
    {

        private IValidator<IndividuoInsertValidator> _individuoInsertValidator;
        private IValidator<IndividuoUpdateValidator> _individuoUpdateValidator;
        private ICommonService<IndividuoDto, IndividuoInsertDto, IndividuoUpdateDto> _individuoService;
    }
}
