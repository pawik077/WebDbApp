using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using WebApplication1.Data;
using WebApplication1.Models;
using RestSharp;
using Newtonsoft.Json.Linq;



namespace WebApplication1.Pages.WeatherPage
{
    public class CreateModel : PageModel
    {
    const string apiKey = "a4d7d088521a6fd7b655eec8dd00e43a";
    static JToken ApiDownload(string city) {
      string url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&units=metric&&appid=" + apiKey;
      RestClient client = new RestClient(url);
      RestRequest request = new RestRequest(Method.GET);
      IRestResponse response = client.Execute(request);
      if(!response.IsSuccessful) {
        throw new InvalidOperationException("Unknown city!!");
      }
      return JToken.Parse(response.Content);
    }
    private readonly WebApplication1.Data.WeatherDbContext _context;

        public CreateModel(WebApplication1.Data.WeatherDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Weather Weather { get; set;  }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            JToken json = ApiDownload(Weather.city);
            Weather.weather = json.SelectToken("weather[0].main").ToString();
            Weather.temperature = (float)json.SelectToken("main.temp");
            Weather.time = DateTime.Now;
            _context.WeatherData.Add(Weather);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
