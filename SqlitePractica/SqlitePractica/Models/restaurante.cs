namespace SqlitePractica.Models
{
    using System;

    public partial class restaurante
    {
        public int idRes { get; set; }
        public string nombre { get; set; }
        public Nullable<float> rating { get; set; }
        public string imgLogo { get; set; }
        public Nullable<float> xlat { get; set; }
        public Nullable<float> ylon { get; set; }
        public string descp { get; set; }
        public string horaS { get; set; }
        public string horaE { get; set; }
        public string imgLaye { get; set; }
        public string pass { get; set; }
        public string PersonaEncargada { get; set; }
        public string NumTelefono { get; set; }
    }
    
}
