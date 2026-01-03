# TFT Benzeri Kart Oyunu - Tasarım Dokümanı

## 1. Özet
Bu doküman, Teamfight Tactics (TFT) benzeri otomatik savaş kart-şampiyon oyunu için ilk taslak ve gereksinimleri içerir. Amaç: düşük maliyetli bir MVP ile oynanabilir bir prototip oluşturmak.

## 2. Hedefler
- MVP: Tek oyunculu yerel maç simülatörü (AI vs AI / Player vs AI). 
- Kart/şampiyon toplama, yerleştirme, otomatik savaş ve basit ekonomi (altın) mekanikleri.
- Genişletilebilir veri modeli (karakterler, yetenekler, sinerjiler).

## 3. Temel Mekanikler
- Tur Döngüsü: Alış, Yerleştirme, Savaş, Ödül
- El (Shop): Rastgele kart teklifleri, altınla satın alma, takas/yenileme
- Kurulum: Oyuncu birden fazla kartı tahtaya yerleştirir; tur başladığında otomatik savaş gerçekleşir.
- Destek Mekanikleri: Sınıflar/faction (sinerji), seviye ve birleştirme (aynı karttan 3 tanesi -> yükseltme)

## 4. Kart/Şampiyon Veri Modeli (özet)
- id: string
- name: string
- cost: int
- health: int
- attack: int
- armor: int
- magicResist: int
- attackSpeed: float
- abilities: list
- traits: list (sınıflar/faction)
- rarity/level: int

Örnek JSON:

```
{
	"id": "champ_001",
	"name": "Kılıç Ustası",
	"cost": 1,
	"health": 500,
	"attack": 50,
	"abilities": [ { "id":"slash","type":"single_target","damage":100 } ],
	"traits": ["Savaşçı"]
}
```

## 5. Savaş Motoru / Simülasyon
- Basit bir tur simülatörü: her birim inisiyatif/order ile saldırır.
- Hasar hesaplama: fiziksel hasar = max(0, attack - target.armor)
- Yetenekler: anlık veya zamanlı efektler (örn. AoE, stun)
- Kazanma koşulu: rakibin tüm birimleri yok olursa.

## 6. MVP Kapsamı
- Oyun döngüsü çalışır: shop, satın alma, yerleştirme, savaş simülasyonu.
- En az 10 örnek kart ve 3 trait seti.
- Basit UI/CLI gösterimi (oyuncu elini ve tahta durumunu gösteren).

## 7. Teknoloji Önerileri
- Hızlı prototip (masaüstü/game engine): Unity + C# (grafik + input kolaylığı).
- Web prototip: React (frontend) + Node.js/Express (backend simülasyon) — single-player için backend zorunlu değil.
- CLI/Prototip: Python ile hızlı simülasyon (öğrenme, denge için ideal).

## 8. İlerleme Adımları (kısa)
1. Tasarım dokümanı (bu dosya) — tamamlandı.
2. Proje iskeleti ve teknoloji seçimi.
3. Kart veri modeli ve örnek kartlar.
4. Savaş motoru prototipi (CLI veya küçük UI).
5. Basit UI ve oynanabilir MVP.

---
Not: İsterseniz şimdi proje iskeletini (ör. Unity projesi veya Node+React) oluşturayım.

