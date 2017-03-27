

## Dependency
    $ dotnet add package AutoMapper

## Outer facing model != Business model != Entity model
    Entity : the object in database, has validation attributes
    Dto (Data transfer objects): The return value of the RESTful API
    
## Coding
    * Startup.cs / Configure()
    AutoMapper.Mapper.Initialize(cfg =>
    {
        // output
        cfg.CreateMap<Author, AuthorDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>
            $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src =>
            src.DateOfBirth.GetCurrentAge()));

        cfg.CreateMap<Book, BookDto>();
        
        // input
        cfg.CreateMap<AuthorForCreationDto, Author>();
        cfg.CreateMap<BookForCreationDto, Book>();
    });