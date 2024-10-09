using System.ComponentModel.DataAnnotations;

namespace BpMeasurementApp.Entities
{
    public class BpMeasurement
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a systolic reading")]
        [Range(20, 400)]
        public int Systolic { get; set; }

        [Required(ErrorMessage = "Please enter a diastolic reading.")]
        [Range(10, 300)]
        public int Diastolic { get; set; }

        [Required(ErrorMessage = "Please enter a measurement date")]
        public DateTime MeasurementDate { get; set; }

        // Foreign Key for Position
        [Required(ErrorMessage = "Please enter a position for the measurement")]
        public string? PositionID { get; set; }
        public Position? Position { get; set; }

        // Readonly property to determine BP Category
        public string Category
        {
            get
            {
                if (Systolic < 120 && Diastolic < 80)
                    return "Normal";
                else if (Systolic <= 129 && Diastolic < 80)
                    return "Elevated";
                else if (Systolic <= 139 || Diastolic <= 89)
                    return "Hypertension Stage 1";
                else if (Systolic >= 140 || Diastolic >= 90)
                    return "Hypertension Stage 2";
                else
                    return "Hypertensive Crisis";
            }
        }
    }
}
