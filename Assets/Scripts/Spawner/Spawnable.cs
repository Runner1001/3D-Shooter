using UnityEngine;

public class Spawnable : PooledMonoBehaviour
{
    [SerializeField] private float respawnDelay = 10f;

    private void Start()
    {
        if(GetComponent<Health>() != null)
            GetComponent<Health>().OnDied += () => ReturnToPool(respawnDelay);
    }
}
