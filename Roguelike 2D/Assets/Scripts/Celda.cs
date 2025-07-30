using UnityEngine;

public class Celda
{
    private bool pasable;
    private GameObject objeto;

    public void SetPasable(bool estado)
    {
        pasable = estado;
    }
    
    public bool GetPasable()
    {
        return pasable;
    }

    public void AsignarObjeto(GameObject nuevoObjeto)
    {
        objeto = nuevoObjeto;
    }
    
    public bool Vacia()
    {
        return objeto == null;
    }
}
