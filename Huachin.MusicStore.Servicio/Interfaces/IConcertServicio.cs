using Huachin.MusicStore.Dto.Request.Eventos;
using Huachin.MusicStore.Dto.Response.Eventos;
using Huachin.MusicStore.Dto.Response;
using Huachin.MusicStore.Dto.Request.Generos;

namespace Huachin.MusicStore.Servicio.Interfaces
{
    public interface IConcertServicio
    {
		Task<BaseResponse> Registrar(ConcertRequestDto request);
		Task<BaseResponseGeneric<IEnumerable<ListaEventosResponseDto>>> Listar(BusquedaEventosRequest request);

	}
}
