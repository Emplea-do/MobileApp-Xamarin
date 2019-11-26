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
                new JobCards { NameCard = "Diseño Gráfico", Image = "disenoGrafico.png" },
                new JobCards { NameCard = "Desarrollo Web", Image = "web.png"},
                new JobCards { NameCard = "Desarrollo para Móviles", Image = "movil.png" },
                new JobCards { NameCard = "Desarrollo para Software", Image = "software.png"},
                new JobCards { NameCard = "Administrador de Sistemas", Image = "sistemas.png"},
                new JobCards { NameCard = "Redes y telecomunicaciones", Image = "redes.png"},
                new JobCards { NameCard = "IT Ventas", Image = "ventas.png"},
                new JobCards { NameCard = "Administrador de Base de Datos", Image = "baseDeDatos.png"},
                new JobCards { NameCard = "Desarrollo de Videojuegos", Image = "videoJuegos.png"}
            };
        }
    }
}
