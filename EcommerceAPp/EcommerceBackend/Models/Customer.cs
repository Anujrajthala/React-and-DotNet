using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EcommerceBackend.Models{
    public class Customer{

        private int CustId{set; get;}
        private required string UserName{ get;}

        private required string Email{ get; }

        private required string PasswordHash {get; set;}

        public Customer(string Username ,string email, string Password){
            UserName = Username;
            Email = email;
            PasswordHash = Password;
        }


    }
}