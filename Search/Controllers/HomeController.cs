using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Search.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Bul(string str)
        {
            string text = @"Alan Mathison Turing, 23 Haziran 1912 tarihinde İngiltere’nin başkenti Londra’da doğmuştur. Babası 
            Julius Mathison Turing, Hindistan’ın Orissa şehrinin Chatrapur kasabasında İngiliz kolonisi devlet memuru
            olarak çalışıyordu. Annesi Sara ise orada iken Alan Mathison Turing’e hamile kaldı ve Alan Mathison Turing’in 
            İngitere’de doğmasını istediklerinden Londra’ya gelerek şimdi yerinde Colonnade Hotel olan Londra’da Maide Vale’de
            bir eve yerleştiler. Alan Turing’in John adlı bir abisi vardır. 6 yaşında iken St Michaels okuluna başladı. 1926’da 
            14 yaşındayken Dorset’te ünlü çok pahalı bir özel okul olan Sherborne Okuluna girdi. Bilgisayar’ın mucidi 
            sayılan Alan Turing, II'inci Dünya Savaşı’nda Alman şifrelerinin kırılması konusunda önemli çalışmalara imza atan 
            ekibe değerli katkılar yapmıştır. Alan Turing, İkinci Dünya Savaşı’nda İngiltere ile Almanya deniz savaşındayken 
            İngiltere’nin Almanya’yı yenmesinde Turing’in “Enigma” adı verilen şifre makinelerinin metinlerini çözmeye yarayan 
            bir makine tasarlaması sayesinde oldu. Bu yeni makine dünyanın ilk bilgisayarı unvanını aldı. Alan Turing, Sherborne 
            okulunda öğrenci iken üst sınıftan Christopher Marcom’la yakın arkadaşlık ve aşk ilişkisi kurmuştur. Marcom,
            tüberküloz hastalığı nedeniyle, okuldan mezun olamadan öldü. Bu tarih Alan Turing için dönüm noktası oldu. 
            Turing, dini inancını kaybetti ve ateist oldu. Tamam dedi boyle bisey olamaz dedi. Merhaba diye uyandı birdenbire.Neden
            merhaba dedi bilmiyordu. Test oldu. Ögrenciler test sınavına hazılanıyordu. Testiyi kırdı. Tamamsa tamam dedi.";
            string replacement = Regex.Replace(text, @"\t|\n|\r", "");
            text = replacement;
            text = text.Replace(".", "." + "\n");

            string[] sentences = text.ToString().Split('.');
            LinkedList<string> ll = new LinkedList<string>(sentences);
            LinkedListNode<string> lln = ll.First;

            var result = "";
            int len = sentences.Length;

            while (lln != null)
            {
                if (lln.Value.ToLower().Contains(str.ToLower()))
                {
                    result += lln.Value;
                    result += '.';

                }
                lln = lln.Next;
            }
            if (result == "")
            {
                result = "Aradığınız kelime bulunamadı.";
            }
            if (str == "")
            {
                result = "";
            }
            var data = new { status = "ok", result = result };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}

