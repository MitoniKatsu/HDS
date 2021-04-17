using AutoMapper;
using AutoMapper.Configuration;
using HDS.Domain.DTOs;
using HDS.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                cfg.CreateMap<AddressType, AddressTypeDetailsDto>();
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
                cfg.CreateMap<ContactMethodType, ContactMethodTypeDetailsDto>();
                #endregion
                #region Customer
                cfg.CreateMap<CreateCustomerDto, Customer>();
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<Customer, CustomerVerboseDto>();
                #endregion
                #region EntityAddress
                cfg.CreateMap<CreateCustomerAddressDto, CustomerAddress>();
                cfg.CreateMap<CustomerAddress, CustomerAddressDto>();
                cfg.CreateMap<CreateEmployeeAddressDto, EmployeeAddress>();
                cfg.CreateMap<EmployeeAddress, EmployeeAddressDto>();
                cfg.CreateMap<CreateStoreAddressDto, StoreAddress>();
                cfg.CreateMap<StoreAddress, StoreAddressDto>();
                #endregion
                #region Employee
                cfg.CreateMap<CreateEmployeeDto, Employee>();
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Employee, EmployeeVerboseDto>();
                #endregion
                #region EmployeePosition
                cfg.CreateMap<CreateEmployeePositionDto, EmployeePosition>();
                cfg.CreateMap<EmployeePosition, EmployeePositionDto>();
                cfg.CreateMap<EmployeePosition, EmployeePositionEmployeeQueryDto>();
                cfg.CreateMap<EmployeePosition, EmployeePositionStoreRoleQueryDto>()
                    .ForMember(d => d.FirstName, o => o.MapFrom(s => s.Employee.FirstName))
                    .ForMember(d => d.LastName, o => o.MapFrom(s => s.Employee.LastName));
                #endregion
                #region Inventory
                cfg.CreateMap<CreateInventoryDto, Inventory>();
                cfg.CreateMap<Inventory, InventoryVerboseDto>();
                cfg.CreateMap<Inventory, InventoryDto>();
                #endregion
                #region Store
                cfg.CreateMap<CreateStoreDto, Store>();
                cfg.CreateMap<Store, BaseStoreDto>();
                cfg.CreateMap<Store, StoreDto>();
                cfg.CreateMap<Store, StoreVerboseDto>();
                #endregion
                #region StoreRole
                cfg.CreateMap<CreateStoreRoleDto, StoreRole>();
                cfg.CreateMap<StoreRole, BaseStoreRoleDto>();
                cfg.CreateMap<StoreRole, StoreRoleDto>();
                cfg.CreateMap<StoreRole, StoreRoleVerboseDto>();
                cfg.CreateMap<StoreRole, StoreRoleStoreQueryDto>();
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
            entity.Updated = DateTime.UtcNow;
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
            entity.Updated = DateTime.UtcNow;
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
        public static CustomerVerboseDto ToVerboseDto(this Customer entity)
        {
            Init();
            return Mapper.Map<CustomerVerboseDto>(entity);
        }
        public static void Merge(this Customer entity, CustomerDto dto)
        {
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.Updated = DateTime.UtcNow;
        }
        #endregion
        #region Employee
        public static Employee ToEntity(this CreateEmployeeDto dto)
        {
            Init();
            return Mapper.Map<Employee>(dto);
        }
        public static EmployeeDto ToDto(this Employee entity)
        {
            Init();
            return Mapper.Map<EmployeeDto>(entity);
        }
        public static EmployeeVerboseDto ToVerboseDto(this Employee entity)
        {
            Init();
            return Mapper.Map<EmployeeVerboseDto>(entity);
        }
        public static void Merge(this Employee entity, EmployeeDto dto)
        {
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.Updated = DateTime.UtcNow;
        }
        #endregion
        #region EmployeePosition
        public static EmployeePosition ToEntity(this CreateEmployeePositionDto dto)
        {
            Init();
            return Mapper.Map<EmployeePosition>(dto);
        }
        public static EmployeePositionDto ToDto(this EmployeePosition entity)
        {
            Init();
            return Mapper.Map<EmployeePositionDto>(entity);
        }
        public static EmployeePositionEmployeeQueryDto ToEmployeeQueryDto(this EmployeePosition entity)
        {
            Init();
            return Mapper.Map<EmployeePositionEmployeeQueryDto>(entity);
        }
        public static EmployeePositionStoreRoleQueryDto ToStoreRoleDto(this EmployeePosition entity)
        {
            Init();
            return Mapper.Map<EmployeePositionStoreRoleQueryDto>(entity);
        }
        public static void Merge(this EmployeePosition entity, UpdateEmployeePositionDto dto)
        {
            entity.EmployeeID = dto.EmployeeID;
            entity.PositionID = dto.PositionID;
            entity.Updated = DateTime.UtcNow;
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
            entity.Updated = DateTime.UtcNow;
        }
        #endregion
        #region Inventory
        public static Inventory ToEntity(this CreateInventoryDto dto)
        {
            Init();
            return Mapper.Map<Inventory>(dto);
        }
        public static InventoryDto ToDto(this Inventory entity)
        {
            Init();
            return Mapper.Map<InventoryDto>(entity);
        }
        public static InventoryVerboseDto ToVerboseDto(this Inventory entity)
        {
            Init();
            return Mapper.Map<InventoryVerboseDto>(entity);
        }
        public static void Merge(this Inventory entity, UpdateInventoryDto dto)
        {
            entity.Model = dto.Model;
            entity.Brand = dto.Brand;
            entity.ProductDescription = dto.ProductDescription;
            entity.LocationID = dto.LocationID;
            entity.SerialNumber = dto.SerialNumber;
            entity.Cost = dto.Cost;
            entity.Price = dto.Price;
            entity.Updated = DateTime.UtcNow;
        }
        #endregion
        #region Store
        public static Store ToEntity(this CreateStoreDto dto)
        {
            Init();
            return Mapper.Map<Store>(dto);
        }
        public static StoreDto ToDto(this Store entity)
        {
            Init();
            return Mapper.Map<StoreDto>(entity);
        }public static StoreVerboseDto ToVerboseDto(this Store entity)
        {
            Init();
            return Mapper.Map<StoreVerboseDto>(entity);
        }
        public static void Merge(this Store entity, StoreDto dto)
        {
            entity.StoreName = dto.StoreName;
            entity.Updated = DateTime.UtcNow;
        }
        #endregion
        #region StoreRole
        public static StoreRole ToEntity(this CreateStoreRoleDto dto)
        {
            Init();
            return Mapper.Map<StoreRole>(dto);
        }
        public static StoreRoleDto ToDto(this StoreRole entity)
        {
            Init();
            return Mapper.Map<StoreRoleDto>(entity);
        }
        public static StoreRoleStoreQueryDto ToStoreQueryDto(this StoreRole entity)
        {
            Init();
            return Mapper.Map<StoreRoleStoreQueryDto>(entity);
        }
        public static StoreRoleVerboseDto ToVerboseDto(this StoreRole entity)
        {
            Init();
            return Mapper.Map<StoreRoleVerboseDto>(entity);
        }
        public static void Merge(this StoreRole entity, StoreRoleDto dto)
        {
            entity.StoreID = dto.StoreID;
            entity.RoleDescription = dto.RoleDescription;
            entity.Updated = DateTime.UtcNow;
        }
        #endregion
        #endregion
    }
}
