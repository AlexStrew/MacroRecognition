using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RecognitionAPI
{
    public class RecognitionServer
    {
        
        public class DataItemm
        {

            public string EventId { get; set; }
            public string Timestamp { get; set; }
            public string BinaryTimestamp { get; set; }
            public string ZonedTimestamp { get; set; }
            public string EventDescription { get; set; }
            public string IsAlarmEvent { get; set; }
            public string ChannelId { get; set; }
            public string ChannelName { get; set; }
            public string Comment { get; set; }
            public string EventType { get; set; }
            public string InitiatorName { get; set; }
            public string IsIdentified { get; set; }
            public string plateText { get; set; }
            public string Speed { get; set; }
            public string Reliability { get; set; }
            public string Left { get; set; }
            public string Top { get; set; }
            public string lastName { get; set; }
            public string firstName { get; set; }
            public string patronymic { get; set; }
            public string carbrand { get; set; }
            public string carcolor { get; set; }
            public string additionalInfo { get; set; }
            public string groups { get; set; }
            public List<string> direction { get; set; }
            public string ExternalId { get; set; }
            public string ExternalOwnerId { get; set; }
            public string Width { get; set; }
            public string Height { get; set; }
            public string Numberplate { get; set; }

        }

        //public async static void GetReco()
        //{
        ////    var task = new Task(() => GetData());
        //    task.Start();
        //}

        //static async Task GetData()
        //{
        //    while (true)
        //    {
        //        string url = "http://192.168.0.197:8080/event?login=root&password=&filter=c9d6d086-c965-4cf8-aef6-85b3894e3a4a&responsetype=json";
        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //        try
        //        {
        //            using (WebResponse response = await request.GetResponseAsync())
        //            using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
        //            {
        //                using (var jsonReader = new JsonTextReader(rdr))
        //                {
        //                    while (!rdr.EndOfStream)
        //                    {
        //                        var str = rdr.ReadLine();
                                
        //                        File.AppendAllText("errors.log", str);
        //                    }
        //                    var jsonSerializer = new JsonSerializer();
        //                    var data = jsonSerializer.Deserialize<dynamic>(jsonReader);
        //                    var dataItemm = JsonConvert.DeserializeObject<DataItemm>(data.ToString());
        //                    if (dataItemm.EventId == "c9d6d086-c965-4cf8-aef6-85b3894e3a4a")
        //                    {
        //                       // Console.WriteLine("ok" + DateTime.Now);
        //                        using (SqlConnection connection = new SqlConnection("Data Source=SV-SQL-02\\SVSQL02;Initial Catalog=RecognitionDB;Integrated Security=True"))
        //                        {
        //                            await connection.OpenAsync();

        //                            // Вставка данных в таблицу
        //                            using (SqlCommand command = new SqlCommand(
        //                                    "INSERT INTO TruckDetection (EventId, Timestamp, BinaryTimestamp, ZonedTimestamp, EventDescription, IsAlarmEvent, ChannelId, ChannelName, Comment, EventType, InitiatorName, IsIdentified, plateText, Reliability, Numberplate) VALUES (@EventId, @Timestamp, @BinaryTimestamp, @ZonedTimestamp, @EventDescription, @IsAlarmEvent, @ChannelId, @ChannelName, @Comment, @EventType, @InitiatorName, @IsIdentified, @plateText, @Reliability, @Numberplate)", connection))
        //                            {
        //                                command.Parameters.AddWithValue("@EventId", dataItemm.EventId);
        //                                command.Parameters.AddWithValue("@Timestamp", dataItemm.Timestamp);
        //                                command.Parameters.AddWithValue("@BinaryTimestamp", dataItemm.BinaryTimestamp);
        //                                command.Parameters.AddWithValue("@ZonedTimestamp", dataItemm.ZonedTimestamp);
        //                                command.Parameters.AddWithValue("@EventDescription", dataItemm.EventDescription);
        //                                command.Parameters.AddWithValue("@IsAlarmEvent", dataItemm.IsAlarmEvent);
        //                                command.Parameters.AddWithValue("@ChannelId", dataItemm.ChannelId);
        //                                command.Parameters.AddWithValue("@ChannelName", dataItemm.ChannelName);
        //                                command.Parameters.AddWithValue("@Comment", dataItemm.Comment);
        //                                command.Parameters.AddWithValue("@EventType", dataItemm.EventType);
        //                                command.Parameters.AddWithValue("@InitiatorName", dataItemm.InitiatorName);
        //                                command.Parameters.AddWithValue("@IsIdentified", dataItemm.IsIdentified);
        //                                command.Parameters.AddWithValue("@plateText", dataItemm.plateText);
        //                                command.Parameters.AddWithValue("@Reliability", dataItemm.Reliability);
        //                                command.Parameters.AddWithValue("@Numberplate", dataItemm.Numberplate);
        //                                await command.ExecuteNonQueryAsync();
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        catch (HttpRequestException ex)
        //        {

        //            //Console.WriteLine($"{DateTime.Now} HTTP error: {ex.Message}");
        //            string errorMessage = $"{DateTime.Now} HTTP error: {ex.Message}\n";
        //            File.AppendAllText("errors.log", errorMessage);
        //        }
        //        catch (SqlException ex)
        //        {
        //            //Console.WriteLine($"{DateTime.Now} Database error: {ex.Message}");
        //            string errorMessage = $"{DateTime.Now} Database error: {ex.Message}\n";
        //            File.AppendAllText("errors.log", errorMessage);
        //        }
        //        catch (Exception ex)
        //        {
        //            //Console.WriteLine($"{DateTime.Now} An error occurred: {ex.Message}");
        //            var errorMessage = $"{DateTime.Now} An error occurred: {ex.Message}\n";
        //            File.AppendAllText("errors.log", errorMessage);
        //        }
        //    }
        //}
    }
}
