using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientWeb
{
    internal class EmployeeAPIClient
    {
        static Uri uri = new Uri("http://localhost:5231/api/Employee/");
        public static async Task CallGetEmployee()
        {
          using(var client = new HttpClient()) { 
                client.BaseAddress = uri;
                HttpResponseMessage response = await client.GetAsync("GetEmployee");
                response.EnsureSuccessStatusCode();
                if(response.IsSuccessStatusCode)
                {
                    String x=await response.Content.ReadAsStringAsync();
                    await Console.Out.WriteLineAsync(x);
                }
            }

        }
        public static async Task CallGetEmployeeObj()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                List<EmpViewModel> employees = new List<EmpViewModel>();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage response = await client.GetAsync("GetEmployee");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    employees =JsonConvert.DeserializeObject<List<EmpViewModel>>(json); 
                    
                    foreach(var emp in employees)
                    {
                        await Console.Out.WriteLineAsync($"{emp.EmpId},{emp.FirstName},{emp.LastName},{emp.Title},{emp.City},{emp.HireDate},{emp.BirthDate},{emp.ReportTo}");
                    }
                  
                }
            }

        }
       
    }
}
