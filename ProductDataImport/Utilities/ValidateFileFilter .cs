using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace ProductDataImport.Utilities
{
    /// <summary>
    /// Filer to validate extension formats
    /// </summary>
    public class ValidateFileFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            object postedFile;
            string fileExtension;
            if (context.ActionArguments.ContainsKey("postedFile"))
            {
                //Get extension from context
                postedFile = context.ActionArguments["postedFile"];
                fileExtension = Path.GetExtension(((Microsoft.AspNetCore.Http.FormFile)postedFile).FileName);

                //Validate uploaded file and return error.
                if (!Validator.IsValidFIle(fileExtension))
                {
                    (context.Controller as Controller).ViewBag.Message = "Please select valid file. Allowd file formats: .csv, .flf";
                    context.Result = new ViewResult
                    {
                        ViewName = "Index",
                    };

                    base.OnActionExecuting(context);
                }
            }
        }

    }
}
