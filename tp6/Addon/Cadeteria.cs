using System;
using System.Collections.Generic;

namespace tp6
{
    class Cadeteria
    {
        private string nombre_cadeteria;
        private List<Cadete> listaCad;

        public string Nombre_cadeteria { get => nombre_cadeteria; set => nombre_cadeteria = value; }
        public List<Cadete> ListaCad { get => listaCad; set => listaCad = value; }

        public void CargarCadeteria(String _NombreCad, List<Cadete> _Lista)
        {
            Nombre_cadeteria = _NombreCad;
            ListaCad = new List<Cadete>();
            foreach (var Cadete in _Lista)
            {
                ListaCad.Add(Cadete);
            }
        }
    }
}
