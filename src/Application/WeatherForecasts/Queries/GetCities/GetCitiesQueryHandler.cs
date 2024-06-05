using Assignment.Application.Common.Interfaces;
using Assignment.Application.WeatherForecasts.Queries.GetCities;

namespace Assignment.Application.WeatherForecasts.Queries.GetCountries;
public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, IList<CityDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCitiesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<CityDto>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Cities
                .Where(t => t.CountryId == request.CountryId)
                .AsNoTracking()
                .ProjectTo<CityDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Name)
                .ToListAsync(cancellationToken);
    }
}
