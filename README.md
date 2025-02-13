# İş Takip Sistemi

Bu proje, kullanıcı bazında iş takibini kolaylaştırmak amacıyla geliştirilmiş bir ASP.NET Core MVC uygulamasıdır. Kullanıcılar iş ekleyebilir, düzenleyebilir, silebilir ve durumlarını değiştirebilir.
Bu proje, Acun Medya Akademi Genişletilmiş Back-End Yazılım Uzmanlığı eğitiminin temel eğitimini tamamladıktan sonra, uzmanlık aşamasına geçiş sürecindeki kamp döneminde geliştirdim.

## 🚀 Özellikler

- 📊 **Raporlama**: Kullanıcı bazında aktif ve tamamlanmış işlerin toplamını listeleyen bir rapor paneli.
- 📋 **İş Listesi**: İşlerin durumuna göre "Aktif" veya "Tamamlandı" bilgilerini içeren listeleme ekranı.
- ✏ **CRUD İşlemleri**: İş oluşturma, düzenleme, silme ve durum değiştirme özellikleri.
- 🔍 **Detay Sayfası**: Belirli bir işe atanmış kullanıcı ve detaylı açıklama bilgilerinin yer aldığı ekran.

## 🛠 Kullanılan Teknolojiler

- **ASP.NET Core MVC**
- **Dapper** ve **SQLClient** 
- **MS SQL Server**
- **Bootstrap 5**

## 📌 Kurulum

1. **Projeyi klonlayın:**
   ```sh
   git clone https://github.com/kullaniciadi/IsTakipSistemi.git
   ```
2. **Bağımlılıkları yükleyin:**
   ```sh
   dotnet restore
   ```
3. **Veritabanını oluşturun ve güncelleyin:**
   - `appsettings.json` dosyasındaki **ConnectionString** değerini kendi veritabanınıza göre güncelleyin.
   - Aşağıdaki SQL sorgusunu kullanarak gerekli tabloları oluşturabilirsiniz:
   ```sql
   CREATE TABLE Jobs (
       Id INT PRIMARY KEY IDENTITY,
       Title NVARCHAR(100),
       Description NVARCHAR(500),
       Status NVARCHAR(50),
       AssignedUserId INT,
       CreatedDate DATETIME DEFAULT GETDATE()
   );
   ```
4. **Projeyi çalıştırın:**
   ```sh
   dotnet run
   ```

🎯 Geliştirmelere katkıda bulunmak isterseniz pull request gönderebilirsiniz!

