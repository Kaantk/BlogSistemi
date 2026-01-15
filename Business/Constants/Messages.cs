using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        // General
        public static string Success = "İşlem başarılı.";
        public static string ValidationError = "Gönderilen veriler geçersiz.";
        public static string UnexpectedError = "Beklenmeyen bir hata oluştu.";        

        // User
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string UserCreated = "Kullanıcı başarıyla oluşturuldu.";
        public static string UsersListed = "Kullanıcılar başarıyla getirildi.";
        public static string UserAlreadyExists = "Bu email adresi zaten kayıtlı.";
        public static string UserCreateFailed = "Kullanıcı oluşturulamadı.";

        // Auth
        public static string SuccessfulLogin = "Kullanıcı girişi başarılıdır.";
        public static string PasswordError = "Girilen şifre hatalıdır.";
    }
}
