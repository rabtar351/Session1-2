using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/v1/Document")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetDocument()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    return await db.Documents.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostDocument(DocumentRequest document)
        {
            try
            {
                if (document == null)
                    return StatusCode(404, "Не найдено");

                using (var db = new MyDbContext())
                {
                    var documentAdd = new Document()
                    {
                        Id = document.Id,
                        Title = document.Title,
                        DateCreated = document.DateCreated,
                        DateUpdated = document.DateUpdated,
                        Category = document.Category,
                        HasComment = document.HasComment,
                    };

                    await db.AddAsync(documentAdd);
                    await db.SaveChangesAsync();
                    return StatusCode(201, "Комментарий добавлен");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
