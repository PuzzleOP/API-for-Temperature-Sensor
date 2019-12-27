using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Arduino
{
    public class ArduinoSensorClass
    {
        static SerialPort port = new SerialPort();

        static void Main(string[] args)
        {
            //...
        }
        public static List<string> readTemperatureSensor()
        {
            port.BaudRate = 9600;
            port.PortName = "COM3";
            port.Open();

            List<string> measurements = new List<string>();

            measurements.Add(port.ReadLine());
            measurements.Add(port.ReadLine());
            
            port.Close();

            CheckForUpdate(measurements);

            return measurements;
        }

        public static void CheckForUpdate(List<string> values)
        {
            if(DateTime.Now.Hour == 18 && DateTime.Now.Minute == 00)
            {
                Database.UpdateDatabase(values);
            }
        }
    }
}
