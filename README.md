# Task Details
Your task is to create a native Android app. The app must be hidden into the background in the initial loading state. When the button "volume down" is pressed 3 times consecutively, it will toggle the visibility of the app (hidden/visible). Write down your assumptions and the instruction to run your solution into a file named "README.md". Lastly, create a repository on GitHub or Bitbucket, upload your solution with the "README.md" file, then send us the repository URL by email at hr@f8th.ai. Good luck!

#How to run
- Once open the project in Visual Studio, select a Android simulator.
- Build the project.
- Run the app.
- The app will start a background service, which will listen to the key Volumn down and quickly closes the app which will return to Home screen to set the app to run in the background.
- Press the volumn down three times, it will show the home page of the app.
- Press the volume down three times again, it will close the app and set the app to run in the background and listening for the volumn pressed event again.

