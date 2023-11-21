using UnityEngine;
using UnityEngine.Events;

public class TriggerManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent firstTriggerEvent;

    [SerializeField]
    private UnityEvent secondTriggerEvent;

    public void TriggerFirst()
    {
        firstTriggerEvent?.Invoke();
    }

    public void TriggerSecond()
    {
        secondTriggerEvent?.Invoke();
    }
}
