using UnityEngine;
using UnityEngine.Tilemaps;

public class MapaManager : MonoBehaviour
{
    [SerializeField]
    [Range(4,16)]
    private int ancho;
    
    [SerializeField]
    [Range(4,16)]
    private int  alto;
    
    [SerializeField]
    private Tile[] sueloTiles;
    
    [SerializeField]
    private Tile[] paredTiles;
    
    [SerializeField]
    private JugadorController jugador;
    
    private Tilemap mapaTilemap;
    private Grid grilla;
    private Celda[,] datosMapa;

    private void Awake()
    {
        mapaTilemap = GetComponentInChildren<Tilemap>();
        grilla = GetComponent<Grid>();
        datosMapa = new Celda[ancho, alto]; 
    }

    void Start()
    {
        GenerarMapa();
    }

    private void GenerarMapa()
    {
        for (int y = 0; y < alto; y++)
        {
            for (int x = 0; x < ancho; x++)
            {
                Tile tile;
                datosMapa[x, y] = new Celda();
                
                if (x == 0 || y == 0 || x == ancho - 1 || y == alto - 1)
                {
                    tile = paredTiles[Random.Range(0,paredTiles.Length)];
                    datosMapa[x, y].SetPasable(false);
                }
                else
                {
                    tile = sueloTiles[Random.Range(0, sueloTiles.Length)];
                    datosMapa[x, y].SetPasable(true);
                }
                
                mapaTilemap.SetTile(new Vector3Int(x,y,0) , tile);
            }
        }
        
        jugador.Spawn(this, new Vector2Int(2,2));
    }
    
    public Vector3 ObtenerPosicionCelda(Vector2Int celda)
    {
        return grilla.GetCellCenterWorld((Vector3Int)celda);
    }
    
    public Celda ObtenerDatosCelda(Vector2Int celda)
    {
        if (celda.x < 0 || celda.x >= ancho ||celda.y < 0 || celda.y >= alto)
        {
            return null;
        }

        return datosMapa[celda.x, celda.y];
    }

}
