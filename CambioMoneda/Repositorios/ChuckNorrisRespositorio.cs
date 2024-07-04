using CambioMoneda.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambioMoneda.Repositorios
{
    public class ChuckNorrisRespositorio
    {
        public string _dbPath;
        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<ChuckNorris>();
        }

        public ChuckNorrisRespositorio(string dbPath)
        {
            _dbPath = dbPath;
        }

        public List <ChuckNorris> DevuelveListadoChistes()
        {
            return conn.Table<ChuckNorris>().ToList();
        }

        public void GuardarChisteChuckNorris(ChuckNorris chiste)
        {
            conn.Insert(chiste);
        }

        public async Task <ChuckNorris> DevuelveChisteChuckNorris()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://api.chucknorris.io/jokes/random/");
            string response_json = await response.Result.Content.ReadAsStringAsync();

            ChuckNorris chuck = JsonConvert.DeserializeObject<ChuckNorris>(response_json);

            return chuck;
        }
    }
}
