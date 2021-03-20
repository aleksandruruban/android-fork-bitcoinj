using System;
using System.CodeDom.Compiler;
using System.IO;

namespace Virtual3750Assembler
{
    public class Assembler
    {
        public void Assemble(string assemblyFilename, string objectCodeFilename)
        {
            // Open up the assembly file.
            StreamReader reader = new StreamReader(assemblyFilename);

            // Create the Object Code File
            StreamWriter writer = new StreamWriter(objectCodeFilename);

            // Read each line of the assembly file.
            string record = reader.ReadLine();

            while (record != null)
            {
                // Console.WriteLine(record);

                switch (record)
                {
                    // HALT -----> Transfers control to the operating system
                    case VCA_Mnemonics.HALT:
                        {
                            writer.WriteLine(VCO_Opcodes.HALT);
                            writer.Flush();
                            break;
                        }

                    // CLR -----> Sets ACC to 0
                    case VCA_Mnemonics.CLR_ACC:
                        {
                            writer.WriteLine(VCO_Opcodes.CLR_ACC);
                            writer.Flush();
                            break;
                        }

                    // CLR -----> Sets REG_[?] to 0
                    case VCA_Mnemonics.CLR_REG_A:
                        {
                            writer.WriteLine(VCO_Opcodes.CLR_REG_A);
                            writer.Flush();
                            break;
                        }
                    case VCA_Mnemonics.CLR_REG_B:
                        {
                            writer.WriteLine(VCO_Opcodes.CLR_REG_B);
                            writer.Flush();
                            break;
                        }
                    case VCA_Mnemonics.CLR_REG_C:
                        {
                            writer.WriteLine(VCO_Opcodes.CLR_REG_C);
                            writer.Flush();
                            break;
                        }
                    case VCA_Mnemonics.CLR_REG_D:
                        {
                            writer.WriteLine(VCO_Opcodes.CLR_REG_D);
                            writer.Flush();
                            break;
                        }

                    // ADD -----> ADDS the 32-bit int value stored in REG_[?] to ACC
                    case VCA_Mnemonics.ADD_REG_A:
                        {
                            writer.WriteLine(VCO_Opcodes.ADD_REG_A);
                            writer.Flush();
                            break;
                        }
                    case VCA_Mnemonics.ADD_REG_B:
                        {
                            writer.WriteLine(VCO_Opcodes.ADD_REG_B);
                            writer.Flush();
                            break;
                        }
                    case VCA_Mnemonics.ADD_REG_C:
                        {
                            writer.WriteLine(VCO_Opcodes.ADD_REG_C);
                            writer.Flush();
                            break;
                        }
                    case VCA_Mnemonics.ADD_REG_D:
                        {
                            writer.WriteLine(VCO_Opcodes.ADD_REG_D);
                            writer.Flush();
                            break;
                        }

                    // MOV -----> MOVES a 32-bit int value from REG_[?] to ACC
                    case VCA_Mnemonics.MOV_REG_A_ACC:
                        {
                            writer.WriteLine(VCO_Opcodes.MOV_REG_A_ACC);
                            writer.Flush();
                            break;
                        }
                    case VCA_Mnemonics.MOV_REG_B_ACC:
                        {
                            writer.WriteLine(VCO_Opcodes.MOV_REG_B_ACC);
                            writer.Flush();
                            break;
                        }
                    case VCA_Mnemonics.MOV_REG_C_ACC:
                        {
                            writer.WriteLine(VCO_Opcodes.MOV_REG_C_ACC);
                            writer.Flush();
                            break;
                        }
                    case VCA_Mnemonics.MOV_REG_D_ACC:
                        {
                            writer.WriteLine(VCO_Opcodes.MOV_REG_D_ACC);
                            writer.Flush();
                            break;
                        }

                    // MOV -----> MOVES a 32-bit int value from ACC TO REG_[?]
                    case VCA_Mnemonics.MOV_ACC_REG_A:
                        {
                            writer.WriteLine(VCO_Opcodes.MOV_ACC_REG_A);
                            writer.Flush();
                            break;
                        }
                    case VCA_Mnemonics.MOV_ACC_REG_B:
                        {
                            writer.WriteLine(VCO_Opcodes.MOV_ACC_REG_B);
                            writer.Flush();
                            break;
                        }
                    case VCA_Mnemonics.MOV_ACC_REG_C:
                        {
                            writer.WriteLine(VCO_Opcodes.MOV_ACC_REG_C);
                            writer.Flush();
                            break;
                        }
                    case VCA_Mnemonics.MOV_ACC_REG_D:
                        {
                            writer.WriteLine(VCO_Opcodes.MOV_ACC_REG_D);
                            writer.Flush();
                            break;
                        }
                                        
                    // CMP -----> COMPARES the 32-bit integer value stored in REG_[?] to ACC
                    case VCA_Mnemonics.CMP_REG_A:
                        {
                            writer.WriteLine(VCO_Opcodes.CMP_REG_A);
                            writer.Flush();
                            break;
                        }
                    case VCA_Mnemonics.CMP_REG_B:
                        {
                            writer.WriteLine(VCO_Opcodes.CMP_REG_B);
                            writer.Flush();
                            break;
                        }
                    case VCA_Mnemonics.CMP_REG_C:
                        {
                            writer.WriteLine(VCO_Opcodes.CMP_REG_C);
                            writer.Flush();
                            break;
                        }
                    case VCA_Mnemonics.CMP_REG_D:
                        {
                            writer.WriteLine(VCO_Opcodes.CMP_REG_D);
                            writer.Flush();
                            break;
                        }

                    default:
                        {
                            // MOVI -----> MOVES a literal 32-bit int value into REG_[?]
                            if (record.StartsWith(VCA_Mnemonics.MOVI_REG_A))
                            {
                                string opcode = VCA_Mnemonics.MOVI_REG_A;
                                int opcodeLength = opcode.Length;
                                int indexOfImmediateValue = opcodeLength;

                                string immediateValue = record.Substring(indexOfImmediateValue);
                                immediateValue = immediateValue.Trim();

                                writer.WriteLine(VCO_Opcodes.MOVI_REG_A + " " + immediateValue);
                                writer.Flush();
                            }
                            
                            else if (record.StartsWith(VCA_Mnemonics.MOVI_REG_B)) 
                            {
                                string opcode = VCA_Mnemonics.MOVI_REG_B;
                                int opcodeLength = opcode.Length;
                                int indexOfImmediateValue = opcodeLength;

                                string immediateValue = record.Substring(indexOfImmediateValue);
                                immediateValue = immediateValue.Trim();

                                writer.WriteLine(VCO_Opcodes.MOVI_REG_B + " " + immediateValue);
                                writer.Flush();
                            } 
                            
                            else if (record.StartsWith(VCA_Mnemonics.MOVI_REG_C))
                            {
                                string opcode = VCA_Mnemonics.MOVI_REG_C;
                                int opcodeLength = opcode.Length;
                                int indexOfImmediateValue = opcodeLength;

                                string immediateValue = record.Substring(indexOfImmediateValue);
                                immediateValue = immediateValue.Trim();

                                writer.WriteLine(VCO_Opcodes.MOVI_REG_C + " " + immediateValue);
                                writer.Flush();
                            }   
                            
                            else if (record.StartsWith(VCA_Mnemonics.MOVI_REG_D))
                            {
                                string opcode = VCA_Mnemonics.MOVI_REG_D;
                                int opcodeLength = opcode.Length;
                                int indexOfImmediateValue = opcodeLength;

                                string immediateValue = record.Substring(indexOfImmediateValue);
                                immediateValue = immediateValue.Trim();

                                writer.WriteLine(VCO_Opcodes.MOVI_REG_D + " " + immediateValue);
                                writer.Flush();
                            }

                            // STORE -----> STORES a 32-bit int value from REG_[?] to memory location defined by ADDR
                            else if (record.StartsWith(VCA_Mnemonics.STORE_REG_A))
                            {
                                string opcode = VCA_Mnemonics.STORE_REG_A;
                                int opcodeLength = opcode.Length;
                                int indexOfImmediateValue = opcodeLength;

                                string immediateValue = record.Substring(indexOfImmediateValue);
                                immediateValue = immediateValue.Trim();

                                writer.WriteLine(VCO_Opcodes.STORE_REG_A + " " + immediateValue);
                                writer.Flush();
                            }

                            else if (record.StartsWith(VCA_Mnemonics.STORE_REG_B))
                            {
                                string opcode = VCA_Mnemonics.STORE_REG_B;
                                int opcodeLength = opcode.Length;
                                int indexOfImmediateValue = opcodeLength;

                                string immediateValue = record.Substring(indexOfImmediateValue);
                                immediateValue = immediateValue.Trim();

                                writer.WriteLine(VCO_Opcodes.STORE_REG_B + " " + immediateValue);
                                writer.Flush();
                            }

                            else if (record.StartsWith(VCA_Mnemonics.STORE_REG_C))
                            {
                                string opcode = VCA_Mnemonics.STORE_REG_C;
                                int opcodeLength = opcode.Length;
                                int indexOfImmediateValue = opcodeLength;

                                string immediateValue = record.Substring(indexOfImmediateValue);
                                immediateValue = immediateValue.Trim();

                                writer.WriteLine(VCO_Opcodes.STORE_REG_C + " " + immediateValue);
                                writer.Flush();
                            }

                            else if (record.StartsWith(VCA_Mnemonics.STORE_REG_D))
                            {
                                string opcode = VCA_Mnemonics.STORE_REG_D;
                                int opcodeLength = opcode.Length;
                                int indexOfImmediateValue = opcodeLength;

                                string immediateValue = record.Substring(indexOfImmediateValue);
                                immediateValue = immediateValue.Trim();

                                writer.WriteLine(VCO_Opcodes.STORE_REG_D + " " + immediateValue);
                                writer.Flush();
                            }


                            // LOAD -----> LOADS a 32-bit int value from memory location defined by ADDR to REG_[?]
                            else if (record.StartsWith(VCA_Mnemonics.LOAD_REG_A))
                            {
                                string opcode = VCA_Mnemonics.LOAD_REG_A;
                                int opcodeLength = opcode.Length;
                                int indexOfImmediateValue = opcodeLength;

                                string immediateValue = record.Substring(indexOfImmediateValue);
                                immediateValue = immediateValue.Trim();

                                writer.WriteLine(VCO_Opcodes.LOAD_REG_A + " " + immediateValue);
                                writer.Flush();
                            }

                            else if (record.StartsWith(VCA_Mnemonics.LOAD_REG_B))
                            {
                                string opcode = VCA_Mnemonics.LOAD_REG_B;
                                int opcodeLength = opcode.Length;
                                int indexOfImmediateValue = opcodeLength;

                                string immediateValue = record.Substring(indexOfImmediateValue);
                                immediateValue = immediateValue.Trim();

                                writer.WriteLine(VCO_Opcodes.LOAD_REG_B + " " + immediateValue);
                                writer.Flush();
                            }

                            else if (record.StartsWith(VCA_Mnemonics.LOAD_REG_C))
                            {
                                string opcode = VCA_Mnemonics.LOAD_REG_C;
                                int opcodeLength = opcode.Length;
                                int indexOfImmediateValue = opcodeLength;

                                string immediateValue = record.Substring(indexOfImmediateValue);
                                immediateValue = immediateValue.Trim();

                                writer.WriteLine(VCO_Opcodes.LOAD_REG_C + " " + immediateValue);
                                writer.Flush();
                            }

                            else if (record.StartsWith(VCA_Mnemonics.LOAD_REG_D))
                            {
                                string opcode = VCA_Mnemonics.LOAD_REG_D;
                                int opcodeLength = opcode.Length;
                                int indexOfImmediateValue = opcodeLength;

                                string immediateValue = record.Substring(indexOfImmediateValue);
                                immediateValue = immediateValue.Trim();

                                writer.WriteLine(VCO_Opcodes.LOAD_REG_D + " " + immediateValue);
                                writer.Flush();
                            }

                            break;
                        
                        }
                }

                record = reader.ReadLine();
            }

            reader.Close();
            writer.Close();
        
        }
        
        public void ListObjectCodeFile(string objectCodeFilename)
        {
            // Open the generated object code file
            // Output the content of the generate object code file
            
            StreamReader reader = new StreamReader(objectCodeFilename);

            string tmp = reader.ReadLine();

            while (tmp != null)
            {
                Console.WriteLine(tmp);
                tmp = reader.ReadLine();
            }
            reader.Close();
        }
    }
}
