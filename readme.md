# RssLemmyNotifier

This is a pet project that allows a user to subscribe to RSS feeds and submit a post to a lemmy community whenever a new item is added to that rss feed. 

## Set Up

Just clone the directory and open in your .NET IDE of choice. Copy the `appsettings.template.json` file into a new file named `appsettings.json`. 

An `appsettings.json` is required for the application to run. 

| Key               | Description                                                                                   |
| ----------------- | --------------------------------------------------------------------------------------------- |
| LemmyInstanceHost | The public host name of the lemmy instance you are connecting to (for example, `lemmy.world`) |
| UserName          | The username or email of the account you will be using to post from                           |
| Password          | The password for the account that you will be posting from                                    |
| LemmyApiVersion   | The version of the Lemmy API to use                                                           |
| UpdateMode        | `true` if you want the application to post to the given lemmy community. You can run this without `true` to build a cache to prevent bombing a community with every item in the collection                                                                                              |