using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ShigeDev.WebGLJsDialogTool;

namespace ShigeDev.WebGLJsDialogTool {

    public class WebGLJsDialogDemo : MonoBehaviour
    {
        [SerializeField] private Text _text;
        
        public void ShowAlert(string alertContent)
        {
            WebGLJsDialogTool.DisplayJsAlert(alertContent);
        }

        public void ShowPrompt()
        {
            string? userInput = WebGLJsDialogTool.DisplayJsPrompt("Write something");
            
            if(userInput == null)
            {
                _text.text = "Pressed cancel";
                return;
            }
                
            _text.text = userInput;
        }

        public void ShowConfirm()
        {
            bool result = WebGLJsDialogTool.DisplayJsConfirm("Select OK or Cancel");

            if(result == true )
                _text.text = "Selected OK";

            if(result == false )
                _text.text = "Selected Cancel";
        }

        public void ShowDialog(string dialogId)
        {
            WebGLJsDialogTool.DisplayJsDialog(dialogId);
        }

    }
}