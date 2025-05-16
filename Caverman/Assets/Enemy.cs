using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float speed = 0.2f;

    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Player not found! Make sure the player has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (player == null) return;

        // Rotate to face the player
        transform.LookAt(player);

        // Move toward the player in a straight line
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }
}
