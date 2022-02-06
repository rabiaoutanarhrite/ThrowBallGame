using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private List<Target> targets = new List<Target>();

    [SerializeField] private List<string> reactions = new List<string>();

    [SerializeField] private TextMeshProUGUI reactText;

    public int countTarget = 0;

    private int temp = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckTarget();
    }

    private void CheckTarget()
    {
        Debug.Log(countTarget);

        if (countTarget == targets.Count)
        {
            Debug.Log("Win!");
        }
    }

    public void Test()
    {
        Debug.Log("hhhhehe");

    }

      
    public void GiveReaction()
    {
        reactText.gameObject.SetActive(true);
        reactText.text = reactions[Random.Range(0, reactions.Count)];
        if (reactText.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("ReactionTxt"))
        {
            reactText.gameObject.SetActive(false);
        }

    }



    
}
