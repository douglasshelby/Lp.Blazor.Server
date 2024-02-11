using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Lp.Blazor.Server.Data.Models
{
    public class QueryOptions : IValidatableObject
    {
        public DateTime? StartDate{ get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime MinStartDate { get; set; }
        public DateTime MaxEndDate { get; set; }

        public bool IsValid => Validate(null).Count() == 0;
        public IEnumerable<ValidationResult> Validate() => Validate(null);
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //validate start date
            if (StartDate > EndDate || StartDate < MinStartDate)
            {
                yield return new ValidationResult("Start Date must be before End Date");
            }
            //validate start date
            if (EndDate < StartDate || EndDate > MaxEndDate)
            {
                yield return new ValidationResult("End Date must be after Start Date");
            }
        }
    }
}
