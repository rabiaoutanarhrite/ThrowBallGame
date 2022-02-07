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

    [SerializeField]
    private TextMeshProUGUI winOrLoseTxt;

    [SerializeField] private int numTargets = 0;
 
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
        Debug.Log(countTarget);

        if (countTarget == targets.Count)
        {
            winOrLoseTxt.gameObject.SetActive(true);
            winOrLoseTxt.text = "Win !";
        }
    }
  
    public void GiveReaction()
    {
        Debug.Log("What is this");
        reactText.gameObject.SetActive(true);
        reactText.GetComponent<Animator>().enabled = true;
        reactText.text = reactions[Random.Range(0, reactions.Count)];

        StartCoroutine(HideText());
    }

    public static void Test()
    {
        instance.GiveReaction();
        
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(3f);

        reactText.gameObject.SetActive(false);

    }




}
