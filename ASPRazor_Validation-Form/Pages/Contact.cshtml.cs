using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPRazor_Validation_Form.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        public ContactModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [BindProperty]
        public CustomerInfo customerInfo { set; get; }

        [BindProperty]
        [DataType(DataType.Upload)]
        //[Required(ErrorMessage = "Chon file upload")]
        [CheckFileExtension]
        [DisplayName("File Upload")]
        public IFormFile FileUploader { set; get; }

        [DisplayName("chon nhieu File Upload")]
        public IFormFile[] FileUploads { set; get; }


        public void OnGet()
        {
        }
        public string thongbao { set; get; }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                thongbao = "Du lieu phu hop";
                //_environment.WebRootPath
                //FileUploader.FileName
                if (FileUploader != null)
                {
                    var filepath = Path.Combine(_environment.WebRootPath, "uploads", FileUploader.FileName);
                    using var filestrem = new FileStream(filepath, FileMode.Create);
                    FileUploader.CopyTo(filestrem);
                }

                foreach (var f in FileUploads)
                {
                    var filepath = Path.Combine(_environment.WebRootPath, "uploads", f.FileName);
                    using var filestrem = new FileStream(filepath, FileMode.Create);
                    f.CopyTo(filestrem);
                }

            }
            else
            {
                thongbao = "Du lieu ko phu hop";
            }
        }
    }
}
