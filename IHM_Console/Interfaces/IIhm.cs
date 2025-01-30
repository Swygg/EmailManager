using BLL.Interfaces;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM_Console.Interfaces
{
    public interface IIhm
    {
        public void GetHostersList();
        public void GetEmailAccountsList();
    }
}
