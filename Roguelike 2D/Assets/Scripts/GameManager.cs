using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private JugadorController jugador;
    
    [SerializeField]
    private MapaManager mapa;

    private TurnosManager turnosManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        turnosManager = new TurnosManager();
        mapa.GenerarMapa();
        jugador.Spawn(mapa, new Vector2Int(2,2));
    }
}
