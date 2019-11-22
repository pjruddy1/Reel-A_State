using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reel_A_StateData.Models;

namespace Reel_A_StateData.DataAccessLayer
{
    public class EstatePropertySeedData
    {
        public static List<EstateProperties> GenerateListOfEstateProperties()
        {
            List<EstateProperties> estateProperties = new List<EstateProperties>()
            {
                new EstateProperties()
                {
                    Address = "1212 State St",
                    City = "Traverse City",
                    Zipcode = 49686,
                    Price = 210000,
                    Bedrooms = 3,
                    Bathrooms = 2,
                    Fireplace = true,
                    Pool = false                    
                },
                new EstateProperties()
                {
                    Address = "1600 Grande Rd",
                    City = "Traverse City",
                    Zipcode = 49686,
                    Price = 195000,
                    Bedrooms = 4,
                    Bathrooms = 1,
                    Fireplace = true,
                    Pool = true
                },
                new EstateProperties()
                {
                    Address = "1986 Henry Ln",
                    City = "Traverse City",
                    Zipcode = 49686,
                    Price = 205000,
                    Bedrooms = 2,
                    Bathrooms = 2,
                    Fireplace = true,
                    Pool = true
                }
            };
            return estateProperties;
        }
    }
}
