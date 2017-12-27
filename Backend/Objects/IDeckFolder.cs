﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NickAc.Backend.Objects
{
    public interface IDeckFolder : IDeckItem
    {
        List<IDeckFolder> GetSubFolders();
        List<IDeckItem> GetDeckItems();
    }
}