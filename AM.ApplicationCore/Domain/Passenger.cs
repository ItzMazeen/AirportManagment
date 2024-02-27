using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
        public string PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }
        public int TelNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Flight> Flights { get; set; }

        //public bool CheckProfile(string prenom, string nom)
        //{
        //    return firstname.equals(prenom) && lastname.equals(nom);
        //}
        public bool CheckProfile(string prenom, string nom, string email=null)
        {
            if(email!=null)
            return FirstName.Equals(prenom) && LastName.Equals(nom) && email.Equals(EmailAdress);
            else
            {
                return FirstName.Equals(prenom) && LastName.Equals(nom);
            }

        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a Passanger");
        }
    }
    
}

