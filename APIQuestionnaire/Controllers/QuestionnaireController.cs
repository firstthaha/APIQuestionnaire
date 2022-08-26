using APIQuestionnaire.Data;
using APIQuestionnaire.Interface;
using APIQuestionnaire.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text;

namespace APIQuestionnaire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionnaireController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IExportFile _exportFile;

        public QuestionnaireController(DataContext context, IExportFile exportFile)
        {
            _context = context;
            _exportFile = exportFile;
        }

        [HttpGet("country")]
        public async Task<ActionResult<List<Occupation>>> Country()
        {
            return Ok(await _context.CountryTable.OrderBy(i => Convert.ToInt32(i.CountryCode)).ToListAsync());
        }

        [HttpGet("occupation")]
        public async Task<ActionResult<List<Occupation>>> Occupation()
        {
            return Ok(await _context.OccupationTable.ToListAsync());
        }

        [HttpGet("topic")]
        public async Task<ActionResult<List<Occupation>>> Topic()
        {
            return Ok(await _context.TopicTable.OrderBy(i => i.Seq).ToListAsync());
        }

        [HttpGet("title")]
        public async Task<ActionResult<List<Title>>> Tilte()
        {
            return Ok(await _context.TitleTable.ToListAsync());
        }

        [HttpPost("question")]
        public async Task<ActionResult<List<DataQuestion>>> Question(DataQuestion question)
        {
            _context.QuestionTable.Add(question);
            await _context.SaveChangesAsync();
            return Ok(await _context.QuestionTable.ToListAsync());
        }

        [HttpGet("export")]
        public async Task<ActionResult<List<DataQuestion>>> Export()
        {
            List<DataQuestion> dataQuestions = await _context.QuestionTable.ToListAsync();
            DataTable dt = await _exportFile.ToDataTable(dataQuestions);

            string data = await _exportFile.TransFromTableToCSV(dt);
            byte[] file = Encoding.UTF8.GetBytes(data);
            return File(file, "text/csv", "Questionnaire.csv");
        }
    }
}
