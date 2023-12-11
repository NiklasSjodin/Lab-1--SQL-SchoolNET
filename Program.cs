
using Microsoft.Data.SqlClient;

namespace SchoolNET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectingString = "Data Source=(localdb)\\.;Initial Catalog=SchoolNET;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectingString))
            {
                connection.Open();
                Menus.MainMenu(connection);
            }
        }
    }
}