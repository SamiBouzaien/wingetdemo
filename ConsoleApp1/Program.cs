using System;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
     private static string RunScript (string script)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(script);
            pipeline.Commands.Add("Out-String");
            Collection<PSObject> res = pipeline.Invoke();
            runspace.Close();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject pSObject in res)
            {
                stringBuilder.AppendLine(pSObject.ToString());
            }
            return stringBuilder.ToString();
        }
         static void Main(string[] args)
        {
            String stdout=RunScript("Winget show notepad++");
            Console.WriteLine(stdout);
        }
    }
}
