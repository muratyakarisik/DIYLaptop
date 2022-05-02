using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PaintIn3D.Examples;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public P3dChangeCounterText changeCounterText;
    public int stage;
    public GameObject laptop;
    public GameObject laptopWhite;
    public GameObject sprayTool;
    public GameObject removeTool;
    public GameObject[] sprays;
    public GameObject sprayPanel;
    public int sprayNumber;
    public GameObject okButton;
    public GameObject sticker;
    public GameObject stickerButton;
    public GameObject stickerPanel;
    public int stickerNumber;
    public GameObject[] stickers;
    public GameObject stickerClone;
    public GameObject stickerButtonClone;
    public GameObject stickerCloseButton;
    public GameObject stickerCloseButtonClone;
    private int stickerCounter;
    public GameObject pencilPanel;
    public GameObject pencilTool;
    public GameObject[] pencils;
    public int pencilNumber;
    public List<GameObject> stickerss = new List<GameObject>();
    public List<GameObject> stickerPartners = new List<GameObject>();
    public GameObject sprayPencilPanel;
    public GameObject spPanel;
    public bool isSprayPencil;
    public GameObject endTyping;
    public GameObject mainCam;
    public GameObject[] sprayImages;
    public GameObject[] pencilImages;
    public GameObject[] stageAgainButtons;
    public GameObject endGoing;
    public GameObject outBaked;
    public GameObject[] endClosed;
    public GameObject hand;
    public GameObject laptopEndGoingPos;
    public GameObject endGoingButton;
    public GameObject fadeInFadeOut;
    public Image[] sprayPencilSprites;
    public Sprite[] sprite;
    public Image[] topImages;
    public GameObject topPanel;
    public bool isFirstTouch;
    public GameObject swerve;
    private float stickerPosY = -1.8f;
    public GameObject nextLevel;
    public GameObject light1;


    private void Awake()
    {
        changeCounterText.fillCounter = "0";
        changeCounterText.removeCounter = "100";
        StartCoroutine(LaptopActive());
    }

    void Update()
    {
        if (stage == 0)
        {
            if (int.Parse(changeCounterText.removeCounter) <= 70 && int.Parse(changeCounterText.removeCounter) > 0)
            {
                StartCoroutine(Stage0());
            }
        }
    }

    IEnumerator LaptopActive()
    {
        yield return new WaitForSeconds(0.5f);
        laptop.SetActive(true);
    }

    IEnumerator Stage0()
    {
        removeTool.SetActive(false);
        laptop.SetActive(false);
        laptopWhite.SetActive(true);
        laptopWhite.GetComponent<Laptop>().vfx.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        laptopWhite.GetComponent<Laptop>().vfx.SetActive(false);
        sprayPencilPanel.SetActive(true);
        spPanel.SetActive(true);
        sprayPanel.SetActive(true);
        okButton.SetActive(true);
        stageAgainButtons[0].SetActive(true);
        topImages[0].sprite = sprite[2];
        stage++;
    }

    IEnumerator Stage1()
    {
        okButton.SetActive(false);
        stageAgainButtons[0].SetActive(false);
        sprayPanel.SetActive(false);
        sprayTool.SetActive(false);
        pencilPanel.SetActive(false);
        pencilTool.SetActive(false);
        sprayPencilPanel.SetActive(false);
        laptopWhite.GetComponent<Laptop>().vfx.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        laptopWhite.GetComponent<Laptop>().vfx.SetActive(false);
        stickerPanel.SetActive(true);
        okButton.SetActive(true);
        stageAgainButtons[1].SetActive(true);
        topImages[1].sprite = sprite[3];
        stage++;
    }

    public void SprayPencilSwictch1()
    {
        sprayPencilSprites[0].sprite = sprite[1];
        sprayPencilSprites[1].sprite = sprite[0];

        for (int i = 0; i < pencils.Length; i++)
        {
            Color pencilColor = pencilImages[i].GetComponent<Image>().color;
            pencilImages[i].GetComponent<Image>().color = new Color(pencilColor.r, pencilColor.g, pencilColor.b, 0f);
        }

        if (isSprayPencil == true)
        {
            pencils[sprayNumber].SetActive(false);
            pencilTool.SetActive(false);
            pencilPanel.SetActive(false);
            sprayPanel.SetActive(true);
            sprayTool.transform.position = new Vector3(11f, 1.15f, -8f);
            isSprayPencil = false;
        }
    }

    public void SprayPencilSwictch2()
    {
        for (int i = 0; i < sprays.Length; i++)
        {
            Color sprayColor = sprayImages[i].GetComponent<Image>().color;
            sprayImages[i].GetComponent<Image>().color = new Color(sprayColor.r, sprayColor.g, sprayColor.b, 0f);
        }

        sprayPencilSprites[0].sprite = sprite[0];
        sprayPencilSprites[1].sprite = sprite[1];

        if (isSprayPencil == false)
        {
            sprays[sprayNumber].SetActive(false);
            sprayTool.SetActive(false);
            sprayPanel.SetActive(false);
            pencilPanel.SetActive(true);
            pencilTool.transform.position = new Vector3(12f, -0.75f, -8f);
            isSprayPencil = true;
        }
    }

    public void PickSpray()
    {
        sprayNumber = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        for (int i = 0; i < sprays.Length; i++)
        {
            sprays[i].SetActive(false);
        }

        sprayTool.SetActive(true);
        sprays[sprayNumber].SetActive(true);
        

        for (int i = 0; i < sprays.Length; i++)
        {
            Color sprayColor = sprayImages[i].GetComponent<Image>().color;
            sprayImages[i].GetComponent<Image>().color = new Color(sprayColor.r, sprayColor.g, sprayColor.b, 0f);
        }

        Color sprayColor2 = sprayImages[sprayNumber].GetComponent<Image>().color;
        sprayImages[sprayNumber].GetComponent<Image>().color = new Color(sprayColor2.r, sprayColor2.g, sprayColor2.b, 1f);
    }

    public void PickPencil()
    {
        pencilNumber = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        for (int i = 0; i < pencils.Length; i++)
        {
            pencils[i].SetActive(false);
        }

        pencilTool.SetActive(true);
        pencils[pencilNumber].SetActive(true);

        for (int i = 0; i < pencils.Length; i++)
        {
            Color pencilColor = pencilImages[i].GetComponent<Image>().color;
            pencilImages[i].GetComponent<Image>().color = new Color(pencilColor.r, pencilColor.g, pencilColor.b, 0f);
        }

        Color pencilColor2 = sprayImages[pencilNumber].GetComponent<Image>().color;
        pencilImages[pencilNumber].GetComponent<Image>().color = new Color(pencilColor2.r, pencilColor2.g, pencilColor2.b, 1f);
    }

    public void PickSticker()
    {
        if (stickerCounter < 3)
        {
            stickerNumber = int.Parse(EventSystem.current.currentSelectedGameObject.name);

            if (stickerClone == null)
            {
                GameObject stickerObj = Instantiate(stickers[stickerNumber], transform.position, Quaternion.identity);
                sticker = stickerObj;
                stickerObj.transform.localPosition = new Vector3(10f, stickerPosY + (stickerCounter * 0.025f), -8f);

                GameObject stickerButtonObj = Instantiate(stickerButton, transform.position, Quaternion.identity);
                stickerButtonObj.transform.parent = GameObject.FindGameObjectWithTag("Canvas").transform;

                GameObject stickerCloseButtonObj = Instantiate(stickerCloseButton, transform.position, Quaternion.identity);
                stickerCloseButtonObj.transform.parent = GameObject.FindGameObjectWithTag("Canvas").transform;

                stickerButtonObj.GetComponent<Sticker>().sticker = stickerObj;
                stickerButtonObj.GetComponent<Sticker>().pos = stickerObj.transform.GetChild(0).gameObject;
                stickerButtonObj.transform.localRotation = Quaternion.identity;

                stickerCloseButtonObj.GetComponent<StickerCloseButton>().pos = stickerObj.transform.GetChild(1).gameObject;
                stickerCloseButtonObj.transform.localRotation = Quaternion.identity;

                stickerClone = stickerObj;
                stickerButtonClone = stickerButtonObj;
                stickerCloseButtonClone = stickerCloseButtonObj;
            }
            else
            {
                Destroy(stickerButtonClone);
                Destroy(stickerCloseButtonClone);

                GameObject stickerObj = Instantiate(stickers[stickerNumber], transform.position, Quaternion.identity);
                sticker = stickerObj;
                stickerObj.transform.localPosition = new Vector3(10f, stickerPosY + (stickerCounter * 0.025f), -8f);

                GameObject stickerButtonObj = Instantiate(stickerButton, transform.position, Quaternion.identity);
                stickerButtonObj.transform.parent = GameObject.FindGameObjectWithTag("Canvas").transform;

                GameObject stickerCloseButtonObj = Instantiate(stickerCloseButton, transform.position, Quaternion.identity);
                stickerCloseButtonObj.transform.parent = GameObject.FindGameObjectWithTag("Canvas").transform;

                stickerButtonObj.GetComponent<Sticker>().sticker = stickerObj;
                stickerButtonObj.GetComponent<Sticker>().pos = stickerObj.transform.GetChild(0).gameObject;
                stickerButtonObj.transform.localRotation = Quaternion.identity;

                stickerCloseButtonObj.GetComponent<StickerCloseButton>().pos = stickerObj.transform.GetChild(1).gameObject;
                stickerCloseButtonObj.transform.localRotation = Quaternion.identity;

                stickerClone.GetComponent<StickerFollow>().isClamp = true;
                stickerClone.GetComponent<BoxCollider>().enabled = false;
                stickerClone = stickerObj;
                stickerButtonClone = stickerButtonObj;
                stickerCloseButtonClone = stickerCloseButtonObj;
            }

            stickerss.Add(stickerClone);
            stickerPartners.Add(stickerCloseButtonClone);
            stickerPartners.Add(stickerButtonClone);
            stickerCounter++;
        }
    }

    public void ClearStickers()
    {
        if (stage == 2)
        {
            foreach (var obj in stickerPartners)
            {
                Destroy(obj);
            }

            foreach (var objects in stickerss)
            {
                Destroy(objects);
            }

            stickerPartners.Clear();
            stickerss.Clear();

            stickerCounter = 0;
        }
    }

    public void OkButton()
    {
        if (stage == 1)
        {
            StartCoroutine(Stage1());
        }
        else if (stage == 2)
        {
            stickerPanel.SetActive(false);
            okButton.SetActive(false);
            stageAgainButtons[1].SetActive(false);

            for (int i = 0; i < stickerss.Count; i++)
            {
                stickerss[i].transform.parent = laptopWhite.transform.GetChild(0).transform;
            }

            stickerss.Clear();
            stickerPartners.Clear();

            Destroy(stickerButtonClone);
            Destroy(stickerCloseButtonClone);

            topPanel.SetActive(false);
            FindObjectOfType<Cam>().GetComponent<Animator>().SetTrigger("Active1");
        }
    }

    public void StickerCloseButton()
    {
        stickerss.RemoveAt(stickerss.Count - 1);

        for (int i = 1; i < 3; i++)
        {
            stickerPartners.RemoveAt(stickerPartners.Count - 1);
        }
        
        Destroy(stickerClone);
        Destroy(stickerButtonClone);
        Destroy(stickerCloseButtonClone);
        stickerCounter--;
    }

    public void EndTyping()
    {
        fadeInFadeOut.SetActive(true);
        mainCam.SetActive(false);
        endTyping.SetActive(true);
        laptopWhite.GetComponent<Animator>().SetTrigger("End");
        StartCoroutine(EndGoingGo());
    }

    private IEnumerator EndGoingGo()
    {
        yield return new WaitForSeconds(2f);
        fadeInFadeOut.SetActive(false);
        endGoingButton.SetActive(true);
    }

    public void EndGoing()
    {
        light1.SetActive(true);
        fadeInFadeOut.SetActive(true);
        endGoingButton.SetActive(false);

        for (int i = 0; i < endClosed.Length; i++)
        {
            endClosed[i].SetActive(false);
        }

        endGoing.SetActive(true);
        outBaked.SetActive(true);

        laptopWhite.GetComponent<Animator>().enabled = false;
        laptopWhite.transform.parent = hand.transform;
        laptopWhite.transform.GetChild(0).rotation = Quaternion.Euler(16.5f,180f,0f);
        laptopWhite.transform.localPosition = laptopEndGoingPos.transform.localPosition;
        laptopWhite.transform.localRotation = laptopEndGoingPos.transform.localRotation;
        laptopWhite.transform.localScale = laptopEndGoingPos.transform.localScale;

        StartCoroutine(NextLevelBTN());
    }

    private IEnumerator NextLevelBTN()
    {
        yield return new WaitForSeconds(2f);
        fadeInFadeOut.SetActive(false);
        nextLevel.SetActive(true);
    }
}
