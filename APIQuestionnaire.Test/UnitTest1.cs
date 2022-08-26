using APIQuestionnaire.Interface;
using APIQuestionnaire.Model;
using System.Data;
using System.Globalization;

namespace APIQuestionnaire.Test
{
    public class UnitTest1
    {
        private static List<DataQuestion> GetMockDataQuestion()
        {
            List<DataQuestion> dataQuestions = new List<DataQuestion>
            {
                new DataQuestion
                {
                    Id = "01",
                    Title = "Mr.",
                    FirstName = "Test",
                    LastName = "Test",
                    DateOfBirth = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd",new CultureInfo("en-GB"))),
                    Country = "Thai",
                    House = "Ladprao",
                    Work = "Ladprao",
                    Occupation = "Developer",
                    JobTitle = "Develop",
                    BusinessType = "Finance"
                }
            };
            return dataQuestions;
        }

        [Fact]
        public async Task ListToDataTable_IsNotNull()
        {
            // Arrange
            var exportfile = new Exportfile();
            var dataQuestions = GetMockDataQuestion();

            // Act
            var result = await exportfile.ToDataTable(dataQuestions);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ListToDataTable_IsNull()
        {
            // Arrange
            var exportfile = new Exportfile();
            var dataQuestions = new List<string>();

            // Act
            var result = await exportfile.ToDataTable(dataQuestions);
            bool empty = !DataTableExtensions.AsEnumerable(result).Any();

            // Assert
            Assert.True(empty);
        }

        [Fact]
        public async Task TransFromTableToCSV_Success()
        {
            // Arrange
            var exportfile = new Exportfile();
            var dataQuestions = GetMockDataQuestion();

            // Act
            var data = await exportfile.ToDataTable(dataQuestions);
            var result = await exportfile.TransFromTableToCSV(data);

            // Assert
            Assert.NotEmpty(result);
        }
    }

}