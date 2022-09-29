using static Helper1;
class Program
{
  public static async Task Main(string[] args)
    {
        try
        {
            var tasks = new List<Task<string>>();
            for (var i = 1; i < 4; i++)
            {
                var iteration = i;
                Task<string> task = Task.Run(async () =>
                {
                    await Task.Delay(100);
                    Console.WriteLine($"Iteration {iteration}");
                    return "iteration";
                });
                tasks.Add(task);

            }

           var cancel = new CancellationTokenSource(3000);
            var ct = cancel.Token;
            foreach (var task in tasks)
                await task.WithCancellation(ct);

            Console.WriteLine("Task completed");
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine(ex.Message);
        }
        /* Task<string> t1 = new Task<string>(
        () => {
            return "1000";
        });
         Task<string> t2 = new Task<string>(
      () => {
          return "2000";
      });
         Task<string> t3 = new Task<string>(
     () => {
         return "3000";
     });

         var tasks = new List<Task<string>>();
         for (var i = 1; i < 4; i++)
         {
             var iteration = i;
             Task<string> task = Task.Run<string>(async () =>
             {
                 await Task.Delay(100);
                 Console.WriteLine($"Iteration {iteration}");
                 return "iteration";
             });  
             tasks.Add(task);

         }
         //Task<string>[] tasks = new Task<string>[2];
         try
         {
             CancellationToken cancellationToken = new CancellationToken();
             foreach (var task in tasks)
             await Helper1.WithCancellation(task, cancellationToken);

         }
         catch (Exception ex)
         {
             Console.WriteLine(ex.ToString());
         }
         //Thread.Sleep(5000);*/
        /*   var cancel = new CancellationTokenSource(3000);
            var ct = cancel.Token;

            try
            {
                await Task.Delay(1000).WithCancellation(ct);
                Console.WriteLine("Task completed");
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }*/
    }
}
