using Microsoft.ML.Data;

namespace Licenta_Mamograf.Classes
{
    /// <summary>
    /// model input class for MLTissue.
    /// </summary>
    public class ModelInput
    {
        [LoadColumn(0)]
        [ColumnName(@"Label")]
        public string Label { get; set; }

        [LoadColumn(1)]
        [ColumnName(@"ImageSource")]
        public byte[] ImageSource { get; set; }
    }
}
