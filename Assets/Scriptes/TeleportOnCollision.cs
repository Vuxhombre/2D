using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TeleportOnCollision : MonoBehaviour
{
    public TeleportOnCollision teleport;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        teleport.gameObject.SetActive(false);
        collision.transform.position = teleport.transform.position;
        StartCoroutine(TeleportPlayer(3.0f));
    }
    IEnumerator TeleportPlayer(float TimeToTeleport)
    {
        yield return new WaitForSeconds(TimeToTeleport);
        teleport.gameObject.SetActive(true);
    }
}
