using AutoMapper;
using AutoMapper.Configuration;
using HDS.Domain.DTOs;
using HDS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Utility
{
    public static class MappingExtensions
    {
        private static bool _initialized = false;

        private static void Init()
        {
            if (!_initialized)
            {
                _initialized = true;
                var cfg = new MapperConfigurationExpression();

                #region Mappings


                #region Address
                cfg.CreateMap<CreateAddressDto, Address>();
                cfg.CreateMap<Address, AddressDto>();
                #endregion
                #region AddressType
                cfg.CreateMap<AddressType, AddressTypeDto>();
                #endregion
                #region ContactMethod
                cfg.CreateMap<CreateContactMethodDto, ContactMethod>();
                cfg.CreateMap<ContactMethod, ContactMethodDto>();
                #endregion
                #region ContactMethodType
                cfg.CreateMap<ContactMethodType, ContactMethodTypeDto>();
                #endregion
                #region Customer
                cfg.CreateMap<CreateCustomerDto, Customer>();
                cfg.CreateMap<Customer, CustomerDto>();
                #endregion
                #region EntityAddress
                cfg.CreateMap<CreateEntityAddressDto, EntityAddress>();
                cfg.CreateMap<EntityAddress, EntityAddressDto>();
                #endregion
                #region EntityType
                cfg.CreateMap<EntityType, EntityTypeDto>();
                #endregion

                #endregion

                Mapper.Initialize(cfg);
            }
        }

        #region Address
        public static Address ToEntity(this CreateAddressDto dto)
        {
            Init();
            return Mapper.Map<Address>(dto);
        }
        public static AddressDto ToDto(this Address entity)
        {
            Init();
            return Mapper.Map<AddressDto>(entity);
        }
        #endregion
        #region AddressType
        public static AddressTypeDto ToDto(this AddressType entity)
        {
            Init();
            return Mapper.Map<AddressTypeDto>(entity);
        }
        #endregion
        #region ContactMethod
        public static ContactMethod ToEntity(this CreateContactMethodDto dto)
        {
            Init();
            return Mapper.Map<ContactMethod>(dto);
        }
        public static ContactMethodDto ToDto(this ContactMethod entity)
        {
            Init();
            return Mapper.Map<ContactMethodDto>(entity);
        }
        #endregion
        #region ContactMethodType
        public static ContactMethodTypeDto ToDto(this ContactMethodType entity)
        {
            Init();
            return Mapper.Map<ContactMethodTypeDto>(entity);
        }
        #endregion
        #region Customer
        public static Customer ToEntity(this CreateCustomerDto dto)
        {
            Init();
            return Mapper.Map<Customer>(dto);
        }
        public static CustomerDto ToDto(this Customer entity)
        {
            Init();
            return Mapper.Map<CustomerDto>(entity);
        }
        #endregion
        #region EntityAddress
        public static EntityAddress ToEntity(this CreateEntityAddressDto dto)
        {
            Init();
            return Mapper.Map<EntityAddress>(dto);
        }
        public static EntityAddressDto ToDto(this EntityAddress entity)
        {
            Init();
            return Mapper.Map<EntityAddressDto>(entity);
        }
        #endregion
        #region EntityType
        public static EntityTypeDto ToDto(this EntityType entity)
        {
            Init();
            return Mapper.Map<EntityTypeDto>(entity);
        }
        #endregion
    }
}
