using Nibulon.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nibulon.WebApp.Services
{
   public interface IGrainManipulation
    {
        public List<Grain> ReadJson();
    }
}
