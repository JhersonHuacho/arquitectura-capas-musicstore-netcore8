using Huachin.MusicStore.AccesoDatos.Contexto;
using Huachin.MusicStore.Dto.Request;
using Huachin.MusicStore.Dto.Response;
using Huachin.MusicStore.Repositorios.Interfaces;
using Huachin.MusicStore.Servicio.Interfaces;

namespace Huachin.MusicStore.Servicio.Implementaciones
{
	public class GenreServicio : IGenreServicio
	{
		private readonly IGenreRepositorio _genreRepositorio;

		public GenreServicio(IGenreRepositorio genreRepositorio)
		{
			_genreRepositorio = genreRepositorio;
		}

		public async Task<BaseResponse> Registrar(GenreRequestDto request)
		{
			var response = new BaseResponse();
			try
			{
				var genre = new Genre()
				{
					Name = request.Name
				};

				await _genreRepositorio.AddAsync(genre);

				response.Message = "Género registrado correctamente";
				response.Success = true;
			}
			catch (Exception ex)
			{
				response.Message = "Ocurrió un error al registrar el género";
				response.Success = false;
				throw;
			}

			return response;
		}
	}
}
