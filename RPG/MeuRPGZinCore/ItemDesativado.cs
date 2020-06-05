using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRPGZinCore
{
    /// <summary>
    /// Interface que é implementada por itens que precisão ter o benefício 
    /// que é concedido à feiticeira desativado, após um turno da batalha.
    /// </summary>
    public interface ItemDesativado
    {
        /// <summary>
        /// Desativa o benefício concedido por um Item.
        /// </summary>
        /// <param name="jogador"></param>
        void DesativarItem(Feiticeira jogador);
    }
}
