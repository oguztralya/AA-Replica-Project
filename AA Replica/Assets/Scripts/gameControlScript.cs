using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameControlScript : MonoBehaviour
{
    private GameObject mCircleCon;
    private GameObject rCircleCon;
    public Animator anim;
    [SerializeField] private Text levelNameText;
    public int howManyBullets = 10;
    [SerializeField] private Text mCircleText, mCircleText1, mCircleText2;
    private bool check = true;
    void Start()
    {
        rCircleCon = GameObject.FindGameObjectWithTag("rCircleTag");
        mCircleCon = GameObject.FindGameObjectWithTag("mCircleTag");
        levelNameText.text = "" + SceneManager.GetActiveScene().name;
        startingBulletCounting();
        PlayerPrefs.SetInt("saveLevel", int.Parse(SceneManager.GetActiveScene().name));
        
    }

    // Update is called once per frame
    void Update()
    {
        goMenu();
    }

    public void GameOver()
    {
        StartCoroutine(gameOverAni());
    }

    IEnumerator gameOverAni()
    {
        rCircleCon.GetComponent<rCircleScript>().enabled = false;
        mCircleCon.GetComponent<mCircleScript>().enabled = false;
        check = false;
        yield return new WaitForSeconds(0.3f);
        anim.SetTrigger("gameOverTri");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("mainMenu");

    }

    IEnumerator newLevelAni()
    {
        rCircleCon.GetComponent<rCircleScript>().enabled = false;
        mCircleCon.GetComponent<mCircleScript>().enabled = false;
        yield return new WaitForSeconds(1);
        if (check)
        {
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
        }

    }

    private void startingBulletCounting()
    {
        if(howManyBullets<2)
        {
            mCircleText.text = "" + howManyBullets;
            
        }
        if(howManyBullets<3)
        {
            mCircleText.text = "" + howManyBullets;
            mCircleText1.text = "" + (howManyBullets - 1);
            
        }
        else
        {
            mCircleText.text = "" + howManyBullets;
            mCircleText1.text = "" + (howManyBullets - 1);
            mCircleText2.text = "" + (howManyBullets - 2);
        }
    }

    public void updateBulletCounting()
    {
        howManyBullets--;
        
        if(howManyBullets<2)
        {
            mCircleText.text = "" + howManyBullets;
            mCircleText1.text = "";
            mCircleText2.text = "";
        }
        else if(howManyBullets<3)
        {
            mCircleText.text = "" + howManyBullets;
            mCircleText1.text = "" + (howManyBullets - 1);
            mCircleText2.text = "";
        }
        else
         {
             mCircleText.text = "" + howManyBullets;
             mCircleText1.text = "" + (howManyBullets - 1);
             mCircleText2.text = "" + (howManyBullets - 2);
         }
         if(howManyBullets==0)
         {
            StartCoroutine(newLevelAni());
         }

    }
    void goMenu ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("mainMenu");
        }
    }
}
