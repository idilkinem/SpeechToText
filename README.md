# SpeechToText
🗣️ Konuşmadan Metne (Speech To Text App)

Türkçe konuşmayı metne dönüştüren bir Windows Forms uygulamasıdır.
Bu proje, Vosk dil modeli ve NAudio kütüphanesini kullanarak çevrimdışı ses tanıma işlemi yapar.
Amaç, kullanıcı mikrofonundan alınan sesi gerçek zamanlı olarak metne çevirmek ve isterse kaydetmektir.

🎯 Proje Özellikleri

🎙️ Gerçek zamanlı ses tanıma

🧠 Türkçe dil modeli (vosk-model-small-tr-0.3)

💻 Tamamen çevrimdışı çalışır (internet gerekmez)

💾 Metin çıktısı kaydedilebilir

🎨 Basit ve anlaşılır kullanıcı arayüzü (WinForms)

🧩 Kullanılan Teknolojiler
Teknoloji	Açıklama
🟣 C# (.NET Framework)	WinForms arayüz ve genel uygulama altyapısı
🟢 Vosk API	Türkçe konuşma tanıma modeli
🔵 NAudio	Mikrofon girişini işleme ve ses verisini okuma
⚙️ Newtonsoft.Json	Model sonuçlarını JSON olarak çözümleme

🧠 Nasıl Çalışır?

Modeli ekleyin:
vosk-model-small-tr-0.3 klasörünü proje dizinine kopyalayın.
(Yani SpeechToText/bin/x64/Debug klasöründe olmalı.)

Uygulamayı başlatın.

“🎤 Dinlemeyi Başlat” butonuna basın.

Uygulama mikrofonunuzdan sesi alıp anlık olarak metne dönüştürecektir.

“💾 Kaydet” butonuna tıklayarak metni .txt dosyası olarak saklayabilirsiniz.

📦 Kurulum (Kütüphaneler)

Projenin NuGet bağımlılıkları:

Install-Package NAudio
Install-Package Vosk
Install-Package Newtonsoft.Json

💡 Örnek Çalışma

🎧 “Merhaba, nasılsın?”
➡️ Uygulama sonucu:

merhaba nasılsın

👩‍💻 Geliştirici

İdil Kinem
📚 Yazılım Mühendisliği Öğrencisi
💼 GitHub: @idilkinem

📜 Lisans

Bu proje açık kaynaklıdır ve yalnızca eğitim amaçlı olarak paylaşılmıştır.
