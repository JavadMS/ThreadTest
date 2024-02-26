using System.Threading;

class Program
{
    static int thread1Var = 0;
    static int thread2Var = 0;
    static int thread3Var = 0;

    static bool runningThread1 = true;
    static bool runningThread2 = true;
    static bool runningThread3 = true;
    static void Main()
    {

        // Create and start Thread 1
        Thread thread1 = new Thread(Thread1);
        thread1.Start();

        // Create and start Thread 2
        Thread thread2 = new Thread(Thread2);
        thread2.Start();

        // Create and start Thread 3
        Thread thread3 = new Thread(Thread3);
        thread3.Start();


        // Wait for all threads to finish
        thread1.Join();
        thread2.Join();
        thread3.Join();

        //This following codes execute when all the threads specified by Join() are not running.
        Console.WriteLine("All Threads Exit.");

        //Actualy by joining the threads, you ensure that all three threads have finished executing their
        //respective methods(Thread1(), Thread2(), and Thread3()) before the program exits.
        //It allows for proper synchronization and ensures that the program doesn't terminate
        //prematurely, especially if you have dependencies or need to collect results from
        //the threads before continuing.For example:

        Console.WriteLine($"runningThread1: {runningThread1}");
        Console.WriteLine($"runningThread2: {runningThread2}");
        Console.WriteLine($"runningThread3: {runningThread3}");

        Console.WriteLine($"thread1Var: {thread1Var}");
        Console.WriteLine($"thread1Var: {thread2Var}");
        Console.WriteLine($"thread1Var: {thread3Var}");

    }


    #region threads
    static void Thread1()
    {
        // Thread 1 runs until runningThread1 is set to false
        while (runningThread1)
        {
            thread1Var++;
            Console.WriteLine($"*thread 1 (1 sec): {thread1Var}");

            // Check if thread1Var has reached 5
            if (thread1Var == 5)
            {
                runningThread1 = false;
            }

            // Sleep for 1 second
            Thread.Sleep(1000);
        }
    }

    static void Thread2()
    {
        // Thread 2 runs until runningThread2 is set to false
        while (runningThread2)
        {
            thread2Var++;
            Console.WriteLine($"*thread 2 (5 sec): {thread2Var}");

            // Check if thread2Var has reached 5
            if (thread2Var == 5)
            {
                runningThread2 = false;
            }

            // Sleep for 5 seconds
            Thread.Sleep(5000);
        }
    }

    static void Thread3()
    {
        // Thread 3 runs until runningThread3 is set to false
        while (runningThread3)
        {
            thread3Var++;
            Console.WriteLine($"*thread 3 (10 sec): {thread3Var}");

            // Check if thread3Var has reached 5
            if (thread3Var == 5)
            {
                runningThread3 = false;
            }

            // Sleep for 10 seconds
            Thread.Sleep(10000);
        }
    }
    #endregion
}