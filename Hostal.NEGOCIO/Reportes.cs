using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using System.Xml.Serialization;
using Hostal.NEGOCIO;
using System.Web;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;


namespace Hostal.NEGOCIO
{
    public class Reportes
    {
        private Factura _factura;
        private List<DetalleFactura> _detFac;
        private List<Habitacion> _habitaciones;
        private List<Servicio> _servicio;
        private List<Empresa> _empresa;
        private List<Huesped> _huesped;

        private Pedido _pedido;
        private List<DetallePedido> _detPedido;

        public Factura Factura
        {
            get
            {
                return _factura;
            }

            set
            {
                _factura = value;
            }
        }

        public List<DetalleFactura> DetFac
        {
            get
            {
                return _detFac;
            }

            set
            {
                _detFac = value;
            }
        }

        public List<Habitacion> Habitaciones
        {
            get
            {
                return _habitaciones;
            }

            set
            {
                _habitaciones = value;
            }
        }

        public List<Servicio> Servicio
        {
            get
            {
                return _servicio;
            }

            set
            {
                _servicio = value;
            }
        }

        public List<Empresa> Empresa
        {
            get
            {
                return _empresa;
            }

            set
            {
                _empresa = value;
            }
        }

        public List<Huesped> Huesped
        {
            get
            {
                return _huesped;
            }

            set
            {
                _huesped = value;
            }
        }

        public Pedido Pedido
        {
            get
            {
                return _pedido;
            }

            set
            {
                _pedido = value;
            }
        }

        public List<DetallePedido> DetPedido
        {
            get
            {
                return _detPedido;
            }

            set
            {
                _detPedido = value;
            }
        }

        public Reportes()
        {
            this.Factura = new Factura();
            this.DetFac = new List<DetalleFactura>();
            this.Habitaciones = new List<Habitacion>();
            this.Servicio = new List<Servicio>();
            this.Empresa = new List<Empresa>();
            this.Huesped = new List<Huesped>();
            this.Pedido = new Pedido();
            this.DetPedido = new List<DetallePedido>();
        }

        public byte[] ReportePedidos(DateTime fecha, int[] tipos)
        {
            var mes = fecha.Month;
            var año = fecha.Year;

            PedidoCollection pedido = new PedidoCollection();
            /*
            pedido.BuscarReporte(mes,año);

            int resultado = pedido.BuscarReporte(mes, año);
            */
            var bytes = new byte[0];

            string cuponhtml = @"<html lang=""en"">
                                  <head>
                                  <metacontent =""text/html; charset=utf-8"" http-equiv=""Content-Type""/>
                                  <title></title>
                                  </head>
                                  <body>
                                         <div>
                                            <h2>"+DateTime.Today.ToShortDateString()+@"</h2>
                                            <img width=""200%""  src=""C:\\Uploads\\logo.jpg"" />
                                            <br />
                                            <br />
                                            <br />
                                        </div>
                                    <div>
                                        <h2>Reporte de Pedidos Hostal Doña Clarita</h2>
                                        <br />
                                        <br />
                                        <br />
                                        <h3>Fecha Consultada: "+fecha.ToShortDateString()+ @"</h3>
                                        <br />
                                        <br />
                                    </div>
                                    <div>";


            foreach (var item in tipos)
            {
                switch(item)
                {
                    case 1:
                        cuponhtml = cuponhtml + @"<h3>Pedidos Rechazados: " + pedido.BuscarReporte(mes, año, item) + @"</h3><br /><br />";
                        break;
                    case 2:
                        cuponhtml = cuponhtml + @"<h3>Pedidos Sin Procesar: " + pedido.BuscarReporte(mes, año, item) + @"</h3><br /><br />";
                        break;
                    case 3:
                        cuponhtml = cuponhtml + @"<h3>Pedidos Aprobados: " + pedido.BuscarReporte(mes, año, item) + @"</h3><br /><br />";
                        break;
                    case 4:
                        cuponhtml = cuponhtml + @"<h3>Pedidos Totales: " + pedido.BuscarReporteTotal(mes, año) + @"</h3><br /><br />";
                        break;
                    default:
                        break;
                }
            }

           
                                        
            cuponhtml = cuponhtml+ @"</div>
                                  </body>
                                  </html>
                                    ";

            string cuponcss = @"";

            using (var memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 40, 30, 30, 30);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                using (var cssMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(cuponcss)))
                {
                    using (var htmlMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(cuponhtml)))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, htmlMemoryStream, cssMemoryStream);
                    }
                }
                document.Close();

                bytes = memoryStream.ToArray();
            }


            return bytes;
        }

    }
}
