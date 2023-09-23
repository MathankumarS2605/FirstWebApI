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
            using (var client = new HttpClient()) {
                client.BaseAddress = uri;
                HttpResponseMessage response = await client.GetAsync("GetEmployee");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    String x = await response.Content.ReadAsStringAsync();
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
                    employees = JsonConvert.DeserializeObject<List<EmpViewModel>>(json);

                    foreach (var emp in employees)
                    {
                        await Console.Out.WriteLineAsync($"{emp.EmpId},{emp.FirstName},{emp.LastName},{emp.Title},{emp.City},{emp.HireDate},{emp.BirthDate},{emp.ReportTo}");
                    }

                }
            }

        }

        public static async Task AddnewEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                EmpViewModel empViewModel = new EmpViewModel();
                //empViewModel.EmpId = 18;
                empViewModel.FirstName = "Test";
                empViewModel.LastName = "Kumar";
                empViewModel.BirthDate = DateTime.Now;
                empViewModel.HireDate = DateTime.Now;
                empViewModel.Title = "Test";
                //empViewModel.ReportTo = 1;
                empViewModel.City = "Thanjavur";
                string myContent = JsonConvert.SerializeObject(empViewModel);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage httpResponseMessage = await client.PostAsync("AddEmployee", byteContent);
                httpResponseMessage.EnsureSuccessStatusCode();
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    await Console.Out.WriteLineAsync(httpResponseMessage.StatusCode.ToString());
                }
            }
        }

        public static async Task UpdateEmployee() {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                EmpViewModel empViewModel = new EmpViewModel();
                Console.WriteLine("Enter the id to be modified");
                string temp = Console.ReadLine();
                int id = int.Parse(temp);
                empViewModel.EmpId = id;
                empViewModel.FirstName = "Ram";
                empViewModel.LastName = "Kumar";
                empViewModel.BirthDate = DateTime.Now;
                empViewModel.HireDate = DateTime.Now;
                empViewModel.Title = "Test";
                //empViewModel.ReportTo = 1;
                empViewModel.City = "Thanjavur";
                var json = JsonConvert.SerializeObject(empViewModel);
                var bytes = Encoding.UTF8.GetBytes(json);
                var byteHttpContent = new ByteArrayContent(bytes);
                byteHttpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage responseMessage = await client.PutAsync("ModifyEmployee", byteHttpContent);
                responseMessage.EnsureSuccessStatusCode();
                if (responseMessage.IsSuccessStatusCode) {
                    await Console.Out.WriteLineAsync($"{responseMessage.StatusCode.ToString()}");
                }
            }

        }

        public static async Task DeleteTask()
        {
            
            using(var client = new HttpClient() ) { 
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Console.WriteLine("Enter the id to be Deleted");
                string temp = Console.ReadLine();
                int id = int.Parse(temp);
 
                var json= JsonConvert.SerializeObject(id);
                var bytes= Encoding.UTF8.GetBytes(json);    
                var byteHttpClient= new ByteArrayContent(bytes);
                byteHttpClient.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var Uri = uri + $"DeleteEmployee?id={id}";
                HttpResponseMessage response = await client.DeleteAsync(Uri);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteLineAsync($"{response.StatusCode.ToString()}");
                }

            }
        }


    }
}
