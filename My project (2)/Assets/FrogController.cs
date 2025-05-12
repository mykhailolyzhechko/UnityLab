using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float jumpSpeed = 5f;
    public float jumpHeight = 2f;
    private bool isJumping = false;

    public void JumpTo(Vector3 target)
    {
        if (!isJumping)
            StartCoroutine(JumpRoutine(target));
    }

    private IEnumerator JumpRoutine(Vector3 target)
    {
        isJumping = true;

        Vector3 start = transform.position;
        float time = 0f;
        float duration = Vector3.Distance(start, target) / jumpSpeed;

        while (time < duration)
        {
            float t = time / duration;
            float height = Mathf.Sin(t * Mathf.PI) * jumpHeight;
            transform.position = Vector3.Lerp(start, target, t) + Vector3.up * height;
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
        isJumping = false;
    }
}
