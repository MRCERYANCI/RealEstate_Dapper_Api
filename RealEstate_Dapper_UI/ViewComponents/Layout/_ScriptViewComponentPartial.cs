﻿using Microsoft.AspNetCore.Mvc;
namespace RealEstate_Dapper_UI.ViewComponents.Layout
{
	public class _ScriptViewComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
