using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Windows;
using Microsoft.Win32;
using System.Security;

namespace CadastradorDeAval
{
    //
    // Summary:
    //     Classe que concentra tarefas comuns ao cadastramento das informações para o cabeçalho,
    //     incluindo Enunciado e metadados.
    public class SeletorArquivos : InterfCadastrador
    {
        // Objeto declarado fora da função. Faz com que ele lembre qual foi o último diretório 
        // visitado.
        private OpenFileDialog dialogo = new OpenFileDialog();
        //
        // Summary:
        //     Define os atributos para o painel de diálogo de abertura de arquivo. A variavel
        //     extensao define o tipo de arquivo com o qual a função irá trabalhar.
        public void initDialogo(params string[] extensao)
        {
            dialogo.Title = @"Localizar " + extensao;
            dialogo.CheckFileExists = true;
            dialogo.CheckPathExists = true;
            dialogo.Multiselect = false;
            dialogo.Filter = pegaFiltro(extensao) + "|Todos arquivos (*.*)|*.*";
        }
        // Summary:
        //     Recebe um vetor de string que define os possíveis filtros para escolha de arquivos.
        //
        // Returns:
        //     Uma string com o filtro a ser utilizado no atributo Filter da classe OpenFileDialog
        private string pegaFiltro(params string[] extensao)
        {
            string filtro = "";
            foreach (string ext in extensao)
            {
                switch (ext)
                {
                    case "csv":
                        filtro =  filtro + @"Variáveis separadas por vírgulas (*.csv)|*.csv|";
                        break;
                    case "imagem":
                        filtro = filtro + @"Imagen (*.jpg)|*.jpg|(*.png)|*.png|(*.gif)|*.gif|(*.jpeg)|*.jpeg|"
                                        + @"(*.bmp)|*.bmp|";
                        break;
                    case "audio":
                        filtro = filtro + @"Audio (*.mp3)|*.mp3|(*.wav)|*.wav|";
                        break;
                    case "texto":
                        filtro = filtro + @"Texto (*.txt)|*.txt|";
                        break;
                    default:
                        break;
                }
            }
            filtro = filtro.TrimEnd('|');
            return filtro;
        }
        // Summary:
        //     Seleciona um arquivo de extensão 'extensao', usando o diálogo de abertura de
        //     arquivo e devolve o caminho absoluto desse arquivo.
        //
        // Returns:
        //     Uma string que contém o camiho absoluto do arquivo de extensão 'extensao'.
        public string LocalizarArq(params string[] extensao)
        {
            string caminho = "";
            initDialogo(extensao);
            if (dialogo.ShowDialog() == true)
            {
                try
                {
                    caminho = dialogo.FileName;
                }
                catch (SecurityException ex)
                {
                    // O usuário não possui permissão para ler arquivos
                    MessageBox.Show("Verfique se você tem permissão para ler" 
                        + "os arquivos e tente novamente.\n"
                        + ex.Message, 
                        "Erro de leitura", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Error);
                }
                catch (System.Exception ex)
                {   
                    // Erro ao ler o arquivo
                    MessageBox.Show("Erro ao ler o arquivo.\n"
                        + ex.Message,
                        "Erro de leitura",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            return caminho;
        }
    }
    //
    // Summary:
    //     Classe que armazena a lista de questões.

    public class NI
    {   
        // Atributo de Nome
        private string nome = "Err_nome_não_definido_";
        public string Nome
        { get; set; }

        // Atributo de NID
        private int nid = -1;
        public int NID { get; set; }

        // Construtor da classe
        public NI(string titulo="", int numID=0)
        {
            Nome = titulo;
            NID = numID;
        }
    }
}
