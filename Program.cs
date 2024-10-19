using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;
using System.Diagnostics;
using OpenQA.Selenium.Interactions;
using WebClick;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

class Program
{
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    const int SW_SHOW = 5;

    static void Main(string[] args)
    {
        
        // Устанавливаем и инициализируем ChromeDriver с помощью WebDriverManager
        new DriverManager().SetUpDriver(new ChromeConfig());

        // Путь к Browser driver
        string webDriverPath = @"C:\Program Files\chromedriver-win64\chromedriver.exe";

        // Путь к Opera GX
        string browserPath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

        // Настраиваем ChromeOptions для Opera GX
        ChromeOptions options = new ChromeOptions();
        options.BinaryLocation = browserPath;

        // Инициализация ChromeDriver с заданными опциями
        IWebDriver driver = new ChromeDriver(webDriverPath, options);

        try
        {
            // Открываем веб-страницу
            driver.Navigate().GoToUrl("https://vision.api-factory.ru/meetings");
            // Устанавливаем WebDriverWait для ожидания элементов
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);


            try
            {
                IWebElement notificationButton = driver.FindElement(By.XPath("//*[@id=\"root\"]/main/div/section[2]/nav/div/div[2]/img"));
                Console.WriteLine("Пользователь авторизован.");
            }
            catch (NoSuchElementException)
            {

                // Чтение логина и пароля из YAML-файла
                var credentials = ReadCredentials("credentials.yaml");
                string login = credentials.Login;
                string password = credentials.Password;

                // Находим и нажимаем на кнопку "ВОЙТИ"
                IWebElement loginButton = wait.Until(SeleniumExtras.WaitHelpers
                    .ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"root\"]/main/div/section[2]/nav/div/div[2]/div")));
                loginButton.Click();
                Thread.Sleep(500);
                // Вводим логин
                IWebElement loginField = wait.Until(SeleniumExtras.WaitHelpers
                    .ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"root\"]/main/form/label[1]/div/input")));
                loginField.SendKeys(login);
                Thread.Sleep(500);
                // Вводим название конференции
                IWebElement passwordField = wait.Until(SeleniumExtras.WaitHelpers
                    .ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"root\"]/main/form/label[2]/div/input")));
                passwordField.SendKeys(password);
                // log in
                Thread.Sleep(500);
                wait.Until(SeleniumExtras.WaitHelpers
                    .ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"root\"]/main/form/button"))).Click();
                wait.Until(SeleniumExtras.WaitHelpers
                    .ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"root\"]/main/div/section[1]/div/a[2]"))).Click();
            }

            // Получаем дескриптор окна браузера
            IntPtr handle = Process.GetProcessesByName("chrome")[0].MainWindowHandle;

            // Делаем окно Chrome активным и поверх всех
            ShowWindow(handle, SW_SHOW);
            SetForegroundWindow(handle);
            // Устанавливаем размеры окна на весь экран
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080); // Замените на свои разрешения
            Thread.Sleep(500);

            for (int i = 0; i < int.MaxValue; ++i)
            {

            
            // Находим и нажимаем на кнопку "+"
            IWebElement plusButton = wait.Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"root\"]/main/div/section[2]/div/section/div[1]/div[1]/img[2]")));
            plusButton.Click();

            // Подождем немного для загрузки формы создания конференции
            Thread.Sleep(500);

            // Вводим название конференции
            IWebElement conferenceNameField = wait.Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"root\"]/main/div/section[2]/div/section/div[3]/div/div/form/div[2]/label[1]/input")));
            conferenceNameField.SendKeys($"Nidzhat 頑張れ！{i}");
            Thread.Sleep(500);
            // Вводим описание конференции
            IWebElement conferenceDescriptionField = wait.Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"root\"]/main/div/section[2]/div/section/div[3]/div/div/form/div[2]/label[2]/textarea")));
            conferenceDescriptionField.SendKeys("БОЛЬШОЕПРИБОЛЬШОЕНАЗВАНИЕКАНФЕРЕНЦЫИБОЛЬШОЕПРИБОЛЬШОЕНАЗВАНИЕКАНФЕРЕНЦЫИ\nБОЛЬШОЕПРИБОЛЬШОЕНАЗВАНИЕКАНФЕРЕНЦЫИ\nБОЛЬШОЕПРИБОЛЬШОЕНАЗВАНИЕКАНФЕРЕНЦЫИЫИБОЛЬШОЕПРИБОЛЬИЕКАНФЕРЕНЦЫИРИБОЛЬШОЕНАЗВАНИЕКАНФЕРЕНЦРИБОЛЬШОЕНАЗВАНИЕКАНФЕРЕНЦ");
            Thread.Sleep(500);
            // Нажимаем на "OK"
            IWebElement okButton = wait.Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"root\"]/main/div/section[2]/div/section/div[3]/div/div/form/div[3]/button")));
            okButton.Click();
            Thread.Sleep(500);
            // Подтверждаем еще раз
            IWebElement okButton2 = wait.Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"root\"]/main/div/section[2]/div/section/div[3]/div/div/form/div[3]/button[2]")));
            okButton2.Click();

            // Подтверждаем еще раз
            Thread.Sleep(500);
            IWebElement participiantsField = wait.Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"root\"]/main/div/section[2]/div/section/div[3]/div/div/form/div[2]/div[1]/label/input")));
            participiantsField.SendKeys("Ниджат");
            Thread.Sleep(300);
            participiantsField.SendKeys(Keys.Enter);
            Thread.Sleep(300);
            participiantsField.SendKeys("Захар");
            Thread.Sleep(300);
            participiantsField.SendKeys(Keys.Enter);

            IWebElement createButton = wait.Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"root\"]/main/div/section[2]/div/section/div[3]/div/div/form/div[3]/button[2]")));
            createButton.Click();
            

            // Ждем, чтобы убедиться, что конференция создана
            Thread.Sleep(200000);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception occurred: {e.Message}");
        }
        finally
        {
            // Закрываем браузер
            driver.Quit();
        }
    }


    static Credentials ReadCredentials(string filePath)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(PascalCaseNamingConvention.Instance)
            .Build();

        using (var reader = new StreamReader(filePath))
        {
            return deserializer.Deserialize<Credentials>(reader);
        }
    }
}
