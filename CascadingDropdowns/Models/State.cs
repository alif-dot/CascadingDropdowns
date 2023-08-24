using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CascadingDropdowns.Models
{
    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public int CountryID { get; set; }
    }
}
