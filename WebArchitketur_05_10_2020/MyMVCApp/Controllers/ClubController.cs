using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


using MyDomain.Entities;
using Newtonsoft.Json;

namespace MyMVCApp.Controllers
{
    public class ClubController : Controller
    {

        string baseAddress = "https://localhost:44354/api/Clubs/";
        public ClubController()
        {
            
        }

        // GET: Club
        public async Task<IActionResult> Index()
        {
            IList<Clubs> resultList = new List<Clubs>();

            HttpClient client = new HttpClient();

            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, baseAddress);
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.SendAsync(message);
            string jsonText = await response.Content.ReadAsStringAsync();

            resultList = JsonConvert.DeserializeObject<List<Clubs>>(jsonText);

            return View(resultList);
        }

        // GET: Club/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clubs clubs = null;
            string url = baseAddress + id.ToString();

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url);
                string jsonTxt = await response.Result.Content.ReadAsStringAsync();
                clubs = JsonConvert.DeserializeObject<Clubs>(jsonTxt);
            }

            if (clubs == null)
            {
                return NotFound();
            }

            return View(clubs);
        }

        // GET: Club/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Club/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FoundingYear,TransferBudget,ArenaCapacity,ArenaName")] Clubs clubs)
        {
            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(clubs);

                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    var response = client.PostAsync(baseAddress, data);

                    string result = await response.Result.Content.ReadAsStringAsync();

                }


                return RedirectToAction(nameof(Index));
            }
            return View(clubs);
        }

        // GET: Club/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clubs clubs = null;
            string url = baseAddress + id.ToString();

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url);
                string jsonTxt = await response.Result.Content.ReadAsStringAsync();
                clubs = JsonConvert.DeserializeObject<Clubs>(jsonTxt);
            }

            if (clubs == null)
            {
                return NotFound();
            }
            return View(clubs);
        }

        // POST: Club/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FoundingYear,TransferBudget,ArenaCapacity,ArenaName")] Clubs clubs)
        {
            if (id != clubs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    string url = baseAddress + id.ToString();

                    var json = JsonConvert.SerializeObject(clubs);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.PutAsync(url, data);

                        string result = await response.Content.ReadAsStringAsync(); //Erwarte ein 200er Ergebnis
                    }


                }
                catch (Exception)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clubs);
        }

        // GET: Club/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clubs clubs = null;
            string url = baseAddress + id.ToString();

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url);
                string jsonTxt = await response.Result.Content.ReadAsStringAsync();
                clubs = JsonConvert.DeserializeObject<Clubs>(jsonTxt);
            }

            if (clubs == null)
            {
                return NotFound();
            }

            return View(clubs);
        }

        // POST: Club/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            string url = baseAddress + id.ToString();

            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(url);


                string result = await response.Content.ReadAsStringAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        
    }
}
