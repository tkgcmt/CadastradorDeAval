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
        // Declaração de constantes
        public const string INICIAL = "Atributo não inicializado.";
        public const string CAM_INICIAL = "Local do arquivo.csv";
        // Declaração de variáveis e objetos
        public Arquivo seletor = new Arquivo();
        public Avaliacao Aval = new Avaliacao();
        public List<Questao> Quest = new List<Questao>();

        // Summary:
        //     Função principal
        public MainWindow()
        {
            InitializeComponent();
            InicializarValores();
        }

        public void InicializarValores()
        {   

            // Constroi uma lista de questões para teste em ComboBox
            int num = 1000;
            for (int i = 0; i < 10; i++)
            {   
                Quest.Add(new Questao());
                Quest[i].NI = num;
                Quest[i].Titulo = num.ToString() + " - lalala";
                num = num + 1;
                
            }

            // Setting DataContext and ItemsSource here ensures that the data
            // is initialized before the data is displayed.
            QuestSaltosPosCmb.ItemsSource = Quest;
            QuestSaltosNegCmb.ItemsSource = Quest;
            QuestListaListb.ItemsSource = Quest;

            AvalTituloTxt.DataContext = Aval;
            AvalTituloTxt.IsReadOnly = true;
            AvalFeedbackPosTxt.DataContext = Aval;
            AvalFeedbackNegTxt.DataContext = Aval;
        }

        private void AvalFeedbackPosBtn_Click(object sender, RoutedEventArgs e)
        {
            Aval.PosFeed = seletor.LocalizarArq("audio");
            AvalFeedbackPosTxt.IsEnabled = true;
        }

        private void AvalFeedbackPosBtn1_Click(object sender, RoutedEventArgs e)
        {
            Aval.PosFeed = "";
            AvalFeedbackPosTxt.IsEnabled = false;
        }

        private void AvalFeedbackNegBtn_Click(object sender, RoutedEventArgs e)
        {
            Aval.NegFeed = seletor.LocalizarArq("audio");
            AvalFeedbackNegTxt.IsEnabled = true;
        }

        private void AvalFeedbackNegBtn1_Click(object sender, RoutedEventArgs e)
        {
            Aval.NegFeed = "";
            AvalFeedbackNegTxt.IsEnabled = false;
        }

        private void AvalAbrir_Click(object sender, RoutedEventArgs e)
        {
            Aval.Caminho = seletor.LocalizarArq("csv");
        }

        private void AvalNovo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AvalDel_Click(object sender, RoutedEventArgs e)
        {
            Aval.Caminho = CAM_INICIAL;
        }
    }
}
