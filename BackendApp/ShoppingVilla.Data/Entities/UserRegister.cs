﻿using ShoppingVilla.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShoppingVilla.Data.Entities
{
    public class UserRegister
    {
        private DateTime _currentDt = DateTime.Now;
        private bool _isActive = true;
        private string _roleName = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        [MinLength(5)]
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [MinLength(5)]
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [MinLength(10), MaxLength(10)]
        [Required(ErrorMessage = "Mobile Number is required")]
        public string? Mobile { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
       
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password must match with password")]
        public string? ConfirmPassword { get; set; }
        public DateTime CreatedDate
        {
            get
            {
                return _currentDt;
            }
            set
            {
                _currentDt = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
        }
        public string RoleName
        {
            get
            {
                return _roleName;
            }
            set
            {
                _roleName = string.IsNullOrEmpty(value)?string.Empty:value.ToUpper();
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public virtual Role? Role { get; set; }

    }
}
