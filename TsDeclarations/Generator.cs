using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsDeclarations {

    public class Generator {

        public string Generate(string moduleName, IEnumerable<ClassMeta> classes) {
            var writer = new Writer();

            writer.StartModule(moduleName);

            foreach(var classMeta in classes) {
                writer.StartInterface(classMeta);

                foreach(var prop in classMeta.Props)
                    writer.AppendProp(prop);
                
                foreach (var method in classMeta.Methods)
                    writer.AppendMethod(method);

                writer.EndInterface();
            }

            writer.EndModule();

            return writer.ToString();
        }

        class Writer {
            const int TAB_SIZE = 4;

            readonly StringBuilder _stringBuilder;
            int _indent;

            public Writer() {
                _stringBuilder = new StringBuilder();
                _indent = 0;
            }

            public Writer StartModule(string name) {
                AppendLine($"declare module {name} {{");
                _indent += 1;

                return this;
            }

            public Writer StartInterface(ClassMeta classMeta) {
                AppendLine($"export interface {classMeta.Name} {{");
                _indent += 1;

                return this;
            }

            public Writer AppendProp(PropertyMeta prop) {
                AppendLine($"{prop.Name}: {prop.Types.FirstOrDefault()};");

                return this;
            }

            public Writer AppendMethod(MethodMeta method)
            {
                AppendLine($"{method.Name}({getArgsString(method.Args)}): {method.ReturnType};");

                return this;
            }

            string getArgsString(PropertyMeta[] args)
            {
                string result = "";
                if (args == null) {
                    return result;
                }

                foreach (var arg in args)
                {
                    result += $"{arg.Name}: {arg.Types.FirstOrDefault()},";
                }
                result = result.Remove(result.Length - 1);
                

                return result;
            }

            public Writer EndModule() => EndBlock();

            public Writer EndInterface() => EndBlock();

            Writer EndBlock() {
                AppendLine("}");
                _indent -= 1;

                return this;
            }

            public override string ToString() => _stringBuilder.ToString();

            void AppendLine(string text) {
                _stringBuilder.AppendLine($"{new String(' ', _indent * TAB_SIZE)}{text}");
            }
        }
    }

}
