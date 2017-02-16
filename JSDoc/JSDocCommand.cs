using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSDoc {

    class JSDocCommand {

        public CommandResult Run(string relFileName) {
            var workDir = AppDomain.CurrentDomain.BaseDirectory;

            var process = new Process();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.FileName = Path.Combine(workDir, "RunJSDoc.bat");
            process.StartInfo.WorkingDirectory = workDir;
            process.StartInfo.Arguments = relFileName;

            if(!File.Exists(process.StartInfo.FileName))
                throw new Exception($"File not found: '{process.StartInfo.FileName}'");

            if(!File.Exists(Path.Combine(workDir, relFileName)))
                throw new Exception($"File not found: '{Path.Combine(workDir, relFileName)}'");

            process.Start();
            if(!process.WaitForExit(milliseconds: 1000)) {
                process.Kill();
                throw new Exception($"JSDoc process exited due to timeout: '{process.StandardOutput.ReadToEnd()}'");
            }

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
