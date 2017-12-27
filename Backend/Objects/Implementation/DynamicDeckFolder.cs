﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NickAc.Backend.Objects.Implementation
{
    public class DynamicDeckFolder : IDeckFolder
    {
        readonly Dictionary<int, IDeckItem> items = new Dictionary<int, IDeckItem>();

        public List<IDeckItem> GetDeckItems() => items.Values.ToList();
        public List<IDeckFolder> GetSubFolders() => items.Values.OfType<IDeckFolder>().ToList();

        public void Add(int slot, IDeckItem item) => items.Add(slot, item);
    }
}