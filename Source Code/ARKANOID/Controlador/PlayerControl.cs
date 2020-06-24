using System;
using System.Collections.Generic;
using System.Data;
using Arkanoid.Modelo;

namespace Arkanoid.Controlador
{
    public static class PlayerControl
    {
        public static bool CreatePlayer(string nickname)
        {
            var dt = DataBaseController.ExecuteQuery($"SELECT * FROM PLAYER WHERE nickname = '{nickname}'");

            if(dt.Rows.Count > 0)
                return true;
            else
            {
                DataBaseController.ExecuteNonQuery("INSERT INTO PLAYER(nickname) VALUES" +
                    $"('{nickname}')");

                return false;
            }
        }

        public static void CreateNewScore(int idPlayer, int score)
        {
            DataBaseController.ExecuteNonQuery("INSERT INTO SCORES(idPlayer, score) VALUES" +
                $"({idPlayer}, {score})");
        }

        public static List<Player> ObtainTopPlayers()
        {
            var topPlayers = new List<Player>();
            DataTable dt = DataBaseController.ExecuteQuery("SELECT pl.nickname, sc.score " +
                                                    "FROM PLAYER pl, SCORES sc " +
                                                    "WHERE pl.idPlayer = sc.idPlayer " +
                                                    "ORDER BY sc.score DESC " +
                                                    "LIMIT 10");

            foreach(DataRow dr in dt.Rows)
            {
                Player u = new Player();
                u.Score = Convert.ToInt32(dr[1].ToString());
                u.Nickname = dr[0].ToString();
                

                topPlayers.Add(u);            }

            return topPlayers;
        }
        
        public static List<Player> getLista()
        {
            string sql = "select * from PLAYER";

            DataTable dt = DataBaseController.ExecuteQuery(sql);

            List<Player> lista = new List<Player>();
            foreach (DataRow row in dt.Rows)
            {
                Player u = new Player();
                u.idPlayer = Convert.ToInt32(row[0].ToString());
                u.Nickname = row[1].ToString();
                

                lista.Add(u);
            }
            return lista;    
        }
    }
}