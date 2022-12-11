﻿using CloudShopApp.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace CloudShopApp.Model
{
    // контекст модели
    public class CloudShopDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }    // маппинг (отображение) таблицы в класс

        // конфигурация контекста
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // получаем файл конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // устанавливаем для контекста строку подключения
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("CloudDbConnectionString"));
        }
    }
}
