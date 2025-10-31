using System;
using Emgu.CV; // Emgu CV kütüphanelerini içeri al
using Emgu.CV.Structure;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // 1. Webcam'i Başlat
        // '0' genellikle varsayılan webcam'dir. Çalışmazsa 1, 2 veya -1 deneyin.
        VideoCapture capture;
        try
        {
            capture = new VideoCapture(0);
            if (!capture.IsOpened)
            {
                Console.WriteLine("Kamera açılamadı! Başka bir program mı kullanıyor?");
                Console.ReadKey();
                return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Kamera hatası: {ex.Message}");
            Console.WriteLine("Webcam sürücülerinizin güncel olduğundan emin olun.");
            Console.ReadKey();
            return;
        }

        // 2. Görüntüyü İşlemek İçin Nesneler Oluştur
        Mat frame = new Mat(); // Kameradan alınan her bir kare
        Mat grayFrame = new Mat(); // Görüntünün gri tonlamalı hali

        // 3. Haar Cascade Sınıflandırıcısını Yükle
        // Bu dosyanın .exe ile aynı klasörde olması gerekir (Adım 4'te bunu sağladık)
        string cascadePath = "haarcascade_frontalface_default.xml";
        CascadeClassifier faceDetector;
        try
        {
            faceDetector = new CascadeClassifier(cascadePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"HATA: Model dosyası yüklenemedi: {cascadePath}");
            Console.WriteLine(ex.Message);
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Webcam açılıyor... Yüzünüzü gösterin.");
        Console.WriteLine("Kapatmak için 'q' tuşuna basın veya pencereyi kapatın.");

        while (true)
        {
            // 4. Kameradan Bir Kare Oku
            capture.Read(frame);
            if (frame.IsEmpty)
            {
                Console.WriteLine("Kamera bağlantısı kesildi.");
                break;
            }

            // 5. Görüntüyü Griye Çevir (Algılama gri tonda daha hızlıdır)
            CvInvoke.CvtColor(frame, grayFrame, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            CvInvoke.EqualizeHist(grayFrame, grayFrame); // Kontrastı iyileştir

            // 6. Yüzleri Algıla
            Rectangle[] faces = faceDetector.DetectMultiScale(
                grayFrame,
                1.1, // Scale Factor: Görüntüyü ne kadar küçülteceği
                10,  // Min Neighbors: Bir yüzü onaylamak için gereken minimum komşu sayısı
                new Size(30, 30) // Min Detection Size: En küçük yüz boyutu (30x30 pixel)
            );

            // 7. Bulunan Yüzleri Çizdir
            foreach (Rectangle face in faces)
            {
                // Orijinal renkli kareye (frame) yeşil bir dikdörtgen çiz
                CvInvoke.Rectangle(frame, face, new MCvScalar(0, 255, 0), 2);
            }

            // 8. İşlenmiş Görüntüyü Ekranda Göster
            CvInvoke.Imshow("OpenCV Yüz Tanıma - Kapatmak için 'q' basın", frame);

            // Bir tuşa basılmasını bekle (1 milisaniye)
            int key = CvInvoke.WaitKey(1);
            if (key == 'q' || key == 'Q') // 'q' tuşuna basılırsa döngüden çık
            {
                break;
            }
        }

        // 9. Kaynakları Serbest Bırak
        capture.Release(); // Kamerayı serbest bırak
        CvInvoke.DestroyAllWindows(); // Tüm pencereleri kapat
    }
}