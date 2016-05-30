using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CadastradorDeAval
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SeletorArquivos seletor = new SeletorArquivos();
        private List<NI> _LISTAO = new List<NI>();
        public MainWindow()
        {
            int num = 0;
            for (int i = 0; i < 10; i++)
            {
                num = 1000 + i + 1;
                _LISTAO.Add(new NI("T" + num.ToString(), num));

            }
            InitializeComponent();
            AvalSaltosNegCmb.ItemsSource = _LISTAO;
        }

        private void AvalFeedbackPosBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] arr = { "audio" };
            AvalFeedbackPosTxt.Text = seletor.LocalizarArq(arr);
        }

        private void AvalFeedbackNegBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] arr = { "audio" };
            AvalFeedbackNegTxt.Text = seletor.LocalizarArq(arr);
        }

        private void AvalSaltosPosCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SaltoPosEnunEx_1_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void AvalSaltosNegCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AvalSaltosPosTxt.Text != "a")
            {
                AvalSaltosPosTxt.Text = "a";
            }
            else
            {
                AvalSaltosPosTxt.Text = "b";
            }            
            //AvalSaltosNegTxt.Text = AvalSaltosPosCmb.SelectedItem.ToString().Remove(0, AvalSaltosPosCmb.SelectedItem.ToString().Length - 4 );
        }

        private void AvalSaltosNegDel_Click(object sender, RoutedEventArgs e)
        {
            AvalSaltosNegTxt.Text = "";
        }

        private void AvalSaltosPosDel_Click(object sender, RoutedEventArgs e)
        {
            AvalSaltosNegTxt.Text = "";
        }
    }
}
