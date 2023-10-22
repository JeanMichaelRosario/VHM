using API.Models;
using AutoMapper;

namespace API.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            MapeoDePropietarioAConsultaDePlaca();
            MapeoDeRegistroDePlacaAPropietario();
            MapeoDeRegistroDePlacaAVehiculo();
            MapeoDeRegistroDePlacaAPlaca();
        }

        private void MapeoDeRegistroDePlacaAVehiculo()
        {
            CreateMap<RegistroDePlaca, Vehiculo>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.TipoAutomovil));
        }

        private void MapeoDeRegistroDePlacaAPlaca()
        {
            CreateMap<RegistroDePlaca, Placa>()
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.GenerarPlaca()))
                .ForMember(dest => dest.Monto, opt => opt.MapFrom(src => src.Monto));
        }

        private void MapeoDeRegistroDePlacaAPropietario()
        {
            CreateMap<RegistroDePlaca, Propietario>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.TipoPersona))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Cedula, opt => opt.MapFrom(src => src.Cedula));
        }

        private void MapeoDePropietarioAConsultaDePlaca()
        {
            CreateMap<Propietario, ConsultaDePlaca>()
                        .ForPath(dest => dest.Cliente.Name, opt => opt.MapFrom(src => src.Name))
                        .ForPath(dest => dest.Cliente.LastName, opt => opt.MapFrom(src => src.LastName))
                        .ForPath(dest => dest.Cliente.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                        .ForPath(dest => dest.Cliente.Cedula, opt => opt.MapFrom(src => src.Cedula))
                        .ForMember(dest => dest.Placas, opt => opt.MapFrom(src => src.Placas.Select(p => new InformacionPlaca
                        {
                            TipoDePlaca = TipoDeVehiculoATipoDePlaca(p.Vehiculo.Tipo),
                            NumeroDePlaca = $"{TipoDeVehiculoATipoDePlaca(p.Vehiculo.Tipo)}{p.Number}",
                            FechaDeVenta = p.CreatedAt,
                            Monto = p.Monto
                        })));

            CreateMap<TipoAutomovil, char>().ConvertUsing(src => TipoDeVehiculoATipoDePlaca(src));
            CreateMap<char, TipoAutomovil>().ConvertUsing(src => TipoDePlacaATipoDeVehiculo(src));
        }

        char TipoDeVehiculoATipoDePlaca(TipoAutomovil tipo) => tipo switch
        {
            TipoAutomovil.Publico => 'A',
            TipoAutomovil.Privado => 'F',
            TipoAutomovil.Transporte => 'T',
            TipoAutomovil.Pesado => 'P',
            _ => throw new NotImplementedException()
        };

        TipoAutomovil TipoDePlacaATipoDeVehiculo(char tipo) => tipo switch
        {
            'A' => TipoAutomovil.Publico,
            'F' => TipoAutomovil.Privado,
            'T' => TipoAutomovil.Transporte,
            'P' => TipoAutomovil.Pesado,
            _ => throw new NotImplementedException()
        };
    }

    public class AutoMapperService
    {
        public IMapper Mapper { get; }

        public AutoMapperService()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapper());
            });

            Mapper = mappingConfig.CreateMapper();
        }
    }
}
