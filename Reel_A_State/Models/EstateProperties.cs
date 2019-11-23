using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reel_A_StateData.Models
{
    public class EstateProperties
    {
        #region Fields
        private Guid _id;
        private string _address;
        private string _city;
        private int _zipcode;
        private decimal _price;
        private int _bedrooms;
        private int _bathrooms;
        private bool _fireplace;
        private bool _pool;
        private List<string> _imageFileNames;
        private string _imageFilePath1;
        private string _state;
        private string _description;
        private string _comment;
        private int _sqrFeet;
        #endregion


        #region Properties
        [BsonId]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public int Zipcode
        {
            get { return _zipcode; }
            set { _zipcode = value; }
        }
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public int Bedrooms
        {
            get { return _bedrooms; }
            set { _bedrooms = value; }
        }
        public int Bathrooms
        {
            get { return _bathrooms; }
            set { _bathrooms = value; }
        }
        public bool Fireplace
        {
            get { return _fireplace; }
            set { _fireplace = value; }
        }
        public bool Pool
        {
            get { return _pool; }
            set { _pool = value; }
        }
        public List<string> ImageFileNames
        {
            get { return _imageFileNames; }
            set { _imageFileNames = value; }
        }
        public string ImageFilePath
        {
            get { return _imageFilePath1; }
            set { _imageFilePath1 = value; }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        public int SqrFeet
        {
            get { return _sqrFeet; }
            set { _sqrFeet = value; }
        }
        #endregion


        #region Constructors
        public EstateProperties()
        {

        }
        #endregion

    }
}
