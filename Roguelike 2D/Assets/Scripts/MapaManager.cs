using System.Collections.Generic;
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
    [Range(5,20)]
    private int  cantidadComida;
    
    [SerializeField]
    private GameObject[] objetosComida;
    
    private Tilemap mapaTilemap;
    private Grid grilla;
    private Celda[,] datosMapa;
    private List<Vector2Int> celdasDisponibles;

    private void Awake()
    {
        mapaTilemap = GetComponentInChildren<Tilemap>();
        grilla = GetComponent<Grid>();
        datosMapa = new Celda[ancho, alto]; 
        celdasDisponibles = new List<Vector2Int>();
    }

    public void GenerarMapa()
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
                    celdasDisponibles.Add(new Vector2Int(x, y));
                }
                
                mapaTilemap.SetTile(new Vector3Int(x,y,0) , tile);
            }
        }
        celdasDisponibles.Remove(new Vector2Int(1, 1));
        GenerarComida();
    }

    void GenerarComida()
    {
        for (int i = 0; i < cantidadComida; ++i)
        {
            int indiceAleatorio = Random.Range(0, celdasDisponibles.Count);
            Vector2Int celdaDisponible = celdasDisponibles[indiceAleatorio];
            
            Celda celda = datosMapa[celdaDisponible.x, celdaDisponible.y];
            
            if (celda.Vacia())
            {
                celdasDisponibles.RemoveAt(indiceAleatorio);
                GameObject nuevaComida = Instantiate(objetosComida[Random.Range(0,objetosComida.Length)]);
                nuevaComida.transform.position = ObtenerPosicionCelda(new Vector2Int(celdaDisponible.x, celdaDisponible.y));
                celda.AsignarObjeto(nuevaComida);
            }
        }
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
