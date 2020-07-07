using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using ProductBusinessLayer.BusinessDefinition;
using ProductDataImport.Utilities;
using ProductDataLayer.ViewModel;

namespace ProductDataImport.Controllers
{
    /// <summary>
    /// Hpme page controller.
    /// </summary>
    public class HomeController : Controller
    {
        #region Business context implementation

        private readonly IBusinessDataContext _businessDataContext;

        public HomeController(IBusinessDataContext businessDataContext)
        {
            _businessDataContext = businessDataContext;
        }

        #endregion 

        #region Index view method.

        #region GET: /Home/Index

        /// <summary>
        /// Get: /Home/Index method.
        /// </summary>        
        /// <returns>Return index view</returns>
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region POST: /Home/Index

        /// <summary>
        /// Post: /Home/Index method.
        /// </summary>        
        /// <param name="postedFile">Model Parameter</param>
        /// <returns>Return - Response information</returns>
        //[ValidateFileFilter]
        [HttpPost]
        public ActionResult Index(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                try
                {
                    //Get uploaded file extension
                    var fileExtension = Path.GetExtension(postedFile.FileName);
                    
                    //Validate uploaded file and return error.
                    if (!Validator.IsValidFIle(fileExtension))
                    {
                        ViewBag.Message = "Please select valid file. Allowd file formats: .csv, .flf";
                        return View();
                    }

                    //implementing strategy pattern to load business logic as per imported file extension
                    var productInventories = _businessDataContext.InstantiateStrategy<IFileAbstract>
                               (_businessDataContext.ConextStrategy[fileExtension]).ProcessImportedFiles(postedFile);

                    return View("Result", 
                        new ImportedDataDetail 
                        { 
                            ProductInventories = productInventories,                            
                            Extension = FormatString.FormatImgUrl(fileExtension)
                        }); 
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                }
            }
            else
            {
                ViewBag.Message = "Please select the file to upload.";
            }
            return View();
        }

        #endregion

        #endregion 
    }
}
