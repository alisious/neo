using System.Linq;

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
        [DisplayName("Imiê")]
        public string FirstName { get; set; }

        [StringLength(30)]
        [DisplayName("Drugie imiê")]
        public string MiddleName { get; set; }

        [StringLength(50)]
        [DisplayName("Nazwisko poprzednie")]
        public string PreviousName { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(10)]
        [DisplayName("Data urodzenia")]
        //[RegularExpression("[0-9]{4}-[0-9]{2}-[0-9]{2}", ErrorMessage = "Data w formacie RRRR-MM-DD.")]
        public string BirthDate { get; set; }

        [StringLength(100)]
        [DisplayName("Miejsce urodzenia")]
        public string BirthPlace { get; set; }

        [Required(AllowEmptyStrings=true)]
        [StringLength(50)]
        [DisplayName("Imiê ojca")]
        public string FatherName { get; set; }

        [StringLength(50)]
        [DisplayName("Imiê matki")]
        public string MotherName { get; set; }

        [StringLength(50)]
        [DisplayName("Nazwisko panieñskie matki")]
        public string MotherMaidenName { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage = @"P³eæ jest wymagana!")]
        [StringLength(1)]
        [DisplayName("P³eæ")]
        public string Sex { get; set; }

        private bool _hasPESEL;

        
        [DisplayName("Posiada PESEL")]
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
        [DisplayName("Narodowoœæ")]
        public virtual Country Nationality { get; set; }

        [DisplayName("Obywatelstwo")]
        public virtual HashSet<Country> Citizenships { get; set; }

        public virtual HashSet<Address> Addresses { get; set; }
        public virtual HashSet<Workplace> Workplaces { get; set; }


        #region Address routines

        [NotMapped]
        public Address CurrentAddress { get { return Addresses.FirstOrDefault(a => a.IsCurrent); } }

        public void SetAddressCurrent(Address currentAddress)
        {
            currentAddress.IsCurrent = true;
            foreach (var address in Addresses)
            {
                if (!address.Equals(currentAddress))
                    address.IsCurrent = false;
            }
        }

        public void AddAddress(Address address)
        {
            Addresses.Add(address);
            if (address.IsCurrent)
                SetAddressCurrent(address);
        }

        public void RemoveAddress(Address address)
        {
            var isCurrent = address.IsCurrent;
            Addresses.Remove(address);
            if ((Addresses.Count > 0) && isCurrent)
            {
                var maxId = Addresses.Max(a => a.Id);
                var currentAddress = Addresses.FirstOrDefault(a => a.Id.Equals(maxId));
                SetAddressCurrent(currentAddress);
            }
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
