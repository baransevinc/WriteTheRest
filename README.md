# WriteTheRest – Story Management Platform

# Proje Hakkında

WriteTheRest, kullanıcıların hikâyeler oluşturabildiği, bu hikâyelere bölümler ekleyebildiği ve bölümler üzerinde puanlama ile yorum yapabildiği bir hikâye yönetim platformudur.  
Sistem, frontend ve backend olmak üzere iki ayrı projeden oluşur ve bu projeler birbiriyle entegre şekilde çalışır.

Backend tarafında tüm iş kuralları ve veri işlemleri yer alırken, frontend tarafı kullanıcı arayüzünü sağlar.

# Proje Bileşenleri

- **Backend**  
  .NET 8 tabanlı RESTful API (Story.API).  
  Servisler, iş mantığı ve veri erişimi bu projede bulunur.

- **Frontend**  
  ASP.NET MVC tabanlı web uygulaması (WriteTheRest.Web).  
  Kullanıcı arayüzünü içerir ve API ile iletişim kurar.

Her iki proje birlikte çalışacak şekilde tasarlanmıştır.

# İçerik

- Özellikler  
- Kullanılan Teknolojiler  
- Kurulum  
- Projeleri Çalıştırma  
- API Endpointleri  
- Entegrasyon  
- Katkı Sağlama  
- Lisans  

# Özellikler

- Hikâye (Story) ekleme, listeleme, güncelleme ve silme işlemleri
- Bölüm (Chapter) yönetimi (CRUD)
- Kullanıcı yönetimi
- Hikâye versiyonlama ve puanlama sistemi
- RESTful API mimarisi
- MVC tabanlı kullanıcı arayüzü
- API ve frontend arasında tam entegrasyon

# Teknolojiler

- .NET 8
- ASP.NET Core Web API
- ASP.NET MVC
- Entity Framework Core
- SQL Server (varsayılan)
- AutoMapper
- Swagger (API dokümantasyonu)

# Kurulum

# Backend (API) Projesi

API projesi varsayılan olarak aşağıdaki adreslerde çalışır:

https://localhost:7081/
http://localhost:5134/

css
Kodu kopyala

# Frontend (MVC) Projesi

MVC projesi genellikle aşağıdaki gibi bir adreste çalışır:

https://localhost:5002/

bash
Kodu kopyala

# Projeleri Çalıştırma

Öncelikle API projesini başlatın.  
Gerekli veritabanı migration işlemlerinin tamamlandığından emin olun.

Ardından MVC frontend projesini çalıştırın.  
Web uygulaması, API’ye HTTP istekleri göndererek veri alır ve gönderir.

Her iki projenin de aynı anda çalışıyor olması gerekir.

- API projesi: https://localhost:7081/
- MVC projesi: https://localhost:5002/ (veya kendi port ayarınız)

# API Endpointleri

# Hikâyeler

GET /api/stories/getall
GET /api/stories?id=1
POST /api/stories/add
POST /api/stories/update
DELETE /api/stories/delete?id=1

bash
Kodu kopyala

# Bölümler

GET /api/chapters/getall
GET /api/chapters?id=1
POST /api/chapters/add
POST /api/chapters/update
DELETE /api/chapters/delete?id=1

bash
Kodu kopyala

# Kullanıcılar

GET /api/users/getall
GET /api/users?id=1
POST /api/users/add
POST /api/users/update
DELETE /api/users/delete?id=1

bash
Kodu kopyala

Tüm endpointleri incelemek ve test etmek için Swagger arayüzünü kullanabilirsiniz:

https://localhost:7081/swagger

markdown
Kodu kopyala

# Entegrasyon

MVC projesi, API ile HttpClient üzerinden iletişim kurar.  
API’den dönen DTO’lar, MVC projesinde Models veya Dtos klasörlerinde tutulur.  
API çağrılarını yapan servis sınıfları (StoryApiService, ChapterApiService vb.) Services klasörü altında yer alır.  
CORS ayarları API tarafında yapılandırılmıştır, böylece farklı portlarda çalışan projeler sorunsuz şekilde haberleşir.

# Katkı Sağlama

- Projeyi fork’layın
- Yeni bir branch oluşturun  
  `git checkout -b feature/yeni-ozellik`
- Değişikliklerinizi commit edin  
  `git commit -am 'Yeni özellik eklendi'`
- Branch’i uzak repoya gönderin  
  `git push origin feature/yeni-ozellik`
- Pull request oluşturun

# Lisans

Bu proje **MIT lisansı** ile lisanslanmıştır.

Her türlü soru, öneri veya katkı için iletişime geçebilirsiniz.
