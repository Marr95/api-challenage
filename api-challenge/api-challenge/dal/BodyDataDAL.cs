using api_challenge.dto;
using MySqlConnector;

namespace api_challenge.dal
{
    public class BodyDataDAL
    {

        private MySqlConnection connection;

        public BodyDataDAL()
        {
            connection = new MySqlConnection("server=192.168.44.122;user=marwan;password=marwan;database=challenge");
        }

        public bool postBodyData(BodyDataDTO bodyDataDTO)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO bodydata (temperature, heat) VALUES (@temperature, @heat)";
                command.Prepare();
                command.Parameters.AddWithValue("@temperature", bodyDataDTO.temperature);
                command.Parameters.AddWithValue("@heat", bodyDataDTO.heat);
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
                if(connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
