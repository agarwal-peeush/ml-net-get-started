using FirstMLAppML.Model;
using Microsoft.ML;
using System;

namespace FirstMLApp
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
            // Load the model
            MLContext mlContext = new MLContext();

            ITransformer mlModel = mlContext.Model.Load("MLModel.zip", out var modelInputSchema);

            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            // Use the code below to add input data
            var input = new ModelInput();
            input.SentimentText = "You're so rude";

            // Try model on sample data
            // True is toxic, false is non-toxic
            ModelOutput result = predEngine.Predict(input);

            Console.WriteLine($"Text: {input.SentimentText} | Prediction: {(Convert.ToBoolean(result.Prediction) ? "Toxic" : "Non Toxic")} sentiment");
        }
    }
}
