using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCycle : MonoBehaviour
{
    public CombatState state;

    public float countdownTime;
    float timer;

    CharCombat[] ccs;

    CombatTimer _ct;

    CharDistance _cd;

    bool attackPhaseFinished = false, animatePhaseFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        state = CombatState.NULL;
        ccs = FindObjectsOfType<CharCombat>();
        _ct = FindObjectOfType<CombatTimer>();
        _cd = FindObjectOfType<CharDistance>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == CombatState.TIMER) {
            TimerPhase();
        }
        else if(state == CombatState.ATTACK) {
            CombatPhase();
        }
        else if(state == CombatState.NULL) {
            if(Input.GetButtonUp("Jump")) {
                InitializeCombat();
            }
        }
        else if(state == CombatState.ANIM) {
            AnimatePhase();
        }

        Debug.Log(state.ToString());
        _ct.time = timer;
        _ct.timer = countdownTime;
    }

    void TimerPhase() {
        if(timer > countdownTime) {
            timer = 0.0f;
            state = CombatState.ATTACK;
        }

        if (state == CombatState.TIMER) {
            timer += Time.deltaTime;
        }
    }

    void CombatPhase() {
        if (attackPhaseFinished == true) {
            attackPhaseFinished = false;
            foreach (CharCombat cc in ccs) {
                cc.turnIsFinished = false;
            }
            state = CombatState.ANIM;
        }
        else {
            foreach (CharCombat cc in ccs) {
                    cc.Attack(_cd.distBetweenChars, cc);
                
            }
        }

        attackPhaseFinished = true;
        for(int i = 0; i < ccs.Length;i++) {
            if(ccs[i].turnIsFinished == false) {
                attackPhaseFinished = false;
                break;
            }
        }
    }

    void AnimatePhase() {
        if(animatePhaseFinished == true) {
            animatePhaseFinished = false;
            foreach (CharCombat cc in ccs) {
                cc.animFinished = false;
            }
            state = CombatState.TIMER;
        }
        else {
            foreach(CharCombat cc in ccs) {
                Debug.Log(cc.gameObject.name + " anim play.");
                cc.PlayAnimation();
            }
        }

        animatePhaseFinished = true;
        for (int i = 0; i < ccs.Length; i++) {
            if (ccs[i].animFinished == false) {
                animatePhaseFinished = false;
                break;
            }
        }

    }

    public void InitializeCombat() {
        timer = 0.0f;
        attackPhaseFinished = false;
        foreach (CharCombat cc in ccs) {
            cc.turnIsFinished = false;
            cc.animFinished = false;
        }
        state = CombatState.TIMER;
    }

}

public enum CombatState {
    TIMER,
    ATTACK,
    NULL,
    ANIM
}
