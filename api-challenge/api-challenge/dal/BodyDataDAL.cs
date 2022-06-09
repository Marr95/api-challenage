using api_challenge.dto;
using api_challenge.models;
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
                command.CommandText = "INSERT INTO bodydata (heartBeat, heat) VALUES (@heartBeat, @heat)";
                command.Prepare();
                command.Parameters.AddWithValue("@heartBeat", bodyDataDTO.heartBeat);
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

        public List<BodyData> GetBodyDatas()
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM bodydata";
                List<BodyData> bodyDatas = new List<BodyData>();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bodyDatas.Add(new BodyData() { id = Convert.ToInt32(reader["id"]), heartBeat = Convert.ToInt32(reader["heartBeat"]), heat = Convert.ToDouble(reader["heat"]) });
                    }
                }
                return bodyDatas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
