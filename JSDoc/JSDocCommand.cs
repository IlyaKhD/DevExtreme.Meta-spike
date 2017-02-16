using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSDoc {

    class JSDocCommand {

        public CommandResult Run(IEnumerable<string> relFileNames) {
            var workDir = AppDomain.CurrentDomain.BaseDirectory;

            foreach(var fileName in relFileNames) {
                if(!File.Exists(Path.Combine(workDir, fileName)))
                    throw new Exception($"File not found: '{Path.Combine(workDir, fileName)}'");
            }

            var process = new Process();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.FileName = "cmd";
            process.StartInfo.WorkingDirectory = workDir;
            process.StartInfo.Arguments = "/C jsdoc -X " + String.Join(" ", relFileNames);

            process.Start();
            if(!process.WaitForExit(milliseconds: 1000)) {
                process.Kill();
                return new CommandResult(process.StandardOutput.ReadToEnd(), process.ExitCode, process.StandardError.ReadToEnd());
            }

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
