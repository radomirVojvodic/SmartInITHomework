using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;
using System.Net;

namespace ToDoList.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Index()
        {
            var tasks = GetTasks();

            if (tasks != null)
            {
                return View(tasks);
            }
            return HttpNotFound();
                }

        //GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var tasks = GetTasks();
            var task = tasks.SingleOrDefault(c => c.TaskID == id);
            if(task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Done,TaskID,Title,TaskMade,DueDate,TaskPriority")] Task redefTask)
        {
            if (ModelState.IsValid)
            {
                List<Task> taskList = GetTasks();
                Task task = taskList.SingleOrDefault(c => c.TaskID == redefTask.TaskID);
                taskList.Remove(task);
                taskList.Add(redefTask);
                RefreshList(taskList);
                return RedirectToAction("Index");

            }


            return View(redefTask);
        }

        //GET: Tasks/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Task task = GetTasks().SingleOrDefault(c => c.TaskID == id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        //POST: Tasks/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Task> taskList = GetTasks();
            Task task = taskList.SingleOrDefault(c => c.TaskID == id);
            taskList.Remove(task);
            RefreshList(taskList);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if( id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tasks = GetTasks();
            var task = tasks.SingleOrDefault(c => c.TaskID == id);
            if(task == null)
            {
                return HttpNotFound();
            }

            return View(task);
        }
          

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                AddTask(task);
                return RedirectToAction("Index");
            }

            return View(task);
        }

        private List<Task> GetTasks()
        {
            //ovi podaci se cuvaju u App_Data folderu kod naseg projekta
            string filePath = Server.MapPath(@"~/App_Data/Tasks.json");
            string jsonFromFile = System.IO.File.ReadAllText(filePath);
            List<Task> listOfTasks = JsonConvert.DeserializeObject<List<Task>>(jsonFromFile);

            return listOfTasks;
        }

        private void AddTask(Task task)
        {
            var tasks = GetTasks();
            task.TaskID = tasks.Count();
            tasks.Add(task);

            string jsonString = JsonConvert.SerializeObject(tasks, Formatting.Indented);

            string filePath = Server.MapPath(@"~/App_Data/Tasks.json");
            System.IO.File.WriteAllText(filePath, jsonString);
        }

        public void RefreshList(List<Task> taskList)
        {
            System.IO.File.WriteAllText(Server.MapPath(@"~/App_Data/Tasks.json"), "");
            string jsonToFile = JsonConvert.SerializeObject(taskList, Formatting.Indented);
            System.IO.File.WriteAllText(Server.MapPath(@"~/App_Data/Tasks.json"), jsonToFile);
        }
    }
}