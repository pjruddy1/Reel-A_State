using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reel_A_State.DataAccessLayer;
using Reel_A_StateData.Models;
using DataType = Reel_A_State.DataAccessLayer.DataType;

namespace Reel_A_State.BusinessLayer
{
    public class EstatePropertiesRepository : IEstatePropertiesRepository, IDisposable
    {
        public string Table = "Estates";
        public string database = "PropertyDB";
        private IDataService _dataService;
        List<EstateProperties> _estatProperties;

        public EstatePropertiesRepository()
        {
            _dataService = SetDataService();

            try
            {
                _estatProperties = _dataService.ReadAll(Table) as List<EstateProperties>;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private IDataService SetDataService()
        {
            switch (DataConfig.dataType)
            {
                case DataType.BSON:
                    return new DataServiceMongo(database);

                default:
                    throw new Exception();
            }
        }
        public void Add(EstateProperties estate)
        {
            try
            {
                _estatProperties.Add(estate);
                _dataService.InsertEstate(Table, estate);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Delete(EstateProperties estate)
        {
            try
            {
                _dataService.DeleteEstate(Table, estate.Id, estate);
                _estatProperties.Remove(estate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<EstateProperties> GetAll()
        {
            return _estatProperties;
        }

        public void Update(EstateProperties estate)
        {
            try
            {
                _dataService.UpdateEstate(Table, estate.Id, estate, estate);

                _estatProperties.Remove(estate);
                _estatProperties.Add(estate);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Dispose()
        {
            _dataService = null;
            _estatProperties = null;
        }
    }
}
