using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace HelloWorld
{
    public class AssignmentResponse
    {
        public int id;
        public string bolType;
        public string creditHold;
        public DateTime begin;
        public string customerName;

        public string customerNumber;
        public string day;
        public string daysOpenHours;
        public string driverName;
        public string email;
        public string end;

        public DateTime feedDate;
        public string monthy;
        public string number;
        public bool processed;

        public DateTime processDate;
        public string shipAddress;
        public string shipCity;

        public string shipState;
        public string shipZip;
        public string sourceFileName;
        public string terrId;


        // "[{"id":1003777,"bolType":"Medical","creditHold":"MO","begin":"2017-12-18T05:00:00Z","customerName":"OLD NATIONAL GYN",
        // "customerNumber":"450-0428","day":null,"daysOpenHours":null,"driverName":"NICHOLS","email":"jtolsongolf@gmail.com","end":"2017-12-23T05:00:00Z"
        //,"feedDate":"2018-11-28T05:05:00Z","monthly":"MO","number":"(770) 991-7552","processed":false,"processedDate":null,
        //"shipAddress":"6210 OLD NATIONAL HWY","shipCity":"COLLEGE PARK","shipState":"GA","shipZip":"30349","sourceFileName":"NICHOLS_3_12_18xls.csv",
        // "terrId":"1R"}
    }

    public partial class MainPage : ContentPage
    {
        private const string Value = "error";
        private ObservableCollection<Customer> _customers;
        private List<AssignmentResponse> _oAuth;
        private string SERVER_URL = "http://192.168.1.112:8080";
        private string IMAGE_MEDICAL = "http://lorempixel.com/100/100/people/1/"; 
        private string IMAGE_DOCUMENT = "http://lorempixel.com/100/100/people/2/";
        private HttpClient _oHttpClient = new HttpClient();


        void Call_Clicked(object sender, System.EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var customer = menuItem.CommandParameter as Customer;
            DisplayAlert("Call", customer.Name, "Ok");
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }



        void Delete_Clicked(object sender, System.EventArgs e)
        {
            var customer = (sender as MenuItem).CommandParameter as Customer;
            _customers.Remove(customer);
        }




        // void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        //{
        //    label.Text = String.Format("Value is {0:F2}", e.NewValue);
        //}



        // void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        //{
        //    label.Text = String.Format("Value is {0:F2}", e.NewValue);
        //}

        async Task<string> GetDataAsync()
        {


            // oHttpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");



            HttpResponseMessage response = await _oHttpClient.GetAsync(SERVER_URL + "/MCF_backend/assignment");

            string responseBodyAsText = await response.Content.ReadAsStringAsync();


            /*
            if (String.IsNullOrEmpty(responseBodyAsText))
            {
                responseBodyAsText = "{"id":1003777,"bolType":"Medical","creditHold":"MO","begin":"2017-12-18T05:00:00Z","customerName":"OLD NATIONAL GYN","customerNumber":"450-0428","day":null,"daysOpenHours":null,"driverName":"NICHOLS","email":"jtolsongolf@gmail.com","end":"2017-12-23T05:00:00Z","feedDate":"2018-11-28T05:05:00Z","monthly":"MO","number":"(770) 991-7552","processed":false,"processedDate":null,"shipAddress":"6210 OLD NATIONAL HWY","shipCity":"COLLEGE PARK","shipState":"GA","shipZip":"30349","sourceFileName":"NICHOLS_3_12_18xls.csv","terrId":"1R"},{"id":1003800,"bolType":"Medical","creditHold":null,"begin":"2017-12-18T05:00:00Z","customerName":"APOGEE WOMEN"S HEALTH","customerNumber":"450-2693","day":null,"daysOpenHours":"MON-FRI 9-5","driverName":"NICHOLS","email":"jtolsongolf@gmail.com","end":"2017-12-23T05:00:00Z","feedDate":"2018-11-28T05:05:00Z","monthly":null,"number":"(404) 767-8886","processed":false,"processedDate":null,"shipAddress":"2575 JOLLY ROAD","shipCity":"COLLEGE PARK","shipState":"GA","shipZip":"30349","sourceFileName":"NICHOLS_3_12_18xls.csv","terrId":"2RW"}";
            }

            _oAuth = JsonConvert.DeserializeObject<List<AssignmentResponse>>(responseBodyAsText);

            */
            return responseBodyAsText;
        }


         async void GetCustomers() {
         
           string responseBodyAsText = await GetDataAsync();
            // return error json if unauth
            //if (String.IsNullOrEmpty(responseBodyAsText))
            //{
            if ((responseBodyAsText != null) && (responseBodyAsText.IndexOf(Value) > 0)) { 
                responseBodyAsText = @"[{'id':1003777,'bolType':'Medical','creditHold':'MO','begin':'2017-12-18T05:00:00Z','customerName':'OLD NATIONAL GYN','customerNumber':'450-0428',
                'day':null,'daysOpenHours':null,'driverName':'NICHOLS',
                'email':'jtolsongolf@gmail.com','end':'2017-12-23T05:00:00Z','feedDate':'2018-11-28T05:05:00Z','monthly':'MO',
                'number':'(770) 991-7552','processed':false,'processedDate':null,'shipAddress':'6210 OLD NATIONAL HWY','shipCity':'COLLEGE PARK',
                'shipState':'GA','shipZip':'30349','sourceFileName':'NICHOLS_3_12_18xls.csv','terrId':'1R'},
                {'id':1003778,
                'bolType':'Medical','creditHold':null,'begin':'2017-12-18T05:00:00Z','customerName':'APOGEE WOMENS HEALTH',
                'customerNumber':'450-2693','day':null,'daysOpenHours':'MON-FRI 9-5','driverName':'NICHOLS','email':'jtolsongolf@gmail.com',
                'end':'2017-12-23T05:00:00Z','feedDate':'2018-11-28T05:05:00Z','monthly':null,'number':'(404) 767-8886','processed':false,'processedDate':null,
                'shipAddress':'2575 JOLLY ROAD','shipCity':'COLLEGE PARK','shipState':'GA','shipZip':'30349','sourceFileName':'NICHOLS_3_12_18xls.csv','terrId':'2RW'},
                {'id':1003779,
                'bolType':'DOC','creditHold':null,'begin':'2017-12-18T05:00:00Z','customerName':'APOGEE WOMENS HEALTH',
                'customerNumber':'450-2693','day':null,'daysOpenHours':'MON-FRI 9-5','driverName':'NICHOLS','email':'jtolsongolf@gmail.com',
                'end':'2017-12-23T05:00:00Z','feedDate':'2018-11-28T05:05:00Z','monthly':null,'number':'(404) 767-8886','processed':false,'processedDate':null,
                'shipAddress':'2575 JOLLY ROAD','shipCity':'COLLEGE PARK','shipState':'GA','shipZip':'30349','sourceFileName':'NICHOLS_3_12_18xls.csv','terrId':'2RW'},
                {'id':1003790,
                'bolType':'DOC','creditHold':null,'begin':'2017-12-18T05:00:00Z','customerName':'APOGEE WOMENS HEALTH',
                'customerNumber':'450-2693','day':null,'daysOpenHours':'MON-FRI 9-5','driverName':'NICHOLS','email':'jtolsongolf@gmail.com',
                'end':'2017-12-23T05:00:00Z','feedDate':'2018-11-28T05:05:00Z','monthly':null,'number':'(404) 767-8886','processed':false,'processedDate':null,
                'shipAddress':'2575 JOLLY ROAD','shipCity':'COLLEGE PARK','shipState':'GA','shipZip':'30349','sourceFileName':'NICHOLS_3_12_18xls.csv','terrId':'2RW'}
                ]";
            }

            _oAuth = JsonConvert.DeserializeObject<List<AssignmentResponse>>(responseBodyAsText);

            if (_oAuth != null) {
                Customer customer;
                _customers = new ObservableCollection<Customer>();

                foreach (var assignment in _oAuth)
                {
                    if (assignment.bolType == "DOC")
                    {
                        customer = new Customer { Name = assignment.customerNumber, ImageUrl = IMAGE_DOCUMENT, Status = assignment.customerName };
                    }
                    else
                    {
                        customer = new Customer { Name = assignment.customerNumber, ImageUrl = IMAGE_MEDICAL, Status = assignment.customerName };
                    }

                    _customers.Add(customer);

                    Console.WriteLine("id:{0} name:{1} num: {2} bolType {3}", assignment.id, assignment.customerName, assignment.customerNumber, assignment.bolType);
                }


                if (swt_filter.IsToggled)
                {
                    listView.ItemsSource = _customers.Where(c => c.ImageUrl.Equals(IMAGE_MEDICAL));
                }
                else
                {
                    listView.ItemsSource = _customers.Where(c => c.ImageUrl.Equals(IMAGE_DOCUMENT));
                }

            }

            /*
            _customers = new ObservableCollection<Customer> {
                new Customer {Name = "Mosh", ImageUrl=IMAGE_DOCUMENT, Status = "Lets Talk"},
                new Customer {Name = "Fred", ImageUrl="https://d2yal1mtmg1ts6.cloudfront.net/SK2hL6yrgCB5D9TGjdpAJLz2If5oqgOx4nqpzyK5Fh-Q5HEgAEP2Cd7sas-kqhkoUgOK=w100", Status = "Lets Talk"}
            };
            */
        }

 

        public MainPage() {
            _oHttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + UserSettings.access_token);
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
             GetCustomers();
            base.OnAppearing();
        }

        void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            string txt = srch_filter.Text;
            if (!String.IsNullOrEmpty(txt))
            {
                if (e.Value)
                {
                    listView.ItemsSource = _customers.Where(c => c.ImageUrl.Equals(IMAGE_MEDICAL) && c.Name.StartsWith(txt));
                }
                else
                {
                    listView.ItemsSource = _customers.Where(c => c.ImageUrl.Equals(IMAGE_DOCUMENT) && c.Name.StartsWith(txt));
                }
            }
            else
            {
                if (e.Value)
                {
                    listView.ItemsSource = _customers.Where(c => c.ImageUrl.Equals(IMAGE_MEDICAL));
                }
                else
                {
                    listView.ItemsSource = _customers.Where(c => c.ImageUrl.Equals(IMAGE_DOCUMENT));
                }
            }
        }

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            string txt = e.NewTextValue;

            if (!String.IsNullOrEmpty(txt))
            {
                if (swt_filter.IsEnabled)
                {
                    listView.ItemsSource = _customers.Where(c => c.ImageUrl.Equals(IMAGE_MEDICAL) && c.Name.StartsWith(txt));
                }
                else
                {
                    listView.ItemsSource = _customers.Where(c => c.ImageUrl.Equals(IMAGE_DOCUMENT) && c.Name.StartsWith(txt));
                }
            }
            else
            {
                if (swt_filter.IsEnabled)
                {
                    listView.ItemsSource = _customers.Where(c => c.ImageUrl.Equals(IMAGE_MEDICAL));
                }
                {
                    listView.ItemsSource = _customers.Where(c => c.ImageUrl.Equals(IMAGE_DOCUMENT));
                }
            }

            // listView.ItemsSource = _customers.Where(c => c.Name.Equals(txt));

        }

        void Handle_Refreshing(object sender, System.EventArgs e) {
            GetCustomers();

            listView.EndRefresh();
        }

        async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var customer = e.Item as Customer;
            await DisplayAlert("Tapped", customer.Name + " " + customer.Status, "OK");
            await Navigation.PushAsync(new MedicalInfo());
        }
    }
}
