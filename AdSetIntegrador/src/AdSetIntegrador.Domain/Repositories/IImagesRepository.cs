using AdSetIntegrador.Domain.Entities;

namespace AdSetIntegrador.Domain.Repositories;

public interface IImagesRepository
{
    public void Upload(Image image);
}
