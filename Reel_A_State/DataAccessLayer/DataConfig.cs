using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reel_A_State.DataAccessLayer
{
    public enum DataType
    {
        BSON
    }
    public class DataConfig
    {

        public static DataType dataType = DataType.BSON;

        public static string DataPathBson => @"DataAccessLayer\DataBson\EstateProperties.bson";
    }
}
