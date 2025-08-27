# WriteTheRest - Story Management Platform

## Proje Hakkında

WriteTheRest, hikaye ve bölümlerinin yönetilebildiği, kullanıcıların hikaye ekleyip güncelleyebildiği, bölümlere puan ve yorum verebildiği bir platformdur.  
Proje iki ana bileşenden oluşur:

- **Backend:** .NET 8 tabanlı RESTful API (Story.API)
- **Frontend:** ASP.NET MVC projesi (WriteTheRest.Web ) (Bu projeyi de repolarımda bulabilirsiniz)

Bu iki proje birbirine entegre edilmiştir ve birlikte çalışır.

---

## İçerik

- [Özellikler](#özellikler)
- [Teknolojiler](#teknolojiler)
- [Kurulum](#kurulum)
- [Projeleri Çalıştırma](#projeleri-çalıştırma)
- [API Endpointleri](#api-endpointleri)
- [Entegrasyon](#entegrasyon)
- [Katkı Sağlama](#katkı-sağlama)
- [Lisans](#lisans)

---

## Özellikler

- Hikaye (Story) CRUD işlemleri
- Bölüm (Chapter) CRUD işlemleri
- Kullanıcı yönetimi
- Hikaye versiyonları ve puanlama (Rating)
- RESTful API mimarisi
- MVC tabanlı kullanıcı arayüzü
- API ve MVC arasında tam entegrasyon

---

## Teknolojiler

- .NET 8
- ASP.NET Core Web API
- ASP.NET MVC
- Entity Framework Core
- SQL Server (varsayılan)
- AutoMapper
- Swagger (API dokümantasyonu)

---

## Kurulum

### 1. Backend (API) Projesi

API, varsayılan olarak şu adreslerde çalışır:
- https://localhost:7081/
- http://localhost:5134/

### 2. Frontend (MVC) Projesi

MVC projesi, genellikle https://localhost:5002/ gibi bir adreste çalışır.

---

## Projeleri Çalıştırma

1. **Önce API projesini başlatın.**  
   (Veritabanı migration işlemlerini tamamlayın.)

2. **Ardından MVC frontend projesini başlatın.**  
   (Web projesi, API'ye HTTP istekleri göndererek veri çeker ve gönderir.)

3. **Her iki proje de aynı anda çalışmalıdır.**  
   - API projesi: https://localhost:7081/
   - MVC projesi: https://localhost:5002/ (veya kendi portunuz)

---

## API Endpointleri (Örnekler)

- **Hikayeler**
  - GET    `/api/stories/getall`
  - GET    `/api/stories?id=1`
  - POST   `/api/stories/add`
  - POST   `/api/stories/update`
  - DELETE `/api/stories/delete?id=1`

- **Bölümler**
  - GET    `/api/chapters/getall`
  - GET    `/api/chapters?id=1`
  - POST   `/api/chapters/add`
  - POST   `/api/chapters/update`
  - DELETE `/api/chapters/delete?id=1`

- **Kullanıcılar**
  - GET    `/api/users/getall`
  - GET    `/api/users?id=1`
  - POST   `/api/users/add`
  - POST   `/api/users/update`
  - DELETE `/api/users/delete?id=1`

> Tüm endpointler için Swagger arayüzünü kullanabilirsiniz:  
> `https://localhost:7081/swagger`

---

## Entegrasyon

- **MVC projesi**, API projesine `HttpClient` ile istek gönderir.
- API'den dönen DTO'lar, MVC projesinde `Models` veya `Dtos` klasöründe tutulur.
- API ile haberleşen servisler (`StoryApiService`, `ChapterApiService` vb.) MVC projesinin `Services` klasöründe yer alır.
- CORS ayarları API projesinde yapılmıştır, böylece farklı portlarda çalışan frontend ve backend sorunsuz iletişim kurar.

---

## Katkı Sağlama

1. Fork'layın
2. Yeni bir branch oluşturun (`git checkout -b feature/ozellik`)
3. Değişikliklerinizi commit'leyin (`git commit -am 'Yeni özellik ekle'`)
4. Branch'i push'layın (`git push origin feature/ozellik`)
5. Pull request açın

---

## Lisans

Bu proje MIT lisansı ile lisanslanmıştır.

---

Her türlü soru ve katkı için lütfen iletişime geçin!
