using InterviewTestMid.Models;
using System.Text.Json;


namespace InterviewTestMid
{
    internal class Program
    {
        private readonly ILogger _logger;

        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };
        public Program(ILogger logger)
        {
            _logger = logger;
            DoWork();
        }

        private void DoWork()
        {
            _logger.WriteLogMessage("Doing some JSON tasks...");

            string jsonPath = Path.Combine(AppContext.BaseDirectory, "Data", "SampleData.json");
            string jsonText = File.ReadAllText(jsonPath);

            List<Part> parts = JsonSerializer.Deserialize<List<Part>>(jsonText, JsonOptions)
                ?? throw new InvalidOperationException("Failed to deserialize SampleData.json");

            _logger.WriteLogMessage($"Loaded {parts.Count} parts from JSON.");

            // LINQ query: all material descriptions for the "FOIL" part
            List<string> foilMaterialDescriptions = parts
                .Where(p => p.PartDesc == "FOIL")
                .SelectMany(p => p.Materials)
                .Select(m => m.Material.LookDesc)
                .ToList();

            _logger.WriteLogMessage($"FOIL material descriptions: {string.Join(", ", foilMaterialDescriptions)}");

            // Change the PartWeight of a chosen part ("BLUE TRAY")
            Part? partToUpdate = parts.FirstOrDefault(p => p.PartDesc == "BLUE TRAY");
            if (partToUpdate != null)
            {
                decimal oldWeight = partToUpdate.PartWeight.Value;
                partToUpdate.PartWeight.Value = 2.5m;
                _logger.WriteLogMessage($"Updated {partToUpdate.PartDesc} PartWeight from {oldWeight} to {partToUpdate.PartWeight.Value}.");
            }

            // Serialise the edited object back to a new JSON file
            string updatedJson = JsonSerializer.Serialize(parts, JsonOptions);
            string outputPath = Path.Combine(AppContext.BaseDirectory, "Data", "SampleData_Updated.json");
            File.WriteAllText(outputPath, updatedJson);

            _logger.WriteLogMessage($"Updated JSON written to: {outputPath}");

            _logger.WriteLogMessage("Finished doing some JSON tasks.");
        }
        static void Main(string[] args) {
            ILogger logger = new Logger();
            _  = new Program(logger);
        }
    }
}