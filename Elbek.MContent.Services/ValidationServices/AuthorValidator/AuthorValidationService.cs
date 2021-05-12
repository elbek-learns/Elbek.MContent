﻿using Elbek.MContent.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Elbek.MContent.Services.ValidationServices.AuthorValidator
{
    public interface IAuthorValidationService
    {

        MContentValidationResult Validate(Guid id);
    }

    public class AuthorValidationService : IAuthorValidationService
    {
        private readonly IAuthorValidationRules _rules;
        public MContentValidationResult ValidationResult { get; private set; } = new MContentValidationResult();

        public AuthorValidationService(IAuthorValidationRules rules)
        {
            _rules = rules;
        }

        public MContentValidationResult Validate(Guid id)
        {
            ValidationResult.Errors = new List<string>
            {
                _rules.ValidateIfNullOrEmpty(id.ToString()),
                _rules.ValidateGuidIfDefault(id)
            }.Where(e => string.IsNullOrEmpty(e) == false).ToList(); ;
            if (ValidationResult.Errors.Any() == false)
            {
                ValidationResult.IsValid = true;
            }
            return ValidationResult;
        }


    }
}