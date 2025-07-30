using UnityEngine;

public class ObjetoComida : ObjetoCelda
{
    public override void InteraccionJugador()
    {
        base.InteraccionJugador();
        
        Debug.Log("Incrementar Comida");
    }
}
