using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
    interface ICommon
    {

         int InsertUpdate();
         DataSet Select();
         int Delete(Int32 id);
        
    }
}
