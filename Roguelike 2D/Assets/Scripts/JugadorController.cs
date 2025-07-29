using UnityEngine;

public class JugadorController : MonoBehaviour
{
    
    private MapaManager mapa;
    private Vector2Int celda;

    public void Spawn(MapaManager nuevoMapa, Vector2Int nuevaCelda)
    {
        mapa = nuevoMapa;
        celda = nuevaCelda;

        transform.position = mapa.ObtenerPosicionCelda(celda);
    }
   
}
