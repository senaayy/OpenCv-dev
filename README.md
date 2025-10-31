# C# ve Emgu CV ile Ger‡ek Zamanl Yz Tanma ™devi 
 
## ?? Kullanlan Teknolojiler 
* **C#** (.NET) 
* **Visual Studio 2022** 
* **Emgu CV** (OpenCV i‡in .NET ktphanesi) 
* **Haar Cascade** (Yz tespiti modeli) 
 
--- 
 
## ?? €alŸtrma Admlar 
1. Projeyi klonlayn veya ZIP olarak indirin. 
2. `.sln` dosyasn Visual Studio 2022 ile a‡n. 
3. Visual Studio, `Emgu.CV` ve `Emgu.CV.runtime.windows` paketlerini otomatik olarak ykleyecektir (e§er ykl de§ilse Proje  Paketlerini Y”net ksmndan ykleyin). 
4. `haarcascade_frontalface_default.xml` dosyasna "€”zm Gezgini"nde tklayn. 
5. "™zellikler" penceresinde **"Copy to Output Directory" (Derleme Dizinine Kopyala)** ayarn **"Copy if newer" (Daha yeniyse kopyala)** yapn. 
6. YeŸil "BaŸlat" (Start) d§mesine basn. 
 
--- 
 
## ?? Nasl €alŸr? 
1. `VideoCapture(0)` ile varsaylan webcam a‡lr. 
2. `while(true)` d”ngs i‡inde kameradan srekli kareler okunur. 
3. Hzl iŸlem i‡in kare gri tona (`CvInvoke.CvtColor`) ‡evrilir. 
4. `CascadeClassifier.DetectMultiScale` fonksiyonu, gri kare zerinde yzleri arar. 
5. Bulunan her yzn koordinatna `CvInvoke.Rectangle` ile yeŸil bir dikd”rtgen ‡izilir. 
6. Sonu‡, `CvInvoke.Imshow` ile ekranda g”sterilir. 
