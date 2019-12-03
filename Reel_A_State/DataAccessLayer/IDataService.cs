using Reel_A_StateData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reel_A_State.DataAccessLayer
{
    public interface IDataService
    {
        IEnumerable<EstateProperties> ReadAll(string table);
        void InsertEstate<EstateProperties>(string table, EstateProperties estate);
        void UpdateEstate<T>(string table, Guid id, T Record, EstateProperties estate);
        void DeleteEstate<T>(string table, Guid id, T Record);
    }
}
