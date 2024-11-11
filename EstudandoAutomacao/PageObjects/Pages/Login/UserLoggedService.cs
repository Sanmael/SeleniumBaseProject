using System.Collections.Concurrent;
using EstudandoAutomacao.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public static class UserLoggedService
{
    private static readonly ConcurrentQueue<IWebDriver> DriversPool = new ConcurrentQueue<IWebDriver>();
    //chave
    private static readonly int MaxDrivers = 2;
    private static int initializedDrivers = 0;
    private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(MaxDrivers);
    private static ILoginFactory _loginFactory;

    public static async Task InitializeDriversPool()
    {
        var tasks = new List<Task>();

        if (initializedDrivers >= MaxDrivers) return;

        CreateTasks(tasks);

        await Task.WhenAll(tasks);
    }

    public static void CreateTasks(List<Task> tasks)
    {
        //pegar de chave
        LoginType loginType = 0;

        for (int i = 0; i < MaxDrivers; i++)
        {
            tasks.Add(Task.Run(() =>
            {
                try
                {
                    var driver = new ChromeDriver();

                    _loginFactory = new LoginFactory().ReturnInstance(driver, loginType);

                    _loginFactory.LoadUsers();

                    DriversPool.Enqueue(driver);

                    Interlocked.Increment(ref initializedDrivers);
                }
                catch (Exception ex)
                {
                    //salvar log posteriormente
                    Console.WriteLine($"Erro ao inicializar driver: {ex.Message}");
                }
            }));
        }

    }

    public static async Task<DriverWrapper> GetAvailableDriver()
    {
        //chave
        if (!await semaphoreSlim.WaitAsync(5000))
        {
            throw new TimeoutException("Tempo limite para obter um driver expirou.");
        }

        IWebDriver driver;

        while (!DriversPool.TryDequeue(out driver))
        {
            semaphoreSlim.Release();

            throw new TimeoutException("Nenhum driver disponível dentro do tempo limite.");
        }

        return new DriverWrapper(driver, ReturnDriverToPool);
    }

    private static void ReturnDriverToPool(IWebDriver driver)
    {
        //chave
        _loginFactory.ReturnToHomePage(driver);
        DriversPool.Enqueue(driver);
        semaphoreSlim.Release();
    }

    public static void ClearBrowser()
    {
        while (DriversPool.TryDequeue(out var driver))
        {
            driver.Quit();
        }
    }

    public class DriverWrapper : IDisposable
    {
        public readonly IWebDriver _driver;
        private readonly Action<IWebDriver> _returnToPoolAction;
        private bool _disposed = false;

        public DriverWrapper(IWebDriver driver, Action<IWebDriver> returnToPoolAction)
        {
            _driver = driver;
            _returnToPoolAction = returnToPoolAction;
        }

        public void Dispose()
        {
            if (_disposed) return;

            _returnToPoolAction(_driver);
            _disposed = true;
        }
    }
}