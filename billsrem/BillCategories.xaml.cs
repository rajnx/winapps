﻿using BillsReminder.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.Data.Xml.Dom;
using Windows.Storage;

// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace BillsReminder
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class BillCategories : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public ObservableCollection<Bill> bills = new ObservableCollection<Bill>();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public void LoadBills(ObservableCollection<Bill> bills)
        {
            XmlDocument billCategoriesXML = new XmlDocument();
            
            try
            {
                string categoriesXML = @"Assets\BillCategories.xml";
                StorageFolder InstallationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;

                billCategoriesXML.LoadXml(InstallationFolder.Path + categoriesXML);
                
                XmlNodeList xmlList = billCategoriesXML.SelectNodes("/Categories/Bill");

                foreach (XmlElement element in xmlList)
                {
                    string name = element.GetAttribute("Name");
                    string imagePath = element.GetAttribute("ImagePath");
                    string portalUrl = element.GetAttribute("PortalUrl");
                    string type = element.GetAttribute("Type");
                    string isPaid = element.SelectSingleNode("/IsPaid").InnerText;
                    string dueDate = element.SelectSingleNode("/DueDate").InnerText;

                    Bill bill = new Bill(name, "", imagePath, (BillType)Convert.ToInt16(type), Convert.ToBoolean(isPaid), Convert.ToDateTime(dueDate));
                    bills.Add(bill);
                }
            }
            catch(Exception e)
            {
                string error = e.Message;
            }
        }

        public BillCategories()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;

            LoadBills(bills);
            this.DataContext = bills;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO: Assign a bindable collection of items to this.DefaultViewModel["Items"]
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

    }
}