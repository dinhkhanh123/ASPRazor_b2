using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class CustomerInfo
{

    [Display(Name = "ten khach hang")]
    [Required(ErrorMessage = ("vui long nhap ten"))]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} phai dai tu {2} den {1} ki tu")]
    [ModelBinder(BinderType = typeof(UserNameBinding))]
    public string CustomerName { set; get; }
    [Display(Name = "Email khach hang")]
    [EmailAddress]
    public string Email { set; get; }

    [DisplayName("Nam sinh")]
    [Sochan]
    public int? YearOfBirth { set; get; }
}