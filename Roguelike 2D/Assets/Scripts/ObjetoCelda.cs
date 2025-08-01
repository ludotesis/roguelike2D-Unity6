using UnityEngine;

public class ObjetoCelda : MonoBehaviour
{
    protected Vector2Int coordenada;
    public virtual void Iniciar(Vector2Int nuevaCoordena)
    {
        coordenada = nuevaCoordena;
    }
    
    public virtual void InteraccionJugador()
    {
        Destroy(gameObject);
    }
}
