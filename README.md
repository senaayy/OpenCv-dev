# C# ve Emgu CV ile Gerçek Zamanlı Yüz Tanıma Ödevi

Bu proje, bir C# Konsol Uygulaması kullanarak webcam'den alınan görüntü üzerinde gerçek zamanlı olarak yüz tespiti yapar. Tespit edilen yüzler, yeşil bir dikdörtgen ile işaretlenir.

---

## Kullanılan Teknolojiler

* **C#** (.NET)
* **Visual Studio 2022**
* **Emgu CV** (OpenCV için .NET kütüphanesi)
* **Haar Cascade** (Yüz tespiti modeli)

---

## Çalıştırma Adımları

1. Projeyi klonlayın veya ZIP olarak indirin.
2. `.sln` dosyasını Visual Studio 2022 ile açın.
3. Visual Studio, `Emgu.CV` ve `Emgu.CV.runtime.windows` paketlerini otomatik olarak yükleyecektir (eğer yüklü değilse Proje > NuGet Paketlerini Yönet kısmından yükleyin).
4. `haarcascade_frontalface_default.xml` dosyasına "Çözüm Gezgini"nde tıklayın.
5. "Özellikler" penceresinde **"Copy to Output Directory" (Derleme Dizinine Kopyala)** ayarını **"Copy if newer" (Daha yeniyse kopyala)** yapın.
6. Yeşil "Başlat" (Start) düğmesine basın.

---

##  Nasıl Çalışır?

1. `VideoCapture(0)` ile varsayılan webcam açılır.
2. `while(true)` döngüsü içinde kameradan sürekli kareler okunur.
3. Hızlı işlem için kare gri tona (`CvInvoke.CvtColor`) çevrilir.
4. `CascadeClassifier.DetectMultiScale` fonksiyonu, gri kare üzerinde yüzleri arar.
5. Bulunan her yüzün koordinatına `CvInvoke.Rectangle` ile yeşil bir dikdörtgen çizilir.
6. Sonuç, `CvInvoke.Imshow` ile ekranda gösterilir.
