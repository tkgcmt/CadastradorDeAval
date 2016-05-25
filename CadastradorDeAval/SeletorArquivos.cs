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
    public class SeletorArquivos : InterfCadastrador
    {
        string InterfCadastrador.Localizar(string[] extension)
        {
            // Teste de leitura de extensão
            string ext = extension[0];
            string path = localizarArq(ext);

            return path + "/////" + extension;
        }
        private string pegaFiltro(string extensao)
        {
            switch (extensao)
            {
                case "csv":
                    return @"Variáveis separadas por vírgulas (*.csv)|*.csv";
                case "img":
                    return @"Imagen (*.jpg)|*.jpg|(*.png)|*.png|(*.gif)|*.gif|(*.jpeg)|*.jpeg|(*.bmp)|*.bmp";
                case "audio":
                    return @"Audio (*.mp3)|*.mp3|(*.wav)|*.wav";
                case "txt":
                    return @"Texto (*.txt)|*.txt";
                default:
                    return "";
            }
        }
        public string localizarArq(string extensao)
        {   
            string caminho = "";
            OpenFileDialog dialogo = new OpenFileDialog
            {
                RestoreDirectory = true,
                Title = @"Localizar " + extensao,
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                Filter = pegaFiltro(extensao) + "|Todos arquivos (*.*)|*.*",
            };
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
}
