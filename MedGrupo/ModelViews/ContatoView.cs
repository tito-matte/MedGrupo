using System;

namespace Apl.ERP.API.ModelViews
{
    public class ContatoView
    {
        public int ContatoID { get; set; }
        public string Nome { get; set; }
        public string Nascimento { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }
        public StatusEN Status { get; set; }
    }
}
