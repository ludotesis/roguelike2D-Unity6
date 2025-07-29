using UnityEngine;

public class TurnosManager
{
    private int turnos;

    public TurnosManager()
    {
        turnos = 1;
    }

    public void SiguienteTurno()
    {
        turnos++;
        Debug.Log("El turno actual es "+turnos);
    }
}
