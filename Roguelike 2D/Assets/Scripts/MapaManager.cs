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
    
    private Tilemap mapaTilemap;

    private void Awake()
    {
        mapaTilemap = GetComponentInChildren<Tilemap>();
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

                if (x == 0 || y == 0 || x == ancho - 1 || y == alto - 1)
                {
                    tile = paredTiles[Random.Range(0,paredTiles.Length)];
                }
                else
                {
                    tile = sueloTiles[Random.Range(0, sueloTiles.Length)];
                }
                
                mapaTilemap.SetTile(new Vector3Int(x,y,0) , tile);
            }
        }
    }

}
