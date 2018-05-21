using System;
using Microsoft.ML.Models;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using Microsoft.ML;
using System.Threading.Tasks;

namespace lol
{
    class Program
    {
        const string DataPath = @"C:\Users\Sneha More\Documents\Visual Studio 2017\Projects\lol\lol\bin\Data\trin.csv";
        const string TestDataPath = @"C:\Users\Sneha More\Documents\Visual Studio 2017\Projects\lol\lol\bin\Data\tst.csv";
        const string ModelPath = @"C:\Users\Sneha More\Documents\Visual Studio 2017\Projects\lol\lol\bin\Data\Models\Models.zip";
        static async Task Main(string[] args)
        {
            try
            {
                PredictionModel<RandomFone, Predict> model = await TrainAsync();
                Evaluate(model);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static async System.Threading.Tasks.Task<PredictionModel<RandomFone, Predict>> TrainAsync()
        {
            try
            {
                var pipeline = new LearningPipeline();
                pipeline.Add(new TextLoader<RandomFone>(DataPath, useHeader: true, separator: ","));
                pipeline.Add(new ColumnCopier(("price", "Label")));
                pipeline.Add(new ColumnConcatenator("Features",
                                        "month",
                                        "year",
                                        "price"));
                pipeline.Add(new FastForestRegressor());
                PredictionModel<RandomFone, Predict> model = pipeline.Train<RandomFone, Predict>();
                await model.WriteAsync(ModelPath);
                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        private static void Evaluate(PredictionModel<RandomFone, Predict> model)
        {
            try
            {
                var testData = new TextLoader<RandomFone>(TestDataPath, useHeader: true, separator: ",");
                var evaluator = new RegressionEvaluator();
                RegressionMetrics metrics = evaluator.Evaluate(model, testData);
                Console.WriteLine("Rms=" + metrics.Rms);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
