using Reel_A_StateData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reel_A_State.BusinessLayer
{
    interface IEstatePropertiesRepository
    {
        IEnumerable<EstateProperties> GetAll();
        void Add(EstateProperties estate);
        void Update(EstateProperties estate);
        void Delete(EstateProperties estate);
    }
}
