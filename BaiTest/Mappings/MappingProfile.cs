using AutoMapper;
using BaiTest.DTOs;
using BaiTest.Models;

namespace BaiTest.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // DTO → Entity
            CreateMap<CreateCustomerDTO, Customer>();
            CreateMap<UpdateCustomerDTO, Customer>();

            // Entity → DTO
            CreateMap<Customer, ResponseCustomerDTO>();


            CreateMap<CreateOrderDTO, Order>();
            CreateMap<UpdateOrderDTO, Order>();
            CreateMap<Order, ResponseOrderDTO.OrderDetailDto>()
                .ForMember(dest => dest.CustomerName,
                           opt => opt.MapFrom(src => src.Customer.FullName));


            // OrderItem
            CreateMap<OrderItem, ResponseOrderDTO.OrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));
            CreateMap<CreateOrderItemDTO, OrderItem>();
            CreateMap<UpdateOrderItemDTO, OrderItem>();


            CreateMap<Order, ResponseOrderDTO.OrderDetailDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItem));
            CreateMap<CreateOrderDTO, Order>();
            CreateMap<UpdateOrderDTO, Order>();



            CreateMap<Product, ProductResponseDTO>();
            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();
        }
    }
}
