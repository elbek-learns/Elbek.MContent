﻿using Elbek.MContent.Services.Models;

namespace Elbek.MContent.Services.ValidationServices.AuthorValidator
{
    //https://github.com/aspnet/samples/blob/main/samples/aspnet/WebApi/ValidationSample/ValidationSample/Validators/NonNegativeAttribute.cs
    public interface IAuthorValidationRules : IGenericValidationRules
    {

    }
    public class AuthorValidationRules : GenericValidationRules, IAuthorValidationRules
    {
       
    }
}