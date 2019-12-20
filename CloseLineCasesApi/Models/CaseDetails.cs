using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloseLineCasesApi.Models
{
    public class Orders
    {
        public string FileNo { get; set; }
        public string LenderName { get; set; }
        public string PropAddress { get; set; }
        public string PropCity { get; set; }
        public string PropState { get; set; }
        public string PropZipCode { get; set; }
        public string PropCounty { get; set; }
        public string SettleDate { get; set; }
        public string LOEmail { get; set; }
        public string LOEmail1 { get; set; }
        public string LOEmail2 { get; set; }
        public string BorrowerName { get; set; }
        public string BorrowerEmail { get; set; }
        public string Borr1WPhone { get; set; }
        public string Borr1HPhone { get; set; }
        public string Borr1CPhone { get; set; }
        public string Borr2Name { get; set; }
        public string Borr2Email { get; set; }
        public string Borr2WPhone { get; set; }
        public string Borr2HPhone { get; set; }
        public string Borr2CPhone { get; set; }
        public string SellerName { get; set; }
        public string SellerEmail { get; set; }
        public string Sell2Name { get; set; }
        public string Sell2Email { get; set; }
        public string SellingAgent { get; set; }
        public string ListingAgent { get; set; }
        public string SellingAgentEmail { get; set; }
        public string ListingAgentEmail { get; set; }
    }

    public class Closers
    {
        public int CID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string Fax { get; set; }
        public string Profession { get; set; }
        public string Fee { get; set; }
        public bool isAutoNotify { get; set; }
        public string EmailAutoNotify { get; set; }
        public string DateCreated { get; set; }
        public string Agreement { get; set; }
        public string IsApproved { get; set; }
        public int CloserRanking { get; set; }
        public string Notes { get; set; }
        public int NumberClosed { get; set; }
        public string IsDoNotUse { get; set; }
    }

    public class CloserCounty
    {
        public string CloserEmail { get; set; }
        public string State { get; set; }
        public string County { get; set; }
    }

    public class CaseDetails
    {
        public string FileNumber { get; set; }
        public string Type { get; set; }
        public string Office { get; set; }
        public string LenderName { get; set; }
        public string PropertyAddress { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyState { get; set; }
        public string PropertyZipCode { get; set; }
        public string PropertyCounty { get; set; }
        public string SettlementDate { get; set; }
        public string LoanOfficerEmail { get; set; }
        public string LoanOfficer1Email { get; set; }
        public string LoanOfficer2Email { get; set; }
        public List<Borrower> Borrowers { get; set; }
        public List<Seller> Sellers { get; set; }
        public List<Agent> Agents { get; set; }
    }
    

    public class Borrower
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
    }

    public class LoadOfficer
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }

    public class Seller
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
    }

    public class Agent
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
    }
}