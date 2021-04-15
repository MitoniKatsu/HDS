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
                cfg.CreateMap<CreateCustomerContactDto, CustomerContact>();
                cfg.CreateMap<CustomerContact, CustomerContactDto>();
                cfg.CreateMap<CreateEmployeeContactDto, EmployeeContact>();
                cfg.CreateMap<EmployeeContact, EmployeeContactDto>();
                cfg.CreateMap<CreateStoreContactDto, StoreContact>();
                cfg.CreateMap<StoreContact, StoreContactDto>();
                #endregion
                #region ContactMethodType
                cfg.CreateMap<ContactMethodType, ContactMethodTypeDto>();
                #endregion
                #region Customer
                cfg.CreateMap<CreateCustomerDto, Customer>();
                cfg.CreateMap<Customer, CustomerDto>();
                #endregion
                #region EntityAddress
                cfg.CreateMap<CreateCustomerAddressDto, CustomerAddress>();
                cfg.CreateMap<CustomerAddress, CustomerAddressDto>();
                cfg.CreateMap<CreateEmployeeAddressDto, EmployeeAddress>();
                cfg.CreateMap<EmployeeAddress, EmployeeAddressDto>();
                cfg.CreateMap<CreateStoreAddressDto, StoreAddress>();
                cfg.CreateMap<StoreAddress, StoreAddressDto>();
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
        public static void Merge(this Address entity, AddressDto dto)
        {
            entity.StreetAddress = dto.StreetAddress;
            entity.City = dto.City;
            entity.State = dto.State;
            entity.PostalCode = dto.PostalCode;
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
        public static CustomerContact ToEntity(this CreateCustomerContactDto dto)
        {
            Init();
            return Mapper.Map<CustomerContact>(dto);
        }
        public static CustomerContactDto ToDto(this CustomerContact entity)
        {
            Init();
            return Mapper.Map<CustomerContactDto>(entity);
        }
        public static EmployeeContact ToEntity(this CreateEmployeeContactDto dto)
        {
            Init();
            return Mapper.Map<EmployeeContact>(dto);
        }
        public static EmployeeContactDto ToDto(this EmployeeContact entity)
        {
            Init();
            return Mapper.Map<EmployeeContactDto>(entity);
        }
        public static StoreContact ToEntity(this CreateStoreContactDto dto)
        {
            Init();
            return Mapper.Map<StoreContact>(dto);
        }
        public static StoreContactDto ToDto(this StoreContact entity)
        {
            Init();
            return Mapper.Map<StoreContactDto>(entity);
        }
        public static void Merge(this ContactMethod entity, UpdateContactMethodDto dto)
        {
            entity.ContactMethodTypeID = dto.ContactMethodTypeID;
            entity.ContactMethodValue = dto.ContactMethodValue;
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
        public static void Merge(this Customer entity, UpdateCustomerDetailsDto dto)
        {
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
        }
        #endregion
        #region EntityAddress
        public static CustomerAddress ToEntity(this CreateCustomerAddressDto dto)
        {
            Init();
            return Mapper.Map<CustomerAddress>(dto);
        }
        public static CustomerAddressDto ToDto(this CustomerAddress entity)
        {
            Init();
            return Mapper.Map<CustomerAddressDto>(entity);
        }
        public static EmployeeAddress ToEntity(this CreateEmployeeAddressDto dto)
        {
            Init();
            return Mapper.Map<EmployeeAddress>(dto);
        }
        public static EmployeeAddressDto ToDto(this EmployeeAddress entity)
        {
            Init();
            return Mapper.Map<EmployeeAddressDto>(entity);
        }
        public static StoreAddress ToEntity(this CreateStoreAddressDto dto)
        {
            Init();
            return Mapper.Map<StoreAddress>(dto);
        }
        public static StoreAddressDto ToDto(this StoreAddress entity)
        {
            Init();
            return Mapper.Map<StoreAddressDto>(entity);
        }
        public static void Merge(this EntityAddress entity, UpdateEntityAddressDto dto)
        {
            entity.AddressTypeID = dto.AddressTypeID;
            entity.Primary = dto.Primary ?? false;
            entity.Address.Merge(dto.Address);
        }
        #endregion
    }
}
