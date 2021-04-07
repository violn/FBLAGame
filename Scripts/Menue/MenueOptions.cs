using UnityEngine;
using UnityEngine.UI;

namespace Menue
{
    public class MenueOptions : MonoBehaviour
    {
        public Text inputMessage;
        public Text inputMessageFG;
        public GameObject tutorial;
        public GameObject optionsMenue;
        public GameObject main;

        private void ShiftPlanesH()
        {
            if (!MenueAnimations.doHorizontal && !MenueAnimations.doDiagonal)
            {
                MenueAnimations.doHorizontal = true;
            }
        }

        private void ShiftPlanesD()
        {
            if (!MenueAnimations.doDiagonal && !MenueAnimations.doHorizontal)
            {
                MenueAnimations.doDiagonal = true;
            }
        }

        private void MoveTutorial()
        {
            if (NameEntry.playerName == null)
            {
                MenueAnimations.doTutorial = true;
            }
            else MenueAnimations.doQuickPlay = true;
        }

        public void PlayGame()
        {
            if (!MenueAnimations.menueAnimating)
            {
                if (NameEntry.playerName != null)
                {
                    MenueAnimations.doPlay = true;
                }
                else
                {
                    NameEntryWarning.TextColor = Color.red;
                    inputMessage.text = "Please enter your name before playing.";
                    inputMessageFG.text = "Please enter your name before playing.";
                }
            }
        }

        public void ShowOptions()
        {
            if (!MenueAnimations.menueAnimating)
            {
                optionsMenue.SetActive(true);
                main.SetActive(false);
                ShiftPlanesH();
            }
        }

        public void GoBack()
        {
            if (!MenueAnimations.menueAnimating)
            {
                optionsMenue.SetActive(false);
                main.SetActive(true);
                ShiftPlanesD();
            }
        }

        public void ShowTutorial()
        {
            if (!MenueAnimations.menueAnimating)
            {
                ShiftPlanesH();
                MoveTutorial();
            }
        }

        public void BackToMenue()
        {
            if (!MenueAnimations.menueAnimating)
            {
                ShiftPlanesD();
                MoveTutorial();
            }
        }

        public void Quit()
        {
            if (!MenueAnimations.menueAnimating)
            {
                Application.Quit();
            }
        }
    }
}