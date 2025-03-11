using UnityEngine;

public class EquipTool : Equip
{
    public float attackRate;
    private bool attacking;  
    public float attackDistance;  
    public float useStamina;

    [Header("Resource Gathering")]
    public bool doesGatherResources; 

    [Header("Combat")]
    public bool doesDealDamage;
    public int damage;

    private Animator animator;
    private Camera camera;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        camera = Camera.main;
    }

    public override void OnAttackInput()
    {
        if (!attacking)
        {
            if (CharacterManager.Instance.Player.condition.UseStamina(useStamina))
            {
                attacking = true;
                animator.SetTrigger("Attack");
                Invoke("OnCanAttack", attackRate);
            }
        }
    }

    void OnCanAttack()
    {
        attacking = false;
    }

    public void OnHit()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        Debug.Log("OnHit");
        if (Physics.Raycast(ray, out hit, attackDistance))
        {
            Debug.Log(hit.collider.name);
            Debug.Log(hit.collider.TryGetComponent(out Resource resource));
            //여기 조건에 성립이 안되어있기때문에 flase값이 들어와서 자원채취가 안됨
            if (doesGatherResources)
            {
                resource.Gather(hit.point, hit.normal);
            }
        }
    }
}
