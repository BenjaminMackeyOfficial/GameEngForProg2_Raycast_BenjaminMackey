
using Unity.Mathematics;
using UnityEngine;

public class RunAwayer : MonoBehaviour, Iinteractible
{
    [SerializeField] Vector2 runBounds;
    [SerializeField] float speed;

    private Renderer rend;
    private bool running = false;
    private Vector3 targPos;

    public void Interact()
    {
        if (running == true) return;
        RunAway();
    }
    public void Start()
    {
        targPos = transform.position;
        rend = GetComponent<Renderer>();
    }
    void Update()
    {
        if(Vector3.Distance(transform.position, targPos) < 0.1f) running = false;
        else running = true;

        if (running) rend.material.color = Color.red * (0.5f + math.sin(Time.time * speed) / 2f);
        else rend.material.color = Color.green;

        transform.position = Vector3.MoveTowards(transform.position, targPos, speed * Time.deltaTime);
    }
    private void RunAway()
    {
        targPos = new Vector3(UnityEngine.Random.Range(-runBounds.x, runBounds.x), transform.position.y, UnityEngine.Random.Range(-runBounds.y, runBounds.y));
    }

   
}
