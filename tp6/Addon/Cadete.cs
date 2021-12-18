using System.Collections.Generic;
using System.Xml.Schema;

namespace tp6
{
    public enum TipoTransporte
    {
        Auto = 0,
        Moto = 1,
        Bicicleta = 2
    }

    public class Cadete : Persona
    {
        private int cant_pedidos;
        private TipoTransporte tipoT;
        private int id;
        public int Cant_pedidos { get => cant_pedidos; set => cant_pedidos = value; }
        public TipoTransporte TipoT { get => tipoT; set => tipoT = value; }
        public int Id { get => id; set => id = value; }

        public Cadete() : base(){
            TipoT = 0;
            Id = 0;
        }
        public Cadete(int _id, string _Nombre, string _Direccion, string _Telefono, int _tipo) : base(_Nombre, _Direccion, _Telefono)
        {
            Id = _id;
            TipoT = (TipoTransporte)_tipo;
        }
        /*
        public int Canti_Pedido(List<Pedido> _ListaPedidos)
        {
            int canti = 0;
            foreach (var pedido in _ListaPedidos)
            {
                if (pedido.Estado_actual == Estado.Entregado)
                {
                    canti++;
                }
            }
            return canti;
        }

        public float Jornal(List<Pedido> _ListaPedidos)
        {
            float cantidad = Canti_Pedido(_ListaPedidos);
            float porcentaje = 0;
            switch (tipoT)
            {
                case TipoTransporte.Auto:
                    porcentaje = cantidad * 0.3f;
                    break;
                case TipoTransporte.Moto:
                    porcentaje = cantidad * 0.2f;
                    break;
                case TipoTransporte.Bicicleta:
                    porcentaje = cantidad * 0.05f;
                    break;
            }
            float total = cantidad * 100 + porcentaje;
            return total;
        }*/
    }
}
