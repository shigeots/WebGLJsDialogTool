using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Text;

namespace ShigeDev.WebGLJsDialogTool {

    public static class WebGLJsDialogTool
    {
        [DllImport("__Internal")] private static extern void DisplayAlert(string alertMessage);
        [DllImport("__Internal")] private static extern string? DisplayPrompt(string promptMessage);
        [DllImport("__Internal")] private static extern bool DisplayConfirm(string confirmMessage);
        [DllImport("__Internal")] private static extern void DisplayDialog(string dialogId);

        /// <summary>Method that display the javascript alert dialog box.</summary>
        /// <param name="alertMessage">The text to be displayed in the alert dialog.</param>
        public static void DisplayJsAlert(string alertMessage)
        {
            #if UNITY_EDITOR
                Debug.LogWarning("Display alert is only possible in WebGL build.");
            #endif

            #if UNITY_WEBGL && !UNITY_EDITOR
                DisplayAlert(alertMessage);
            #endif
            
        }
        
        /// <summary>Method that display the javascript prompt dialog box.</summary>
        /// <param name="promptMessage">The text to be displayed in the prompt dialog box.</param>
        /// <returns>The text inputted by the user from the prompt dialog box.</returns>
        public static string? DisplayJsPrompt(string promptMessage)
        {
            #if UNITY_EDITOR
                Debug.LogWarning("Display prompt is only possible in WebGL build.");
                return null;
            #endif

            #if UNITY_WEBGL && !UNITY_EDITOR

                string? userInput = DisplayPrompt(promptMessage);
            
                if (!string.IsNullOrEmpty(userInput))
                {
                    return userInput;
                }
                else
                {
                    return null;
                }
            #endif     

        }

        /// <summary>Method that display the javascript confirm dialog box.</summary>
        /// <param name="confirmMessage">The text to be displayed in the confirm dialog box.</param>
        /// <returns>The selected bool value by the user from the confirm dialog box.</returns>
        public static bool DisplayJsConfirm(string confirmMessage)
        {
            #if UNITY_EDITOR
                Debug.LogWarning("Display confirm is only possible in WebGL build.");
                return false;
            #endif

            #if UNITY_WEBGL && !UNITY_EDITOR
                return DisplayConfirm(confirmMessage);
            #endif
        }

        /// <summary>Method that display the javascript dialog box.</summary>
        /// <param name="dialogId">The id of the dialog you want to show.</param>
        public static void DisplayJsDialog(string dialogId)
        {
            #if UNITY_EDITOR
                Debug.LogWarning("Display dialog is only possible in WebGL build.");
            #endif

            #if UNITY_WEBGL && !UNITY_EDITOR
                DisplayDialog(dialogId);
            #endif
        }
    }
}