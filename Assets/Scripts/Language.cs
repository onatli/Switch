using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.IO;
using System.IO;

[RequireComponent(typeof(Dropdown))]

public class Language : MonoBehaviour
{
    
    public Dropdown drop;
    string LangPath;
    string LangText;
    string PlayButtonText,LevelsButtonText,OptionsButtonText,QuitButtonText,BackButtonText,MusicText,LanguageText,TutorialText,ResetText;
    string[] LangSub;
    public static string LangTUR = "OYNA\nBÖLÜMLER\nAYARLAR\nÇIKIŞ\nGERİ\nMüzik\nDil\nÖğretici\nSıfırla\nEmin misiniz?\nİptal\nTamamlandı\nSonraki Bölüm\nTekrar Oyna\nBaşarısız\n5 Hak Kazan\nAna Menü\nKısım\nAy\nMars\nMenü\nYakında Gelecek\nBİZE DESTEK OLABİLİRSİNİZ\nŞekli değiştirmek için küpü çevirin.\nTüm küplerin şeklini sağ üstteki göstergeye uydurun.\nHareket haklarınız bitmeden tüm küpleri düzeltin.\nMavi küp solundaki bütün küpleri döndürür.\nYeşil küp sağındaki tüm küpleri döndürür.\nSiyah küp tüm üstündeki küpleri döndürür.\nSarı küp altındaki tüm küpleri döndürür.\nKırmızı küp aynı satır ve sütundaki tüm küpleri döndürür.";
    public static string LangENG = "PLAY\nLEVELS\nOPTIONS\nQUIT\nBACK\nMusic\nLanguage\nTutorial\nReset Game\nAre you sure?\nCancel\nLevel Clear\nNext Level\nTry Again\nLevel Fail\nGet 5 Move\nMain Menu\nChapter\nMoon\nMars\nMenu\nComing Soon\nYOU CAN SUPPORT US\nSwipe the cube to change the shape.\nMatch the shape of all cubes to the indicator in the upper right.\nMatch all cubes before you run out of moves.\nThe blue cube rotates all the cubes to its left.\nThe green cube rotates all the cubes to its right.\nThe black cube rotates all the cubes above it.\nThe yellow cube rotates all the cubes under it.\nThe red cube rotates all the cubes in the same row and column.";
    
    
    private void Awake()
    {
        drop = GetComponent<Dropdown>();
        drop.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>(LanguageChange));
        
    }
    
    void ReadLangFile()
    {
        LangPath = Application.persistentDataPath +"/Lang/"+ MainMenu.language + ".txt";
        StreamReader reader = new StreamReader(LangPath);
        LangText = reader.ReadToEnd();
        LangSub = LangText.Split('\n');
        PlayButtonText = LangSub[0];
        LevelsButtonText = LangSub[1];
        OptionsButtonText = LangSub[2];
        QuitButtonText = LangSub[3];
        BackButtonText = LangSub[4];
        MusicText = LangSub[5];
        LanguageText = LangSub[6];
        TutorialText = LangSub[7];
        ResetText = LangSub[8];

        reader.Close();
    }
    void LangExecute()
    {
        ReadLangFile();
        GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = PlayButtonText;
        GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = LevelsButtonText;
        GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = OptionsButtonText;
        GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = QuitButtonText;
        GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = OptionsButtonText;
        GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = MusicText;
        GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(2).GetComponent<Text>().text = LanguageText;
        GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(4).transform.GetChild(1).GetComponent<Text>().text = TutorialText;
        GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(5).transform.GetChild(0).GetComponent<Text>().text = ResetText;
        GameObject.Find("Canvas").transform.GetChild(1).transform.GetChild(6).transform.GetChild(0).GetComponent<Text>().text = BackButtonText;

    }

    public void LanguageChange(int val)
    {
        if (val==0)
        {
            MainMenu.language = "ENG";
            MainMenu.CreateLog();
            LangExecute();
        }
        else if (val == 1)
        {
            MainMenu.language = "TUR";
            MainMenu.CreateLog();
            LangExecute();
        }


    }
    void Start()
    {
        if (MainMenu.language == "TUR")
        {
            drop.value = 1;
            LanguageChange(drop.value);
        }
        else if (MainMenu.language == "ENG")
        {
            drop.value = 0;
            LanguageChange(drop.value);
        }
        
    }
}
    
