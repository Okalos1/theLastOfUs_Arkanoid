﻿namespace Arkanoid.Modelo
{
    public class Player
    {
        public int? idPlayer { get; set; }
        public string Nickname { get; set; }
        public int Score { get; set; }

        public Player()
        {
            idPlayer = null;
            Nickname = "";
            Score = 0;
        }
    }
}