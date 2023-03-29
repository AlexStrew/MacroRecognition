using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;

namespace RecognitionAPI {
    public class CloneDamaskTable {
        public static void GetUpdate() {
            string connectionString = @"Server=hv-sql;Database=RecognitionDB;Persist Security Info=False;user=api-user;Password=QFgQJkWi4t;TrustServerCertificate=True";

            string commandText = "MERGE DamaskTable t \r\n USING DAMASK_S1.damask.[public].link_oss s\r\nON (s.id = t.id)\r\n\r\nWHEN NOT MATCHED BY TARGET \r\n    THEN INSERT (id, arrival_time, departure_time, truck_number, truck_id, reg_time, begin_service_time, last_begin_service_time, end_service_time, ticket_id, ticket_text)\r\n         VALUES (s.id, s.arrival_time, s.departure_time, s.truck_number, s.truck_id, s.reg_time, s.begin_service_time, s.last_begin_service_time, s.end_service_time, s.ticket_id, s.ticket_text);";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(commandText, conn)) {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            
        }
    }
}
