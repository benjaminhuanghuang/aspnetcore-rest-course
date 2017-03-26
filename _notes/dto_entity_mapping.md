## Dependency
    $ dotnet add package AutoMapper

## 
    Entity : the object in database, has validation attributes
    Data transfer objects: The return value of the RESTful API
    
## Coding
    * Startup.cs / Configure()
    AutoMapper.Mapper.Initialize(cfg =>
    {
        cfg.CreateMap<Entities.Author, Models.AuthorDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>
            $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src =>
            src.DateOfBirth.GetCurrentAge()));

        cfg.CreateMap<Entities.Book, Models.BookDto>();
    });