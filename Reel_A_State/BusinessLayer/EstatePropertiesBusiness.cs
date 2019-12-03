using Reel_A_StateData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reel_A_State.BusinessLayer
{
    public class EstatePropertiesBusiness
    {
        public EstatePropertiesBusiness()
        {

        }

        private List<EstateProperties> GetAllEstateProperties()
        {
            List<EstateProperties> estateProperties = null;
            try
            {
                using(EstatePropertiesRepository epRepository = new EstatePropertiesRepository())
                {
                    estateProperties = epRepository.GetAll() as List<EstateProperties>;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return estateProperties;
        }

        public List<EstateProperties> AllEstateProperties()
        {
            return GetAllEstateProperties() as List<EstateProperties>;
        }

        public void AddEstateProperty(EstateProperties estate)
        {
            try
            {
                using (EstatePropertiesRepository epRepository = new EstatePropertiesRepository())
                {
                    epRepository.Add(estate);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteEstateProperty(EstateProperties estate)
        {
            try
            {
                using (EstatePropertiesRepository epRepository = new EstatePropertiesRepository())
                {
                    epRepository.Delete(estate);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateEstateProperty(EstateProperties estate)
        {
            try
            {
                using (EstatePropertiesRepository epRepository = new EstatePropertiesRepository())
                {
                    epRepository.Update(estate);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
