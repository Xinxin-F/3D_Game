using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Elemental Reaction")]
public class ElementalReactionSkill : Ability
{
    public GameObject fireballPrefab;
    public GameObject iceballPrefab;
    public float bulletSpeed = 10f;

    // public override void Activate(GameObject parent, bool isLongPress)
    // {
    //     GameObject selectedBulletPrefab = isLongPress ? iceballPrefab : fireballPrefab;
    //     ShootElementalBullet(parent, selectedBulletPrefab);
    // }

    public override void Activate(GameObject parent)
    {
        base.Activate(parent);
    }

    public void Activate(GameObject parent, bool isLongPress)
    {
        GameObject selectedBulletPrefab = isLongPress ? iceballPrefab : fireballPrefab;
        ShootElementalBullet(parent, selectedBulletPrefab);
    }

    private void ShootElementalBullet(GameObject parent, GameObject bulletPrefab)
    {
        Vector3 direction = AttackDirection.GetDirectionFromMouse(Camera.main, parent);
        if (direction != Vector3.zero)
        {
            Transform parentTransform = parent.transform;
            Vector3 spawnPosition = parentTransform.position + direction;
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, parentTransform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }
        }
    }
}
