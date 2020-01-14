using CloseLineCasesApi.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CloseLineCasesApi.Repository
{
    public class CloselineRepository
    {
        public static string ConnectionString { get { return ConfigurationManager.ConnectionStrings["CloselineDB"].ToString(); } }

        public static Orders GetCase(string fileno)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.QueryFirstOrDefault<Orders>($"Select * from [Orders] Where FileNo=@fileno",new { @fileno= fileno});
            }
        }

        public static List<CalendarNotes> GetCalendarNotes()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<CalendarNotes>($"Select * from [CalendarNotes] where IsCalendarNote=1").ToList();
            }
        }

        public static List<CalendarNotes> GetClientNotes()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<CalendarNotes>($"Select * from [CalendarNotes] where VisibleToClient=1").ToList();
            }
        }

        public static List<CalendarNotes> GetCalendarNotes(string fileno)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<CalendarNotes>($"Select * from [CalendarNotes] Where FileNo=@fileno and IsCalendarNote=1", new { @fileno = fileno }).ToList();
            }
        }

        public static List<CalendarNotes> GetAllNotes()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<CalendarNotes>($"Select * from [CalendarNotes]").ToList();
            }
        }
        public static List<CalendarNotes> GetCaseNotes(string fileno)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<CalendarNotes>($"Select * from [CalendarNotes] Where FileNo=@fileno", new { @fileno = fileno }).ToList();
            }
        }
        public static List<CalendarNotes> GetClientNotes(string fileno)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<CalendarNotes>($"Select * from [CalendarNotes] Where FileNo=@fileno and VisibleToClient=1", new { @fileno = fileno}).ToList();
            }
        }

        public static List<Closers> GetClosers(string state,string county)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<Closers>($"select C.* from Closer C join CloserCounty CC on C.Email=CC.CloserEmail Where UPPER(CC.State)=UPPER(@state) and REPLACE(UPPER(CC.County),'COUNTY','')=REPLACE(@county,'COUNTY','')  and isnull(C.IsApproved,0)=1 and isnull(CC.IsDoNotUse,0)=0", new { @state = state, @county = county }).ToList();

            }
        }

        public static Closers GetCloser(string email)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.QueryFirstOrDefault<Closers>($"select * from Closer where Email=@email", new { @email = email});

            }
        }

        public static List<CloserCounty> GetCloserCounties(string email)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<CloserCounty>($"select * from CloserCounty where CloserEmail=@email", new { @email = email }).ToList();

            }
        }

        public static CaseDetails GetCaseDetail(string fileno)
        {
            var order = GetCase(fileno);

            if (order == null)
                return null;

            var type = "";
            var office ="";

            var dashindex = order.FileNo.IndexOf("-");

            type = (order.FileNo.Substring(dashindex - 1, 1)=="F")? "PURCHASE": "REFINANCE";
            office = order.FileNo.Split('-')[1];

            var borrowers = new List<Borrower>();
            var sellers = new List<Seller>();
            var agents = new List<Agent>();

            if (!string.IsNullOrEmpty(order.BorrowerName))
                borrowers.Add(new Borrower { FullName = order.BorrowerName.ToDefaultString(), Email = order.BorrowerEmail.ToDefaultString(), CellPhone = order.Borr1CPhone.ToDefaultString(), HomePhone = order.Borr1HPhone.ToDefaultString(), WorkPhone = order.Borr1WPhone.ToDefaultString() });

            if (!string.IsNullOrEmpty(order.Borr2Name))
                borrowers.Add(new Borrower { FullName = order.Borr2Name.ToDefaultString(), Email = order.Borr2Email.ToDefaultString(), CellPhone = order.Borr2CPhone.ToDefaultString(), HomePhone = order.Borr2HPhone.ToDefaultString(), WorkPhone = order.Borr2WPhone.ToDefaultString() });

            if (!string.IsNullOrEmpty(order.SellerName))
                sellers.Add(new Seller { FullName = order.SellerName.ToDefaultString(), Email = order.SellerEmail.ToDefaultString(),CellPhone="",HomePhone="",WorkPhone="" });

            if (!string.IsNullOrEmpty(order.Sell2Name))
                sellers.Add(new Seller { FullName = order.Sell2Name.ToDefaultString(), Email = order.Sell2Email.ToDefaultString(), CellPhone = "", HomePhone = "", WorkPhone = "" });

            if (!string.IsNullOrEmpty(order.SellingAgent))
                agents.Add(new Agent { FullName = order.SellingAgent.ToDefaultString(), Type = "Selling", Email = order.SellingAgentEmail.ToDefaultString() });

            if (!string.IsNullOrEmpty(order.ListingAgent))
                agents.Add(new Agent { FullName = order.ListingAgent.ToDefaultString(), Type = "Listing", Email = order.ListingAgentEmail.ToDefaultString() });


            var calenderNotes = GetCalendarNotes(fileno);
            var clientcalenderNotes = GetClientNotes(fileno);

            var caseDetail = new CaseDetails
            {
                FileNumber = order.FileNo,
                Type = type,
                Office = office,
                LenderName = order.LenderName.ToDefaultString(),
                PropertyAddress = order.PropAddress.ToDefaultString(),
                PropertyCity = order.PropCity.ToDefaultString(),
                PropertyState = order.PropState.ToDefaultString(),
                PropertyCounty = order.PropCounty.ToDefaultString(),
                LoanOfficerEmail = order.LOEmail.ToDefaultString(),
                LoanOfficer1Email = order.LOEmail1.ToDefaultString(),
                LoanOfficer2Email = order.LOEmail2.ToDefaultString(),
                PropertyZipCode = order.PropZipCode.ToDefaultString(),
                SettlementDate = order.SettleDate.ToDefaultString(),
                Borrowers = borrowers,
                Sellers = sellers,
                Agents = agents,
                CalendarNotes= calenderNotes,
                ClientNotes= clientcalenderNotes,
            };

            return caseDetail;
        }
    }
}