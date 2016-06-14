using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Windows;
using Microsoft.Win32;
using System.Security;
using System;
using System.ComponentModel;

namespace CadastradorDeAval
{
    //
    // Summary:
    //     Classe que concentra tarefas comuns ao cadastramento das informações para o cabeçalho,
    //     incluindo Enunciado e metadados.
    public class Arquivo : InterfCadastrador, INotifyPropertyChanged
    {
        //Implementing INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }

        //Guarda o caminho absoluto do arquivo selecionado
        private string arq = "";

        public string Arq
        {
            get
            {
                return arq;

            }

            set
            {
                arq = value;

                NotifyPropertyChanged("Arq");
            }
        }
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
                        filtro = filtro + @"Variáveis separadas por vírgulas (*.csv)|*.csv|";
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

        public FileStream AbreCSV(string caminho)
        {
            throw new NotImplementedException();
        }

        public FileStream AbreAudio(string caminho)
        {
            throw new NotImplementedException();
        }

        public FileStream AbreImagem(string caminho)
        {
            throw new NotImplementedException();
        }
    }

    // Summary:
    //     Classe que contém informações sobre a questão e/ou informações comuns a todas as
    //     alternativas. Atributos e variáveis que contenham a letra 'Q' no nome, será referente
    //     a essa classe.
    public class Alternativa : INotifyPropertyChanged
    {   //Implementing INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }

        private int tela;
        public int OrdemTela
        {
            get
            {
                return tela;

            }
            set
            {
                tela = value;

                NotifyPropertyChanged("OrdemTela");
            }
        }

        private int resp;
        public int OrdemResposta
        {
            get
            {
                return resp;

            }
            set
            {
                resp = value;

                NotifyPropertyChanged("OrdemResposta");
            }
        }


        private string posFeed;
        public string PosFeed
        {
            get
            {
                return posFeed;
            }
            set
            {
                posFeed = value;
                NotifyPropertyChanged("PosFeed");
            }

        }
        private string negFeed;
        public string NegFeed
        {
            get
            {
                return negFeed;
            }
            set
            {
                negFeed = value;
                NotifyPropertyChanged("NegFeed");
            }

        }
        private string posSalto;
        public string PosSalto
        {
            get
            {
                return posSalto;
            }
            set
            {
                posSalto = value;
                NotifyPropertyChanged("PosSalto");
            }

        }
        private string negSalto;
        public string NegSalto
        {
            get
            {
                return negSalto;
            }
            set
            {
                negSalto = value;
                NotifyPropertyChanged("NegSalto");
            }

        }

        private string img;
        public string Imagem
        {
            get
            {
                return img;

            }
            set
            {
                img = value;

                NotifyPropertyChanged("Imagem");
            }
        }

        private string text;
        public string Texto
        {
            get
            {
                return text;

            }
            set
            {
                text = value;

                NotifyPropertyChanged("Texto");
            }
        }

        private string aud;
        public string Audio
        {
            get
            {
                return aud;

            }
            set
            {
                aud = value;

                NotifyPropertyChanged("Audio");
            }
        }
    }


    // Summary:
    //     Classe que contém informações sobre a questão e/ou informações comuns a todas as
    //     alternativas. Atributos e variáveis que contenham a letra 'Q' no nome, será referente
    //     a essa classe.
    public class Questao : INotifyPropertyChanged
    {   //Implementing INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }
        private int ni;
        public int NI
        {
            get
            {
                return ni;

            }
            set
            {
                ni = value;

                NotifyPropertyChanged("NI");
            }
        }
        private bool dica;
        public bool Dica
        {
            get
            {
                return dica;

            }
            set
            {
                dica = value;

                NotifyPropertyChanged("Dica");
            }
        }

        private string tipo;
        public string Tipo
        {
            get
            {
                return tipo;

            }
            set
            {
                tipo = value;

                NotifyPropertyChanged("Tipo");
            }
        }

        private string cor;
        public string Cor
        {
            get
            {
                return cor;

            }
            set
            {
                cor = value;

                NotifyPropertyChanged("Cor");
            }
        }

        private string disci;
        public string Disciplina
        {
            get
            {
                return disci;

            }
            set
            {
                disci = value;

                NotifyPropertyChanged("Disciplina");
            }
        }

        private string eixo;

        public string Eixo
        {
            get
            {
                return eixo;

            }
            set
            {
                eixo = value;

                NotifyPropertyChanged("Eixo");
            }
        }

        private string comp;

        public string Competencia
        {
            get
            {
                return comp;

            }
            set
            {
                comp = value;

                NotifyPropertyChanged("Competencia");
            }
        }

        private string titu;

        public string Titulo
        {
            get
            {
                return titu;

            }
            set
            {
                titu = value;

                NotifyPropertyChanged("Titulo");
            }
        }

        private string posFeed;
        public string PosFeed
        {
            get
            {
                return posFeed;
            }
            set
            {
                posFeed = value;
                NotifyPropertyChanged("PosFeed");
            }

        }
        private string negFeed;
        public string NegFeed
        {
            get
            {
                return negFeed;
            }
            set
            {
                negFeed = value;
                NotifyPropertyChanged("NegFeed");
            }

        }
        private string posSalto;
        public string PosSalto
        {
            get
            {
                return posSalto;
            }
            set
            {
                posSalto = value;
                NotifyPropertyChanged("PosSalto");
            }

        }
        private string negSalto;
        public string NegSalto
        {
            get
            {
                return negSalto;
            }
            set
            {
                negSalto = value;
                NotifyPropertyChanged("NegSalto");
            }

        }
        private string img;
        public string Imagem
        {
            get
            {
                return img;

            }
            set
            {
                img = value;

                NotifyPropertyChanged("Imagem");
            }
        }

        private string text;
        public string Texto
        {
            get
            {
                return text;

            }
            set
            {
                text = value;

                NotifyPropertyChanged("Texto");
            }
            }

        private string aud;
        public string Audio
        {
            get
            {
                return aud;

            }
            set
            {
                aud = value;

                NotifyPropertyChanged("Audio");
            }
        }

        private string psicoVar;
        public string Variacao
        {
            get
            {
                return psicoVar;
            }
            set
            {
                psicoVar = value;
                NotifyPropertyChanged("Variacao");
            }
        }

        public Alternativa[] ListaAlt;
    }


    //
    // Summary:
    //     Classe que referente aos atributos comuns a toda a Avaliação

    public class Avaliacao :INotifyPropertyChanged
    {   //Implementing INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }
        private string caminho = "Local do arquivo .csv";
        public string Caminho
        {
            get
            {
                return caminho;
            }
            set
            {
                caminho = value;
                NotifyPropertyChanged("Caminho");
            }
        }
        private string posFeed;
        public string PosFeed
        {
                get
            {
                return posFeed;
            }
            set
            {
                posFeed = value;
                NotifyPropertyChanged("PosFeed");
            }

        }
        private string negFeed;
        public string NegFeed
        {
            get
            {
                return negFeed;
            }
            set
            {
                negFeed = value;
                NotifyPropertyChanged("NegFeed");
            }

        }

        private string descrip;
        public string Descrip
        {
            get
            {
                return descrip;

            }
            set
            {
                descrip = value;

                NotifyPropertyChanged("Descrip");
            }

        }
        public int DisciNum { get; set;}
        public int QNum { get; set; }

        public Questao[] ListaQ;
    }
}
