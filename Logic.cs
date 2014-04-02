using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace cs2103_project_UI_logic
{
    class Logic
    {
        private List<Task> taskObjects=new List<Task>();
        private int maintainId = 0;
        private List<Task> matchingTasks=new List<Task>();
        public List<int> getCode()
        {          
            List<int> codeCount = new List<int>();
            for (int i = 0; i < matchingTasks.Count(); i++)
            {
                codeCount.Add( matchingTasks[i].getTaskID());
            }
            return codeCount;
        }
        public List<string> edit(string[] splittedEnteredTask)
        {
            //List<Task> matchingTasks = new List<Task>();
            //matchingTasks = search();
            string[] numToBeEdited = splittedEnteredTask[0].Split(',');
            string[] tagToEdit=new String[20];
            string[] tagtoEditVal = new String[20];
            string[] temptoEdit = new String[2];
            List<Task> editedTask = new List<Task>();
            for (int i = 1,j=0; i < splittedEnteredTask.Count(); i++,j++)
            {
                temptoEdit = splittedEnteredTask[i].Split(' ');
                tagToEdit[j] = temptoEdit[0];
                if (temptoEdit.Count() > 1)
                    tagtoEditVal[j] = temptoEdit[1];
            }

            List<int> idCount=new List<int>();
            idCount=getCode();
            int num;
            for (int i = 0; i < numToBeEdited.Count(); i++)
            {
                num=int.Parse(numToBeEdited[i]);
                editedTask.Add(taskObjects[idCount[num-1]-1]);
                for (int j = 0; j <splittedEnteredTask.Count()-1; j++)
                {
                    
                    switch (tagToEdit[j])
                    {
                        case "-dt":taskObjects[idCount[num-1]-1].writeDate(tagtoEditVal[j]);
                            break;
                        case "-stat": taskObjects[idCount[num-1]-1].writeStartTime(tagtoEditVal[j]);
                            break;
                        case "-endat": taskObjects[idCount[num-1]-1].writeEndTime(tagtoEditVal[j]);
                            break;
                        case "-s": taskObjects[idCount[num-1]-1].writeStarred(true);
                            break;

                    }
                }

            }

            List<string> concatenetedEditedString;
            concatenetedEditedString = convertObjectToString(editedTask);
            return concatenetedEditedString;
        }




        public void addTask(string taskName,string[] tagName,string[] tagValue,int arrayCountTags)
        {
            maintainId++;
            Task tempObj = new Task();
            tempObj.writeTaskName(taskName);
            tempObj.writeTaskID(maintainId);
            for (int i = 0; i < arrayCountTags; i++)
            {
                switch (tagName[i])
                {
                    case "-dt": tempObj.writeDate(tagValue[i]);
                        break;
                    case "-stat": tempObj.writeStartTime(tagValue[i]);
                        break;
                    case "-endat": tempObj.writeEndTime(tagValue[i]);
                        break;
                    case "-s": tempObj.writeStarred(true);
                        break;

                }
            }

            taskObjects.Add(tempObj);

        }
        public void deleteTask()
        {
            
        }
        public List<string> search(string taskName)
        {
            List<string> words;
            
            List<int> addedTasks = new List<int>();
            for (int i = 0; i < taskObjects.Count(); i++)
            {
                words = CalculateWordPermutations(taskObjects[i].getTaskName().Split(), new List<string>(), 0);
                foreach (string word in words)
                {
                    if (taskName.Split(' ').Contains(word) && !addedTasks.Contains(taskObjects[i].getTaskID()))
                    {
                        matchingTasks.Add(taskObjects[i]);
                        addedTasks.Add(taskObjects[i].getTaskID());
                    }
                }
            }
            List<string> concatenateMatchingString=convertObjectToString(matchingTasks);
            return concatenateMatchingString;


        }

        public List<string> CalculateWordPermutations(string[] letters, List<string> words, int index)
        {
            bool finished = true;
            List<string> newWords = new List<string>();
            if (words.Count() == 0)
            {
                foreach (string letter in letters)
                {
                    words.Add(letter);
                }
            }

            for (int j = index; j < words.Count(); j++)
            {
                string word = (string)words[j];
                for (int i = 0; i < letters.Length; i++)
                {
                    if (!word.Contains(letters[i]))
                    {
                        finished = false;
                        string newWord = (string)word.Clone();
                        newWord += letters[i];
                        newWords.Add(newWord);
                    }
                }
            }

            foreach (string newWord in newWords)
            {
                words.Add(newWord);
            }

            if (finished == false)
            {
                CalculateWordPermutations(letters, words, words.Count - newWords.Count);
            }
            return words;
        }

        public List<string> convertObjectToString(List<Task> task)
        {
            List<string> concatenatedStringObjects = new List<string>();
            for (int i = 0; i < task.Count(); i++)
            {
                concatenatedStringObjects.Add(task[i].getTaskName() + " " + task[i].getTaskDate());
            }
            return concatenatedStringObjects;
        }
       
  
    }
}
