using System;

namespace BlazorSignalRApp.Shared
{
    public class Characters
    {
        // [Key]
        public int Id { get; set; }
        public string CharName { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public bool IsAlive { get; set; }
        public float Proficiency { get; set; }

        // Character stats
        public int Health { get; set; }
        public int Mana { get; set; }
        public float Strength { get; set; }
        public float Agility { get; set; }
        public float Magic { get; set; }
    }
}