using CloseLineCasesApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;

namespace CloseLineCasesApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CloserController : ApiController
    {
        /// <summary>
        /// This method accept file number as parameter and reutrn Order details
        /// </summary>
        [Route("api/Closers/{state}/{county}")]
        [HttpGet]
        public IHttpActionResult GetClosers(string state,string county)
        {
            
            try
            {
                if (Request.IsValid())
                {
                    var closers = CloselineRepository.GetClosers(state, county);

                    if(closers!=null)
                        return Ok(new { status = 1, Result = closers, Message = "", RecordCount = closers.Count() });
                    else
                        return Ok(new { status = 0, Result = "", Message = "Record not found!", });

                }
                else
                {
                    return Content(HttpStatusCode.MethodNotAllowed, new { status = 0, Message = "Invalid Request" });
                }

            }
            catch (Exception ex)
            {
                var json = new JavaScriptSerializer().Serialize(ex.Message);
                string ErrorMsg = "";
                ErrorMsg += "<b>Inner Exception: </b>" + ex.InnerException;
                ErrorMsg += "<br/><b>Message: </b>" + ex.Message;
                ErrorMsg += "<br/><b>Source: </b>" + ex.Source;
                ErrorMsg += "<br/><b>Stack Trace: </b>" + ex.StackTrace;
                ErrorMsg += "<br/><b>Help Link: </b>" + ex.HelpLink;

                return Content(HttpStatusCode.BadRequest, new { status = 0, Message = $"{ex.Message}", InnerErrorInfo = json });
            }
        }

        [Route("api/Closers/{email}")]
        [HttpGet]
        public IHttpActionResult GetCloser(string email)
        {

            try
            {
                if (Request.IsValid())
                {
                    var closer = CloselineRepository.GetCloser(email);

                    if (closer != null)
                        return Ok(new { status = 1, Result = closer, Message = ""});
                    else
                        return Ok(new { status = 0, Result = "", Message = "Record not found!", });

                }
                else
                {
                    return Content(HttpStatusCode.MethodNotAllowed, new { status = 0, Message = "Invalid Request" });
                }

            }
            catch (Exception ex)
            {
                var json = new JavaScriptSerializer().Serialize(ex.Message);
                string ErrorMsg = "";
                ErrorMsg += "<b>Inner Exception: </b>" + ex.InnerException;
                ErrorMsg += "<br/><b>Message: </b>" + ex.Message;
                ErrorMsg += "<br/><b>Source: </b>" + ex.Source;
                ErrorMsg += "<br/><b>Stack Trace: </b>" + ex.StackTrace;
                ErrorMsg += "<br/><b>Help Link: </b>" + ex.HelpLink;

                return Content(HttpStatusCode.BadRequest, new { status = 0, Message = $"{ex.Message}", InnerErrorInfo = json });
            }
        }

        [Route("api/CloserCounty/{email}")]
        [HttpGet]
        public IHttpActionResult GetCloserCounty(string email)
        {

            try
            {
                if (Request.IsValid())
                {
                    var closercounties = CloselineRepository.GetCloserCounties(email);

                    if (closercounties != null)
                        return Ok(new { status = 1, Result = closercounties, Message = "",RecordCount= closercounties.Count() });
                    else
                        return Ok(new { status = 0, Result = "", Message = "Record not found!", });

                }
                else
                {
                    return Content(HttpStatusCode.MethodNotAllowed, new { status = 0, Message = "Invalid Request" });
                }

            }
            catch (Exception ex)
            {
                var json = new JavaScriptSerializer().Serialize(ex.Message);
                string ErrorMsg = "";
                ErrorMsg += "<b>Inner Exception: </b>" + ex.InnerException;
                ErrorMsg += "<br/><b>Message: </b>" + ex.Message;
                ErrorMsg += "<br/><b>Source: </b>" + ex.Source;
                ErrorMsg += "<br/><b>Stack Trace: </b>" + ex.StackTrace;
                ErrorMsg += "<br/><b>Help Link: </b>" + ex.HelpLink;

                return Content(HttpStatusCode.BadRequest, new { status = 0, Message = $"{ex.Message}", InnerErrorInfo = json });
            }
        }

    }
}
