using System;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConsoleApp.DataServerInterface foob;
        public MainWindow()
        {
            InitializeComponent();

            ChannelFactory<ConsoleApp.DataServerInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();

            string URL = "net.tcp://localhost:8100/DataService";
            foobFactory = new ChannelFactory<ConsoleApp.DataServerInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();

            TotalNum.Text = foob.GetNumEntries().ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            string fName = "", lName = "";
            int bal = 0;
            uint acctNo = 0, pin = 0;

            if (!int.TryParse(IndexNum.Text, out index))
            {
                MessageBox.Show("Please enter a valid index number.");
                return;
            }

            foob.GetValuesForEntry(index, out acctNo, out pin, out bal, out fName, out lName);
            FNameBox.Text = fName;
            LNameBox.Text = lName;
            BalBox.Text = bal.ToString("C");
            AcctNoBox.Text = acctNo.ToString();
            PinBox.Text = pin.ToString("D4");
        }
    }
}