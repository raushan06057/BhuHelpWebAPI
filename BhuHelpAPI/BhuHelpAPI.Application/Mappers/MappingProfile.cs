namespace BhuHelpAPI.Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateApplicationUserCommand, ApplicationUser>().ReverseMap();
        CreateMap<CreateApplicationRoleCommand, ApplicationRole>().ReverseMap();
        CreateMap<CreateBhuInfoCommand,BhuInfoEntity>().ReverseMap();
        CreateMap<DeleteApplicationRoleCommand, ApplicationRole>().ReverseMap();
        CreateMap<LoginCommand,ApplicationUser>().ReverseMap();
        CreateMap<UpdateApplicationRoleCommand, ApplicationRole>().ReverseMap();
        CreateMap<UpdateApplicationUserCommand, ApplicationUser>().ReverseMap();
        CreateMap<CreateBhuInfoCommand, BhuInfoEntity>().ReverseMap();
        CreateMap<UpdateBhuInfoCommand, BhuInfoEntity>().ReverseMap();
        CreateMap<CreateGotraCommand, GotraEntity>().ReverseMap();
        CreateMap<CreateProfessionalCommand, ProfessionalEntity>().ReverseMap();
    }
}
