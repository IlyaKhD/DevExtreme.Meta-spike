using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSDoc {

    class JSDocCommand {

        public CommandResult Run(string arguments) {
            var workingDirectory = AppDomain.CurrentDomain.BaseDirectory;

            var process = new Process();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.FileName = Path.Combine(workingDirectory, "RunJSDoc.bat");
            process.StartInfo.WorkingDirectory = workingDirectory;
            process.StartInfo.Arguments = arguments;
            process.Start();
            process.WaitForExit();

            process.StandardOutput.ReadLine();
            process.StandardOutput.ReadLine();

            return new CommandResult(process.StandardOutput.ReadToEnd(), process.ExitCode, process.StandardError.ReadToEnd());
        }

        public struct CommandResult {
            public readonly int ExitCode;
            public readonly string Output;
            public readonly string Errors;
            public CommandResult(string output, int exitCode, string errors) {
                Output = output;
                ExitCode = exitCode;
                Errors = errors;
            }
        }
    }

}
