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
   git clone https://github.com/mertagralii/IsTakipSistemi.git
   ```
2. **Bağımlılıkları yükleyin:**
   ```sh
   dotnet restore
   ```
3. **Veritabanını oluşturun ve güncelleyin:**
   - `appsettings.json` dosyasındaki **ConnectionString** değerini kendi veritabanınıza göre güncelleyin.
   - Aşağıdaki SQL script'ini kullanarak gerekli tabloları oluşturabilirsiniz:
   
   ```sql
   USE [DBSatis]
   GO
   
   CREATE TABLE [dbo].[TBLDurumlar](
   	[Id] [int] IDENTITY(1,1) NOT NULL,
   	[DurumAdi] [varchar](50) NULL,
   	[DurumSirasi] [int] NULL,
    CONSTRAINT [PK_TBLDurumlar] PRIMARY KEY CLUSTERED ([Id] ASC)
   ) ON [PRIMARY]
   GO
   
   CREATE TABLE [dbo].[TBLMusteri](
   	[Id] [int] IDENTITY(1,1) NOT NULL,
   	[MusteriAdi] [varchar](50) NULL,
   	  NULL,
   	  NULL,
   	  NULL,
    CONSTRAINT [PK_TBLMusteri] PRIMARY KEY CLUSTERED ([Id] ASC)
   ) ON [PRIMARY]
   GO
   
   CREATE TABLE [dbo].[TBLTeklif](
   	[Id] [int] IDENTITY(1,1) NOT NULL,
   	[MusteriId] [int] NULL,
   	[DurumId] [int] NULL,
   	[TeklifBaslik] [varchar](50) NULL,
   	[Fiyat] [float] NULL,
    CONSTRAINT [PK_TBLTeklif] PRIMARY KEY CLUSTERED ([Id] ASC)
   ) ON [PRIMARY]
   GO
   
   SET IDENTITY_INSERT [dbo].[TBLDurumlar] ON 
   GO
   INSERT INTO [dbo].[TBLDurumlar] ([Id], [DurumAdi], [DurumSirasi]) VALUES (1, N'Teklif', 1), (2, N'Pazarlık', 2), (3, N'Kazanıldı', 3), (4, N'Kaybedildi', 4), (10, N'YeniDurum', 5);
   GO
   SET IDENTITY_INSERT [dbo].[TBLDurumlar] OFF
   GO
   
   SET IDENTITY_INSERT [dbo].[TBLMusteri] ON 
   GO
   INSERT INTO [dbo].[TBLMusteri] ([Id], [MusteriAdi], [MusteriSoyadi], [Eposta], [Telefon]) VALUES (1, N'Mert', N'Ağralı', N'mmertagrali@gmail.com', N'3333333'), (2, N'Mete', N'Test', N'metetest@gmail.com', N'999999'), (3, N'Kerem', N'Can', N'keremcan@gmail.com', N'555555'), (5, N'Tetik', N'Tetikoğulları', N'tetikogullari@gmail.com', N'123123123');
   GO
   SET IDENTITY_INSERT [dbo].[TBLMusteri] OFF
   GO
   
   SET IDENTITY_INSERT [dbo].[TBLTeklif] ON 
   GO
   INSERT INTO [dbo].[TBLTeklif] ([Id], [MusteriId], [DurumId], [TeklifBaslik], [Fiyat]) VALUES (1, 5, 1, N'Testss', 2000), (2, 2, 2, N'Test2', 300), (3, 3, 3, N'test3', 400), (4, 1, 2, N'TESTLER', 600), (8, 3, 4, N'Kaybedilditeklif', 300), (9, 5, 10, N'Yeni Durum Teklif', 3000);
   GO
   SET IDENTITY_INSERT [dbo].[TBLTeklif] OFF
   GO
   ```

4. **Projeyi çalıştırın:**
   ```sh
   dotnet run
   ```



---

🎯 Geliştirmelere katkıda bulunmak isterseniz pull request gönderebilirsiniz!

