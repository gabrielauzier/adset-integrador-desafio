using AdSetIntegrador.Domain.Entities;
using AdSetIntegrador.Domain.Repositories;

namespace AdSetIntegrador.Infrastructure.DataAccess.Repositories;

internal class ImagesRepository : IImagesRepository
{
    private readonly AdSetIntegradorDbContext _dbContext;

    public ImagesRepository(AdSetIntegradorDbContext dbContext)
    {
        _dbContext = dbContext;

    }

    public void Upload(Image image)
    {
        _dbContext.Images.Add(image);
    }
}
