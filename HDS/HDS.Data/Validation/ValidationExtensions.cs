using HDS.Data;
using HDS.Domain.DTOs;
using HDS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDS.Domain.Utility
{
    public static class ValidationExtensions
    {
        #region ContactMethod
        public static void ValidateData(this IHDSContext context, CreateCustomerContactDto dto, int id)
        {
            var errors = new StringBuilder();
            // CustomerID
            errors.AddIfExists(context.KeyExists<Customer>(id, ValidationMessages.CustomerIDNotFound));
            // ContactMethodTypeID
            errors.AddIfExists(dto.ContactMethodTypeID.ValidateRequired(ValidationMessages.ContactMethodTypeIDRequired));
            errors.AddIfExists(context.KeyExists<ContactMethodType>(dto.ContactMethodTypeID, ValidationMessages.ContactMethodTypeIDNotFound));
            // ContactMethod Value
            errors.AddIfExists(dto.ContactMethodValue.ValidateRequired(ValidationMessages.ContactMethodValueRequired));
            errors.AddIfExists(dto.ContactMethodValue.ValidateLength(100, ValidationMessages.ContactMethodValueLength));

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }

        public static void ValidateData(this IHDSContext context, CreateEmployeeContactDto dto, int id)
        {
            var errors = new StringBuilder();
            // EmployeeID
            errors.AddIfExists(context.KeyExists<Employee>(id, ValidationMessages.EmployeeIDNotFound));
            // ContactMethodTypeID
            errors.AddIfExists(dto.ContactMethodTypeID.ValidateRequired(ValidationMessages.ContactMethodTypeIDRequired));
            errors.AddIfExists(context.KeyExists<ContactMethodType>(dto.ContactMethodTypeID, ValidationMessages.ContactMethodTypeIDNotFound));
            // ContactMethod Value
            errors.AddIfExists(dto.ContactMethodValue.ValidateRequired(ValidationMessages.ContactMethodValueRequired));
            errors.AddIfExists(dto.ContactMethodValue.ValidateLength(100, ValidationMessages.ContactMethodValueLength));

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }

        public static void ValidateData(this IHDSContext context, CreateStoreContactDto dto, int id)
        {
            var errors = new StringBuilder();
            // StoreID
            errors.AddIfExists(context.KeyExists<Store>(id, ValidationMessages.StoreIDNotFound));
            // ContactMethodTypeID
            errors.AddIfExists(dto.ContactMethodTypeID.ValidateRequired(ValidationMessages.ContactMethodTypeIDRequired));
            errors.AddIfExists(context.KeyExists<ContactMethodType>(dto.ContactMethodTypeID, ValidationMessages.ContactMethodTypeIDNotFound));
            // ContactMethod Value
            errors.AddIfExists(dto.ContactMethodValue.ValidateRequired(ValidationMessages.ContactMethodValueRequired));
            errors.AddIfExists(dto.ContactMethodValue.ValidateLength(100, ValidationMessages.ContactMethodValueLength));

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }

        public static void ValidateData(this IHDSContext context, UpdateContactMethodDto dto)
        {
            var errors = new StringBuilder();
            // ContactMethodID
            errors.AddIfExists(dto.ContactMethodID.ValidateRequired(ValidationMessages.ContactMethodIDRequired));
            errors.AddIfExists(context.KeyExists<ContactMethod>(dto.ContactMethodID, ValidationMessages.ContactMethodIDNotFound));
            // ContactMethodTypeID
            errors.AddIfExists(dto.ContactMethodTypeID.ValidateRequired(ValidationMessages.ContactMethodTypeIDRequired));
            errors.AddIfExists(context.KeyExists<ContactMethodType>(dto.ContactMethodTypeID, ValidationMessages.ContactMethodTypeIDNotFound));
            // ContactMethod Value
            errors.AddIfExists(dto.ContactMethodValue.ValidateRequired(ValidationMessages.ContactMethodValueRequired));
            errors.AddIfExists(dto.ContactMethodValue.ValidateLength(100, ValidationMessages.ContactMethodValueLength));

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        #endregion
        #region Customer
        public static void ValidateData(this IHDSContext context, CreateCustomerDto dto)
        {
            var errors = new StringBuilder();
            // FirstName
            errors.AddIfExists(dto.FirstName.ValidateRequired(ValidationMessages.FirstNameRequired));
            errors.AddIfExists(dto.FirstName.ValidateLength(100, ValidationMessages.FirstNameLength));
            // LastName
            errors.AddIfExists(dto.LastName.ValidateRequired(ValidationMessages.LastNameRequired));
            errors.AddIfExists(dto.LastName.ValidateLength(100, ValidationMessages.LastNameLength));
            if (dto.Addresses != null && dto.Addresses.Any())
            {
                // Addresses
                for (int i = 0; i < dto.Addresses.Count; i++)
                {
                    if (dto.Addresses.Select(o => o.Primary).Count() > 1)
                    {
                        errors.AddIfExists(ValidationMessages.PrimaryAddressSingle);
                    }
                    // AddressTypeID
                    errors.AddIfExists(dto.Addresses[i].AddressTypeID.ValidateRequired($"Address [{i}]:{ValidationMessages.AddressTypeIDRequired}"));
                    errors.AddIfExists(context.KeyExists<AddressType>(dto.Addresses[i].AddressTypeID, $"Address [{i}]:{ValidationMessages.AddressTypeIDNotFound}"));
                    // Address
                    if (dto.Addresses[i].Address != null)
                    {
                        // Street Address
                        errors.AddIfExists(dto.Addresses[i].Address?.StreetAddress.ValidateRequired($"Address [{i}]:{ValidationMessages.StreetAddressRequired}"));
                        errors.AddIfExists(dto.Addresses[i].Address?.StreetAddress.ValidateLength(100, $"Address [{i}]:{ValidationMessages.StreetAddressRequired}"));
                        // City
                        errors.AddIfExists(dto.Addresses[i].Address?.City.ValidateRequired($"Address [{i}]:{ValidationMessages.CityRequired}"));
                        errors.AddIfExists(dto.Addresses[i].Address?.City.ValidateLength(50, $"Address [{i}]:{ValidationMessages.CityLength}"));
                        // State
                        errors.AddIfExists(dto.Addresses[i].Address?.State.ValidateRequired($"Address [{i}]:{ValidationMessages.StateRequired}"));
                        errors.AddIfExists(dto.Addresses[i].Address?.State.ValidateLength(50, $"Address [{i}]:{ValidationMessages.StateLength}"));
                        // PostCode
                        errors.AddIfExists(dto.Addresses[i].Address?.PostalCode.ValidateRequired($"Address [{i}]:{ValidationMessages.PostalCodeRequired}"));
                        errors.AddIfExists(dto.Addresses[i].Address?.PostalCode.ValidateLength(10, $"Address [{i}]:{ValidationMessages.PostalCodeLength}"));
                    }
                    else
                    {
                        errors.AddIfExists($"Address [{i}]:{ValidationMessages.AddressRequired}");
                    }
                }
            }
            if (dto.ContactMethods != null && dto.ContactMethods.Any())
            {
                // ContactMethods
                for (int i = 0; i < dto.ContactMethods.Count; i++)
                {
                    // ContactMethodTypeID
                    errors.AddIfExists(dto.ContactMethods[i].ContactMethodTypeID.ValidateRequired($"ContactMethod [{i}]:{ValidationMessages.ContactMethodTypeIDRequired}"));
                    errors.AddIfExists(context.KeyExists<ContactMethodType>(dto.ContactMethods[i].ContactMethodTypeID, $"ContactMethod [{i}]:{ValidationMessages.ContactMethodTypeIDNotFound}"));
                    // ContactMethod Value
                    errors.AddIfExists(dto.ContactMethods[i].ContactMethodValue.ValidateRequired($"ContactMethod [{i}]:{ValidationMessages.ContactMethodValueRequired}"));
                    errors.AddIfExists(dto.ContactMethods[i].ContactMethodValue.ValidateLength(100, $"ContactMethod [{i}]:{ValidationMessages.ContactMethodValueLength}"));
                }
            }

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }

        public static void ValidateData(this IHDSContext context, CustomerDto dto)
        {
            var errors = new StringBuilder();
            // CustomerID
            errors.AddIfExists(dto.CustomerID.ValidateRequired(ValidationMessages.CustomerIDRequired));
            errors.AddIfExists(context.KeyExists<Customer>(dto.CustomerID, ValidationMessages.CustomerIDNotFound));
            // FirstName
            errors.AddIfExists(dto.FirstName.ValidateRequired(ValidationMessages.FirstNameRequired));
            errors.AddIfExists(dto.FirstName.ValidateLength(100, ValidationMessages.FirstNameLength));
            // LastName
            errors.AddIfExists(dto.LastName.ValidateRequired(ValidationMessages.LastNameRequired));
            errors.AddIfExists(dto.LastName.ValidateLength(100, ValidationMessages.LastNameLength));

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        #endregion
        #region Employee
        public static void ValidateData(this IHDSContext context, CreateEmployeeDto dto)
        {
            var errors = new StringBuilder();
            // FirstName
            errors.AddIfExists(dto.FirstName.ValidateRequired(ValidationMessages.FirstNameRequired));
            errors.AddIfExists(dto.FirstName.ValidateLength(100, ValidationMessages.FirstNameLength));
            // LastName
            errors.AddIfExists(dto.LastName.ValidateRequired(ValidationMessages.LastNameRequired));
            errors.AddIfExists(dto.LastName.ValidateLength(100, ValidationMessages.LastNameLength));
            if (dto.Addresses != null && dto.Addresses.Any())
            {
                // Addresses
                for (int i = 0; i < dto.Addresses.Count; i++)
                {
                    if (dto.Addresses.Select(o => o.Primary).Count() > 1)
                    {
                        errors.AddIfExists(ValidationMessages.PrimaryAddressSingle);
                    }
                    // AddressTypeID
                    errors.AddIfExists(dto.Addresses[i].AddressTypeID.ValidateRequired($"Address [{i}]:{ValidationMessages.AddressTypeIDRequired}"));
                    errors.AddIfExists(context.KeyExists<AddressType>(dto.Addresses[i].AddressTypeID, $"Address [{i}]:{ValidationMessages.AddressTypeIDNotFound}"));
                    // Address
                    if (dto.Addresses[i].Address != null)
                    {
                        // Street Address
                        errors.AddIfExists(dto.Addresses[i].Address?.StreetAddress.ValidateRequired($"Address [{i}]:{ValidationMessages.StreetAddressRequired}"));
                        errors.AddIfExists(dto.Addresses[i].Address?.StreetAddress.ValidateLength(100, $"Address [{i}]:{ValidationMessages.StreetAddressRequired}"));
                        // City
                        errors.AddIfExists(dto.Addresses[i].Address?.City.ValidateRequired($"Address [{i}]:{ValidationMessages.CityRequired}"));
                        errors.AddIfExists(dto.Addresses[i].Address?.City.ValidateLength(50, $"Address [{i}]:{ValidationMessages.CityLength}"));
                        // State
                        errors.AddIfExists(dto.Addresses[i].Address?.State.ValidateRequired($"Address [{i}]:{ValidationMessages.StateRequired}"));
                        errors.AddIfExists(dto.Addresses[i].Address?.State.ValidateLength(50, $"Address [{i}]:{ValidationMessages.StateLength}"));
                        // PostCode
                        errors.AddIfExists(dto.Addresses[i].Address?.PostalCode.ValidateRequired($"Address [{i}]:{ValidationMessages.PostalCodeRequired}"));
                        errors.AddIfExists(dto.Addresses[i].Address?.PostalCode.ValidateLength(10, $"Address [{i}]:{ValidationMessages.PostalCodeLength}"));
                    }
                    else
                    {
                        errors.AddIfExists($"Address [{i}]:{ValidationMessages.AddressRequired}");
                    }
                }
            }
            if (dto.ContactMethods != null && dto.ContactMethods.Any())
            {
                // ContactMethods
                for (int i = 0; i < dto.ContactMethods.Count; i++)
                {
                    // ContactMethodTypeID
                    errors.AddIfExists(dto.ContactMethods[i].ContactMethodTypeID.ValidateRequired($"ContactMethod [{i}]:{ValidationMessages.ContactMethodTypeIDRequired}"));
                    errors.AddIfExists(context.KeyExists<ContactMethodType>(dto.ContactMethods[i].ContactMethodTypeID, $"ContactMethod [{i}]:{ValidationMessages.ContactMethodTypeIDNotFound}"));
                    // ContactMethod Value
                    errors.AddIfExists(dto.ContactMethods[i].ContactMethodValue.ValidateRequired($"ContactMethod [{i}]:{ValidationMessages.ContactMethodValueRequired}"));
                    errors.AddIfExists(dto.ContactMethods[i].ContactMethodValue.ValidateLength(100, $"ContactMethod [{i}]:{ValidationMessages.ContactMethodValueLength}"));
                }
            }

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }

        public static void ValidateData(this IHDSContext context, EmployeeDto dto)
        {
            var errors = new StringBuilder();
            // CustomerID
            errors.AddIfExists(dto.EmployeeID.ValidateRequired(ValidationMessages.EmployeeIDRequired));
            errors.AddIfExists(context.KeyExists<Employee>(dto.EmployeeID, ValidationMessages.EmployeeIDNotFound));
            // FirstName
            errors.AddIfExists(dto.FirstName.ValidateRequired(ValidationMessages.FirstNameRequired));
            errors.AddIfExists(dto.FirstName.ValidateLength(100, ValidationMessages.FirstNameLength));
            // LastName
            errors.AddIfExists(dto.LastName.ValidateRequired(ValidationMessages.LastNameRequired));
            errors.AddIfExists(dto.LastName.ValidateLength(100, ValidationMessages.LastNameLength));

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        #endregion
        #region EmployeePosition
        public static void ValidateData(this IHDSContext context, CreateEmployeePositionDto dto, int id)
        {
            var errors = new StringBuilder();
            // PositionID
            errors.AddIfExists(id.ValidateRequired(ValidationMessages.StoreRoleIDRequired));
            errors.AddIfExists(context.KeyExists<StoreRole>(id, ValidationMessages.StoreRoleIDNotFound));
            // EmployeeID
            errors.AddIfExists(dto.EmployeeID.ValidateRequired(ValidationMessages.EmployeeIDRequired));
            errors.AddIfExists(context.KeyExists<Employee>(dto.EmployeeID, ValidationMessages.EmployeeIDNotFound));

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        public static void ValidateData(this IHDSContext context, UpdateEmployeePositionDto dto)
        {
            var errors = new StringBuilder();
            // EmployeePositionID
            errors.AddIfExists(dto.EmployeePositionID.ValidateRequired(ValidationMessages.EmployeePositionIDRequired));
            errors.AddIfExists(context.KeyExists<EmployeePosition>(dto.EmployeePositionID, ValidationMessages.EmployeePositionIDNotFound));
            // PositionID
            errors.AddIfExists(dto.PositionID.ValidateRequired(ValidationMessages.StoreRoleIDRequired));
            errors.AddIfExists(context.KeyExists<StoreRole>(dto.PositionID, ValidationMessages.StoreRoleIDNotFound));
            // EmployeeID
            errors.AddIfExists(dto.EmployeeID.ValidateRequired(ValidationMessages.EmployeeIDRequired));
            errors.AddIfExists(context.KeyExists<Employee>(dto.EmployeeID, ValidationMessages.EmployeeIDNotFound));

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        #endregion
        #region EntityAddress
        public static void ValidateData(this IHDSContext context, CreateCustomerAddressDto dto, int id)
        {
            var errors = new StringBuilder();
            // CustomerID
            errors.AddIfExists(context.KeyExists<Customer>(id, ValidationMessages.CustomerIDNotFound));
            // AddressTypeID
            errors.AddIfExists(dto.AddressTypeID.ValidateRequired(ValidationMessages.AddressTypeIDRequired));
            errors.AddIfExists(context.KeyExists<AddressType>(dto.AddressTypeID, ValidationMessages.AddressTypeIDNotFound));
            // Address
            if (dto.Address != null)
            {
                // Street Address
                errors.AddIfExists(dto.Address?.StreetAddress.ValidateRequired(ValidationMessages.StreetAddressRequired));
                errors.AddIfExists(dto.Address?.StreetAddress.ValidateLength(100, ValidationMessages.StreetAddressRequired));
                // City
                errors.AddIfExists(dto.Address?.City.ValidateRequired(ValidationMessages.CityRequired));
                errors.AddIfExists(dto.Address?.City.ValidateLength(50, ValidationMessages.CityLength));
                // State
                errors.AddIfExists(dto.Address?.State.ValidateRequired(ValidationMessages.StateRequired));
                errors.AddIfExists(dto.Address?.State.ValidateLength(50, ValidationMessages.StateLength));
                // PostCode
                errors.AddIfExists(dto.Address?.PostalCode.ValidateRequired(ValidationMessages.PostalCodeRequired));
                errors.AddIfExists(dto.Address?.PostalCode.ValidateLength(10, ValidationMessages.PostalCodeLength));
            }
            else
            {
                errors.AddIfExists(ValidationMessages.AddressRequired);
            }

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }

        public static void ValidateData(this IHDSContext context, CreateEmployeeAddressDto dto, int id)
        {
            var errors = new StringBuilder();
            // EmployeeID
            errors.AddIfExists(context.KeyExists<Employee>(id, ValidationMessages.EmployeeIDNotFound));
            // AddressTypeID
            errors.AddIfExists(dto.AddressTypeID.ValidateRequired(ValidationMessages.AddressTypeIDRequired));
            errors.AddIfExists(context.KeyExists<AddressType>(dto.AddressTypeID, ValidationMessages.AddressTypeIDNotFound));
            // Address
            if (dto.Address != null)
            {
                // Street Address
                errors.AddIfExists(dto.Address?.StreetAddress.ValidateRequired(ValidationMessages.StreetAddressRequired));
                errors.AddIfExists(dto.Address?.StreetAddress.ValidateLength(100, ValidationMessages.StreetAddressRequired));
                // City
                errors.AddIfExists(dto.Address?.City.ValidateRequired(ValidationMessages.CityRequired));
                errors.AddIfExists(dto.Address?.City.ValidateLength(50, ValidationMessages.CityLength));
                // State
                errors.AddIfExists(dto.Address?.State.ValidateRequired(ValidationMessages.StateRequired));
                errors.AddIfExists(dto.Address?.State.ValidateLength(50, ValidationMessages.StateLength));
                // PostCode
                errors.AddIfExists(dto.Address?.PostalCode.ValidateRequired(ValidationMessages.PostalCodeRequired));
                errors.AddIfExists(dto.Address?.PostalCode.ValidateLength(10, ValidationMessages.PostalCodeLength));
            }
            else
            {
                errors.AddIfExists(ValidationMessages.AddressRequired);
            }

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }

        public static void ValidateData(this IHDSContext context, CreateStoreAddressDto dto, int id)
        {
            var errors = new StringBuilder();
            // StoreID
            errors.AddIfExists(context.KeyExists<Store>(id, ValidationMessages.StoreIDNotFound));
            // AddressTypeID
            errors.AddIfExists(dto.AddressTypeID.ValidateRequired(ValidationMessages.AddressTypeIDRequired));
            errors.AddIfExists(context.KeyExists<AddressType>(dto.AddressTypeID, ValidationMessages.AddressTypeIDNotFound));
            // Address
            if (dto.Address != null)
            {
                // Street Address
                errors.AddIfExists(dto.Address?.StreetAddress.ValidateRequired(ValidationMessages.StreetAddressRequired));
                errors.AddIfExists(dto.Address?.StreetAddress.ValidateLength(100, ValidationMessages.StreetAddressRequired));
                // City
                errors.AddIfExists(dto.Address?.City.ValidateRequired(ValidationMessages.CityRequired));
                errors.AddIfExists(dto.Address?.City.ValidateLength(50, ValidationMessages.CityLength));
                // State
                errors.AddIfExists(dto.Address?.State.ValidateRequired(ValidationMessages.StateRequired));
                errors.AddIfExists(dto.Address?.State.ValidateLength(50, ValidationMessages.StateLength));
                // PostCode
                errors.AddIfExists(dto.Address?.PostalCode.ValidateRequired(ValidationMessages.PostalCodeRequired));
                errors.AddIfExists(dto.Address?.PostalCode.ValidateLength(10, ValidationMessages.PostalCodeLength));
            }
            else
            {
                errors.AddIfExists(ValidationMessages.AddressRequired);
            }

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        public static void ValidateData(this IHDSContext context, UpdateEntityAddressDto dto)
        {
            var errors = new StringBuilder();
            // EntityAddressID
            errors.AddIfExists(context.KeyExists<EntityAddress>(dto.EntityAddressID, ValidationMessages.EntityAddressIDNotFound));
            // AddressTypeID
            errors.AddIfExists(dto.AddressTypeID.ValidateRequired(ValidationMessages.AddressTypeIDRequired));
            errors.AddIfExists(context.KeyExists<AddressType>(dto.AddressTypeID, ValidationMessages.AddressTypeIDNotFound));
            // Address
            if (dto.Address != null)
            {
                // Street Address
                errors.AddIfExists(dto.Address?.StreetAddress.ValidateRequired(ValidationMessages.StreetAddressRequired));
                errors.AddIfExists(dto.Address?.StreetAddress.ValidateLength(100, ValidationMessages.StreetAddressRequired));
                // City
                errors.AddIfExists(dto.Address?.City.ValidateRequired(ValidationMessages.CityRequired));
                errors.AddIfExists(dto.Address?.City.ValidateLength(50, ValidationMessages.CityLength));
                // State
                errors.AddIfExists(dto.Address?.State.ValidateRequired(ValidationMessages.StateRequired));
                errors.AddIfExists(dto.Address?.State.ValidateLength(50, ValidationMessages.StateLength));
                // PostCode
                errors.AddIfExists(dto.Address?.PostalCode.ValidateRequired(ValidationMessages.PostalCodeRequired));
                errors.AddIfExists(dto.Address?.PostalCode.ValidateLength(10, ValidationMessages.PostalCodeLength));
            }
            else
            {
                errors.AddIfExists(ValidationMessages.AddressRequired);
            }

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        #endregion
        #region Inventory
        public static void ValidateData(this IHDSContext context, CreateInventoryDto dto)
        {
            var errors = new StringBuilder();
            // Model
            errors.AddIfExists(dto.Model.ValidateRequired(ValidationMessages.ModelRequired));
            errors.AddIfExists(dto.Model.ValidateLength(100, ValidationMessages.ModelLength));
            // Brand
            errors.AddIfExists(dto.Model.ValidateRequired(ValidationMessages.BrandRequired));
            errors.AddIfExists(dto.Model.ValidateLength(100, ValidationMessages.BrandLength));
            // SerialNumber
            errors.AddIfExists(dto.Model.ValidateLength(100, ValidationMessages.SerialNumberLength));
            // ProductDescription
            errors.AddIfExists(dto.Model.ValidateRequired(ValidationMessages.ProductDescriptionRequired));
            errors.AddIfExists(dto.Model.ValidateLength(1000, ValidationMessages.ProductDescriptionLength));
            // Cost
            errors.AddIfExists(dto.Model.ValidateRequired(ValidationMessages.CostRequired));
            // Price
            errors.AddIfExists(dto.Model.ValidateRequired(ValidationMessages.PriceRequired));
            // LocationID
            errors.AddIfExists(dto.Model.ValidateRequired(ValidationMessages.StoreIDRequired));
            errors.AddIfExists(context.KeyExists<Store>(dto.LocationID, ValidationMessages.StoreIDNotFound));

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        public static void ValidateData(this IHDSContext context, UpdateInventoryDto dto)
        {
            var errors = new StringBuilder();
            // ProductID
            errors.AddIfExists(dto.Model.ValidateRequired(ValidationMessages.ProductIDRequired));
            errors.AddIfExists(context.KeyExists<Inventory>(dto.ProductID, ValidationMessages.ProductIDNotFound));
            // Model
            errors.AddIfExists(dto.Model.ValidateRequired(ValidationMessages.ModelRequired));
            errors.AddIfExists(dto.Model.ValidateLength(100, ValidationMessages.ModelLength));
            // Brand
            errors.AddIfExists(dto.Model.ValidateRequired(ValidationMessages.BrandRequired));
            errors.AddIfExists(dto.Model.ValidateLength(100, ValidationMessages.BrandLength));
            // SerialNumber
            errors.AddIfExists(dto.Model.ValidateLength(100, ValidationMessages.SerialNumberLength));
            // ProductDescription
            errors.AddIfExists(dto.Model.ValidateRequired(ValidationMessages.ProductDescriptionRequired));
            errors.AddIfExists(dto.Model.ValidateLength(1000, ValidationMessages.ProductDescriptionLength));
            // Cost
            errors.AddIfExists(dto.Model.ValidateRequired(ValidationMessages.CostRequired));
            // Price
            errors.AddIfExists(dto.Model.ValidateRequired(ValidationMessages.PriceRequired));
            // LocationID
            errors.AddIfExists(dto.Model.ValidateRequired(ValidationMessages.StoreIDRequired));
            errors.AddIfExists(context.KeyExists<Store>(dto.LocationID, ValidationMessages.StoreIDNotFound));

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        #endregion
        #region Order
        public static void ValidateData(this IHDSContext context, CreateOrderDto dto)
        {
            var errors = new StringBuilder();
            // CustomerID
            errors.AddIfExists(dto.CustomerID.ValidateRequired(ValidationMessages.CustomerIDRequired));
            errors.AddIfExists(context.KeyExists<Customer>(dto.CustomerID, ValidationMessages.CustomerIDNotFound));
            // Employee
            errors.AddIfExists(dto.EmployeeID.ValidateRequired(ValidationMessages.EmployeeIDRequired));
            errors.AddIfExists(context.KeyExists<Employee>(dto.EmployeeID, ValidationMessages.EmployeeIDNotFound));

            if (dto.Services != null && dto.Services.Any())
            {
                // Services
                for (int i = 0; i < dto.Services.Count; i++)
                {
                    // ServiceDate
                    errors.AddIfExists(dto.Services[i].ServiceDate.ValidateFutureDate($"Service [{i}]:{ValidationMessages.ServiceDateValid}"));
                    // ServiceDescription
                    errors.AddIfExists(dto.Services[i].ServiceDescription.ValidateRequired($"Service [{i}]:{ValidationMessages.ServiceDescriptionRequired}"));
                    errors.AddIfExists(dto.Services[i].ServiceDescription.ValidateLength(400, $"Service [{i}]:{ValidationMessages.ServiceDescriptionLength}"));
                    // Price
                    errors.AddIfExists(dto.Services[i].Price.ValidatePositiveDecimal($"Service [{i}]:{ValidationMessages.PriceRequired}"));
                }
            }
            if (dto.OrderDetails != null && dto.OrderDetails.Any())
            {
                // OrderDetails
                for (int i = 0; i < dto.OrderDetails.Count; i++)
                {
                    // ProductID
                    errors.AddIfExists(dto.OrderDetails[i].ProductID.ValidateRequired($"Order Detail [{i}]:{ValidationMessages.ProductIDRequired}"));
                    errors.AddIfExists(context.KeyExists<Inventory>(dto.OrderDetails[i].ProductID, $"Order Detail [{i}]:{ValidationMessages.ProductIDNotFound}"));
                    // Quoted Price
                    errors.AddIfExists(dto.OrderDetails[i].QuotedPrice.ValidatePositiveDecimal($"Order Detail [{i}]:{ValidationMessages.PriceRequired}"));
                    // Quantity
                    errors.AddIfExists(dto.OrderDetails[i].Quantity.ValidateRequired($"Order Detail [{i}]:{ValidationMessages.QuantityRequired}"));
                    errors.AddIfExists(dto.OrderDetails[i].Quantity.ValidatePositiveInt($"Order Detail [{i}]:{ValidationMessages.QuantityValid}"));
                }
            }

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }

        public static void ValidateData(this IHDSContext context, OrderDto dto)
        {
            var errors = new StringBuilder();
            // OrderID
            errors.AddIfExists(dto.OrderID.ValidateRequired(ValidationMessages.OrderIDRequired));
            errors.AddIfExists(context.KeyExists<Customer>(dto.OrderID, ValidationMessages.OrderIDNotFound));
            // CustomerID
            errors.AddIfExists(dto.CustomerID.ValidateRequired(ValidationMessages.CustomerIDRequired));
            errors.AddIfExists(context.KeyExists<Customer>(dto.CustomerID, ValidationMessages.CustomerIDNotFound));
            // Employee
            errors.AddIfExists(dto.EmployeeID.ValidateRequired(ValidationMessages.EmployeeIDRequired));
            errors.AddIfExists(context.KeyExists<Employee>(dto.EmployeeID, ValidationMessages.EmployeeIDNotFound));

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        #endregion
        #region OrderDetails
        public static void ValidateData(this IHDSContext context, CreateOrderDetailDto dto)
        {
            var errors = new StringBuilder();
            // ProductID
            errors.AddIfExists(dto.ProductID.ValidateRequired(ValidationMessages.ProductIDRequired));
            errors.AddIfExists(context.KeyExists<Inventory>(dto.ProductID, ValidationMessages.ProductIDNotFound));
            // Quoted Price
            errors.AddIfExists(dto.QuotedPrice.ValidatePositiveDecimal(ValidationMessages.PriceRequired));
            // Quantity
            errors.AddIfExists(dto.Quantity.ValidateRequired(ValidationMessages.QuantityRequired));
            errors.AddIfExists(dto.Quantity.ValidatePositiveInt(ValidationMessages.QuantityValid));

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        public static void ValidateData(this IHDSContext context, UpdateOrderDetailDto dto)
        {
            var errors = new StringBuilder();
            // OrderDetailID
            errors.AddIfExists(dto.OrderDetailID.ValidateRequired(ValidationMessages.OrderDetailIDRequired));
            errors.AddIfExists(context.KeyExists<OrderDetail>(dto.OrderDetailID, ValidationMessages.OrderDetailIDNotFound));
            // OrderID
            errors.AddIfExists(dto.OrderID.ValidateRequired(ValidationMessages.OrderIDRequired));
            errors.AddIfExists(context.KeyExists<Order>(dto.OrderID, ValidationMessages.OrderIDNotFound));
            // ProductID
            errors.AddIfExists(dto.ProductID.ValidateRequired(ValidationMessages.ProductIDRequired));
            errors.AddIfExists(context.KeyExists<Inventory>(dto.ProductID, ValidationMessages.ProductIDNotFound));
            // Quoted Price
            errors.AddIfExists(dto.QuotedPrice.ValidatePositiveDecimal(ValidationMessages.PriceRequired));
            // Quantity
            errors.AddIfExists(dto.Quantity.ValidateRequired(ValidationMessages.QuantityRequired));
            errors.AddIfExists(dto.Quantity.ValidatePositiveInt(ValidationMessages.QuantityValid));


            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        #endregion
        #region Service
        public static void ValidateData(this CreateServiceDto dto)
        {
            var errors = new StringBuilder();
            // ServiceDate
            errors.AddIfExists(dto.ServiceDate.ValidateFutureDate(ValidationMessages.ServiceDateValid));
            // ServiceDescription
            errors.AddIfExists(dto.ServiceDescription.ValidateRequired(ValidationMessages.ServiceDescriptionRequired));
            errors.AddIfExists(dto.ServiceDescription.ValidateLength(400, ValidationMessages.ServiceDescriptionLength));
            // Price
            errors.AddIfExists(dto.Price.ValidatePositiveDecimal(ValidationMessages.PriceRequired));

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        public static void ValidateData(this IHDSContext context, UpdateServiceDto dto)
        {
            var errors = new StringBuilder();
            // ServiceID
            errors.AddIfExists(dto.ServiceID.ValidateRequired(ValidationMessages.ServiceIDRequired));
            errors.AddIfExists(context.KeyExists<Service>(dto.ServiceID, ValidationMessages.ServiceIDNotFound));
            // OrderID
            errors.AddIfExists(dto.OrderID.ValidateRequired(ValidationMessages.OrderIDRequired));
            errors.AddIfExists(context.KeyExists<Order>(dto.OrderID, ValidationMessages.OrderIDNotFound));
            // ServiceDate
            errors.AddIfExists(dto.ServiceDate.ValidateFutureDate(ValidationMessages.ServiceDateValid));
            // ServiceDescription
            errors.AddIfExists(dto.ServiceDescription.ValidateRequired(ValidationMessages.ServiceDescriptionRequired));
            errors.AddIfExists(dto.ServiceDescription.ValidateLength(400, ValidationMessages.ServiceDescriptionLength));
            // Price
            errors.AddIfExists(dto.Price.ValidatePositiveDecimal(ValidationMessages.PriceRequired));

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        #endregion
        #region Store
        public static void ValidateData(this IHDSContext context, CreateStoreDto dto)
        {
            var errors = new StringBuilder();
            // StoreName
            errors.AddIfExists(dto.StoreName.ValidateRequired(ValidationMessages.StoreNameRequired));
            errors.AddIfExists(dto.StoreName.ValidateLength(100, ValidationMessages.StoreNameLength));
            if (dto.Addresses != null && dto.Addresses.Any())
            {
                // Addresses
                for (int i = 0; i < dto.Addresses.Count; i++)
                {
                    if (dto.Addresses.Select(o => o.Primary).Count() > 1)
                    {
                        errors.AddIfExists(ValidationMessages.PrimaryAddressSingle);
                    }
                    // AddressTypeID
                    errors.AddIfExists(dto.Addresses[i].AddressTypeID.ValidateRequired($"Address [{i}]:{ValidationMessages.AddressTypeIDRequired}"));
                    errors.AddIfExists(context.KeyExists<AddressType>(dto.Addresses[i].AddressTypeID, $"Address [{i}]:{ValidationMessages.AddressTypeIDNotFound}"));
                    // Address
                    if (dto.Addresses[i].Address != null)
                    {
                        // Street Address
                        errors.AddIfExists(dto.Addresses[i].Address?.StreetAddress.ValidateRequired($"Address [{i}]:{ValidationMessages.StreetAddressRequired}"));
                        errors.AddIfExists(dto.Addresses[i].Address?.StreetAddress.ValidateLength(100, $"Address [{i}]:{ValidationMessages.StreetAddressRequired}"));
                        // City
                        errors.AddIfExists(dto.Addresses[i].Address?.City.ValidateRequired($"Address [{i}]:{ValidationMessages.CityRequired}"));
                        errors.AddIfExists(dto.Addresses[i].Address?.City.ValidateLength(50, $"Address [{i}]:{ValidationMessages.CityLength}"));
                        // State
                        errors.AddIfExists(dto.Addresses[i].Address?.State.ValidateRequired($"Address [{i}]:{ValidationMessages.StateRequired}"));
                        errors.AddIfExists(dto.Addresses[i].Address?.State.ValidateLength(50, $"Address [{i}]:{ValidationMessages.StateLength}"));
                        // PostCode
                        errors.AddIfExists(dto.Addresses[i].Address?.PostalCode.ValidateRequired($"Address [{i}]:{ValidationMessages.PostalCodeRequired}"));
                        errors.AddIfExists(dto.Addresses[i].Address?.PostalCode.ValidateLength(10, $"Address [{i}]:{ValidationMessages.PostalCodeLength}"));
                    }
                    else
                    {
                        errors.AddIfExists($"Address [{i}]:{ValidationMessages.AddressRequired}");
                    }
                }
            }
            if (dto.ContactMethods != null && dto.ContactMethods.Any())
            {
                // ContactMethods
                for (int i = 0; i < dto.ContactMethods.Count; i++)
                {
                    // ContactMethodTypeID
                    errors.AddIfExists(dto.ContactMethods[i].ContactMethodTypeID.ValidateRequired($"ContactMethod [{i}]:{ValidationMessages.ContactMethodTypeIDRequired}"));
                    errors.AddIfExists(context.KeyExists<ContactMethodType>(dto.ContactMethods[i].ContactMethodTypeID, $"ContactMethod [{i}]:{ValidationMessages.ContactMethodTypeIDNotFound}"));
                    // ContactMethod Value
                    errors.AddIfExists(dto.ContactMethods[i].ContactMethodValue.ValidateRequired($"ContactMethod [{i}]:{ValidationMessages.ContactMethodValueRequired}"));
                    errors.AddIfExists(dto.ContactMethods[i].ContactMethodValue.ValidateLength(100, $"ContactMethod [{i}]:{ValidationMessages.ContactMethodValueLength}"));
                }
            }

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        public static void ValidateData(this IHDSContext context, StoreDto dto)
        {
            var errors = new StringBuilder();
            // StoreID
            errors.AddIfExists(dto.StoreID.ValidateRequired(ValidationMessages.StoreIDRequired));
            errors.AddIfExists(context.KeyExists<Store>(dto.StoreID, ValidationMessages.StoreIDNotFound));
            // StoreName
            errors.AddIfExists(dto.StoreName.ValidateRequired(ValidationMessages.StoreNameRequired));
            errors.AddIfExists(dto.StoreName.ValidateLength(100, ValidationMessages.StoreNameLength));

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        #endregion
        #region StoreRole
        public static void ValidateData(this IHDSContext context, CreateStoreRoleDto dto)
        {
            var errors = new StringBuilder();
            // RoleDescription
            errors.AddIfExists(dto.RoleDescription.ValidateRequired(ValidationMessages.RoleDescriptionRequired));
            errors.AddIfExists(dto.RoleDescription.ValidateLength(400, ValidationMessages.RoleDescriptionLength));
            // StoreID
            errors.AddIfExists(dto.StoreID.ValidateRequired(ValidationMessages.StoreIDRequired));
            errors.AddIfExists(context.KeyExists<Store>(dto.StoreID, ValidationMessages.StoreIDNotFound));
            if (dto.EmployeePositions != null && dto.EmployeePositions.Any())
            {
                // EmployeePositions
                for (int i = 0; i < dto.EmployeePositions.Count; i++)
                {
                    // EmployeeID
                    errors.AddIfExists(dto.EmployeePositions[i].EmployeeID.ValidateRequired($"EmployeePosition [{i}]:{ValidationMessages.EmployeeIDRequired}"));
                    errors.AddIfExists(context.KeyExists<Employee>(dto.EmployeePositions[i].EmployeeID, $"EmployeePosition [{i}]:{ValidationMessages.EmployeeIDNotFound}"));
                }
            }

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        public static void ValidateData(this IHDSContext context, StoreRoleDto dto)
        {
            var errors = new StringBuilder();
            // StoreRoleID
            errors.AddIfExists(dto.StoreRoleID.ValidateRequired(ValidationMessages.StoreRoleIDRequired));
            errors.AddIfExists(context.KeyExists<Customer>(dto.StoreID, ValidationMessages.StoreRoleIDNotFound));
            // RoleDescription
            errors.AddIfExists(dto.RoleDescription.ValidateRequired(ValidationMessages.RoleDescriptionRequired));
            errors.AddIfExists(dto.RoleDescription.ValidateLength(400, ValidationMessages.RoleDescriptionLength));
            // StoreID
            errors.AddIfExists(dto.StoreID.ValidateRequired(ValidationMessages.StoreIDRequired));
            errors.AddIfExists(context.KeyExists<Store>(dto.StoreID, ValidationMessages.StoreIDNotFound));

            if (errors.Length > 0)
            {
                throw new ValidationException(errors.ToString());
            }
        }
        #endregion

        #region Helper Methods
        public static void AddIfExists(this StringBuilder errorString, string validationResult)
        {
            if (validationResult != null)
            {
                if (errorString.Length == 0)
                {
                    errorString.Append(validationResult);
                }
                else
                {
                    errorString.Append($"\n{validationResult}");
                }
            }
        }

        public static string ValidateRequired(this string property, string message)
        {
            if (string.IsNullOrEmpty(property))
            {
                return message;
            }
            return null;
        }

        public static string ValidateRequired(this int property, string message)
        {
            // Check for default initialization
            if (property == 0)
            {
                return message;
            }
            return null;
        }

        public static string ValidateLength(this string property, int maxLength, string message)
        {
            if (property?.Length > maxLength)
            {
                return message;
            }
            return null;
        }

        public static string ValidatePositiveInt(this int property, string message)
        {
            if (property <= 0)
            {
                return message;
            }
            return null;
        }

        public static string ValidatePositiveDecimal(this decimal property, string message)
        {
            if (property <= 0)
            {
                return message;
            }
            return null;
        }

        public static string ValidateFutureDate(this DateTime property, string message)
        {
            var now = DateTime.UtcNow;
            if (property < now)
            {
                return message;
            }
            return null;
        }

        public static string KeyExists<T>(this IHDSContext context, int keyToCheck, string message) where T : DataTable
        {
            if (context.Find<T>(keyToCheck) == null)
            {
                return message;
            }
            return null;
        }
        #endregion

    }
    #region ValidationException
    public class ValidationException : Exception
    {
        public ValidationException() : base()
        {

        }

        public ValidationException(string errorMessage) : base(errorMessage)
        {

        }
    }
    #endregion
}
