using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Gun/Make New Gun", order = 0)]
public class Gun : ScriptableObject 
{
    [SerializeField] Projectile projectile = null;
    [SerializeField] float damage;

    public void Shoot(Transform gunPipe)
    {
        if (projectile == null) { return;}

        projectile.Shoot(damage, gunPipe);
    }
    
}