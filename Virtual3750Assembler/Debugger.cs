using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual3750Assembler
{
    public class Debugger
    {
        
        //Fields
        string[] virtualMemory;
        string f_objectCodeFilename;

        //Methods
        public void Load(string objectCodeFilename)
        {
            virtualMemory = new string[50];
            f_objectCodeFilename = objectCodeFilename;
            
            /*
            a.Open the Object Code File
            b.Read each line of the Object Code File and store the opcode (Operation Code) in the virtual memory.
            c.Initializes the data segment memory
            d.Memory is an array of strings
                i.Each string element represents an opcode instruction
            */

            virtualMemory[0] = "0x1000";

        }

        public void ListObjectCodeMemory()
        {
            //Lists the object code loaded in memory
            //(Display the opcode instructions that are in the array of strings


        }

        public void ShowNextStatement()
        {
            //Output the machine instruction from virtual memory that is executed next
        }

        public void Step()
        {
            //Execute the next machine instruction from virtual memory
        }

        public void ListRegisters()
        {
            //Output the contents of your registers
            //Much more to talk about here!
        }

        public void ListDataSegmentMemory()
        {
            //Output the contents of the data segment
            //Much more to talk about here!

            /*
             * a.	Memory is an array of 32-bit signed-integers
                    i.	Each element represents a data segment variable

             */
        }

        public void Reload()
        {
            /*
            a.Loads Object Code File into memory
            b.Initializes the data segment memory
            c.Memory is an array of strings
                i.Each string element represents an opcode instruction
            */
        }
    }
}
