namespace ControlStock.Web.ViewsModels
{
    public class DashboardViewModel
    {
        public int TotalProductos { get; set; }
        public int ProductosStockBajo { get; set; }
        public int TotalCategorias { get; set; }
        public decimal ValorInventario { get; set; }
    }
}
