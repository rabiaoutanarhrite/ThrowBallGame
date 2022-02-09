using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] 
    private List<Target> targets = new List<Target>();

    [SerializeField] 
    private List<string> reactions = new List<string>();

    [SerializeField] 
    private TextMeshProUGUI reactText;

    public TextMeshProUGUI restBallsTxt;

    [SerializeField]
    private TextMeshProUGUI winOrLoseTxt;

    [SerializeField] private int numTargets = 0;
 
    public int countTarget = 0;

    public bool isWin = false;

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

    private void Start()
    {
        //reactText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTarget();
    }

    private void CheckTarget()
    {

        if (countTarget == targets.Count)
        {
            StartCoroutine(Winning());
        }
    }
  
    public void GiveReaction()
    {
        reactText.gameObject.SetActive(true);
        reactText.GetComponent<Animator>().enabled = true;
        reactText.text = reactions[Random.Range(0, reactions.Count)];

        StartCoroutine(HideText());
    }

    public static void Test()
    {
        instance.GiveReaction();
        
    }

    public void Losing()
    {
        winOrLoseTxt.gameObject.SetActive(true);
        winOrLoseTxt.text = "Game Over!";
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(3f);

        reactText.gameObject.SetActive(false);

    }

    IEnumerator Winning()
    {
        yield return new WaitForSeconds(4f);

        winOrLoseTxt.gameObject.SetActive(true);
        isWin = true;
        winOrLoseTxt.text = "Win !";
    }


}
