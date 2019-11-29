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
                new JobCards { NameCard = "Diseño Gráfico", Image = "graphicdesing.png" },
                new JobCards { NameCard = "Desarrollo Web", Image = "web.png"},
                new JobCards { NameCard = "Desarrollo para Móviles", Image = "mobile.png" },
                new JobCards { NameCard = "Desarrollo para Software", Image = "software.png"},
                new JobCards { NameCard = "Administrador de Sistemas", Image = "systems.png"},
                new JobCards { NameCard = "Redes y telecomunicaciones", Image = "networks.png"},
                new JobCards { NameCard = "IT Ventas", Image = "sales.png"},
                new JobCards { NameCard = "Administrador de Base de Datos", Image = "database.png"},
                new JobCards { NameCard = "Desarrollo de Videojuegos", Image = "videogame.png"}
            };
        }
    }
}
