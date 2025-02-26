namespace SuppliesRequisition.Model
{
    public class SAPModels
    {

    }
    public class Items
    {
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public string? Size { get; set; }
        public string? ChildColor { get; set; }
        public string? InvntryUom { get; set; }
    }

    public class RequisitionHeader
    {
        public int HeaderId { get; set; }
        public string RequestedBy { get; set; } = string.Empty;
        public DateTime DateOfRequest { get; set; }
        public string company {get; set;} = string.Empty;
        public string chain {get; set;} = string.Empty;
        public string branchName {get; set; } = string.Empty;
        public DateTime? dateReview { get; set; }
        public string Reviewer { get; set; } = string.Empty;
        public string Approver { get; set; } = string.Empty;
        public DateTime? DateApprove { get; set; } // Added 02/05/2025
        public DateTime? DateCompleted { get; set; } // Added 02/05/2025
        public string? Process { get; set; } = string.Empty; // Added 02/05/2025
        public string? User { get; set; } = string.Empty; // Added 02/07/2025
        public string Status { get; set; } = string.Empty;
        public string? Position { get; set; } = string.Empty;
        public List<RequisitionDetail> details { get; set; } = new List<RequisitionDetail>();
    }

    public class RequisitionDetail
    {
        public int DetailId { get; set; }
        public int HeaderId { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string ItemDescription { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string UOM { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public string Consumption { get; set; } = string.Empty;
        public string SapStatus { get; set; } = string.Empty;
    }

}
