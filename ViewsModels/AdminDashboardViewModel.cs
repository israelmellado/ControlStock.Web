namespace ControlStock.Web.ViewsModels
{
    public class AdminDashboardViewModel
    {
        public int TotalProductos { get; set; }
        public int StockBajo { get; set; }
        public decimal ValorInventario { get; set; }
        public int TotalCategorias { get; set; }
    }
}
