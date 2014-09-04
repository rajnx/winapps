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
        private BillType billType;
        private DateTime dueDate;
        private bool isPaid;

        public Bill(string title, string subtitle, string imagepath, BillType billType, bool isPaid, DateTime dueDate)
        {
            this.title = title;
            this.subTitle = subtitle;
            this.imagePath = imagepath;
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

        public string ImagePath
        {
            get { return this.imagePath; }
            set { this.imagePath = value; }
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
