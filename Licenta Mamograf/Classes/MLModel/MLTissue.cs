using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Licenta_Mamograf.Classes
{
    public partial class MLTissue
    {
        private static readonly string MLNetModelPath = Path.Combine(Directory.GetCurrentDirectory(), @"../../Classes/MLModel/Model.mlnet");
        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);
        
        private static Dictionary<string, string> labelMap = new Dictionary<string, string>
        {
            { "F", "Fatty" },
            { "G", "Fatty-Glandular" },
            { "D", "Dense-Glandular" }
        };

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
        public static IOrderedEnumerable<KeyValuePair<string, float>> PredictAllLabels(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            var result = predEngine.Predict(input);
            return GetSortedScoresWithLabels(result);
        }
        public static IOrderedEnumerable<KeyValuePair<string, float>> GetSortedScoresWithLabels(ModelOutput result)
        {
            var unlabeledScores = result.Score;
            var labelNames = GetLabels(result);
            Dictionary<string, float> labledScores = new Dictionary<string, float>();
            
            for (int i = 0; i < labelNames.Count(); i++)
            {
                string labelName = labelMap[labelNames.ElementAt(i)];
                labledScores.Add(labelName, (float)Math.Round(unlabeledScores[i] * 100, 1));
            }

            return labledScores.OrderByDescending(c => c.Value);
        }
        public static IEnumerable<string> GetLabels(ModelOutput result)
        {
            var schema = PredictEngine.Value.OutputSchema;

            var labelColumn = schema.GetColumnOrNull("Label");
            if (labelColumn == null)
            {
                throw new Exception("Label column not found. Make sure the name searched for matches the name in the schema.");
            }

            var keyNames = new VBuffer<ReadOnlyMemory<char>>();
            labelColumn.Value.GetKeyValues(ref keyNames);
            return keyNames.DenseValues().Select(x => x.ToString());
        }
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            var output = predEngine.Predict(input);
            output.PredictedLabel = labelMap[output.PredictedLabel];
            return output;
        }
    }
}
