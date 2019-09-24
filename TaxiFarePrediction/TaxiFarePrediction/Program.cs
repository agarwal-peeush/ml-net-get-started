using System;
using TaxiFarePredictionML.Model;

namespace TaxiFarePrediction
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsumeModel();
            Console.ReadKey();
        }

        static void ConsumeModel()
        {
            // Add input data
            var input = new ModelInput()
            {
                Rate_code = 1,
                Passenger_count = 1,
                Trip_time_in_secs = 821,
                Trip_distance = 2.5f,
                Payment_type = "CSH",
                Vendor_id = "CMT",
            };

            // Load model and predict output of sample data
            ModelOutput result = TaxiFarePredictionML.Model.ConsumeModel.Predict(input);
            Console.WriteLine($"Taxi Fare predicted = {result.Score}");
        }
    }
}
