using System;
using System.Collections.Generic;

namespace antrenman
{
    class Program
    {
        
        static void Main(string[] args)
        {
            metotlar fonksiyon=new(); // İHTİYAÇ DUYULAN TÜM METOTLARA "fonksiyon" ADI İLE ULAŞACAĞIZ
            List<kisi> rehber=new List<kisi>();
            string secim;
            string secimarama;
            while(true)
            {
                fonksiyon.anamenugoster();
                secim=Console.ReadLine();
                if(secim=="1")
                {
                    rehber.Add(fonksiyon.ekle());
                }
                if(secim=="2")
                {
                    fonksiyon.sil(rehber);
                }
                if(secim=="3")
                {
                    fonksiyon.guncelle(rehber);
                }
                if(secim=="4")
                {
                    fonksiyon.rehberlistele(rehber);
                }
                if(secim=="5")
                {
                    Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.\n**********************************************");
                    Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)\nTelefon numarasına göre arama yapmak için: (2)");
                    secimarama=Console.ReadLine();
                    if(secimarama=="1")
                    fonksiyon.araisim(rehber);
                    if(secimarama=="2")
                    fonksiyon.aratel(rehber);
                }
            }
        }
}
class kisi
    {
        public string ad;
        public string soyad;
        public string telno;
    }
    class metotlar
    {
//***************************************************************
        //REHBERE KİŞİ EKLEME
        public kisi ekle()
        {
        Console.WriteLine("Lütfen isim giriniz             :");
        string isim;
        isim=Console.ReadLine();

        Console.WriteLine("Lütfen soyisim giriniz             :");
        string soyisim;
        soyisim=Console.ReadLine();

        Console.WriteLine("Lütfen telefon numarası giriniz :");
        string numara;
        numara=Console.ReadLine();

        kisi ekleyici=new();
        ekleyici.ad=isim;
        ekleyici.soyad=soyisim;
        ekleyici.telno=numara;
        return ekleyici;
        }
//***************************************************************
        //ANA MENUYU GOSTEREN METOT
        public void anamenugoster()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
        }
//***************************************************************
        //REHBER LİSTELEME
        public void rehberlistele(List<kisi> rehber)
        {
            string secim;
            kisi tutucu;
            Console.WriteLine("A-Z liste için seçim (1) olmalı");
            Console.WriteLine("Z-A liste için seçim (2) olmalı");
            secim=Console.ReadLine();
                for (int i = 0; i < (rehber.Count-1); i++)
                {
                    for (int j = i; j < rehber.Count; j++)
                    {
                        if(String.Compare(rehber[i].ad,rehber[j].ad)==1)
                        {
                            tutucu=rehber[i];
                            rehber[i]=rehber[j];
                            rehber[j]=tutucu;
                        }
                    }
                }
                Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("**********************************************");
            if(secim=="1")
            {
                foreach (var item in rehber)
                {
                yaz(item);
                }
            }

            if(secim=="2")
            {
                rehber.Reverse();
            foreach (var item in rehber)
            {
                yaz(item);
            }
            }
        }
//***************************************************************
        //ARAMA FONKSİYONU
        public void araisim(List<kisi> rehber) //İSİM VEYA SOYİSİMLE ARAMA YAPMAK
        {
            string aranan;
            Console.WriteLine("Aramak istediğiniz ismi giriniz");
            aranan=Console.ReadLine();
            List<int> indexlistesi=new();
            Console.WriteLine("Arama Sonuçlarınız");
            Console.WriteLine("**********************************************");
            indexlistesi=bul(aranan,rehber);
            if(indexlistesi.Count>0)
            {
            foreach (var item in indexlistesi)
            {
            yaz(rehber[item]);
            }
            }
            if(indexlistesi.Count==0)
            Console.WriteLine("Sonuç bulunamadı\n-");
        }
        public List<int> bul(string aranan,List<kisi> rehber)
        {
            List<int> indexlistesi=new();
            foreach (var item in rehber)
            {
                if(String.Compare(item.ad,aranan)==0 || 
                String.Compare(item.soyad,aranan)==0 || String.Compare(string.Concat(item.ad," ",item.soyad),aranan)==0)
                {
                indexlistesi.Add(rehber.IndexOf(item));
                }
            }
            return indexlistesi;
        }
        public void aratel(List<kisi> rehber)  //TEL NO İLE ARAMA YAPMAK
        {
            int sayac=0;
            string aranan;
            Console.WriteLine("Aramak istediğiniz telefon numarasını giriniz");
            aranan=Console.ReadLine();
            
            Console.WriteLine("Arama Sonuçlarınız");
            Console.WriteLine("**********************************************");
            foreach (var item in rehber)
            {
                if(String.Compare(item.telno,aranan)==0)
                {
                    sayac++;
                yaz(item);
                }
            }
            if(sayac==0)
            Console.WriteLine("Sonuç bulunamadı\n-");
        }
//***************************************************************
        //YAZMA FONKSİYONU
        public void yaz(kisi ornekkisi)
        {
            Console.WriteLine("isim: "+ornekkisi.ad);
                Console.WriteLine("Soyisim: "+ornekkisi.soyad);
                Console.WriteLine("Telefon Numarası: "+ornekkisi.telno);
                Console.WriteLine("-");
        }
//***************************************************************
        //SİLME FONKSİYONUFONKSİYONU
        public void sil(List<kisi> rehber)
        {
            etiket:
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");

            string silinecek=Console.ReadLine();
            List<int> indexlistesi=new();
            byte secim;
            string silemri;

            indexlistesi=bul(silinecek,rehber);
            if(indexlistesi.Count>0)
            {
                Console.WriteLine("{0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)",rehber[indexlistesi[0]].ad);
                silemri=Console.ReadLine();
                if(silemri=="y")
                {
                rehber.RemoveAt(indexlistesi[0]);
                Console.WriteLine("{0} kişisi silindi",silinecek);
                return;
                }
                if(silemri=="n")
                return;
                else
                {
                Console.WriteLine("Hatalı giriş,işlem iptal edildi");
                return;
                }
            }
            if(indexlistesi.Count==0)
            {
            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Silmeyi sonlandırmak için : (1)\n* Yeniden denemek için      : (2)");
            secim=Convert.ToByte(Console.ReadLine());
                if(secim==1)
                return;
                if(secim==2)
                goto etiket;
                else
                goto etiket;
            }
        }
//***************************************************************
        //GÜNCELLEME FONKSİYONU
        public void guncelle(List<kisi> rehber)
        {
            string secim;
            sticker:
            string guncellenen;
            Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
            guncellenen=Console.ReadLine();
            List<int> indexsayisi=new();
            indexsayisi=bul(guncellenen,rehber);
            if(indexsayisi.Count>0)
            {
                rehber[indexsayisi[0]]=ekle();
            }
            if(indexsayisi.Count==0)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Güncellemeyi sonlandırmak için    : (1)\n* Yeniden denemek için              : (2)");
                secim=Console.ReadLine();
                if(secim=="1")
                return;
                if(secim=="2")
                goto sticker;

            }
        }
//***************************************************************
    }
}