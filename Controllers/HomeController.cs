using System.Data;
using System.Diagnostics;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using SatisProjesi.Models;

namespace SatisProjesi.Controllers
{

    public class HomeController : Controller
    {
        private readonly IDbConnection _connection;

        public HomeController(IDbConnection connection)
        {
            _connection = connection;
        }


        public IActionResult Index()
        {
            var satisList = _connection.Query<SatisListesiLeftJoin>
                                                        (
                                                            @"SELECT t.*,
                                                             m.MusteriAdi,
                                                             m.MusteriSoyadi,
                                                             d.DurumAdi
                                                             FROM TBLTeklif t
                                                             LEFT JOIN TBLMusteri m ON t.MusteriId = m.Id
                                                             LEFT JOIN TBLDurumlar d ON t.DurumId = d.Id"
                                                        ).ToList();

            var teklifListesi = _connection.Query<TBLTeklif>("SELECT * FROM TBLTeklif").ToList();

            var durumlarListesi = _connection.Query<TBLDurumlar>("SELECT * FROM TBLDurumlar").ToList();

            var musteriListesi = _connection.Query<TBLMusteri>("SELECT * FROM TBLMusteri").ToList();

            foreach (var durum in durumlarListesi)
            {
                durum.Teklifler = new List<TBLTeklif>();

                foreach (var teklif in teklifListesi)
                {

                    if (teklif.DurumId == durum.Id)
                    {
                        durum.Teklifler.Add(teklif);
                    }

                }
                ViewBag.TeklifSayisi = durum.Teklifler.Count();
            }

           




            var model = new IndexViewModel()
            {
                Durumlar = durumlarListesi,
                Musteriler = musteriListesi,
                Teklifler = satisList,
            };
            


            return View(model);
        }

        [HttpPost]
        public IActionResult InsertTeklif(TBLTeklif teklif) 
        {
            var insertTeklif = _connection.Execute(
                                                   @"INSERT INTO TBLTeklif
                                                    (MusteriId,DurumId,TeklifBaslik,Fiyat)
                                                    VALUES
                                                    (@MusteriId,@DurumId,@TeklifBaslik,@Fiyat)",teklif
                                                  );
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult InsertDurum(TBLDurumlar durum) 
        {
            var insertDurum = _connection.Execute(
                                                   @"INSERT INTO TBLDurumlar
                                                      (DurumAdi,DurumSirasi)
                                                      VALUES
                                                      (@DurumAdi,@DurumSirasi)",durum
                                                 );
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDurum(int Id) 
        {
            var selectedDurum = _connection.QuerySingle<TBLDurumlar>("SELECT * FROM TBLDurumlar WHERE Id=@Id", new {Id});

            return View(selectedDurum);
        }

        [HttpPost]
        public IActionResult UpdateDurum(TBLDurumlar durum)
        {
            var updateDurum = _connection.Execute(
                                                   @"UPDATE TBLDurumlar
                                                    SET
                                                    DurumAdi = @DurumAdi,
                                                    DurumSirasi =@DurumSirasi
                                                    WHERE Id=@Id",durum
                                                 );
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteDurum(int Id) 
        {
            var deleteDurum = _connection.Execute(
                                                   @"DELETE FROM TBLDurumlar Where Id=@Id", new {Id}
                                                 ); 
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult InsertMusteri(TBLMusteri musteri)
        {
            var insertMusteri = _connection.Execute(
                                                    @"INSERT INTO TBLMusteri
                                                      (MusteriAdi,MusteriSoyadi,Eposta,Telefon)
                                                      VALUES
                                                      (@MusteriAdi,@MusteriSoyadi,@Eposta,@Telefon)", musteri
                                                   );
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteMusteri(int Id) 
        {
            var deleteMusteri = _connection.Execute("DELETE FROM TBLMusteri WHERE Id=@Id", new { Id });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateMusteri(int Id) 
        {
            var selectedMusteri = _connection.QuerySingleOrDefault<TBLMusteri>("SELECT * FROM TBLMusteri Where Id=@Id", new {Id});
            
            return View(selectedMusteri); 
        }

        [HttpPost]
        public IActionResult UpdateMusteri(TBLMusteri musteri) 
        {
            var updateMusteri = _connection.Execute(
                                                    @"UPDATE TBLMusteri
                                                      SET
                                                      MusteriAdi = @MusteriAdi,
                                                      MusteriSoyadi = @MusteriSoyadi,
                                                      Eposta = @Eposta,
                                                      Telefon = @Telefon
                                                      WHERE Id=@Id", musteri 
                                                   );
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateTeklif(int Id)
        {
            var selectedTeklif = _connection.QuerySingleOrDefault<SatisListesiLeftJoin>
                                                        (
                                                            @"SELECT t.*,
                                                             m.MusteriAdi,
                                                             m.MusteriSoyadi,
                                                             d.DurumAdi
                                                             FROM TBLTeklif t
                                                             LEFT JOIN TBLMusteri m ON t.MusteriId = m.Id
                                                             LEFT JOIN TBLDurumlar d ON t.DurumId = d.Id
                                                             WHERE t.Id=@Id", new {Id}
                                                        );
            


            var durumlarListesi = _connection.Query<TBLDurumlar>("SELECT * FROM TBLDurumlar").ToList();

              var musteriListesi = _connection.Query<TBLMusteri>("SELECT * FROM TBLMusteri").ToList();

          

                                    var model = new UpdateTeklifViewModel()
            {
                Durumlar = durumlarListesi,
                Musteriler = musteriListesi,
                Teklifler = selectedTeklif
            };

            



            return View(model); 
        }

        [HttpPost]
        public IActionResult UpdateTeklif(TBLTeklif teklif)
        {
            var updateTeklif = _connection.Execute(
                                                    @"UPDATE TBLTeklif
                                                     SET
                                                     MusteriId=@MusteriId,
                                                     DurumId = @DurumId,
                                                     TeklifBaslik = @TeklifBaslik,
                                                     Fiyat = @Fiyat
                                                     WHERE Id=@Id",teklif
                                                  );

            return RedirectToAction("Index"); 
        }

        public IActionResult DeleteTeklif(int Id) 
        {
            var deleteTeklif = _connection.Execute("DELETE FROM TBLTeklif WHERE Id=@Id", new {Id});
            return RedirectToAction("Index");
        }



    }
}
