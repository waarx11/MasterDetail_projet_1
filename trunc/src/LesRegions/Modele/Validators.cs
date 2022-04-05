using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace appli.validators
{
    class TextRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str;

            try
            {
                str = (string)value;
            }catch(Exception e)
            {
                return new ValidationResult(false, "Caractère interdits");
            }

            if (string.IsNullOrWhiteSpace(str))
            {
                return new ValidationResult(false, "La chaîne de caractère ne peut pas êtres vide.")
            }

            return ValidationResult.ValidResult;
            //return new ValidationResult(true, "");
        }
    }
}
