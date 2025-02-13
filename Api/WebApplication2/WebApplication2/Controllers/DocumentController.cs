using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Model;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/v1/Document")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        /// <summary>
        /// Запрос для получения списка документов из базы данных
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetDocument()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var list = await db.Documents.ToListAsync();
                    return Ok(list.ConvertAll(p => new DocumentModel(p)));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Запрос для получение списка комментариев к документам из базы данных
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        [HttpGet("Document/{documentId}/Comments")]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetComment(int documentId)
        {
            try
            {
                using (var db = new MyDbContext())
                {

                    var list = await db.Comments.Include(p => p.Author).Include(p => p.Author.Position).Where(p => p.Id == documentId).ToListAsync();
                    if (list.Count == 0)
                    {
                        StatusCode(404, "Не найден комментарий");
                    }
                    return Ok(list.ConvertAll( p => new CommentModel(p)));
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // Запрос на добавление комментария в базу данных
        [HttpPost("Document/{documentId}/Comment")]
        public async Task<ActionResult> PostComment([FromBody] CommentRequest comment)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var document = await db.Documents.Where(p => p.Id == comment.DocumentId).FirstOrDefaultAsync();
                    if (document == null)
                    {
                        return BadRequest("Документ не найден");
                    }

                    // Создание комментария
                    var commentAdd = new Comment()
                    {
                        Id = comment.Id,
                        DocumentId = comment.DocumentId,
                        Text = comment.Text,
                        DateCreated = comment.DateCreated,
                        DateUpdated = comment.DateUpdated,
                        AuthorId = comment.AuthorId,
                        Position = comment.Position,
                    };

                    // Добавления комментария в базу данных
                    await db.AddAsync(commentAdd);
                    await db.SaveChangesAsync();
                    return Ok("Комментарий добавлен");  
                }
            }
            catch (Exception ex)
            {
                return StatusCode(400, "Неправильно сформирован запрос {0}" + ex.Message);
            }
        }
    }
}
