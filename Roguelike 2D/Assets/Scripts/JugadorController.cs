using UnityEngine;

public class JugadorController : MonoBehaviour
{
    
    private MapaManager mapa;
    private Vector2Int posicionCelda;

    public void Spawn(MapaManager nuevoMapa, Vector2Int nuevaPosicionCelda)
    {
        mapa = nuevoMapa;
        posicionCelda = nuevaPosicionCelda;
    }
   
}
