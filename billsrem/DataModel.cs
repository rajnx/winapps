using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsReminder
{
    public enum BillType
    {
        CreditCard,
        Loan,
        Phone,
        Internet,
        School,
        Rent
    }

    public sealed class Bill
    {
        private string title;
        private string subTitle;
        private string imagePath;
        private string portalUrl;
        private BillType billType;
        private DateTime dueDate;
        private Boolean isPaid;

        public Bill(string title, string subtitle, string imagepath, string portalUrl, BillType billType, Boolean isPaid, DateTime dueDate)
        {
            this.title = title;
            this.subTitle = subtitle;
            this.imagePath = imagepath;
            this.portalUrl = portalUrl;
            this.billType = billType;
            this.dueDate = dueDate;
            this.isPaid = isPaid;
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public BillType BillType
        {
            get { return this.billType; }
            set { this.billType = value; }
        }

        public string SubTitle
        {
            get { return this.subTitle; }
            set { this.subTitle = value; }
        }

        public string PortalUrl
        {
            get { return this.portalUrl; }
            set { this.portalUrl = value; }
        }

        public string ImagePath
        {
            get { return this.imagePath; }
            set { this.imagePath = value; }
        }

        public DateTime DueDate
        {
            get { return this.dueDate; }
            set { this.dueDate = value; }
        }

        public Boolean IsPaid
        {
            get { return this.isPaid; }
            set { this.isPaid = value; }
        }
    }

    public sealed class CreditCard
    {
        private string creditCompanyName;
        private string billUrl;
        private string imagePath;

        public CreditCard(string creditCompanyName, string billUrl, string imagePath)
        {
            this.creditCompanyName = creditCompanyName;
            this.billUrl = billUrl;
            this.imagePath = imagePath;
        }

        public string CompanyName
        {
            get { return this.creditCompanyName; }
            set { this.creditCompanyName = value; }
        }

        public string BillPayPortalUrl
        {
            get { return this.billUrl; }
            set { this.billUrl = value; }
        }

        public string ImagePath
        {
            get { return this.imagePath; }
            set { this.imagePath = value; }
        }
    }
}
