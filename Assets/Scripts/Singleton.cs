using UnityEngine;

// T is a Generic class
// It means it can be anything that fulfills the "where" condition
// It can be any class as long it is a MonoBehaviour
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected void Awake()
    {
        // Check if there is already an instance
        // and you are not the ACTUAL instance
        if (Instance != null && Instance != this as T)
        {
            // Give way to the proper instance and destroy self
            Destroy(this.gameObject);
            return;
        }
        else
        {
            // There is still no Instance assigned, we assign self
            Instance = this as T;
            //When new scene is loaded, make sure this does not get destroyed
            DontDestroyOnLoad(this.gameObject);
        }
    }

    protected void OnDestroy()
    {
        // Make sure to reset back to null if the Instance is destroyed
        if (Instance == this as T)
        {
            Instance = null;
        }
    }
}
