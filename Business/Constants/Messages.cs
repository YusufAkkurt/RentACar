using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba ekleme işlemi başarılı";
        public static string CarDeleted = "Araba silme işlemi başarılı";
        public static string CarUpdated = "Araba güncelleme işlemi başarılı";
        public static string CarCouldntBeUpdated = "Araba'nın günlük fiyatı 80'den yukarı olmalıdır";

        public static string BrandAdded = "Marka ekleme işlemi başarılı";
        public static string BrandDeleted = "Marka silme işlemi başarılı";
        public static string BrandUpdated = "Marka güncelleme işlemi başarılı";

        public static string ColorAdded = "Renk ekleme işlemi başarılı";
        public static string ColorDeleted = "Renk silme işlemi başarılı";
        public static string ColorUpdated = "Renk güncelleme işlemi başarılı";

        public static string UserAdded = "Kullanıcı ekleme işlemi başarılı";
        public static string UserDeleted = "Kullanıcı silme işlemi başarılı";
        public static string UserUpdated = "Kullanıcı güncelleme işlemi başarılı";

        public static string CustomerAdded = "Müşteri ekleme işlemi başarılı";
        public static string CustomerDeleted = "Müşteri silme işlemi başarılı";
        public static string CustomerUpdated = "Kullanıcı bilgileri başarıyla güncellendi";

        public static string RentalAdded = "Kiralama işlemi başarılı";
        public static string RentalDeleted = "Kiralama işlemi silindi";
        public static string RentalUpdated = "Kiralama işlemi güncellendi";
        public static string CarIsStillRentalled = "Araba henüz teslim edilmemiş";

        public static string InvalidRequest = "Lütfen bilgileri kontrol edip, tekrar deneyin";
        
        public static string CarImageAdded = "Araba resmi ekleme işlemi başarılı";
        public static string CarImageDeleted = "Araba resmi silme işlemi başarılı";
        public static string CarImageUpdated = "Araba resmi güncelleme işlemi başarılı";
        public static string CarLimitExceded = "Araba'nın eklebilecek resim limitine ulaşıldı";

        public static string CardAdded = "Kart bilgileri kaydedildi";
        public static string CardDeleted = "Kart bilgileri silindi";
        public static string CardUpdated = "Kart bilgileri güncellendi";
        public static string CardAlreadyExists = "Kart daha önceden kaydedilmiş";

        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
    }
}