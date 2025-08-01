using UnityEngine;

public class ObjetoComida : ObjetoCelda
{
    [SerializeField][Range(5,20)]
    public int valorComida = 10;
    public override void InteraccionJugador()
    {
        base.InteraccionJugador();
        GameManager.Instance.ModificarComida(valorComida);
    }
}
