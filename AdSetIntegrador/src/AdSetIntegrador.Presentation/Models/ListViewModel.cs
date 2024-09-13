namespace AdSetIntegrador.Presentation.Models
{
    public class ListViewModel
    {
        public OverviewModel Overview { get; set; } = new OverviewModel();
        public List<VehicleModel> Vehicles { get; set; } = new List<VehicleModel>();
        public FilterModel? Filter { get; set; }
    }
}
