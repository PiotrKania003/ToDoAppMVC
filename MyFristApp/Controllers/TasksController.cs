using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFristApp.Data;
using MyFristApp.Models;

namespace MyFristApp.Controllers
{
	public class TasksController : Controller
	{
		private readonly MyAppContext _appContext;

		public TasksController(MyAppContext appContext)
		{
			_appContext = appContext;
		}
		public async Task<IActionResult> Index()
		{

			var task = await _appContext.Tasks.ToListAsync();

			return View(task);
		}

		public IActionResult Create() 
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Id, Name, Description, ClassName, Deadline, IsCompleted")] TaskViewModel Task)
		{
			if(ModelState.IsValid)
			{
				_appContext.Tasks.Add(Task);
				await _appContext.SaveChangesAsync();
				return RedirectToAction("Index");
			}

			return View(Task);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var task = await _appContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
			return View(task);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Description, ClassName, Deadline, IsCompleted")] TaskViewModel Task)
		{
			if (ModelState.IsValid)
			{
				_appContext.Update(Task);
				await _appContext.SaveChangesAsync();
				return RedirectToAction("Index");
			}

			return View(Task);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var task = await _appContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);

			return View(task);
		}

		[HttpPost]
		public async Task<IActionResult> Deleted(int id)
		{
			var task = await _appContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
			if (task != null) 
			{
				_appContext.Tasks.Remove(task);
				await _appContext.SaveChangesAsync();
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Finished(int id)
		{
			var task = await _appContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);

			if (task != null)
			{
				task.IsCompleted = true;
				_appContext.Update(task);
				await _appContext.SaveChangesAsync();
			}
			
			return RedirectToAction("Finished");
		}
	}
}
