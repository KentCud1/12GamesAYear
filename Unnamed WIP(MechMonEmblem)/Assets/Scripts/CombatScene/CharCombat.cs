using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCombat : MonoBehaviour
{

    public int health;

    public CloseAttack closeAttack;
    //close attack,
    public MediumAttack mediumAttack;
    //med attack.
    public FarAttack farAttack;
    //far attack.

    Attack currentAttack;

    Animator _anim;

    public bool turnIsFinished;
    public bool animFinished;
    bool animPlayed;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if (currentAttack != null) {
        //    if (!_anim.GetCurrentAnimatorStateInfo(0).IsName(currentAttack.animName) || !_anim.GetNextAnimatorStateInfo(0).IsName(currentAttack.animName)) {
        //        animPlayed = true;
        //        Debug.Log("Anim finished for " + name);
        //        currentAttack = null;
        //    }
        //}
    }

    public void Attack(Dist dist, CharCombat other) {
        currentAttack = null;
        if(dist == Dist.CLOSE) {
            currentAttack = closeAttack;
        }
        else if(dist == Dist.MEDIUM) {
            currentAttack = mediumAttack;
        }
        else if(dist == Dist.FAR) {
            currentAttack = farAttack;
        }

        other.health -= CalculateDamageFromAttack(currentAttack);
        Debug.Log(name + " has attacked with " + currentAttack.name + ". " + other.name + " has received " + currentAttack.damage + " damage.");

        turnIsFinished = true;
        Debug.Log("Turn finished for " + name);
    }

    public void PlayAnimation() {
        if ((!_anim.GetCurrentAnimatorStateInfo(0).IsName(currentAttack.animName) && !_anim.GetNextAnimatorStateInfo(0).IsName(currentAttack.animName)|| !_anim.HasState(0, Animator.StringToHash(currentAttack.animName))) && animPlayed == true) {
            Debug.Log("Animation finished fir " + gameObject.name);
            animFinished = true;
        }
        if (_anim.HasState(0, Animator.StringToHash(currentAttack.animName))) {
            if (!_anim.GetCurrentAnimatorStateInfo(0).IsName(currentAttack.animName) && !_anim.GetNextAnimatorStateInfo(0).IsName(currentAttack.animName) && animPlayed == false) {
                Debug.Log(gameObject.name + " played " + currentAttack.animName);
                _anim.Play(currentAttack.animName);
                animPlayed = true;
            }
        }
        else {
            animPlayed = true;
        }

        if(animFinished == true) {
            animPlayed = false;
        }

    }

    int CalculateDamageFromAttack(Attack atk) {
        int damage = 0;
        damage = atk.damage;
        return damage;
    }
}
