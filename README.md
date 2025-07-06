# IT-Мост — Платформа менторства в Магнитогорске

## Описание
«IT-Мост» — это бесплатная платформа для обмена знаниями между студентами и профессионалами IT-сферы Магнитогорска. Студенты задают вопросы по программированию, тестированию, DevOps, аналитике и карьере, а эксперты из местных компаний отвечают на них в свободное время, помогая формировать будущих сотрудников.

## Цель проекта
Создать пространство, где:
- студенты получают поддержку от реальных IT-специалистов,
- эксперты делятся опытом без отрыва от работы,
- компании находят мотивированных кандидатов.

## Как это работает?
Формат: вопрос → ответ, как на Stack Overflow, но с акцентом на локальное сообщество.  
Каждый вопрос может быть помечен как "срочный", проголосован за полезность, отфильтрован по тегам (например, `#Python`, `#React`, `#Собеседования`).

## Для студентов
- Категории вопросов: Frontend, Backend, Data Science, Карьера.
- Голосование за полезные вопросы.
- Поиск по тегам.
- Флаг "срочного" вопроса.
- Публичный профиль + возможность добавить резюме (GitHub, LinkedIn, Telegram).

## Для экспертов
- Получайте уведомления о новых вопросах через Telegram.
- Публичный профиль с опытом и достижениями.
- Возможность найти потенциальных стажёров или сотрудников.

## Для компаний
- Канал прямого взаимодействия с молодыми специалистами.
- Продвижение технологий внутри города.
- Социальная ответственность и укрепление имиджа.

## Уникальная фишка
Интеграция с интерактивной картой **"IT-Магнитогорска"**, где отображаются компании, поддерживающие платформу.

## Технологии
- .NET 9
- ASP.NET Core
- Entity Framework Core
- MediatR
- PostgreSQL
- Swagger / OpenAPI
- JWT Authentication
- RabbitMQ
- Telegram Bot API

## Как запустить
1. Установите [dotnet SDK](https://dotnet.microsoft.com/download )
2. Клонируйте репозиторий 
3. В Visual Studio зайти в проект и выбрать CoreServiceWebApi.sln
4. Изменить параметры в DefaultConnection для подлючения к БД. Для этого нужно перейти и изменить два файла appsettings.json, которые находятся в CoreServiceWebApi и Notification.
5. Выполнить миграции:
5.1. dotnet ef database update -s CoreServiceWebApi -p CoreService.Infrastructure
5.2. dotnet ef database update -s Notification -p NotificationService.Infrastructure
6. Выполните `dotnet run`
 
Если нужно пересоздать миграции:
1. dotnet ef migrations add init -s CoreServiceWebApi -p CoreService.Infrastructure
2. dotnet ef migrations add init -s Notification -p NotificationService.Infrastructure 

## Авторы
[Kustubaev](https://github.com/Kustubaev)
[alexzubkov-tech](https://github.com/alexzubkov-tech)