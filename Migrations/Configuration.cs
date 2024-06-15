﻿namespace iCantine.Migrations
{
    using iCantine.models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

    internal sealed class Configuration : DbMigrationsConfiguration<iCantine.models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(iCantine.models.Context context)
        {
            context.Employees.AddOrUpdate(
                e => e.idUser,
                new Employee("aeb", "aeb", 123123123),
                new Employee("joel", "joel", 321321321),
                new Employee("pedro", "pedro", 231231231)
            );
            context.Plates.AddOrUpdate(
            p => p.idPlate,
                new Plate("Feijoada", "Carne", 20, 25.00),
                new Plate("Bacalhau à Brás", "Peixe", 15, 30.00),
                new Plate("Moqueca de Camarão", "Peixe", 10, 35.00),
                new Plate("Lasanha de Legumes", "Vegetariano", 12, 22.00),
                new Plate("Strogonoff de Frango", "Carne", 18, 20.00),
                new Plate("Risoto de Funghi", "Vegetariano", 15, 28.00),
                new Plate("Salada Grega", "Vegetariano", 25, 18.00),
                new Plate("Picanha na Brasa", "Carne", 8, 40.00),
                new Plate("Filete de Salmão", "Peixe", 12, 38.00),
                new Plate("Quiche de Espinafres e Requeijão", "Vegetariano", 20, 15.00)

                );
            context.Extras.AddOrUpdate(
                e => e.idExtra,
                new Extra("Batata Frita", 50, 3),
                new Extra("Arroz Branco", 40, 2),
                new Extra("Feijão Preto", 35, 2),
                new Extra("Salada Verde", 30, 3),
                new Extra("Legumes Cozidos", 25, 3),
                new Extra("Farofa", 20, 1),
                new Extra("Vinagrete", 20, 1),
                new Extra("Molho de Pimenta", 15, 1),
                new Extra("Pão de Alho", 20, 2),
                new Extra("Queijo Coalho", 15, 3)
            );
        }
    }
}
