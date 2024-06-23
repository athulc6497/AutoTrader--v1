using AutoTrader.Models.General;

namespace AutoTrader.Models.CarInfo
{
    public class CarDetails
    {
        public int CarId { get; set; }
        public int VehicleTypeId { get; set; }
        public string Engine { get; set; }
        public int TransmissionId { get; set; }
        public string Ownership { get; set; }
        public string PeakTorque { get; set; }

        public string ModelName { get; set; }
        public string Doors { get; set; }
        public int DriveId { get; set; }
        public int SeatingCapacityId { get; set; }
        public string ManufacturingYear { get; set; }
        public int FuelId { get; set; }
        public string KmsDone { get; set; }
        public string Price { get; set; }
        public string ExteriorColor { get; set; }
        public string PaidFeature { get; set; }
        public byte[]? Photo { get; set; }

        [NonDbMember]
        public string Image => Photo == null ? "" : $"data:image/jpeg;base64,{Convert.ToBase64String(Photo)}";
    }
}
