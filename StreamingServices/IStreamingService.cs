
using System.Collections.Generic;
using System.Threading.Tasks;
using SongFinder.DTO;

namespace SongFinder.StreamingServices.Interfaces
{

    internal interface IStreamingService
    {
        Task<SongResponseDTO> SearchSong(SongSearchDTO query);
        Task<List<SongResponseDTO>> SearchSongs(SongSearchDTO query);
    }
}