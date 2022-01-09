using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NotesApp.Data.Models;
using NotesApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace NotesApp.Web.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {

        const string baseServiceurl = "https://localhost:44356/";

        public async Task<ActionResult> Index()
        {
            IEnumerable<NoteViewModel> notes = new List<NoteViewModel>();
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseServiceurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource
                HttpResponseMessage res = await client.GetAsync($"api/Notes/GetAllNotesforUser/{id}");

                //if (!res.IsSuccessStatusCode)
                //{
                //}

               //Storing the response details recieved from web api
                var response = res.Content.ReadAsStringAsync().Result;


                //Deserializing the response recieved from web api 
                notes = JsonConvert.DeserializeObject<List<Note>>(response).Select(x => new NoteViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Content = x.Content
                });
            }

            return View(notes);

        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new NoteCreateModel();

            return View(model);
        }

        [HttpPost] 
        public async Task<IActionResult> Create(NoteCreateModel model)
        {
            var note = new Note
            {
                Title = model.Title,
                Description = model.Description,
                Content = model.Content,
                DateCreated = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseServiceurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource
                HttpResponseMessage res = await client.PostAsJsonAsync("api/Notes", note);

                if (res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var response = res.Content.ReadAsStringAsync().Result;
                    return RedirectToAction("Index");
                }
                else
                {
                    //TempData["error"] = $"Error from post request - status code - {res.StatusCode} ";
                    return NoContent();
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseServiceurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource
                HttpResponseMessage res = await client.GetAsync($"api/Notes/{id}");

                if (res.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<Note>(res.Content.ReadAsStringAsync().Result);

                    //Storing the response details recieved from web api
                    if (result != null)
                    {
                        var model = new NoteDetailsModel
                        {
                            Title = result.Title,
                            Description = result.Description,
                            Content = result.Content
                        };

                        return View(model);
                    }
                }

                return NotFound();
            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseServiceurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource
                HttpResponseMessage res = await client.DeleteAsync($"api/Notes/{id}");

                if(!res.IsSuccessStatusCode)
                {
                    RedirectToAction("Error");
                }
            } 

            return RedirectToAction("Index");
        }
 
        public async Task<IActionResult> Search(SearchModel srcModel)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<NoteViewModel> notes = new List<NoteViewModel>();

            if (srcModel.SearchText == null) srcModel.SearchText = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseServiceurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource
                HttpResponseMessage res = await client.GetAsync($"api/Notes/{srcModel.SearchText}/{userId}");

                var response = res.Content.ReadAsStringAsync().Result;
                 

                notes = JsonConvert.DeserializeObject<List<Note>>(response).Select(x => new NoteViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Content = x.Content
                });

                var model = new SearchModel
                {
                    Id = userId,
                    SearchText = "",
                    SearchResult = notes
                };

                return View(model);
            }  
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        { 
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseServiceurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource
                HttpResponseMessage res = await client.GetAsync($"api/Notes/{id}");

                if (res.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<Note>(res.Content.ReadAsStringAsync().Result);

                    //Storing the response details recieved from web api
                    if (result != null)
                    {
                        var model = new NoteEditModel
                        {
                            Title = result.Title,
                            Description = result.Description,
                            Content = result.Content
                        };
                         
                        return View(model);

                    }
                }

            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NoteEditModel model)
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Note note = new Note();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseServiceurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync($"api/Notes/{model.Id}");

                var result = JsonConvert.DeserializeObject<Note>(res.Content.ReadAsStringAsync().Result);

                //Storing the response details recieved from web api
                if (result != null)
                {
                    note.Id = result.Id;  
                    note.Title = result.Title;
                    note.Description = result.Description;
                    note.Content = result.Content;
                    note.User = result.User;
                    note.UserId = result.UserId;
                    note.DateCreated = result.DateCreated;
                    note.LastModified = DateTime.UtcNow;
                }
            } 

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseServiceurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource
                HttpResponseMessage res = await client.PutAsJsonAsync($"api/Notes/{model.Id}", note);

                if(!res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Error");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
