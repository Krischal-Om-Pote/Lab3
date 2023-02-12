using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using ApexRestaurant.Mvc.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
public class CustomerController : Controller
{
    private string baseUri;
    public CustomerController(IConfiguration iConfig)
    {
        // Get baseUri of Web API from appsettings.json > ApiBaseUrl
        baseUri = iConfig.GetValue<string>("ApiBaseUrl");
    }
    // GET: Customer
    public ActionResult Index()
    {
        IEnumerable<CustomerViewModel> customers = null;
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(baseUri);
            client.DefaultRequestHeaders.Add("accept", "application/json");
            var responseTask = client.GetAsync("api/customer");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var apiResponse = result.Content.ReadAsStringAsync();
                apiResponse.Wait();
                customers = JsonConvert.DeserializeObject<IList<CustomerViewModel>>(apiResponse.Result);
            }
            else //web api sent error response
            {
                customers = Enumerable.Empty<CustomerViewModel>();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
        }
        return View(customers);
    }
    public ActionResult Create()

    {
        return View();
    }
    [HttpPost]
    public ActionResult Create(CustomerViewModel customer)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:64189/api/student"); //HTTP POST var postTask = client.PostAsJsonAsync<StudentViewModel>("student", student); postTask.Wait(); var result = postTask.Result; if (result.IsSuccessStatusCode) { return RedirectToAction("Index"); } } ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator."); return View(student); }


        }
    }
    public ActionResult Edit(int id)
    {
        StudentViewModel student = null; using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:64189/api/"); //HTTP GET var responseTask = client.GetAsync("student?id=" + id.ToString()); responseTask.Wait(); var result = responseTask.Result; if (result.IsSuccessStatusCode) { var readTask = result.Content.ReadAsAsync<StudentViewModel>(); readTask.Wait(); student = readTask.Result; } } return View(student); } [HttpPost] public ActionResult Edit(StudentViewModel student) { using (var client = new HttpClient()) { client.BaseAddress = new Uri("http://localhost:64189/api/student"); //HTTP POST var putTask = client.PutAsJsonAsync<StudentViewModel>("student", student); putTask.Wait(); var result = putTask.Result; if (result.IsSuccessStatusCode) { return RedirectToAction("Index"); } } return View(student); }
        }
    }
    public ActionResult Delete(int id)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:5000/api/"); //HTTP DELETE var deleteTask = client.DeleteAsync("student/" + id.ToString()); deleteTask.Wait(); var result = deleteTask.Result; if (result.IsSuccessStatusCode) { return RedirectToAction("Index"); } } return RedirectToAction("Index"); }
        }
    }
}