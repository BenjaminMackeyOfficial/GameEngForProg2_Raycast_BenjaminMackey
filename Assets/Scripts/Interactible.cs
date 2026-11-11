using UnityEngine;

public interface Iinteractible
{
    public abstract void Interact();
    public bool isTarget { get; }
}
