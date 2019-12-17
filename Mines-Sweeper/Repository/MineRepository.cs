using System;
using System.IO;
using Mines_Sweeper.Dao;
using Newtonsoft.Json;

namespace Mines_Sweeper.Repository
{
    public class MineRepository : IMineRepository
    {
        public MineMatrix Load(string token)
        {
            try
            {
                string fileText = File.ReadAllText($"{token}.json");
                var json = JsonConvert.DeserializeObject<MineMatrix>(fileText);
                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public int Save(MineMatrix matrix)
        {
            try
            {
                var jsonToSave = JsonConvert.SerializeObject(matrix);
                File.WriteAllText($"{matrix.Token}.json", jsonToSave);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            

            return 1;
        }
    }
}
