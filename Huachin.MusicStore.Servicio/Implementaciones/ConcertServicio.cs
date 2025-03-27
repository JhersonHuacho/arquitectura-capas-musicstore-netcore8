using Huachin.MusicStore.AccesoDatos.Contexto;
using Huachin.MusicStore.Dto.Request.Eventos;
using Huachin.MusicStore.Dto.Request.Generos;
using Huachin.MusicStore.Dto.Response;
using Huachin.MusicStore.Dto.Response.Eventos;
using Huachin.MusicStore.Dto.Response.Generos;
using Huachin.MusicStore.Repositorios.Implementaciones;
using Huachin.MusicStore.Repositorios.Interfaces;
using Huachin.MusicStore.Servicio.Interfaces;
using Microsoft.Extensions.Logging;

namespace Huachin.MusicStore.Servicio.Implementaciones
{
    public class ConcertServicio : IConcertServicio
	{
        private readonly IConcertRepositorio _concertRepositorio;
		private readonly ILogger<ConcertServicio> _logger;

		public ConcertServicio(IConcertRepositorio concertRepositorio, ILogger<ConcertServicio> logger)
		{
			_concertRepositorio = concertRepositorio;
			_logger = logger;
		}

		public async Task<BaseResponse> Registrar(ConcertRequestDto request)
		{
			var response = new BaseResponse();
			try
			{
				var genre = new Concert()
				{
					IdGenre = request.IdGenre,
					Title = request.Title,
					Description = request.Description,
					Place = request.Place,
					UnitPrice = request.UnitPrice,
					DateEvent = Convert.ToDateTime(request.Fecha),
					ImageUrl = request.ImageUrl,
					TicketsQuantity = request.TicketsQuantity,
					Finalized = false
				};

				await _concertRepositorio.AddAsync(genre);

				response.Message = "Concierto registrado correctamente";
				response.Success = true;
			}
			catch (Exception ex)
			{
				response.Message = "Ocurrió un error al registrar un concierto";
				response.Success = false;
				_logger.LogError(ex, $"{response.Message} {ex.Message}");
			}

			return response;
		}

		public async Task<BaseResponseGeneric<IEnumerable<ListaEventosResponseDto>>> Listar(BusquedaEventosRequest request)
		{
			var response = new BaseResponseGeneric<IEnumerable<ListaEventosResponseDto>>();
			try
			{
				var genres = await _concertRepositorio.ListAsync(
					predicado: x => x.Estado == true && (string.IsNullOrWhiteSpace(request.Title) || x.Title.Contains(request.Title)));

				response.Data = genres.Select(x => new ListaEventosResponseDto
				{
					IdEvento = x.Id,
					NameGenre = x.IdGenreNavigation.Name,
					Title = x.Title,
					Description = x.Description,
					Place = x.Place,
					UnitPrice = x.UnitPrice,
					DateEvent = x.DateEvent,
					TicketsQuantity = x.TicketsQuantity,
					Estado = x.Estado
				});
				response.Message = "Eventos obtenidos correctamente";
				response.Success = true;
			}
			catch (Exception ex)
			{
				response.Message = "Ocurrió un error al obtener los eventos";
				response.Success = false;
				_logger.LogError(ex, $"{response.Message} {ex.Message}");
			}
			return response;
		}
	}
}
