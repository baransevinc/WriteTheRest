using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteTheRest.Core.Attributes
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {

                var errorMessage = context.ModelState
                    .Where(m => m.Value.Errors.Count > 0)
                    .Select(m => m.Value.Errors.Select(e => e.ErrorMessage).FirstOrDefault()) // her alanın ilk hata mesajı alınıyor
                    .FirstOrDefault(); // tüm alanlar arasında ilk hata mesajı seçiliyor

                // BadRequest yanıtı döndür
                context.Result = new BadRequestObjectResult(new
                {
                    Type = "ValidationError",
                    Success = false,
                    Message = errorMessage
                });
            }
        }
    }
