using System;
using Virtual3750Assembler;

namespace Virtual3750Assembler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running 3750 Assembler...");

            //PART 1

            Assembler assembler = new Assembler();
            assembler.Assemble("AssemblyFileExample_01.vca", "AssemblyFileExample_01.vco");
            assembler.ListObjectCodeFile("AssemblyFileExample_01.vco");

            //Read the VC assembly file
            //Generate VC OPCODE for each VC assembly statement

            //PART 2
            Debugger debugger = new Debugger();
            debugger.Load("AssemblyFileExample_01.vco");

            Console.ReadLine();
        }
    }
}
