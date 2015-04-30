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

		//[HttpPost]
		//public virtual ActionResult Index(HomeViewModel homeViewModel)
		//{
		//	var model = new HomeViewModel();

		//	if(this.ModelState.IsValid)
		//		this.ModelState.Clear();
		//	else
		//		model = homeViewModel;

		//	return this.View(model);
		//}
		[HttpPost]
		public virtual ActionResult Index(TestForm subForm)
		{
			var model = new HomeViewModel();

			if(this.ModelState.IsValid)
				this.ModelState.Clear();
			else
				model.SubForm = subForm;

			return this.View(model);
		}

		#endregion
	}
}