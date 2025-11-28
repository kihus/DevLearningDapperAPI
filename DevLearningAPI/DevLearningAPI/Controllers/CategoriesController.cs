using DevLearningAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLearningAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly CategoryService _service;

		public CategoriesController(CategoryService service)
		{
			_service = service;
		}
	}
}
