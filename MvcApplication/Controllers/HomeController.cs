using System.Web.Mvc;
using MvcApplication.Models.Forms;
using MvcApplication.Models.ViewModels;

namespace MvcApplication.Controllers
{
	public class HomeController : Controller
	{
		#region Methods

		public virtual ActionResult Index()
		{
			return this.View(new HomeViewModel());
		}

		[HttpPost]
		public virtual ActionResult Index(HomeViewModel model)
		{
			return this.View(model);
		}

		[HttpPost]
		public virtual ActionResult Index(TestForm model)
		{
			return this.View(new HomeViewModel {SubForm = model});
		}

		#endregion
	}
}