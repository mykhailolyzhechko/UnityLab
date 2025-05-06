using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform slab;
    public Transform cycloidSphere;
    public Transform astroidCylinder;

    public Vector3 pointA = new Vector3(-5, 0, 0);
    public Vector3 pointB = new Vector3(5, 0, 0);
    public float slabSpeed = 2f;

    public float cycloidScale = 1f;
    public float cycloidSpeed = 1f;

    public float astroidScale = 3f;
    public float astroidSpeed = 1f;

    private float time;

    void Update()
    {
        time += Time.deltaTime;

        // Slab movement between A and B
        float pingPong = Mathf.PingPong(Time.time * slabSpeed, 1f);
        slab.position = Vector3.Lerp(pointA, pointB, pingPong);

        // Cycloid: x = r(t - sin(t)), y = r(1 - cos(t))
        float t1 = time * cycloidSpeed;
        float x1 = cycloidScale * (t1 - Mathf.Sin(t1));
        float y1 = cycloidScale * (1 - Mathf.Cos(t1));
        cycloidSphere.position = new Vector3(x1, y1, 0);

        // Astroid: x = a * cos^3(t), y = a * sin^3(t)
        float t2 = time * astroidSpeed;
        float x2 = astroidScale * Mathf.Pow(Mathf.Cos(t2), 3);
        float y2 = astroidScale * Mathf.Pow(Mathf.Sin(t2), 3);
        astroidCylinder.position = new Vector3(x2, y2, 0);
    }
}
