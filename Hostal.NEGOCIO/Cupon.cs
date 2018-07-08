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
    public class Cupon
    {
        private List<DetalleFactura> listaDet;
        private Empresa empresa;
        private Factura factura;

        public List<DetalleFactura> ListaDet
        {
            get
            {
                return listaDet;
            }

            set
            {
                listaDet = value;
            }
        }

        public Empresa Empresa
        {
            get
            {
                return empresa;
            }

            set
            {
                empresa = value;
            }
        }

        public Factura Factura
        {
            get
            {
                return factura;
            }

            set
            {
                factura = value;
            }
        }

        public Cupon()
        {
            this.ListaDet = new List<DetalleFactura>();
            this.Empresa = new Empresa();
            this.Factura = new Factura();
        }



        public byte[] GenerarCupon()
        {
            try
            {
                byte[] bytes = new byte[0];

                var cuponhtml = @"<html lang=""en"">
                                  <head>
                                  <metacontent =""text/html; charset=utf-8"" http-equiv=""Content-Type""/>
                                  <title></title>
                                  </head>
                                  <body>
                                        <div>
                                            <img width=""200%""  src=""C:\\Uploads\\logo.jpg"" />
                                            <br />
                                            <br />
                                            <br />
                                        </div>
                                        <div>
                                            <font size=""6"">Empresa: " + this.Empresa.RazonSocial + @"</font>
                                            <br />
                                            <br />
                                            <br />
                                            <font size=""5"">Fecha Factura: " + this.Factura.FechaFacturacion.ToShortDateString() + @"</font>
                                            <br />
                                            <br />
                                            <font size=""5"">N° Factura: " + this.Factura.Id+ @"</font>
                                            <br />
                                            <br />
                                            <br />
                                        </div>
                                        <div>
                                            <table style=""border-bottom-style:solid;"" width='100%' border='1'>
                                                <tr>
                                                    <th>Cantidad</th>
                                                    <th>Clase</th>
                                                    <th>Tipo</th>
                                                    <th>Precio Unitario</th>
                                                </tr>";

                ServicioCollection servicios = new ServicioCollection();
                
                int cantidad = 0;

                foreach (var item in servicios.ReadAll())
                {
                    cantidad = 0;
                    foreach (var det in ListaDet)
                    {
                        if (item.Id == det.IdServicio)
                        {
                            cantidad++;
                        }
                    }
                    if(cantidad > 0)
                    {
                        cuponhtml = cuponhtml + @"<tr>
                                                    <th>"+cantidad+@"</th>
                                                    <th>Servicio de Comedor</th>
                                                    <th>"+item.Nombre+@"</th>
                                                    <th>"+item.Precio.ToString("C0")+@"</th>
                                                  </tr>";
                    }
                }

                HabitacionCollection habitacion = new HabitacionCollection();
                
                
                foreach (var item in habitacion.ReadAll())
                {
                    cantidad = 0;

                    foreach (var det in ListaDet)
                    {
                        if (item.Numero == det.IdHabitacion)
                        {
                            cantidad++;
                        }
                    }
                    if (cantidad > 0)
                    {
                        cuponhtml = cuponhtml + @"<tr>
                                                    <th>" + cantidad + @"</th>
                                                    <th>Habitacion</th>
                                                    <th>" + item.Tipo+ @"</th>
                                                    <th>" + item.Precio.ToString("C0")+ @"</th>
                                                  </tr>";
                    }
                }

                       cuponhtml = cuponhtml + @"<tr>
                                                    <th></th>
                                                    <th></th>
                                                    <th>Total</th>
                                                    <th>"+this.Factura.Total.ToString("C0")+ @"</th>
                                                 </tr>
                                                </table>
                                                </div>
                                               </body>
                                               </html>";
                var cuponcss = "";

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
            catch (Exception ex)
            {
                return new byte[0];
            }
        }
    }
}
