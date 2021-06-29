using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntakeApp.Classes
{
    public class Status
    {
        private int StatusID;
        private string StatusName;

        public Status(int _StatusID, string _StatusName)
        {
            this.StatusID = _StatusID;
            this.StatusName = _StatusName;
        }

        public int GetStatusId()
        {
            return StatusID;
        }

        public string GetStatusName()
        {
            return StatusName;
        }
    }
}
