using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using log4net;

namespace Data
{
    public class BaseRepository
    {
        public MyLoveContext DB;
        public ILog Logger;
        public BaseRepository()
        {
            DB=new MyLoveContext();
        }
    }
}
