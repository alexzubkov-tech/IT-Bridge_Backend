using CoreService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoreService.Infrastructure.Seeders
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var dbContext = serviceProvider.GetRequiredService<CoreServiceDbContext>();

            try
            {
                // 1. Создаем пользователей
                if (!dbContext.Users.Any())
                {
                    Console.WriteLine("Создаём пользователей...");
                    var users = new List<User>
                    {
                        new User { UserName = "john_doe", Email = "john@example.com" },
                        new User { UserName = "jane_smith", Email = "jane@example.com" },
                        new User { UserName = "mike_brown", Email = "mike@example.com" },
                        new User { UserName = "sarah_jones", Email = "sarah@example.com" },
                        new User { UserName = "alex_wilson", Email = "alex@example.com" }
                    };

                    foreach (var user in users)
                    {
                        await userManager.CreateAsync(user, "password");
                    }

                    await dbContext.SaveChangesAsync();
                    Console.WriteLine("Создали пользователей...");
                }

                // Получаем реальные Id пользователей из БД
                var usersInDb = await userManager.Users.ToListAsync();

                // 2. Компании
                if (!dbContext.Companies.Any())
                {
                    await dbContext.Companies.AddRangeAsync(
                        new Company
                        {
                            Name = "Tech Innovators",
                            TaxID = "1234567890",
                            Address = "ул. Технологическая, д. 5",
                            FoundationDate = new DateOnly(2015, 1, 1),
                            EmployeeCount = 200,
                            Industry = Industry.IT,
                            PhoneNumber = "+7 (495) 111-22-33",
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new Company
                        {
                            Name = "Frontend Masters",
                            TaxID = "2345678901",
                            Address = "ул. Дизайнерская, д. 10",
                            FoundationDate = new DateOnly(2018, 5, 15),
                            EmployeeCount = 80,
                            Industry = Industry.Frontend,
                            PhoneNumber = "+7 (495) 222-33-44",
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new Company
                        {
                            Name = "Backend Experts",
                            TaxID = "3456789012",
                            Address = "ул. Программистов, д. 20",
                            FoundationDate = new DateOnly(2017, 3, 10),
                            EmployeeCount = 120,
                            Industry = Industry.Backend,
                            PhoneNumber = "+7 (495) 333-44-55",
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new Company
                        {
                            Name = "Design Studio",
                            TaxID = "4567890123",
                            Address = "ул. Арт, д. 3",
                            FoundationDate = new DateOnly(2016, 7, 20),
                            EmployeeCount = 40,
                            Industry = Industry.Disign,
                            PhoneNumber = "+7 (495) 444-55-66",
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new Company
                        {
                            Name = "AI Solutions",
                            TaxID = "5678901234",
                            Address = "ул. Науки, д. 1",
                            FoundationDate = new DateOnly(2020, 11, 5),
                            EmployeeCount = 300,
                            Industry = Industry.IT,
                            PhoneNumber = "+7 (495) 555-66-77",
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        }
                    );
                    await dbContext.SaveChangesAsync();
                }

                // 3. Категории
                if (!dbContext.Categories.Any())
                {
                    await dbContext.Categories.AddRangeAsync(
                        new Category { Name = "Backend", Description = "Все о бэкенде", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new Category { Name = "Frontend", Description = "Все о фронтенде", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new Category { Name = "UI/UX", Description = "Дизайн и UX", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new Category { Name = "DevOps", Description = "Процессы разработки и деплоя", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new Category { Name = "Testing", Description = "Тестирование ПО", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
                    );
                    await dbContext.SaveChangesAsync();
                }

                // 4. Теги
                if (!dbContext.Tags.Any())
                {
                    await dbContext.Tags.AddRangeAsync(
                        new Tag { Name = "C#", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new Tag { Name = "ASP.NET Core", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new Tag { Name = "React", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new Tag { Name = "PostgreSQL", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new Tag { Name = "Docker", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
                    );
                    await dbContext.SaveChangesAsync();
                }

                // 5. Профили пользователей
                if (!dbContext.UserProfiles.Any())
                {
                    var profiles = new List<UserProfile>
                    {
                        new UserProfile
                        {
                            FIO = "Иван Иванов",
                            Bio = "Senior Backend Developer",
                            Position = Position.Senior,
                            IsExpert = true,
                            UserId = usersInDb[0].Id,
                            CompanyId = 1,
                            CategoryId = 1,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new UserProfile
                        {
                            FIO = "Мария Петрова",
                            Bio = "Frontend разработчик",
                            Position = Position.Middle,
                            IsExpert = false,
                            UserId = usersInDb[1].Id,
                            CompanyId = 2,
                            CategoryId = 2,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new UserProfile
                        {
                            FIO = "Алексей Смирнов",
                            Bio = "Fullstack разработчик",
                            Position = Position.Senior,
                            IsExpert = true,
                            UserId = usersInDb[2].Id,
                            CompanyId = 3,
                            CategoryId = 1,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new UserProfile
                        {
                            FIO = "Екатерина Новикова",
                            Bio = "UI/UX дизайнер",
                            Position = Position.Middle,
                            IsExpert = false,
                            UserId = usersInDb[3].Id,
                            CompanyId = 4,
                            CategoryId = 3,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new UserProfile
                        {
                            FIO = "Дмитрий Козлов",
                            Bio = "DevOps инженер",
                            Position = Position.Senior,
                            IsExpert = true,
                            UserId = usersInDb[4].Id,
                            CompanyId = 5,
                            CategoryId = 4,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        }
                    };
                    await dbContext.UserProfiles.AddRangeAsync(profiles);
                    await dbContext.SaveChangesAsync();
                }

                // 6. Вопросы
                if (!dbContext.Questions.Any())
                {
                    var questions = new List<Question>
                    {
                        new Question
                        {
                            Title = "Как реализовать пагинацию?",
                            Content = "Нужно реализовать пагинацию в API ASP.NET Core.",
                            IsUrgent = true,
                            UserProfileId = 1,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new Question
                        {
                            Title = "Как стилизовать кнопку в React?",
                            Content = "Не могу понять, как правильно использовать CSS-in-JS.",
                            IsUrgent = false,
                            UserProfileId = 2,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new Question
                        {
                            Title = "Как оптимизировать SQL-запрос?",
                            Content = "Мой запрос выполняется слишком долго.",
                            IsUrgent = true,
                            UserProfileId = 3,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new Question
                        {
                            Title = "Как настроить Docker для .NET приложения?",
                            Content = "Не могу запустить контейнер с .NET сервисом.",
                            IsUrgent = true,
                            UserProfileId = 4,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new Question
                        {
                            Title = "Что такое CI/CD и как его настроить?",
                            Content = "Хочу автоматизировать деплой своих проектов.",
                            IsUrgent = false,
                            UserProfileId = 5,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        }
                    };
                    await dbContext.Questions.AddRangeAsync(questions);
                    await dbContext.SaveChangesAsync();
                }

                // 7. Ответы
                if (!dbContext.Answers.Any())
                {
                    var answers = new List<Answer>
                    {
                        new Answer { Content = "Используйте Skip() и Take()", QuestionId = 1, UserProfileId = 2, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new Answer { Content = "Попробуйте styled-components", QuestionId = 2, UserProfileId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new Answer { Content = "Добавьте индексы к полям", QuestionId = 3, UserProfileId = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new Answer { Content = "Используйте Dockerfile из официального образа", QuestionId = 4, UserProfileId = 5, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new Answer { Content = "GitHub Actions — отличное решение", QuestionId = 5, UserProfileId = 3, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
                    };
                    await dbContext.Answers.AddRangeAsync(answers);
                    await dbContext.SaveChangesAsync();
                }

                // 8. Комментарии к вопросам
                if (!dbContext.CommentQuestions.Any())
                {
                    var commentQuestions = new List<CommentQuestion>
                    {
                        new CommentQuestion { Content = "Хороший вопрос!", QuestionId = 1, UserProfileId = 2, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new CommentQuestion { Content = "Тоже столкнулся с этим.", QuestionId = 2, UserProfileId = 3, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new CommentQuestion { Content = "Интересно, есть ли другие варианты?", QuestionId = 3, UserProfileId = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new CommentQuestion { Content = "Спасибо за вопрос!", QuestionId = 4, UserProfileId = 5, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new CommentQuestion { Content = "Полезная тема.", QuestionId = 5, UserProfileId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
                    };
                    await dbContext.CommentQuestions.AddRangeAsync(commentQuestions);
                    await dbContext.SaveChangesAsync();
                }

                // 9. Комментарии к ответам
                if (!dbContext.CommentAnswers.Any())
                {
                    var commentAnswers = new List<CommentAnswer>
                    {
                        new CommentAnswer { Content = "Спасибо за ответ!", AnswerId = 1, UserProfileId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new CommentAnswer { Content = "Это помогло мне.", AnswerId = 2, UserProfileId = 2, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new CommentAnswer { Content = "Интересный подход.", AnswerId = 3, UserProfileId = 3, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new CommentAnswer { Content = "Круто, что поделились решением.", AnswerId = 4, UserProfileId = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new CommentAnswer { Content = "Работает отлично!", AnswerId = 5, UserProfileId = 5, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
                    };
                    await dbContext.CommentAnswers.AddRangeAsync(commentAnswers);
                    await dbContext.SaveChangesAsync();
                }

                // 10. Рейтинги вопросов
                if (!dbContext.RatingQuestions.Any())
                {
                    var ratingQuestions = new List<RatingQuestion>
                    {
                        new RatingQuestion { QuestionId = 1, UserProfileId = 2, IsGoodAnswer = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new RatingQuestion { QuestionId = 2, UserProfileId = 3, IsGoodAnswer = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new RatingQuestion { QuestionId = 3, UserProfileId = 4, IsGoodAnswer = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new RatingQuestion { QuestionId = 4, UserProfileId = 5, IsGoodAnswer = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new RatingQuestion { QuestionId = 5, UserProfileId = 1, IsGoodAnswer = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
                    };
                    await dbContext.RatingQuestions.AddRangeAsync(ratingQuestions);
                    await dbContext.SaveChangesAsync();
                }

                // 11. Рейтинги ответов
                if (!dbContext.RatingAnswers.Any())
                {
                    var ratingAnswers = new List<RatingAnswer>
                    {
                        new RatingAnswer { AnswerId = 1, UserProfileId = 2, IsGoodAnswer = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new RatingAnswer { AnswerId = 2, UserProfileId = 3, IsGoodAnswer = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new RatingAnswer { AnswerId = 3, UserProfileId = 4, IsGoodAnswer = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new RatingAnswer { AnswerId = 4, UserProfileId = 5, IsGoodAnswer = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new RatingAnswer { AnswerId = 5, UserProfileId = 1, IsGoodAnswer = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
                    };
                    await dbContext.RatingAnswers.AddRangeAsync(ratingAnswers);
                    await dbContext.SaveChangesAsync();
                }

                // 12. Теги к вопросам
                if (!dbContext.QuestionTags.Any())
                {
                    var questionTags = new List<QuestionTag>
                    {
                        new QuestionTag { QuestionId = 1, TagId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new QuestionTag { QuestionId = 2, TagId = 3, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new QuestionTag { QuestionId = 3, TagId = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new QuestionTag { QuestionId = 4, TagId = 5, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new QuestionTag { QuestionId = 5, TagId = 2, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
                    };
                    await dbContext.QuestionTags.AddRangeAsync(questionTags);
                    await dbContext.SaveChangesAsync();
                }

                // 13. Категории к вопросам
                if (!dbContext.QuestionCategories.Any())
                {
                    Console.WriteLine("Создаём Категории к вопросам...");
                    var questionCategories = new List<QuestionCategory>
                    {
                        new QuestionCategory { QuestionId = 1, CategoryId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new QuestionCategory { QuestionId = 2, CategoryId = 2, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new QuestionCategory { QuestionId = 3, CategoryId = 5, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new QuestionCategory { QuestionId = 4, CategoryId = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                        new QuestionCategory { QuestionId = 5, CategoryId = 4, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
                    };
                    await dbContext.QuestionCategories.AddRangeAsync(questionCategories);
                    await dbContext.SaveChangesAsync();
                    Console.WriteLine("Создали Категории к вопросам...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сидинге БД: " + ex.Message);
                Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
            }
        }
    }
}