using Huachin.MusicStore.Dto.Request;
using Huachin.MusicStore.Dto.Response;

namespace Huachin.MusicStore.Servicio.Interfaces
{
    public interface IGenreServicio
    {
        Task<BaseResponse> Registrar(GenreRequestDto request);
	}
}
