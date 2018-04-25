using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using snow_bc_api.src.data;
using snow_bc_api.src.model;

namespace snow_bc_api.src.Repositories.modelRepository
{
    public class ImageRepository : EntityRepository<Image>, IImageRepository
    {
        private readonly BcApiDbContext _context;
        public ImageRepository(BcApiDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public byte[] GetImage(Guid imageId)
        {
            return _context.Images.SingleOrDefault(p => p.Id == imageId).Data;
        }
        public IEnumerable<Image> GetImagesForCity(Guid cityId)
        {
            return _context.Images.Where(p => p.CityId == cityId && p.DeleteDate == null).OrderBy(i=>i.IsMainImage);
        }

        public string GetMainImageIdForCity(Guid cityId)
        {
            var image = _context.Images.Where(p => p.CityId == cityId && p.DeleteDate == null && p.IsMainImage).SingleOrDefault();

            if (image == null) return Guid.Empty.ToString();
            return image.Id.ToString();
        }


    }
}
