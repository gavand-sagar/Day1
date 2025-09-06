namespace Day2
{
    public class BookMappingProfile : AutoMapper.Profile
    {
        public BookMappingProfile()
        {
            CreateMap<BookDTO, BookEntity>();
            CreateMap<BookEntity, BookDTO>();
        }
    }
}
