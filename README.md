# WPF Auto-Updater

WPF Auto-Updater is a straightforward and efficient solution designed to automatically update your WPF applications. With this tool, ensure that your users always have the latest version of your application without any manual intervention.

## Features

- **Automatic Version Check**: Compares the current application version with the server version to determine if an update is available.
- **Seamless Updates**: If a new version is detected, the updater prompts the user to download and install the update.
- **Progress Tracking**: A progress bar displays the download progress for a transparent user experience.
- **Customizable Server Files**: Define your server location and application details for a tailored update process.

## How It Works

1. **Version Check**: On application launch, the updater checks the server for the latest version number.
2. **Download Prompt**: If a newer version is detected, the user is prompted to download the update.
3. **Automatic Download**: The updater handles the download process, showing progress to the user.
4. **Launch Updated Application**: Once the download is complete, the updated application is launched automatically.

## Setup

1. Define your server location and application details in the [MainWindow.xaml.cs](https://github.com/HakuSystems/wpf-autoupdater/blob/master/wpf%20autoupdater/MainWindow.xaml.cs) file.
2. Ensure the server files, especially the `version.txt`, are set up correctly as shown in the [---ServerFiles](https://github.com/HakuSystems/wpf-autoupdater/tree/master/---ServerFiles) directory.

## Contribution

Contributions are welcome! Feel free to submit pull requests or raise issues to enhance the functionality of the updater.

## License

This project is open-source.

---

