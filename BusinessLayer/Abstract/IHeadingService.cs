using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetAll();
        void HeadingAdd(Heading heading);
        void HeadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);
        Heading GetById(int id);
        List<Heading> GetAllByWriter(int id);
    }
}
