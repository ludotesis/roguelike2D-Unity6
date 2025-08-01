using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public TurnosManager TurnosManager { get; private set;}
    
    [SerializeField]
    private JugadorController jugador;
    
    [SerializeField]
    private MapaManager mapa;

    [SerializeField]
    [Range(10,200)]
    private int  comida;
    
    [SerializeField]
    public UIDocument juegoUI;
    private Label comidaLabel;
    
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
        TurnosManager.EnTurno += RespuestaNuevoTurno;
        mapa.GenerarMapa();
        jugador.Spawn(mapa, new Vector2Int(1,1));

        comidaLabel = juegoUI.rootVisualElement.Q<Label>("ComidaLabel");
        comidaLabel.text = "Comida: " + comida;
    }

    void RespuestaNuevoTurno()
    {
        ModificarComida(-1);
    }

    public void ModificarComida(int cantidadComida)
    {
        comida += cantidadComida;
        comidaLabel.text = "Comida: " + comida;
    }
}
