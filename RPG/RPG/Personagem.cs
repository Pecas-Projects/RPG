using System;

namespace RPG
{
    public class Personagem 
    { 
    public String nome { get; set; }
    public String raca { get; set; }
    public double forca { get; set; }
    public double forcaEspecial { get; set; }
    public double vida { get; set; }
    public double defesa { get; set; }
    public double estamina { get; set; }
    public double escudo { get; set; }

    public bool escudoAtivo { get; set; }

    /// <summary>
    /// Metodo void que calcula o Dano dado no oponente.
    /// Leva em consideração a estamina e a força do personagem, o escudo do inimigo.
    /// </summary>
    public void atacar(Personagem inimigo)
    {

        if (inimigo.escudoAtivo == true)
        {
            inimigo.vida -= escudo - (this.forca * this.estamina);
        }

        inimigo.vida -= (this.forca * this.estamina);
    }

    public void ataqueEspecial(Personagem inimigo)
    {

        inimigo.vida -= (this.forcaEspecial * this.estamina);
    }

    public void usarEscudo()
    {
        escudoAtivo = true;
    }

    public void decansar() { } /// durante a batalha de turno, a estamina vai aumentar mais rapidamente (personagem fazendo nada)

    public void morrer()
    {
        this.vida = 0;
    }
}
}
