____

<div align=center>
<img src="https://img.shields.io/github/repo-size/HanamiLux/WebClick" alt="repoSize"/>
<img src="https://img.shields.io/github/downloads/HanamiLux/WebClick/total" alt="downloads"/>
<img src="https://img.shields.io/github/last-commit/HanamiLux/WebClick" alt="lastCommit"/>
</div>


<h2 align=center>Automated Web Interaction Tool</h2>


## **Overview**
This tool automates the process of interacting with a website using Selenium in C#. It is designed to streamline repetitive tasks by simulating user actions on the web, such as logging in, filling forms, and navigating through pages.

Features
Automated Login: Uses credentials stored in a secure YAML file to log in to the target website. path(\bin\Debug\net8.0\credentials.yaml)

Customizable Actions: Easily extendable to include various web interactions tailored to your needs.

Selenium Integration: Leverages the power of Selenium WebDriver for robust and reliable web automation.


## **Installation**

- **.Zip**
____

Before you begin, ensure you have met the following requirements:

.NET SDK installed on your system.

Selenium WebDriver for your browser (e.g., ChromeDriver for Google Chrome). Make sure it is in your system's PATH.

YamlDotNet, WebDriverManager, Selenium.WebDriver, DotNetSeleniumExtras.WaitHelpers (4) libraries installed. You can install it using NuGet.
```C#
    <PackageReference Include="DotNetSeleniumExtras.WaitHelpers" Version="3.11.0" />
    <PackageReference Include="Selenium.WebDriver" Version="4.25.0" />
    <PackageReference Include="WebDriverManager" Version="2.17.4" />
    <PackageReference Include="YamlDotNet" Version="16.1.3" />
```

## **Usage**

- Go to path(\bin\Debug\net8.0\credentials.yaml) and set your credentials for authorization if necessary, otherwise - change the code ^_^
- Start programm

## **Show your support**
Leave a ⭐ if this project helped you