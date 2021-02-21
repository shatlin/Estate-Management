namespace MM.ClientModels
{
    public class ExceptionReportModel
    {
        public string FullName { get; set; }
        public string IDNumber { get; set; }
        public string MembershipNumber { get; set; }
        public string MembershipGrade { get; set; }
        public string MembershipType { get; set; }
        public string MembershipStatus { get; set; }
        public string CreatedOn { get; set; }
        public string DateApplicationReceived { get; set; }
        public string PaymentReminder1Date { get; set; }
        public string PaymentReminder2Date { get; set; }
        public string PaymentReminder3Date { get; set; }
        public string URL { get; set; }
        public int NumberofDays { get; set; }
        public string RagInd { get; set; }
        public int MemberId { get; set; }
    }

}