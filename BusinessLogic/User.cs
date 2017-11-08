using System;

namespace BusinessLogic
{
    public class User
    {
        #region Variables

        int _ID_User;
        string _lastName_User, _firstname_User, _email_User;
        bool _isCoursier_User, _isAdmin_User;
        byte[] _salt_User, _hash_User;
        DateTime _createdDate_User, _deletedDate_User;
        Address adresse;
        string nomEtPrenom;
        string numTel;

        #endregion

        #region GetSet

        public int ID_User
        {
            get { return _ID_User; }
            set { _ID_User = value;}
        }

        public string LastName_User
        {
            get { return _lastName_User; }
            set { _lastName_User = value; }
        }

        public string Firstname_User
        {
            get { return _firstname_User; }
            set { _firstname_User = value; }
        }

        public string Email_User
        {
            get { return _email_User; }
            set { _email_User = value; }
        }

        public bool IsCoursier_User
        {
            get { return _isCoursier_User; }
            set { _isCoursier_User = value; }
        }

        public bool IsAdmin_User
        {
            get { return _isAdmin_User; }
            set { _isAdmin_User = value; }
        }

        public byte[] Salt_User
        {
            get { return _salt_User; }
            set { _salt_User = value; }
        }

        public byte[] Hash_User
        {
            get { return _hash_User; }
            set { _hash_User = value; }
        }

        public DateTime CreatedDate_User
        {
            get { return _createdDate_User; }
            set { _createdDate_User = value; }
        }

        public DateTime DeletedDate_User
        {
            get { return _deletedDate_User; }
            set { _deletedDate_User = value; }
        }

        public string NomEtPrenom
        {
            get { return nomEtPrenom; }
            set { nomEtPrenom = value; }
        }

        public string NumTel
        {
            get
            {
                return numTel;
            }

            set
            {
                numTel = value;
            }
        }

        #endregion

        #region Methods

        public User(int ID, string LastName, string FirstName, string Email, bool IsCoursier, bool IsAdmin, byte[] Salt, byte[] Hash, DateTime CreatedDate, DateTime DeletedDate, string numtel)
        {
            _ID_User = ID;
            _lastName_User = LastName;
            _firstname_User = FirstName;
            _email_User = Email;
            _isCoursier_User = IsCoursier;
            _isAdmin_User = IsAdmin;
            _salt_User = Salt;
            _hash_User = Hash;
            _createdDate_User = CreatedDate;
            _deletedDate_User = DeletedDate;
            NumTel = numtel;
        }

    /// <summary>
    /// Récupere le nom est prenom de l'usager ainsi que son adresse
    /// </summary>
    /// <param name="LastName">Nom</param>
    /// <param name="FirstName">Prénom</param>
    /// <param name="Adresse">Adresse de l'usager</param>
    public User(int id, string _lastName, string _firstName, Address _adresse)
        {
            _ID_User = id;
            _lastName_User = _lastName;
            _firstname_User = _firstName;
            adresse = _adresse;
            nomEtPrenom = _firstName + " " + _lastName;
        }

        public User(int id, string _lastName, string _firstName,string _email)
        {
            _ID_User = id;
            _lastName_User = _lastName;
            _firstname_User = _firstName;
            _email_User = _email;
            nomEtPrenom = _firstName + " " + _lastName;
        }

        #endregion
    }
}
