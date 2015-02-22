using System.Linq;
using AutoMapper;

namespace Kseo2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Security.Cryptography;
    using System.Text;

    [Table("Person.Person")]
    public partial class Person :Entity,IEntity
    {
        public Person()
        {
            Citizenships = new HashSet<Country>();
            Workplaces = new HashSet<Workplace>();
            Addresses = new HashSet<Address>();
            Reservations = new HashSet<Reservation>();
            _hasPESEL = true;
            MiddleName = String.Empty;
            PreviousName = String.Empty;
            BirthDate = String.Empty;
            BirthPlace = String.Empty;
            FatherName = String.Empty;
            MotherName = String.Empty;
            MotherMaidenName = String.Empty;
        }


        private  string _pesel;

        public int Id { get; set; }

        [Column(TypeName = "ntext")]
        public string Notes { get; set; }

        [Required]
        [StringLength(11)]
        [DisplayName("PESEL")]
        [Index("INX_PERSON_PESEL", IsUnique = true)]
        public string Pesel
        {
            get
            {
                if(!HasPESEL)
                {
                    _pesel = Guid.NewGuid().ToString().Substring(1,11);
                }
                return _pesel;
            }
            set { _pesel = value; }
        }

        [Required]
        [StringLength(50)]
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Imi�")]
        public string FirstName { get; set; }

        [StringLength(30)]
        [DisplayName("Drugie imi�")]
        public string MiddleName { get; set; }

        [StringLength(50)]
        [DisplayName("Nazwisko poprzednie")]
        public string PreviousName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(10)]
        [DisplayName(@"Data urodzenia")]
        //[RegularExpression("[0-9]{4}-[0-9]{2}-[0-9]{2}", ErrorMessage = "Data w formacie RRRR-MM-DD.")]
        public string BirthDate { get; set; }

        [StringLength(100)]
        [DisplayName(@"Miejsce urodzenia")]
        public string BirthPlace { get; set; }

        [Required(AllowEmptyStrings=true)]
        [StringLength(50)]
        [DisplayName(@"Imi� ojca")]
        public string FatherName { get; set; }

        [StringLength(50)]
        [DisplayName(@"Imi� matki")]
        public string MotherName { get; set; }

        [StringLength(50)]
        [DisplayName(@"Nazwisko panie�skie matki")]
        public string MotherMaidenName { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage = @"P�e� jest wymagana!")]
        [StringLength(1)]
        [DisplayName(@"P�e�")]
        public string Sex { get; set; }

        private bool _hasPESEL;

        
        [DisplayName(@"Posiada PESEL")]
        public bool HasPESEL
        {
            get { return _hasPESEL; } 
            set 
            {
               if (_hasPESEL==true)
               {
                   if (value == false)
                   {
                       SetPeselUnknown();
                   }
               }
               else
                   if (value == true)
                   {
                       Pesel = String.Empty;
                   }
               _hasPESEL = value;

            } 
        }


        public virtual int? NationalityId { get; set; }
        [ForeignKey("NationalityId")]
        [DisplayName("Narodowo��")]
        public virtual Country Nationality { get; set; }

        [DisplayName("Obywatelstwo")]
        public virtual HashSet<Country> Citizenships { get; set; }

        public virtual HashSet<Address> Addresses { get; set; }
        public virtual HashSet<Workplace> Workplaces { get; set; }
        public virtual HashSet<Reservation> Reservations { get; set; } 


        #region Address routines

       
        

        public void AddAddress(Address address)
        {
            Addresses.Add(address);
        }

        public void RemoveAddress(Address address)
        {
            Addresses.Remove(address);
            
        } 

        #endregion

        #region Workplace routines

       public void WorkplaceUpdate(Workplace workplace)
        {
            Mapper.CreateMap<Workplace, Workplace>().ForMember(w => w.Id,m=>m.Ignore());
            Workplace updatedWorkplace = Workplaces.FirstOrDefault(w => w.Id.Equals(workplace.Id));
            updatedWorkplace = Mapper.Map<Workplace, Workplace>(workplace);
        }

        public void WorkplaceRemove(Workplace workplace)
        {
            Workplaces.Remove(workplace);
        }

        #endregion



        [NotMapped]
        public String FullName { get { return String.Format("{0} {1}", LastName, FirstName); } }
        
        [NotMapped]
        public bool IsVerified { get { return true; } }
        [NotMapped]
        public bool IsCooperator { get { return true; } }
        [NotMapped]
        public bool IsReserved { get { return true; } }
        [NotMapped]
        public bool IsContained { get { return true; } }


        [NotMapped]
        public string VerifiedImage
        {
            get { return IsCooperator ? @"..\Images/search_files.png" : String.Empty; }
        }

        [NotMapped]
        public string CooperatorImage 
        {
            get { return IsCooperator ? @"../Images/spy-128.png" : String.Empty; }
        }

        [NotMapped]
        public string ReservedImage
        {
            get { return IsReserved ? @"../Images/preferences-contact-list.png" : String.Empty; }
        }

        [NotMapped]
        public string ContainedImage
        {
            get { return IsContained ? @"../Images/folder-document.png" : String.Empty; }
        }
        
        #region Private methods
        private void SetPeselUnknown()
        {
            char[] chars = new char[10];
            chars = "1234567890".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetBytes(data);
            data = new byte[11];
            crypto.GetBytes(data);
            StringBuilder result = new StringBuilder(7);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            Pesel = result.ToString();
        } 
        #endregion

        
        public EntityState EntityState { get; set; }
        
    }
}
