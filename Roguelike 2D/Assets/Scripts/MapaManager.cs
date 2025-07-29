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
    
    private Tilemap mapaTilemap;

    private void Awake()
    {
        mapaTilemap = GetComponentInChildren<Tilemap>();
    }

    void Start()
    {
        GenerarSuelo();
    }

    private void GenerarSuelo()
    {
        for (int y = 0; y < alto; y++)
        {
            for (int x = 0; x < ancho; x++)
            {
                int indiceTile = Random.Range(0, sueloTiles.Length);
                mapaTilemap.SetTile(new Vector3Int(x,y,0) , sueloTiles[indiceTile]);
            }
        }
    }
}
