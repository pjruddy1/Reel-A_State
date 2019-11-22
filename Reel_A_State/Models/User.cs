using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reel_A_StateData.Models
{
    public class User 
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private List<Comments> _userComments;

        public List<Comments> UserComments
        {
            get { return _userComments; }
            set { _userComments = value; }
        }


        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }


        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public User()
        {

        }

    }
}
