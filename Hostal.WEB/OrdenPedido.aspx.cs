using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostal.WEB
{
    public partial class OrdenPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarGrid()
        {
            NEGOCIO.Proveedor proveedor =  (NEGOCIO.Proveedor)Session["proveedor"];

            NEGOCIO.PedidoCollection collection = new NEGOCIO.PedidoCollection();
            List<NEGOCIO.Pedido> pedidos = new List<NEGOCIO.Pedido>();
            pedidos = collection.ReadById(proveedor.Rut);

            grid_facturas.DataSource = pedidos;
            grid_facturas.DataBind();
            txtEntrega.Disabled = true;
            btn_aprobar.Enabled = false;
            btn_rechazar.Enabled = false;
        }

        protected void grid_facturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Int32.Parse(grid_facturas.SelectedRow.Cells[1].Text);
            NEGOCIO.DetallePedidoCollection collection = new NEGOCIO.DetallePedidoCollection();
            List<NEGOCIO.DetallePedido> detalle = new List<NEGOCIO.DetallePedido>();
            detalle = collection.ReadById(id);

            NEGOCIO.Pedido pedido = new NEGOCIO.Pedido();
            pedido.NPedido = int.Parse(grid_facturas.SelectedRow.Cells[1].Text);
            pedido = pedido.GetPedido();
           
            txt_nOrden.Text = pedido.NPedido.ToString();
            txtEmision.Text = pedido.FechaEmision.ToShortDateString();

            if (pedido.FechaEntrega > pedido.FechaEmision)
            {
                txtEntrega.Disabled = true;
                btn_aprobar.Enabled = false;
                btn_rechazar.Enabled = false;
                txtEntrega.Value = "yyyy-MM-dd";
                if (grid_facturas.SelectedRow.Cells[3].Text != "Rechazado")
                {
                    txtEntrega.Value = pedido.FechaEntrega.ToString("yyyy-MM-dd");         
                }
                
            }else
            {
                txtEntrega.Disabled = false;
                btn_aprobar.Enabled = true;
                btn_rechazar.Enabled = true;
            }           
             
            grid_detalle.DataSource = detalle;
            grid_detalle.DataBind();

            lbl_detalle.Text = String.Format("Productos OC N°: {0}",id);
        }

        protected void btn_aprobar_Click(object sender, EventArgs e)
        {
            NEGOCIO.Pedido pedido = new NEGOCIO.Pedido();
            pedido.NPedido = int.Parse(grid_facturas.SelectedRow.Cells[1].Text);
            pedido = pedido.GetPedido();

            DateTime entrega = DateTime.Parse(txtEntrega.Value);
            DateTime emision = pedido.FechaEmision;

            if (DateTime.Compare(emision, entrega) > 0)
            {
                lbl_Estado.Text = "La fecha de entrega debe ser mayor a la fecha de emisión.";
            }else
            {
                pedido.FechaEntrega = entrega;
                if (pedido.ActualizarPedido())
                {
                    lbl_Estado.Text = "Se a aprobado la orden de compra";
                    CargarGrid();
                }              
            }            
        }

        protected void btn_rechazar_Click(object sender, EventArgs e)
        {
            NEGOCIO.Pedido pedido = new NEGOCIO.Pedido();
            pedido.NPedido = int.Parse(txt_nOrden.Text);
            pedido = pedido.GetPedido();

            pedido.FechaEntrega = DateTime.MaxValue;

            if (pedido.ActualizarPedido())
            {
                lbl_Estado.Text = String.Format("Se ha rechazado el pedido N° {0}",pedido.NPedido);
            }
            
        }
    }
}