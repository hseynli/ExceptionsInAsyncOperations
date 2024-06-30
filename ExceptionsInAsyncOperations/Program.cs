using System.Text;
using System.Xml;

async Task TestCatchingExceptions()
{
    // we can await in here because it's marked as async
    Console.WriteLine("TestCatchingExceptions ThisIsNotATask...");
    await Task.Delay(TimeSpan.FromSeconds(1));
    Console.WriteLine("Finished delay inside TestCatchingExceptions...");

    Console.WriteLine("Calling async method...");

    try
    {
        //await ThisIsATask();

        // we *can't* await this because this method is async
        // but does not return a Task.
        //await ThisIsNotATask();
        ThisIsNotATask();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Caught exception from async method: {ex.Message}");
    }
}

async Task ThisIsATask()
{
    // we can await in here because it's marked as async
    Console.WriteLine("Entering ThisIsATask...");
    await Task.Delay(TimeSpan.FromSeconds(1));
    Console.WriteLine("Finished delay inside ThisIsATask...");

    throw new Exception("ThisIsATask has thrown an exception!");
}

async void ThisIsNotATask()
{
    // we can await in here because it's marked as async
    Console.WriteLine("Entering ThisIsNotATask...");
    await Task.Delay(TimeSpan.FromSeconds(1));
    Console.WriteLine("Finished delay inside ThisIsNotATask...");

    throw new Exception("ThisIsNotATask has thrown an exception!");
}

await TestCatchingExceptions();

Console.ReadKey();

Console.WriteLine("\nDone!");