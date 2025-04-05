using UnityEngine;

public interface IItem
{
    GameObject GameObject { get; }

    void OnCollisionEnter(Collision collision);
    void Effect(GameObject gObject);
}
    

