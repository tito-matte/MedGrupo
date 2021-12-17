using System;

namespace Apl.ERP.API.Models
{
    public class Contato : ModelGeral
    {
        public string ContatoID { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Sexo { get; set; }
        public int Idade
        {
            get
            {
                var spanNascimento = Nascimento.Ticks;
                var spanAgora = DateTime.Today.Ticks;

                var idade = spanAgora - spanNascimento;

                DateTime nasc = new DateTime(idade);

                return nasc.Year;
            }
        }
    }
}
