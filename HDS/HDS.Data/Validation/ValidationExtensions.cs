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

        public static void ValidateData(this IHDSContext context, UpdateCustomerDetailsDto dto)
        {
            var errors = new StringBuilder();
            // CustomerID
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
                // AddressID
                errors.AddIfExists(context.KeyExists<Address>(dto.Address.AddressID, ValidationMessages.AddressIDNotFound));
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

    public class ValidationException : Exception
    {
        public ValidationException() : base()
        {

        }

        public ValidationException(string errorMessage) : base(errorMessage)
        {

        }
    }
}
