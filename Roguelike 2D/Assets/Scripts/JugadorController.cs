using UnityEngine;
using UnityEngine.InputSystem;

public class JugadorController : MonoBehaviour
{
    
    private MapaManager mapa;
    private Vector2Int celda;

    public void Spawn(MapaManager nuevoMapa, Vector2Int nuevaCelda)
    {
        mapa = nuevoMapa;
        Mover(nuevaCelda);
    }

    private void Update()
    {
        Vector2Int siguienteCelda = celda;
        bool movido = false;

        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            siguienteCelda.y += 1;
            movido = true;
        }
        else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            siguienteCelda.y -= 1;
            movido = true;
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            siguienteCelda.x += 1;
            movido = true;
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            siguienteCelda.x -= 1;
            movido = true;
        }

        if (movido)
        {
            Celda datosCelda = mapa.ObtenerDatosCelda(siguienteCelda);

            if (datosCelda != null && datosCelda.GetPasable())
            {
                GameManager.Instance.TurnosManager.SiguienteTurno();
                Mover(siguienteCelda);

                if (!datosCelda.Vacia())
                {
                    datosCelda.Objeto.InteraccionJugador();
                }
            }
        }
    }

    public void Mover(Vector2Int nuevaCelda)
    {
        celda = nuevaCelda;
        transform.position = mapa.ObtenerPosicionCelda(celda);
    }
}
