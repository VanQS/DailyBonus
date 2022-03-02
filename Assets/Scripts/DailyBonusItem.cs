using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DailyBonusItem : MonoBehaviour
{
    public Text txtDay = null;
    public Text txtRewar = null;
    public Text txtRewar1 = null;
    public Text txtRewar2 = null;
    public Image imgIcon = null;
    public GameObject CoinXGem = null;
    public Image imgTick = null;
    public Button btnClams = null;
    public Image imgBox = null;



    private bool clams;
    private string coin = "coin";
    private string gem = "img-gem";
    private Color colorday;
   




    private DailyBonusRewar controller = null;
    private Days days = null;
    

    private void Awake()
    {
        
        colorday = txtDay.GetComponent<Outline>().effectColor;
        clams = true;
    }




    public void SetData(DailyBonusRewar controller , Days days ,bool today, bool dayactive ,bool destroytick)
    {
        
        this.controller = controller;
        this.days = days;
        txtDay.text ="Day "+ days.day.ToString();

        if (days.coin > 0 && days.gem > 0)
        {
            CoinXGem.SetActive(true);
            imgIcon.gameObject.SetActive(false);
            txtRewar1.text = days.coin.ToString();
            txtRewar2.text = days.gem.ToString();
        }
        else
        {
            if (days.coin > 0)
            {

                CoinXGem.SetActive(false);
                imgIcon.gameObject.SetActive(true);
                imgIcon.sprite = controller.SpriteAtlasCheckIcon.GetSprite(coin);
                txtRewar.text = days.coin.ToString();
            }
            if (days.gem > 0)
            {

                CoinXGem.SetActive(false);
                imgIcon.gameObject.SetActive(true);
                imgIcon.sprite = controller.SpriteAtlasCheckIcon.GetSprite(gem);
                txtRewar.text = days.gem.ToString();
            }
        }

        if(today)
        {
            if(DailyBonusMange.CheckTime())
            OnClaim();
        }
        if(dayactive)
        {
            TickActive();
        }
        if(destroytick)
        {
            DestroyTick();
        }    

    }

    public void TickActive()
    {
        imgTick.gameObject.SetActive(true);
    }
    public void DestroyTick()
    {
        imgTick.gameObject.SetActive(false);
    }    

    public void OnClaim()
    {

        imgBox.gameObject.transform.localPosition = new Vector3(imgBox.gameObject.transform.localPosition.x, imgBox.gameObject.transform.localPosition.y +11.2f, 0);
        imgTick.gameObject.SetActive(false);
        txtDay.GetComponent<Outline>().effectColor = Color.green;
        this.transform.localScale = new Vector3(1.2f, 1.2f, 0);
        imgBox.sprite = controller.SpriteAtlasBox.GetSprite("4");
        btnClams.onClick.AddListener(OnReward);
    }
    public void OnReward()
    {
        if (clams)
        {
            GameEvent.AddRewar(days.coin, days.gem);
            DailyBonusMange.OnClaim();
            clams = false;
            this.transform.localScale = new Vector3(1, 1, 1);
            imgTick.gameObject.SetActive(true);
            controller.currday = DailyBonusMange.GetIndex();
            imgBox.sprite = controller.SpriteAtlasBox.GetSprite("5");

            
            controller.StartCoroutine("CloseDailyBonus");
            txtDay.GetComponent<Outline>().effectColor = colorday;
            imgBox.gameObject.transform.localPosition = new Vector3(imgBox.gameObject.transform.localPosition.x, imgBox.gameObject.transform.localPosition.y - 11.2f, 0);
        }
        
    }

    
}
