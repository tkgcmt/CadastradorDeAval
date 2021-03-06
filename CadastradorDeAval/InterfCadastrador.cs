﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CadastradorDeAval
{
    interface InterfCadastrador
    {
        /**********************************************************************
            Abre diálogo de busca de arquivo nas extensões ext[] e devolve o 
            caminho desse arquivo
        **********************************************************************/
        string LocalizarArq(string[] ext);

        FileStream AbreCSV(string caminho);
        FileStream AbreAudio(string caminho);
        FileStream AbreImagem(string caminho);


    }


}
