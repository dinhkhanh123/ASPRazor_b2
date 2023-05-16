using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class UserContact
{
    [BindProperty]
    [DisplayName("Id cua ban")]
    [Range(10, 100, ErrorMessage = "Nhap sai")]
    public int UserId { set; get; }
    [BindProperty]
    [DisplayName("Email cua ban")]
    [EmailAddress(ErrorMessage = "email sai dinh dang")]
    public string Email { set; get; }
    [BindProperty]
    [DisplayName("Ten cua ban")]
    public string UserName { set; get; }
}