using UnityEngine;

public class Celda
{
    private bool pasable;
    private ObjetoCelda objeto;

    public ObjetoCelda Objeto => objeto;

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
        if (nuevoObjeto.TryGetComponent<ObjetoCelda>(out ObjetoCelda objetoCelda))
        {
            objeto = objetoCelda;
        }
    }
    
    public bool Vacia()
    {
        return Objeto == null;
    }
}
