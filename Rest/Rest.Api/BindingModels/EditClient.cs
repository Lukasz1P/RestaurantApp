using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Rest.Common.Enums;

namespace Rest.Api.BindingModels
{
    public class EditClient
    { 
//      [Required]
        [Display(Name = "Clientname")]
        public string ClientName { get; set; }
        
        // [Required]
        [Display(Name = "ClientSurname")]
        public string ClientSurName { get; set; }

        //[Required]
        [Display(Name = "Clientphone")]
        public int ClientPhone { get; set; }

        
        // [Required]
        // [EmailAddress]
        // [DataType(DataType.EmailAddress)]
        [Display(Name = "Clientemail")]
        public string ClientEmail { get; set; }
    }
    
    
    

}