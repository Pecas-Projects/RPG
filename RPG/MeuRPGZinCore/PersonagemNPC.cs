﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    public interface PersonagemNPC
    {
        /// <summary>
        /// Metodo que define a ação do NPC levando em consideração a sua
        /// personalidade e situação de jogo
        /// </summary>
        /// <param name="inimiga"></param>
        /// <returns></returns>
        int Inteligencia(Feiticeira inimiga);

        /// <summary>
        /// Controle de Ação dos NPCs para a utilização do ataque especial 
        /// Caso o retorno seja:
        /// Ataque especial return 2
        /// Ataque return 1
        /// Escudo return 0
        /// Descanço return -1
        /// </summary>
        /// <param name="inimiga"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        int Acao(Feiticeira inimiga, ControllerBatalha controller);
    }
}
