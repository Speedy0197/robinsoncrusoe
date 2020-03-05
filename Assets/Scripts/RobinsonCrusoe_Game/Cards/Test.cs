using Assets.Scripts.RobinsonCrusoe_Game.GameAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.RobinsonCrusoe_Game.Cards
{
    public class Test : MonoBehaviour
    {
        public GameObject CardObject;

        public GameObject CardPosition_0;
        private GameObject instatiatedCard;

        void Start()
        {
            ButtonHandler.Btn_ChangeStageClicked += Btn_ChangeStageClicked;
        }

        private void Btn_ChangeStageClicked(object sender, System.EventArgs e)
        {
            instatiatedCard = Instantiate(CardObject, CardPosition_0.transform);
            ButtonHandler.Btn_ChangeStageClicked -= Btn_ChangeStageClicked;
            ButtonHandler.Btn_ChangeStageClicked += Continue;
        }

        private void Continue(object sender, System.EventArgs e)
        {
            Destroy(instatiatedCard);
            Phases.NextPhase();
        }
    }
}
