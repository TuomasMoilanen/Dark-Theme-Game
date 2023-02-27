using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Player health")]
    public int health;

    private void Update()
    {
        if (health >= 4)
        {
            health = 3;
        }
    }
}