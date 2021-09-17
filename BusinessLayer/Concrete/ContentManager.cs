using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            _contentDal.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDal.Update(content);
        }

        public List<Content> GetAll()
        {
            return _contentDal.List();
        }

        public List<Content> GetAllByHeadingId(int id)
        {
            return _contentDal.List(c => c.HeadingId == id);
        }

        public List<Content> GetAllByWriter(int id)
        {
            return _contentDal.List(c => c.WriterId == id);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(c => c.ContentId == id);
        }
    }
}
