# BookService
A simple .NET Framework application that can be used locally, pushed to CF, and bound to MySQL.


## Manual Use

1. Clone this project and import into Visual Studio.
2. Right click on BookService in the project explorer, and select Publish and select the "Cloud Foundry" profile from the dropdown list.
  * There is no magic involved in that publish profile.  It is just pusblishing the project to the local disk at c:\temp\BookService.
3. `cd c:\temp\BookService`
4. Target your CF api endpoint and login.
5. Create a MySQL service in the space you are pushing to called `BookContextService`.
6. `cf push --no-start` and then `cf enable-diego bookservice` if you are on Pivotal Cloud Foundry <1.6, or `cf push` if you are 1.6 or higher.
7. Browse to your app and enjoy!

## CI Pipeline in TFS
This project also includes a folder "tfs" which includes a Build definition and Release Pipeline that you can import to Visual Studio Online or TFS.  You can get a free Visual Studio Online account by going to https://www.visualstudio.com/vso.

You will also need to make sure to create a MySQL instance in the spaces you will be pushing to called "BookServiceContext".

### Import the Build Definition
1. After signing into your Visual Studio Online account, create a new Project.  You can name the project whatever you like.
2. Click on the "Build and Release" tab, and select "Builds".
3. Click the "+ Import" button, and import the BookServiceBuild.json file.
4. After the import finishes, you'll need to modify a few items to work with your repo.  You should be in the "Tasks" section of the build definition after it is imported, and you should see the "Process" section selected.  In that config section, modify the "Agent queue" setting to select "Hosted".
5. Next, click on the "Get sources" config section, and point the build process at your sources.  You could either push your project into the git server provided by Visual Studio Online for your project, or you could point directly at Github for your own forked project.
6. Next, click on the "Push to Cloud Foundry" task.  You'll need to set up your connection to Cloud Foundry so the pipeline can push your app.  In the task configuration, you'll see a "Cloud Foundry Endpoint" setting.  Click the "Manage" link above it.  You'll have new tab pop up for defining "endpoints".  Click on "New Service Endpoint" and select "Generic Endpoint".  The resulting dialog will allow you to define the coordinates and credentials for whatever CF instance you want to push to.  Enter a "Connection Name" for what you want this config to show up as in lists, then for "Server URL" enter the API endpoint URL for CF, and then enter the username and password you want to use to push to CF in the appropriate boxes.  After you create your service endpoint, close the tab for those, and go back to the tab for the build definition.
7. Click on the dropdown list for "Cloud Foundry Endpoint" and select the name for the endpoint you just created.
8. Next, click on the "Delete Old App Versions" task, an in the "Inline Script" section, there is a reference to "cf.grogscave.net" that you will need to change to the app domain for the CF you are pushing to.
9. Select, "Save and Queue" to kick off a build immediately (just leave the settings at defaults), or click "Save" to just save the definition.
10. If you queue a build for the build definition (or if you select Save and Queue in the last step) you will see a build progress, and end up with an instance of the BookService deployed to your CF environment.

### Import the Release Pipeline
Instructions coming soon.




