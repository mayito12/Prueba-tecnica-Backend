using AutoMapper;
using Backend.DTOs.Clientes;
using Backend.DTOs.Presupuestos;
using Backend.DTOs.Productos;
using Backend.DTOs.Servicios;
using Backend.Models;

namespace Backend.Mappings;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Cliente, ClienteDto>();
        CreateMap<CreateClienteDto, Cliente>()
            .ForMember(destination => destination.Id, options => options.Ignore())
            .ForMember(destination => destination.FechaCreacion, options => options.Ignore())
            .ForMember(destination => destination.Activo, options => options.Ignore())
            .ForMember(destination => destination.Presupuestos, options => options.Ignore());
        CreateMap<UpdateClienteDto, Cliente>()
            .ForMember(destination => destination.Id, options => options.Ignore())
            .ForMember(destination => destination.FechaCreacion, options => options.Ignore())
            .ForMember(destination => destination.Activo, options => options.Ignore())
            .ForMember(destination => destination.Presupuestos, options => options.Ignore());

        CreateMap<Producto, ProductoDto>();
        CreateMap<CreateProductoDto, Producto>()
            .ForMember(destination => destination.Id, options => options.Ignore())
            .ForMember(destination => destination.FechaCreacion, options => options.Ignore())
            .ForMember(destination => destination.Activo, options => options.Ignore())
            .ForMember(destination => destination.PresupuestoProductos, options => options.Ignore());
        CreateMap<UpdateProductoDto, Producto>()
            .ForMember(destination => destination.Id, options => options.Ignore())
            .ForMember(destination => destination.FechaCreacion, options => options.Ignore())
            .ForMember(destination => destination.Activo, options => options.Ignore())
            .ForMember(destination => destination.PresupuestoProductos, options => options.Ignore());

        CreateMap<Servicio, ServicioDto>();
        CreateMap<CreateServicioDto, Servicio>()
            .ForMember(destination => destination.Id, options => options.Ignore())
            .ForMember(destination => destination.FechaCreacion, options => options.Ignore())
            .ForMember(destination => destination.Activo, options => options.Ignore())
            .ForMember(destination => destination.PresupuestoServicios, options => options.Ignore());
        CreateMap<UpdateServicioDto, Servicio>()
            .ForMember(destination => destination.Id, options => options.Ignore())
            .ForMember(destination => destination.FechaCreacion, options => options.Ignore())
            .ForMember(destination => destination.Activo, options => options.Ignore())
            .ForMember(destination => destination.PresupuestoServicios, options => options.Ignore());

        CreateMap<Presupuesto, PresupuestoDto>()
            .ForMember(destination => destination.ClienteNombre,
                options => options.MapFrom(source => source.Cliente.Nombre))
            .ForMember(destination => destination.Estado,
                options => options.MapFrom(source => source.Estado.ToString()))
            .ForMember(destination => destination.Items, options => options.Ignore());

        CreateMap<PresupuestoProducto, PresupuestoItemDto>()
            .ForMember(destination => destination.Tipo, options => options.MapFrom(_ => "Producto"))
            .ForMember(destination => destination.ItemId,
                options => options.MapFrom(source => source.ProductoId))
            .ForMember(destination => destination.NombreItem,
                options => options.MapFrom(source => source.Producto.Nombre));

        CreateMap<PresupuestoServicio, PresupuestoItemDto>()
            .ForMember(destination => destination.Tipo, options => options.MapFrom(_ => "Servicio"))
            .ForMember(destination => destination.ItemId,
                options => options.MapFrom(source => source.ServicioId))
            .ForMember(destination => destination.NombreItem,
                options => options.MapFrom(source => source.Servicio.Nombre));
    }
}
