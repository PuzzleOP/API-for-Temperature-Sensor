using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Arduino;

namespace WebAPICSharpDemo.Controllers
{
    public class WeatherController : ApiController
    {
        // GET: api/Weather
        Database db = new Database();
        public List<string> Get()
        {
            return ArduinoSensorClass.readTemperatureSensor();
        }

        // GET: api/Weather/5
        //public string Get(int id)
        //{
        //    return ArduinoSensorClass.readTemperatureSensor().ElementAt(id);
        //}

        public List<string> Get(int id)
        {
            //day = day.ToLower();
            return db.GetWeatherForDay(id);
        }

        // POST: api/Weather
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Weather/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Weather/5
        public void Delete(int id)
        {
        }
    }
}
