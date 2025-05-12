using UnityEngine;

public class Food : MonoBehaviour
{
    public Leaf myLeaf; // Листок, на якому знаходиться їжа
    public FrogController frogManager;

    private void OnMouseDown()
    {
        frogManager.JumpTo(myLeaf.transform.position);
    }
}