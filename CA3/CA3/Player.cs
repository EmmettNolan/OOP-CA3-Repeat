using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA3
{
    class Player
    {
        public enum Position { Goalkeeper, Defender, Midfielder, Forward }

        // Properties //
        public string Name { get; set; }
        public string Surname { get; set; }
        public Position PerferredPosition { get; set; }
        public Position PlayerPosition { get; set; }
        public string Spaces { get; set; }
        public DateTime DOB { get; set; }

        private int _age;


        public int Age
        {
            get
            {
                _age = DateTime.Now.Year - DOB.Year;
                if (DOB.DayOfYear > DateTime.Now.DayOfYear)
                    _age--;
                return _age;
            }
        }

        public Player(string name, string surname, Position preferedPosition)
        {
            Name = name;
            Surname = surname;

            PlayerPosition = preferedPosition;


        }

        // Methods //
        public override string ToString()
        {
            return $"{Name} {Surname} {DOB} {PlayerPosition}";
        }
    }
}
