using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //Primary key (PassportNumber)
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }

        [MinLength(3,ErrorMessage ="Minimum 3 caractèress !!")]
        [MaxLength(5, ErrorMessage ="Maximum 25 caractères !!")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAdress { get; set; }

        //Tel contenant 8 chiffre
        [RegularExpression("^[0,9]{8}$")]
        public int TelNumber { get; set; }

        //Date valide
        [DataType(DataType.Date)]
        //Affichage nom
        [Display(Name ="Date of birth")]
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

