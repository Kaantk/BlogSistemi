using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string SuccessfulLogin = "Kullanıcı girişi başarılıdır.";

        public static string PasswordError = "Girilen şifre hatalıdır. Lütfen kontrol ediniz!";

        #region Standart Messages

        //// Authentication Messages
        //public static class Auth
        //{
        //    public static string LoginSuccess = "Giriş başarılı! Yönlendiriliyorsunuz...";
        //    public static string LoginFailed = "E-posta veya şifre hatalı. Lütfen tekrar deneyiniz.";
        //    public static string LogoutSuccess = "Çıkış işlemi başarılı.";
        //    public static string UnauthorizedAccess = "Bu işlem için yetkiniz bulunmamaktadır.";
        //    public static string SessionExpired = "Oturumunuz sona erdi. Lütfen tekrar giriş yapınız.";
        //    public static string AccountLocked = "Hesabınız kilitlenmiştir. Lütfen yönetici ile iletişime geçiniz.";
        //}

        //// User Messages
        //public static class User
        //{
        //    public static string UserNotFound = "Kullanıcı bulunamadı.";
        //    public static string UserCreated = "Kullanıcı başarıyla oluşturuldu.";
        //    public static string UserUpdated = "Kullanıcı bilgileri güncellendi.";
        //    public static string UserDeleted = "Kullanıcı başarıyla silindi.";
        //    public static string EmailAlreadyExists = "Bu e-posta adresi zaten kullanılmaktadır.";
        //    public static string InvalidEmail = "Geçersiz e-posta adresi.";
        //}

        //// Password Messages
        //public static class Password
        //{
        //    public static string PasswordIncorrect = "Girilen şifre hatalı.";
        //    public static string PasswordTooShort = "Şifre en az 6 karakter olmalıdır.";
        //    public static string PasswordChanged = "Şifreniz başarıyla değiştirildi.";
        //    public static string PasswordResetSent = "Şifre sıfırlama linki e-posta adresinize gönderildi.";
        //    public static string PasswordMismatch = "Şifreler eşleşmiyor.";
        //    public static string PasswordMustContainNumber = "Şifre en az bir rakam içermelidir.";
        //    public static string PasswordMustContainUppercase = "Şifre en az bir büyük harf içermelidir.";
        //}

        //// Post Messages
        //public static class Post
        //{
        //    public static string PostNotFound = "Gönderi bulunamadı.";
        //    public static string PostCreated = "Gönderi başarıyla oluşturuldu.";
        //    public static string PostUpdated = "Gönderi güncellendi.";
        //    public static string PostDeleted = "Gönderi silindi.";
        //    public static string PostPublished = "Gönderi yayınlandı.";
        //    public static string PostUnpublished = "Gönderi yayından kaldırıldı.";
        //}

        //// Category Messages
        //public static class Category
        //{
        //    public static string CategoryNotFound = "Kategori bulunamadı.";
        //    public static string CategoryCreated = "Kategori başarıyla oluşturuldu.";
        //    public static string CategoryUpdated = "Kategori güncellendi.";
        //    public static string CategoryDeleted = "Kategori silindi.";
        //    public static string CategoryAlreadyExists = "Bu isimde bir kategori zaten mevcut.";
        //}

        //// Comment Messages
        //public static class Comment
        //{
        //    public static string CommentNotFound = "Yorum bulunamadı.";
        //    public static string CommentCreated = "Yorumunuz başarıyla eklendi.";
        //    public static string CommentApproved = "Yorum onaylandı.";
        //    public static string CommentRejected = "Yorum reddedildi.";
        //    public static string CommentDeleted = "Yorum silindi.";
        //}

        //// Validation Messages
        //public static class Validation
        //{
        //    public static string RequiredField = "Bu alan zorunludur.";
        //    public static string InvalidFormat = "Geçersiz format.";
        //    public static string InvalidData = "Girilen veriler geçerli değil.";
        //    public static string FormHasErrors = "Lütfen form hatalarını düzeltin.";
        //}

        //// System Messages
        //public static class System
        //{
        //    public static string OperationSuccessful = "İşlem başarıyla tamamlandı.";
        //    public static string OperationFailed = "İşlem başarısız oldu. Lütfen tekrar deneyiniz.";
        //    public static string UnexpectedError = "Beklenmeyen bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.";
        //    public static string DatabaseError = "Veritabanı hatası oluştu.";
        //    public static string ServiceUnavailable = "Servis şu anda kullanılamıyor.";
        //}

        #endregion


    }
}
