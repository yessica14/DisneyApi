using Alkemy.Disney.Api.Application.Dto;
using Alkemy.Disney.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy.Disney.Api.Application.Services
{
    public interface IProductionService 
    {
        List<ListProductionDTO> GetMovieDtoList();
        ProductionDTO GetDetailProductionById(int Id);
        OperationResponseDTO SaveProduction(ProductionPostDTO productiondto);

        OperationResponseDTO UpdateProduction(int id, ProductionUpdateDTO productionDTO);
        OperationResponseDTO RemoveProduction(int Id);
        List<ListProductionDTO> GetMovieByTitle(string Name);
        List<ListProductionDTO> GetMovieByGender(int genero);

        List<ProductionDTO> SortProductionByDate(string typeOrder);
        string GetDescription(Enum value);
    }
}
