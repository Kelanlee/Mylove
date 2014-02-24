using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyLove.Models
{
    public class LoginInfo
    {
        [Required(ErrorMessage = "请输入账号")]
        public string username { set; get; }

        [Required(ErrorMessage = "请输入密码")]
        [DataType(DataType.Password)]
        public string password { set; get; }
    }
}