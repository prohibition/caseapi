using CloseLineCasesApi.Models;
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
    public class CasesController : ApiController
    {
        /// <summary>
        /// This method accept file number as parameter and reutrn Order details
        /// </summary>
        [Route("api/Case/{filenumber}")]
        [HttpGet]
        public IHttpActionResult GetCase(string filenumber)
        {
            var currentSubject = "";
            try
            {
                if (Request.IsValid())
                {
                    var casedetail = CloselineRepository.GetCaseDetail(filenumber);

                    if (casedetail != null)
                        return Ok(new { status = 1, Result = casedetail, Message = "" });
                    else
                        return Ok(new { status = 0, Result = "", Message = "Record not found!" });
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

                return Content(HttpStatusCode.BadRequest, new { status = 0, Message = $"{ex.Message}", Subject = currentSubject, InnerErrorInfo = json });
            }
        }

        [Route("api/CalendarNotes/{filenumber}")]
        [HttpGet]
        public IHttpActionResult GetCalendarNotes(string filenumber)
        {
            try
            {
                if (Request.IsValid())
                {
                    var calendarnotes = CloselineRepository.GetCalendarNotes(filenumber);

                    if (calendarnotes != null)
                        return Ok(new { status = 1, Result = calendarnotes, Message = "" });
                    else
                        return Ok(new { status = 0, Result = "", Message = "Record not found!" });
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

                return Content(HttpStatusCode.BadRequest, new { status = 0, Message = $"{ex.Message}",InnerErrorInfo = json });
            }
        }

        [Route("api/ClientCalendarNotes/{filenumber}")]
        [HttpGet]
        public IHttpActionResult GetClientCalendarNotes(string filenumber)
        {
            try
            {
                if (Request.IsValid())
                {
                    var calendarnotes = CloselineRepository.GetClientNotes(filenumber);

                    if (calendarnotes != null)
                        return Ok(new { status = 1, Result = calendarnotes, Message = "" });
                    else
                        return Ok(new { status = 0, Result = "", Message = "Record not found!" });
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

        [Route("api/AllCalendarNotes/")]
        [HttpGet]
        public IHttpActionResult GetAllCalendarNotes()
        {
            try
            {
                if (Request.IsValid())
                {
                    var calendarnotes = CloselineRepository.GetCalendarNotes();

                    if (calendarnotes != null)
                        return Ok(new { status = 1, Result = calendarnotes, Message = "" });
                    else
                        return Ok(new { status = 0, Result = "", Message = "Record not found!" });
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

        [Route("api/AllNotes/")]
        [HttpGet]
        public IHttpActionResult AllNotes()
        {
            try
            {
                if (Request.IsValid())
                {
                    var calendarnotes = CloselineRepository.GetAllNotes();

                    if (calendarnotes != null)
                        return Ok(new { status = 1, Result = calendarnotes, Message = "" });
                    else
                        return Ok(new { status = 0, Result = "", Message = "Record not found!" });
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
        
        [Route("api/CaseNotes/{filenumber}")]
        [HttpGet]
        public IHttpActionResult CaseNotes(string filenumber)
        {
            try
            {
                if (Request.IsValid())
                {
                    var calendarnotes = CloselineRepository.GetCaseNotes(filenumber);

                    if (calendarnotes != null)
                        return Ok(new { status = 1, Result = calendarnotes, Message = "" });
                    else
                        return Ok(new { status = 0, Result = "", Message = "Record not found!" });
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

        [Route("api/GetAllClientCalendarNotes/")]
        [HttpGet]
        public IHttpActionResult GetAllClientCalendarNotes()
        {
            try
            {
                if (Request.IsValid())
                {
                    var calendarnotes = CloselineRepository.GetClientNotes();

                    if (calendarnotes != null)
                        return Ok(new { status = 1, Result = calendarnotes, Message = "" });
                    else
                        return Ok(new { status = 0, Result = "", Message = "Record not found!" });
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
