using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player3D : MonoBehaviour
{
    public float runSpeed = 10.0f;
    public float rotationSpeed = 360.0f;

    CharacterController pcController;
    Vector3 direction;

    Animator animator;

    public bool bAttack = false;

    NavMeshAgent agent = null;

    public AudioClip audioClip = null;
    private AudioSource audioSource = null;

    // Start is called before the first frame update
    void Start()
    {
        pcController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();

        audioClip = Resources.Load(string.Format("Sounds/foot/{0}", "army")) as AudioClip;
    }

    // Update is called once per frame
    void Update()
    {
        //Input_Animation();
        //CharacterControll_Slerp();
        NavMesh_Control();
    }

    private void NavMesh_Control()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.destination = hit.point;
            }
        }

        if (agent.velocity.magnitude > 0.5f)
        {
            PlaySound(audioClip);
        }
        else
            StopSound();
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource.isPlaying) return;
        audioSource.PlayOneShot(clip);
    }

    void StopSound()
    {
        audioSource.Stop();
    }

    private void Input_Animation()
    {
        if (Input.GetMouseButtonDown(0) && !bAttack)
        {
            bAttack = true;
            animator.SetLayerWeight(1, 1.0f);
            animator.SetBool("bAttack", bAttack);
            StartCoroutine("Attack_Routine");
        }
    }

    IEnumerator Attack_Routine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0);
            Debug.Log(bAttack && animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.StopAttackAxe"));
            Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.RunAttackAxe"));
            if (bAttack && animator.GetCurrentAnimatorStateInfo(1).IsName("Upperbody.StopAttackAxe"))
            {
                if (animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 0.6f)
                {
                    bAttack = false;
                    animator.SetBool("bAttack", bAttack);
                    break;
                }
            }
            else if (bAttack && animator.GetCurrentAnimatorStateInfo(1).IsName("Upperbody.RunAttackAxe"))
            {
                if (animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 0.6f)
                {
                    bAttack = false;
                    animator.SetBool("bAttack", bAttack);
                    break;
                }
            }
        }
    }

    private void CharacterControll_Slerp()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward, direction, rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));

            transform.LookAt(transform.position + forward);
        }
        else
        {

        }

        animator.SetFloat("Speed", pcController.velocity.magnitude);
        pcController.Move(direction * runSpeed * Time.deltaTime + Physics.gravity * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Coin"))
        {
            
        }

        // 공격받으면 넉백
    }
}
