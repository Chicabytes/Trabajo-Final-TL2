namespace tp6
{
    public enum EstadoPedido
    {
        Todos = -1,
        Recibido = 0,
        Preparado = 1,
        EnCamino = 2,
        Entregado = 3
    }
    public enum TipoPedido
    {
        Delicado = 0,
        Express = 1,
        Ecologico = 2
    };
    public class Pedido
    {
        private int numpedido;
        private string obs;
        private EstadoPedido estado_actual;
        private TipoPedido tipo;
        private Cliente nCliente;
        private Cadete cadete;

        public int Numpedido { get => numpedido; set => numpedido = value; }
        public string Obs { get => obs; set => obs = value; }
        public EstadoPedido Estado_actual { get => estado_actual; set => estado_actual = value; }
        public Cliente NCliente { get => nCliente; set => nCliente = value; }
        public Cadete Cadete { get => cadete; set => cadete = value; }
        public TipoPedido Tipo { get => tipo; set => tipo = value; }

        public Pedido()
        {
        }
        public Pedido(int _numpedido, string _obs, int _estado, int _tipo)
        {
            Numpedido = _numpedido;
            Obs = _obs;
            Estado_actual = (EstadoPedido)_estado;
            Tipo = (TipoPedido)_tipo;
        }
        public override string ToString()
        {
            return " Numero de pedido: " + Numpedido + "\n Observacion: " + Obs + "\n Estado del Pedido: " + Estado_actual.ToString();
        }
    }
}
