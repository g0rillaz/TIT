using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace FillTheDBWithData
{
    class APIInteraction
    {


        /// <summary>
        //Get all StationIds
        /// 
        /// </summary>
        public List<string> getAllStations()
        {
            List<string> allStationIds = new List<string>();
            allStationIds.Add("10637");

            return allStationIds;
        }

        public void getData(string startDate, string endDate ) 
        {
            List<string> allStationIds = getAllStations();

            List<WebRequest> requestForeachStation = new List<WebRequest>();

            //create a request foreach StationId and store the request to requestForeachStation list
            foreach (string stationID in allStationIds)
            {
                string url = "https://api.meteostat.net/v1/history/daily?station=" + stationID + "&start="+ startDate + "&end="+endDate+"&key=GF2pp1rP";
                WebRequest request = WebRequest.Create(url);

                requestForeachStation.Add(request);
            }

         


            for (var i = 0; i < requestForeachStation.Count; i++)
            {
                WebResponse response = requestForeachStation[i].GetResponse();

                if(((HttpWebResponse)response).StatusDescription == "OK")
                {

                    Console.WriteLine("ok");
                    Console.ReadKey();
                    

                    //create an object with the response data an their stationid
                    //SqlDatasetDaily sqlDatasetDaily = new SqlDatasetDaily()
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        //Console.WriteLine(dataStream);

                        StreamReader reader = new StreamReader(dataStream);
                        string responseFromServer = reader.ReadToEnd();

                        //JObject jObject = JObject.Parse(json);
                        //Console.WriteLine(responseFromServer);
                        //List<SqlDatasetDaily> obj = JsonConvert.DeserializeObject<List<SqlDatasetDaily>>(responseFromServer);
                        //string[] words = responseFromServer.Split(new[] { "data" }, StringSplitOptions.None);
                        //Console.WriteLine(words[1]);
                        //Console.WriteLine(words);
                        // Deserializing json data to object  
                        string json = @"{  
                          'id': 'C-sharpcorner',  
                        },
                        {  
                          'id': 'C-sharpcorner2',  
                        }";
                        //String[] a = new String[5];
                        Error[] bsObj  = JsonConvert.DeserializeObject<Error[]>(json);
                        Console.WriteLine("________");
                        Console.WriteLine(bsObj[0].id);



                        Console.ReadKey();
                    }

                    // Close the response.  
                    response.Close();

                }
            }


            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            //using (Stream dataStream = response.GetResponseStream())
            //{
            //    // Open the stream using a StreamReader for easy access.  
            //    StreamReader reader = new StreamReader(dataStream);
            //    // Read the content.  
            //    string responseFromServer = reader.ReadToEnd();
            //    // Display the content.  

            //    //JObject jObject = JObject.Parse(json);
            //    Console.WriteLine(responseFromServer);
            //    Console.ReadKey();
            //}

            //// Close the response.  
            //response.Close();
        }
    }
}
