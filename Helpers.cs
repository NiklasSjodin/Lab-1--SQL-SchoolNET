using Microsoft.Data.SqlClient;

internal class Helpers
{
    internal static void DisplayClasses(SqlConnection connection)
    {
        string query = "SELECT * FROM Classes";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int classID = Convert.ToInt32(reader["ClassID"]);
                    string className = reader["ClassName"].ToString();

                    Console.WriteLine($"{classID}. Name: {className}");
                }
            }
        }
    }

    internal static string GetClassName(SqlConnection connection, int classID)
    {
        string query = $"SELECT ClassName FROM Classes WHERE ClassID = {classID}";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            object result = command.ExecuteScalar();

            return result != null ? result.ToString() : string.Empty;
        }
    }
}