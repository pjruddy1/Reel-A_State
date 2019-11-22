using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reel_A_StateData.Models
{
    public class Comments
    {
        private string _description;
        private int _propertyId;

        public int PropertyId
        {
            get { return _propertyId; }
            set { _propertyId = value; }
        }


        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Comments()
        {

        }

    }
}
