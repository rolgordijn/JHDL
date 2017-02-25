using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JHDL
      


{
    [Serializable]
    public enum Gender
    {
       
        Man,
        Vrouw,
        x
    
    }

    [Serializable]
    public enum MemberPermissions
    {
       /* Lid = 0,
        superlid = 1,
        Vrijwilliger = 100,
        Kernlid = 200,
        Bestuurder = 300,
        Beheerder = 400*/

         Lid = 0,
        superlid = 1,
        Vrijwilliger = 2,
        Kernlid = 3,
        Bestuurder = 4,
        Beheerder = 5 
    }

    [Serializable]
    class Member 
    {

      
        private static Dictionary<string, Member> members = new Dictionary<string, Member>();
        private String name;
        private String city;
        private String phone;
        private  String email;
        private DateTime birthday;
        private Gender gender;
        private MemberPermissions memberPermissions;
        private String password;
        public string Name
        {
            get
            {
                return Security.Decrypt(name);
            }

            set
            {
                name = Security.Encrypt(value);
            }
        }
        public Gender Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }
        private long iD;
        public static int totalMemberCount=1000;

        public DateTime Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                birthday = value;
            }
        }

        public string Email
        {
            get
            {
                if (email != null) { 
                return Security.Decrypt(email);
                }else
                {
                    return "";
                }
            }

            set
            {
                email = Security.Encrypt(value);
            }
        }

        public string City
        {
            get
            {
                if (city != null) { 
                return Security.Decrypt(city);
                }else {
                    return "";
                        }
            }

            set
            {
                city = Security.Encrypt(value);
            }
        }

        public string Phone
        {
            get
            {
                if (phone != null)
                {
                    return Security.Decrypt(phone);
                }else
                {
                    return "";
                }
            }

            set
            {
                phone = Security.Encrypt(value);
            }
        }

        public string Password
        {
            get
            {
                return Security.Decrypt(password);
            }

            set
            {
                password = Security.Encrypt(value);
            }
        }

        public static Dictionary<string, Member> Members
        {
            get
            {
                return members;
            }

            set
            {
                members = value;
            }
        }

        public MemberPermissions MemberPermissions
        {
            get
            {
                return memberPermissions;
            }

            set
            {
                memberPermissions = value;
            }
        }

        public long ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        public Member(String name, String city, String phone, String email, DateTime birthday, Gender gender, MemberPermissions p, long iD)
        {
            this.Name = name;
            this.City = city;
            this.Phone = phone;
            this.Email = email;
            this.Birthday = birthday;
            this.Gender = gender;
            this.MemberPermissions = p;
            this.ID = iD;
        }


        /// <summary>
        /// This constructor is used to create the first user account. Only the name and password are required in the "FirstUserForm.cs".    
        /// (S)he will obtain the highest permission possible. 
        /// </summary>
        /// <param name="name">The name of the first user</param>
        /// <param name="password">The password that's required to </param>
        public Member(String name, string password)
        {
            Name = name;
            Password = password;
            birthday = new DateTime(2000, 1, 1); // temporary birthday value 
            iD = getNewId();
            members.Add(name, this);
            memberPermissions = MemberPermissions.Beheerder;
        }

        public override String ToString()
        {

            string memberToString = String.Format("Naam: {0} \r\nPlaats: {1} \r\nGSM: {2} \r\nemail: {3}\r\ngeboortedatum: {4}\r\nGeslacht: {5}\r\n",this.Name,this.City,this.Phone,this.Email,this.Birthday,this.Gender);
            return memberToString;
        }



        /// <summary>
        /// Each member has a unique ID that we use to identify. The barcode uses this ID. 
        /// The ID is based on the year, month, day, hour and a unique ID that counts how many members that are registred. 
        /// </summary>
        /// <returns></returns>
        public static long getNewId()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;


          //  MessageBox.Show("" + year  + month  + day + hour  + totalMemberCount);
          
                 totalMemberCount++;
            long fullId = (long) ( Math.Pow(10, 10) * (year%1000) )+ (long) Math.Pow(10, 8) * month + (long) Math.Pow(10, 6) * day + (long) Math.Pow(10, 4) * hour + (long) totalMemberCount;
           // MessageBox.Show("nieuw lid krijgt ID" + fullId + " toegewezen");
            return fullId;    
        }

  
    }
}
