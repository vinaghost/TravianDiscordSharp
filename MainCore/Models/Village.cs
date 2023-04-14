﻿namespace MainCore.Models
{
    public class Village
    {
        public int MapId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Tribe { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int AllyId { get; set; }
        public string AllyName { get; set; }
        public int Pop { get; set; }
        public string Region { get; set; }
        public bool IsCapital { get; set; }
        public bool IsCity { get; set; }
        public int VictoryPoints { get; set; }
    }
}