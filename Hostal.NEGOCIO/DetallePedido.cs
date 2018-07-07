using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostal.NEGOCIO
{
    public class DetallePedido
    {
        private int _id,_idpedido,_cantidad;
        private string _producto;

        public DetallePedido()
        {
            this._id = 0;
            this._idpedido = 0;
            this._cantidad = 0;
            this._producto = "";
        }

        public int Cantidad
        {
            get
            {
                return _cantidad;
            }

            set
            {
                _cantidad = value;
            }
        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public int Idpedido
        {
            get
            {
                return _idpedido;
            }

            set
            {
                _idpedido = value;
            }
        }

        public string Producto
        {
            get
            {
                return _producto;
            }

            set
            {
                _producto = value;
            }
        }

        public int getPedidoMaxId()
        {
            try
            {
                int max = (int)CommonBC.Modelo.DETALLE_PEDIDO.Max(us => us.ID);
                return max;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool AgregarDetalle()
        {
            DALC.DETALLE_PEDIDO detpedido = new DALC.DETALLE_PEDIDO();

            try
            {
                // ID por trigger
                detpedido.ID = getPedidoMaxId() + 1;
                detpedido.ID_PEDIDO = this.Idpedido;
                detpedido.PRODUCTO = this.Producto;
                detpedido.CANTIDAD = this.Cantidad;

                CommonBC.Modelo.DETALLE_PEDIDO.Add(detpedido);
                CommonBC.Modelo.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                CommonBC.Modelo.DETALLE_PEDIDO.Remove(detpedido);
                Logger.Log("DetallePedido.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return false;
            }
        }


        public DetallePedido GetDetallePedido()
        {
            DALC.DETALLE_PEDIDO detpedido = new DALC.DETALLE_PEDIDO();

            try
            {
                detpedido = CommonBC.Modelo.DETALLE_PEDIDO.FirstOrDefault(r => this.Id == r.ID);

                if (detpedido != null)
                {
                    DetallePedido pla = new DetallePedido();

                    pla.Id = (int)detpedido.ID;
                    pla.Producto = detpedido.PRODUCTO;
                    pla.Cantidad = (int)detpedido.CANTIDAD;
                    

                    return pla;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Logger.Log("DetallePedido.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return null;
            }
        }

        public bool ActualizarDetallePedido()
        {
            DALC.DETALLE_PEDIDO detpedido = new DALC.DETALLE_PEDIDO();

            try
            {
                detpedido = CommonBC.Modelo.DETALLE_PEDIDO.FirstOrDefault(r => this.Id == r.ID);

                detpedido.ID_PEDIDO = this.Idpedido;
                detpedido.PRODUCTO = this.Producto;
                detpedido.CANTIDAD = this.Cantidad;

                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("DetallePedido.cs");
                Logger.Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Logger.Log(ex.InnerException.ToString());
                }
                return false;
            }
        }

        public bool BorrarDetallePedido()
        {
            DALC.DETALLE_PEDIDO detpedido = new DALC.DETALLE_PEDIDO();

            try
            {
                detpedido = CommonBC.Modelo.DETALLE_PEDIDO.FirstOrDefault(r => this.Id == r.ID);

                CommonBC.Modelo.DETALLE_PEDIDO.Remove(detpedido);
                CommonBC.Modelo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("DetPedido.cs");
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
