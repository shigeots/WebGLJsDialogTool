mergeInto(LibraryManager.library, {
    
  DisplayAlert: function(alertMessage) {
    window.alert(UTF8ToString(alertMessage));
  },

  DisplayPrompt: function(promptMessage) {
    var userInput = prompt(UTF8ToString(promptMessage));
    
    if(userInput !== null) {
      var bufferSize = lengthBytesUTF8(userInput) + 1;
      var buffer = _malloc(bufferSize);
      
      stringToUTF8(userInput, buffer, bufferSize);
      
      return buffer;
    } else {
      return null;
    }
  },

  DisplayConfirm: function(confirmMessage) {
    let resultValue = confirm(UTF8ToString(confirmMessage));
    return resultValue;
  },

  DisplayDialog: function(dialogId) {
    var dialog = document.getElementById(UTF8ToString(dialogId));
    
    if(dialog) {
      dialog.showModal();
    } else {
      console.log("dialog with ID " + UTF8ToString(dialogId) +" not found.");
    }
  },

});