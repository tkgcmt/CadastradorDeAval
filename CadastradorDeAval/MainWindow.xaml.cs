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

        private void InicializarValores()
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

        /// <summary>
        /// Escreve o caminho do arquivo de extensao 'extensao' no parâmetro 'Text' de um objeto 'obj_caminho'.
        /// </summary>
        /// <param name="extensao"></param>
        /// <param name="obj_caminho"></param>
        /// <remarks>Garante o valor original de obj_caminho.Text se o diálogo for cancelado.</remarks>
        private void AbrirArq( TextBox obj_caminho, params string[] extensao)
        {
            string temp = seletor.LocalizarArq("csv");
            if (temp != "")
            {
                obj_caminho.Text = temp;
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        //
        // Controle da interface (VielModel talvez)
        //
        ///////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////////////
        // Aval CSV
        ///////////////////////////////////////////////////////////////////////////////////////////
        private void AvalAbrir_Click(object sender, RoutedEventArgs e)
        {
            AbrirArq(AvalTituloTxt, "csv");
        }

        private void AvalNovo_Click(object sender, RoutedEventArgs e)
        {
            Console.Write("Not implemented yet");
        }

        private void AvalDel_Click(object sender, RoutedEventArgs e)
        {
            Aval.Caminho = "";
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        // Aval Feedback
        ///////////////////////////////////////////////////////////////////////////////////////////
        private void AvalFeedbackPosBtn_Click(object sender, RoutedEventArgs e)
        {
            AbrirArq(AvalFeedbackPosTxt, "audio");
        }

        private void AvalFeedbackPosTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Aval.PosFeed = AvalFeedbackPosTxt.Text;
        }

        private void AvalFeedbackPosDel_Click(object sender, RoutedEventArgs e)
        {
            Aval.PosFeed = "";
        }

        private void AvalFeedbackNegBtn_Click(object sender, RoutedEventArgs e)
        {
            AbrirArq(AvalFeedbackNegTxt, "audio");
        }

        private void AvalFeedbackNegTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Aval.NegFeed = AvalFeedbackNegTxt.Text;
        }

        private void AvalFeedbackNegDel_Click(object sender, RoutedEventArgs e)
        {
            Aval.NegFeed = "";
        }

    }
}
