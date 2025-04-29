using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace BrestCancerDetection.Classes
{
    public partial class MLTissue
    {
        // Calea către modelul ML.NET
        private static readonly string MLNetModelPath = Path.Combine(Directory.GetCurrentDirectory(), "../../Classes/MLModel/Model.mlnet");

        // Motor de predicție instanțiat lazy pentru performanță
        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

        // Dicționar pentru maparea etichetelor prescurtate la denumiri mai descriptive
        private static Dictionary<string, string> labelMap = new Dictionary<string, string>
        {
            { "F", "Fatty" },
            { "G", "Fatty-Glandular" },
            { "D", "Dense-Glandular" }
        };

        /// <summary>
        /// Creează motorul de predicție pe baza modelului ML.NET încărcat.
        /// </summary>
        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }

        /// <summary>
        /// Utilizează această metodă pentru a prezice scorurile pentru toate etichetele posibile.
        /// </summary>
        /// <param name="input">Datele de intrare ale modelului.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static IOrderedEnumerable<KeyValuePair<string, float>> PredictAllLabels(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            var result = predEngine.Predict(input);
            return GetSortedScoresWithLabels(result);
        }

        /// <summary>
        /// Mapează array-ul de scoruri neetichetate la denumirile etichetelor prezise.
        /// </summary>
        /// <param name="result">Predicția din care se obțin scorurile etichetate.</param>
        /// <returns>Listă ordonată de etichete și scoruri.</returns>
        /// <exception cref="Exception"></exception>
        public static IOrderedEnumerable<KeyValuePair<string, float>> GetSortedScoresWithLabels(ModelOutput result)
        {
            var unlabeledScores = result.Score;
            var labelNames = GetLabels(result);
            Dictionary<string, float> labeledScores = new Dictionary<string, float>();

            for (int i = 0; i < labelNames.Count(); i++)
            {
                string labelName = labelMap[labelNames.ElementAt(i)];
                labeledScores.Add(labelName, (float)Math.Round(unlabeledScores[i] * 100, 1));
            }

            return labeledScores.OrderByDescending(c => c.Value);
        }

        /// <summary>
        /// Obține lista ordonată de etichete.
        /// </summary>
        /// <param name="result">Rezultatul prezis din care se extrag etichetele.</param>
        /// <returns>Listă de etichete.</returns>
        /// <exception cref="Exception"></exception>
        public static IEnumerable<string> GetLabels(ModelOutput result)
        {
            var schema = PredictEngine.Value.OutputSchema;

            var labelColumn = schema.GetColumnOrNull("Label");
            if (labelColumn == null)
            {
                throw new Exception("Coloana 'Label' nu a fost găsită. Asigurați-vă că numele căutat corespunde cu cel din schemă.");
            }

            var keyNames = new VBuffer<ReadOnlyMemory<char>>();
            labelColumn.Value.GetKeyValues(ref keyNames);
            return keyNames.DenseValues().Select(x => x.ToString());
        }

        /// <summary>
        /// Utilizează această metodă pentru a prezice pe baza unui <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">Datele de intrare ale modelului.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            var output = predEngine.Predict(input);
            output.PredictedLabel = labelMap[output.PredictedLabel];
            return output;
        }
    }
}
