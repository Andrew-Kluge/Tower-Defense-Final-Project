using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


namespace Code
{
    public class Build_Menu : MonoBehaviour
    {
        public Button yes_btn;
        public Button no_btn;
        public Home_Base hb;
        public GameObject cell_called_from;


        // Use this for initialization
        void Start()
        {
            hb = GameObject.FindObjectOfType<Home_Base>();
            yes_btn = GameObject.FindGameObjectWithTag("yes_btn").GetComponent<Button>();
            no_btn = GameObject.FindGameObjectWithTag("no_btn").GetComponent<Button>();
            if (hb._money < 5)
            {
                yes_btn.interactable = false;
            }
            else
            {
                yes_btn.onClick.AddListener(YesClicked);
            }
            
            no_btn.onClick.AddListener(NoClicked);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void YesClicked()
        {
            Debug.Log("Yes was clicked");
            hb._money -= 5;
            hb.money_text.text = "$" + hb._money;

            cell_called_from.GetComponent<Cell>().BuildTowerOnTop();
            Destroy(gameObject);

        }

        void NoClicked()
        {
            Destroy(gameObject);
        }
    }


}
