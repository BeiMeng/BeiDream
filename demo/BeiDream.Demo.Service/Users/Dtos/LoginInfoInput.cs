using System.ComponentModel.DataAnnotations;
using BeiDream.Core.Validations;

namespace BeiDream.Demo.Service.Users.Dtos
{
    public class LoginInfoInput:IValidate   //实现此接口，自动进行参数验证
    {
         [Required(ErrorMessage = "用户名或邮箱不能为空")]
        public string UserNameOrEmail { get; set; }
         [Required(ErrorMessage = "密码不能为空")]
         public string Password { get; set; }
    }
}