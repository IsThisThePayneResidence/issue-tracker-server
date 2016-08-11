﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It.Model.Interfaces
{
    public interface IEvent
    {
        bool IsGet();

        bool IsUpdate();

        bool IsDelete();

        bool IsCreate();

        Type GetDataType();

        object GetData();
    }
}
