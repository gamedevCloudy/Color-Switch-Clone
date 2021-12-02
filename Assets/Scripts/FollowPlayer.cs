using UnityEngine;

public class FollowPlayer : MonoBehaviour 
{
    public Transform player;
    void Update ()
    {
        if (player.position.y > transform.position.y)
        {
            transform.position = new Vector3(player.position.x, player.position.y, -10f);
            // the z position should be -10 always, the previous 
            // was set as player's z position, thus the camera kept moving to the player, so you could not see anything in
            // the game. 
            
        }
    }
}