using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField]
    private JugadorController jugador;
    
    [SerializeField]
    private MapaManager mapa;

    public TurnosManager TurnosManager { get; private set;}
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
      
        Instance = this;
    }
    
    void Start()
    {
        TurnosManager = new TurnosManager();
        mapa.GenerarMapa();
        jugador.Spawn(mapa, new Vector2Int(1,1));
    }
}
