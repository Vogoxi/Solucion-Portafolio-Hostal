using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class Pedido
    {
        private string _idProveedor;
        private int _nPedido, _idEmpleado;
        private DateTime _fechaEmision, _fechaEntrega;

        public Pedido()
        {
            NPedido = 0;
            IdEmpleado = 0;
            IdProveedor = "";
            FechaEmision = DateTime.Today;
            //FechaEntrega = DateTime.Today;
        }
        public int NPedido
        {
            get
            {
                return _nPedido;
            }

            set
            {
                _nPedido = value;
            }
        }

        public int IdEmpleado
        {
            get
            {
                return _idEmpleado;
            }

            set
            {
                _idEmpleado = value;
            }
        }

        public string IdProveedor
        {
            get
            {
                return _idProveedor;
            }

            set
            {
                _idProveedor = value;
            }
        }

        public DateTime FechaEmision
        {
            get
            {
                return _fechaEmision;
            }

            set
            {
                _fechaEmision = value;
            }
        }

        public DateTime FechaEntrega
        {
            get
            {
                return _fechaEntrega;
            }

            set
            {
                _fechaEntrega = value;
            }
        }

        public int getPedidoMaxId()
        {
            try
            {
                int user = (int)CommonBC.Modelo.PEDIDO.Max(us => us.N_PEDIDO);
                return user;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool AgregarPedido()
        {
            DALC.PEDIDO pedido = new DALC.PEDIDO();

            try
            {
                pedido.N_PEDIDO = getPedidoMaxId() + 1;
                this.NPedido = (int)pedido.N_PEDIDO;

                pedido.N_PEDIDO = getPedidoMaxId() + 1;
                pedido.FECHA_EMISION = this.FechaEmision;
                pedido.FECHA_ENTREGA = this.FechaEntrega;
                pedido.ID_EMPLEADO = this.IdEmpleado;
                pedido.ID_PROVEEDOR = this.IdProveedor;

                CommonBC.Modelo.PEDIDO.Add(pedido);
                CommonBC.Modelo.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                CommonBC.Modelo.PEDIDO.Remove(pedido);
                Logger.Log("Pedido.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return false;
            }
        }


        public Pedido GetPedido()
        {
            DALC.PEDIDO pedido = new DALC.PEDIDO();

            try
            {
                pedido = CommonBC.Modelo.PEDIDO.FirstOrDefault(r => this.NPedido == r.N_PEDIDO);

                if (pedido != null)
                {
                    Pedido pla = new Pedido();

                    pla.NPedido = (int)pedido.N_PEDIDO;
                    pla.IdEmpleado = (int)pedido.ID_EMPLEADO;
                    pla.IdProveedor = pedido.ID_PROVEEDOR;
                    pla.FechaEmision = (DateTime)pedido.FECHA_EMISION;
                    pla.FechaEntrega = (DateTime)pedido.FECHA_ENTREGA;

                    return pla;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Logger.Log("Pedido.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return null;
            }
        }

        public bool ActualizarPedido()
        {
            DALC.PEDIDO pedido = new DALC.PEDIDO();

            try
            {
                pedido = CommonBC.Modelo.PEDIDO.FirstOrDefault(r => this.NPedido == r.N_PEDIDO);


                pedido.ID_EMPLEADO = this.IdEmpleado;
                pedido.ID_PROVEEDOR = this.IdProveedor;
                pedido.FECHA_EMISION = this.FechaEmision;
                pedido.FECHA_ENTREGA = this.FechaEntrega;

                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Pedido.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return false;
            }
        }

        public bool BorrarPedido()
        {
            DALC.PEDIDO pedido = new DALC.PEDIDO();

            try
            {
                pedido = CommonBC.Modelo.PEDIDO.FirstOrDefault(r => this.NPedido == r.N_PEDIDO);

                CommonBC.Modelo.PEDIDO.Remove(pedido);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("Pedido.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return false;
            }
        }



    }
}
