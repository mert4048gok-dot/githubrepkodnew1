Unity + Android (Play Store) Kurulum Rehberi

1) Önerilen Unity Sürümü
- Unity 2021 LTS veya 2022 LTS (Android için stabil, il2cpp ve ARM64 desteği).

2) Yeni Proje Oluşturma
- `File -> New Project` -> 2D veya URP template seçin.

3) Android Build Ayarları
- `File -> Build Settings` -> Platform: Android -> `Switch Platform`.
- Build System: Gradle (default).
- Scripting Backend: IL2CPP.
- Target Architectures: ARMv7 ve ARM64 (Play Store için ARM64 zorunlu).
- Min API Level: Android 7.0 (API 24+) önerilir.

4) Package Name ve Keystore
- `Player Settings` -> `Other Settings` -> `Identification` bölümünden `Package Name` belirleyin (ör. com.company.game).
- `Publishing Settings` altında kendi keystore dosyanızı oluşturun ve `Keystore` + `Key` bilgilerini girin.

5) APK/AAB üretimi
- Play Store için `.aab` (Android App Bundle) üretin: `Build Settings` -> `Build` -> çıktı olarak `.aab` seçin.

6) Performans/Optimizasyon Notları
- Texture compression (ETC2), atlas kullanımı, sprite packing.
- ScriptableObject ile veri modelleyin (kart/şampiyon verileri için).
- Mobilde gc ve alloc'ları azaltın; object pooling kullanın.

7) Test ve Yayınlama
- `adb` ile gerçek cihazlarda test edin.
- Play Console üzerinden uygulama kaydı, store listing, içeriğe uygunluk ve uygulama imzası ayarlarını yapın.

8) Geliştirme İpuçları
- Geliştirme sürecinde küçük sahneler ve test runner'lar oluşturun.
- Network gereksinimi olursa `Unity Transport` veya `Mirror`/`Netcode` paketlerini değerlendirin.

---
Bu rehberi temel alarak proje dosyalarını `Assets/Scripts` altına ekledim. İstersen bir Unity projesi oluşturmam için adımları senin adına otomatikleştirebilirim veya scriptleri geliştirip örnek sahne oluşturabilirim.
