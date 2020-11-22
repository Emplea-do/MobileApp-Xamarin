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
                new JobCards { Id=1, NameCard = "Diseño\nGráfico", Image = "graphicdesing.png" },
                new JobCards { Id=2, NameCard = "Desarrollo\nWeb", Image = "web.png"},
                new JobCards { Id=3, NameCard = "Desarrollo\nMóviles", Image = "mobile.png" },
                new JobCards { Id=4, NameCard = "Desarrollo\nde Software", Image = "software.png"},
                new JobCards { Id=5, NameCard = "Administrador\nde Sistemas", Image = "systems.png"},
                new JobCards { Id=6, NameCard = "Redes y\nTelecomunicaciones", Image = "networks.png"},
                new JobCards { Id=7, NameCard = "IT\nVentas", Image = "sales.png"},
                new JobCards { Id=8, NameCard = "Administrador\nBase de Datos", Image = "database.png"},
                new JobCards { Id=9, NameCard = "Desarrollo de\nVideojuegos", Image = "videogames.png"}
            };
        }
    }
}
