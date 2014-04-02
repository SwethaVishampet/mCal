using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cs2103_project_UI_logic
{
    class Ez_link
    {
        private Logic logicObject = new Logic();
        private string[] tagName = new string[40];
        private string[] tagValue = new string[40];
        private string taskName;
        private int arrayCountTags = 0;
        private string commandName;
        List<string> concatenatedResult;
        const string INVALID_COMMAND_ERROR = " Please Enter a valid command";

        public List<string> getConcatenatedString(ref bool isDispaly)
        {
            if (commandName == "add")
                isDispaly = false;
            else
                isDispaly = true;
            return concatenatedResult;
        }
        private bool isValidTag(string commandEntered)
        {
            bool isValid = false;
            switch (commandEntered)
            {
                case "-d":
                case "-!d":
                case "-dt":
                case "!-dt":
                case "-t":
                case "-b4t":
                case "-at":
                case "stb4t":
                case "-stat":
                case "-endb4t":
                case "-m":
                case "-del":
                case "-delAll":
                case "-e":
                case "-rem":
                case "-s":
                case "-endat":
                    isValid = true;
                    break;
            }
            return isValid;
        }

        public void identifyTags(string[] commandEntered)
        {
            int tempCountforcommandentered = 2;

            string[] extractTag;
            while (tempCountforcommandentered < commandEntered.Count())
            {

                extractTag = commandEntered[tempCountforcommandentered].Split(' ');
                if (isValidTag(extractTag[0]))
                {
                    if (extractTag.Count() == 2)
                    {
                        tagName[arrayCountTags] = extractTag[0];
                        tagValue[arrayCountTags] = extractTag[1];
                    }
                    else if (extractTag.Count() == 3)
                    {
                        tagName[arrayCountTags] = extractTag[0];
                        tagValue[arrayCountTags] = extractTag[1] + " " + extractTag[2];
                    }
                    else
                    {
                        tagName[arrayCountTags] = extractTag[0];

                    }
                    arrayCountTags++;
                    tempCountforcommandentered++;
                }
            }

        }

        public bool identifyCommand(string entered)
        {

            if (entered != "")
            {
                string[] commandEntered;
                commandEntered = entered.Split(';');
                if (commandEntered.Count() > 2)
                    identifyTags(commandEntered);
                commandName = commandEntered[0];
                taskName = commandEntered[1];
                functionCallToLogic();
               
            }

            return true;

        }
        public void edit(string tasksTobeDeleted)
        {
            string[] splitTheenterdText = tasksTobeDeleted.Split(';');
           concatenatedResult= logicObject.edit(splitTheenterdText);
        }
        public bool functionCallToLogic()
        {
            
            switch (commandName)
            {
                case "add": {logicObject.addTask(taskName,tagName,tagValue,arrayCountTags);
                
                }
                    break;
                //case "delete": //deleteTask();
                  //  break;
                case "search": concatenatedResult= logicObject.search(taskName);
                    break;
                case "edit":
                    {
                        concatenatedResult=logicObject.search(taskName);
                    }
                    break;
                default: return false;

            }
            return true;
        }
        public string getTaskname()
        {
            return commandName;
        }
    
    }

       
}
