using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class NationalityVM
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public NationalityVM()
        {

        }

        public NationalityVM(NationalityDTO nationalityDTO)
        {
            Id = nationalityDTO.Id;
            Title = nationalityDTO.Title;
        }

    }
}