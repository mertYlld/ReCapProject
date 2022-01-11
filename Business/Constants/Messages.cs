using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        //Car messages
        public static string CarAdded = "Araç eklendi";      
        public static string CarDeleted = "Araç silindi";
        public static string CarUpdated = "Araç Güncellendi";
        public static string CarNameInvalid = "Araç ismi geçersiz";
        public static string CarsListed = "Araçlar listelendi";

        //System Messages
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string OutOfHours = "Sistem hizmet saatleri dışında";

        //Brand messages
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        //Color messages
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";

        //Rental Messages
        public static string RentalError="Bu araç daha önce kiralanmış";
        public static string CarRented = "Araç başarıyla kiralandı";
        public static string RentalAdded="Kiralık eklendi";
        public static string RentalUpdated="Kiralama güncellendi";




        //User Messages
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı kaydı silindi";
        public static string UserUpdated = "Kullanıcı bilgileri güncellendi";

        //İmage Messages
        public static string ImageUploadedSuccessfully="Resim başarıyla yüklendi";
        public static string OutsideOfInsertionLimits = "Bir aracın en fazla 5 resmi olabilir";
        public static string CarImageUpdated="Araç resmi güncellendi";
        public static string CarImageDeleted="Araç resmi başarıyla silindi";

        //SecuredOperation Messages -- Auth
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt olundu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola Hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token Oluşturuldu";
        
    }

}
