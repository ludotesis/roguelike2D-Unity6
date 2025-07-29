using UnityEngine;

public class TurnosManager
{
    public event System.Action EnTurno;
    
    private int turnos;

    public TurnosManager()
    {
        turnos = 1;
    }

    public void SiguienteTurno()
    {
        turnos++;
        EnTurno?.Invoke();
        Debug.Log("El turno actual es "+turnos);
    }
}
