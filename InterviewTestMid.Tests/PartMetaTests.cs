using System.Text.Json;
using InterviewTestMid.Models;
using Xunit;

namespace InterviewTestMid.Tests
{
    public class PartMetaTests
    {
        private static List<Part> LoadTestParts()
        {
            string jsonPath = Path.Combine(AppContext.BaseDirectory, "TestData", "SampleData.json");
            string jsonText = File.ReadAllText(jsonPath);

            var options = new JsonSerializerOptions { AllowTrailingCommas = true };
            return JsonSerializer.Deserialize<List<Part>>(jsonText, options)
                ?? throw new InvalidOperationException("Failed to load test data.");
        }

        [Theory]
        [InlineData("LABEL UNPRINTED", 4)]
        [InlineData("BLUE TRAY", 4)]
        [InlineData("FOIL", 3)]
        public void Part_Meta_Has_Expected_Number_Of_PopulatedLookupItems(string partDesc, int expectedCount)
        {
            // Arrange
            List<Part> parts = LoadTestParts();
            Part part = parts.Single(p => p.PartDesc == partDesc);

            // Act: 
            int actualCount = typeof(PartMeta)
                .GetProperties()
                .Count(prop => prop.GetValue(part.Meta) != null);

            // Assert
            Assert.Equal(expectedCount, actualCount);
        }
    }
}