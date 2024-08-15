using Microsoft.AspNet.SignalR.Client;
using Resturant.Services.Models;
using Resturant.Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resturant.WindowsClient
{
    public partial class Form1 : Form
    {
        HubConnection connection;
        IHubProxy ordersProxy;
        List<Order> OrdersList;
        OrderServices orderServices;
        public Form1()
        {
            InitializeComponent();
            orderServices = new OrderServices();
            listView1.BackColor = Color.Black;
            listView1.ForeColor = Color.GreenYellow;
            listView1.Dock = DockStyle.Fill;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Order Name", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Total Price", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Order Type", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Order Number ", 100, HorizontalAlignment.Center);
            OrdersList = orderServices.GetAllOrders();

            foreach (var order in OrdersList)
            {
                listView1.Items.Add(new ListViewItem(new string[] { order.Name, order.TotalPrice.ToString(), order.OrderType, order.OrderNumber.ToString() }));
            }

            ClientSettings();
        }
        void ClientSettings()
        {
            connection = new HubConnection("https://localhost:44311");
            ordersProxy = connection.CreateHubProxy("OrdersHub");//Hub name
            connection.Start().Wait();
            ordersProxy.On<Order>("UpdateOrdersList", order =>
            {
                ListViewItem item = new ListViewItem(new String[] { order.Name, order.TotalPrice.ToString(), order.OrderType, order.OrderNumber.ToString() });
                // string text = string.Format("Order Name : {0}\n Order Total Price {1} \n:", order.Name, order.TotalPrice);
                listView1.Invoke(new Action(() => listView1.Items.Add(item)));
            });


        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
