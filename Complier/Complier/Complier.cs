using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complier.Complier
{
    public class Complier
    {
        public CompilerResults Compile(string codes)
        {
            CodeDomProvider compiler = new Microsoft.CSharp.CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();
            parameters.ReferencedAssemblies.Add("System.dll");
            return compiler.CompileAssemblyFromSource(parameters, codes);
        }

        public string GenerateCode(string code)
        {
            string namespaces = @"using System;
using System.ComponentModel;
using System.Text;using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms
;using System.Threading;
using System.Reflection;
";
            string codeHead = @"
sealed class SimpleC
{
    public static void Main()
    {
//----------your code here-----------
";
            //userCode here
            string codeTail = @"
//----------your code here-----------
    }
}
";
            string compileCodes = namespaces + codeHead + code + codeTail;
            return compileCodes;
        }

        public void ShowCompileResult(CompilerResults result)
        {
            if (result.Errors.HasErrors)
            {
                Console.WriteLine("Build Error:");
                Console.WriteLine("Error Numeber:{0}", result.Errors.Count);
                foreach(CompilerError item in result.Errors)
                {
                    Console.WriteLine("Line:{0}\tError:{1}", item.Line, item.ErrorText);
                }
            }
            Console.WriteLine("Build Success!");
            try
            {//call Main entry, Console output --> WinForm Control
#if CompileIntoMemory
                Type Phoenix = result.CompiledAssembly.GetType("SimpleC");
                Phoenix.GetMethod("Main").Invoke(null,new string[]{});
#else    //start another thread to run the generated application
                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = result.PathToAssembly,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };
                System.Diagnostics.Process process;
                process = new System.Diagnostics.Process();
                process.OutputDataReceived += (s, e) => {
                    if (e.Data != null)
                    {
                        Console.WriteLine(e.Data);
                    }
                };
                process.ErrorDataReceived += (s, e) => {
                    if (e.Data != null)
                    {
                        Console.WriteLine(e.Data);
                    }
                };
                process.StartInfo = info;
                process.EnableRaisingEvents = true;
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
#endif
            }
            catch (System.Reflection.TargetInvocationException ex)
            {
                Console.WriteLine("Exception:" + ex.InnerException.Message);
            }
        }
    }
}
