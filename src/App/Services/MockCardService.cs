using App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App.Services
{
    public class MockCardService
    {
       
        public List<JobCards> GetJobCards()
        {
            return new List<JobCards>
            {
                new JobCards { Id=1, NameCard = "Diseño Gráfico", Image = "graphicdesing.png" },
                new JobCards { Id=2, NameCard = "Desarrollo Web", Image = "web.png"},
                new JobCards { Id=3, NameCard = "Desarrollo para Móviles", Image = "mobile.png" },
                new JobCards { Id=4, NameCard = "Desarrollo para Software", Image = "software.png"},
                new JobCards { Id=5, NameCard = "Administrador de Sistemas", Image = "systems.png"},
                new JobCards { Id=6, NameCard = "Redes y telecomunicaciones", Image = "networks.png"},
                new JobCards { Id=7, NameCard = "IT Ventas", Image = "sales.png"},
                new JobCards { Id=8, NameCard = "Administrador de Base de Datos", Image = "database.png"},
                new JobCards { Id=9, NameCard = "Desarrollo de Videojuegos", Image = "videogames.png"}
            };
        }
    }
}
