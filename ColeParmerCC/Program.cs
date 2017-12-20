using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using Interview.Problem1.Domain;

namespace ColeParmerCC
{
    class Program
    {

        private
        static void Main(string[] args)
        {
            //reads in Json file
            var jsonFileData = File.ReadAllText(@"C:\Users\carl gramata\source\repos\ColeParmerCC\ColeParmerCC\Data\tripdata.json");

            //deserializes json and creates a TripVm object
            var list = JsonConvert.DeserializeObject<TripVm>(jsonFileData);

            var listOfEvents = list.TripUploadEvents.OrderBy(entry => entry.Timestamp).ToList();
            var listOfData = list.TripUploadData.OrderBy(entry => entry.Timestamp).ToList();
            var listOfSensorSettings = list.TripSettings;

            List<string> listOfSensorsFromEvents = new List<string>();

            //quries for:
            //data entry channel == sensor2 AND (entry Data is greater than the sensor2 Max)
            //not enough filter, need to query data to find the exit and entry points of temperature
            List<DeviceDataVm> listOfQueriedData = (from listEntry in listOfData
                                         where listEntry.Channel.Equals(listOfEvents[0].Channel) && (listEntry.Data > listOfSensorSettings[1].Max) 
                                         select listEntry).ToList<DeviceDataVm>();


            //limited function in calculating the time spent in alarm in event
            TimeSpan timeDifferenceEvent = new TimeSpan();
            for (int entry = 1; entry < listOfEvents.Count; entry++)
            {
                timeDifferenceEvent += listOfEvents[entry].Timestamp - listOfEvents[entry - 1].Timestamp;
            }


            //incorrectly calculates the time spent in alarm in the data list
            TimeSpan timeDifferenceData = new TimeSpan();
            for (int entry = 1; entry < listOfQueriedData.Count; entry++)
            {
                timeDifferenceData += listOfQueriedData[entry].Timestamp - listOfQueriedData[entry - 1].Timestamp;
            }

            Console.WriteLine("Time spent in alarm via Events list is: " + timeDifferenceEvent);
            Console.WriteLine("Time spent in alarm via Data list is: " + timeDifferenceData);
        }
    }
}
