using System.Collections.Generic;

namespace TodoApp
{
    class ToDoManager
    {
        private List<ToDoItem> listOfToDoItems = new List<ToDoItem>();

        //CreateNewToDoItem
        public void AddToDoItem(string title)
        {
            ToDoItem toDo = new ToDoItem(title);

            listOfToDoItems.Add(toDo);

        }

        //SetToDoItemStatus
        public void SetToDoItemStatus(int index)
        {
            index -= 1;

            for (int i = 0; i < listOfToDoItems.Count; i++)
            {
                if (i == index)
                {
                    listOfToDoItems[i].statusProperty = true;
                }
            }
        }

        //RemoveToDoItem
        public void RemoveToDoItem(int index)
        {
            index -= 1;

            listOfToDoItems.RemoveAt(index);                 
        }

        //PrintToDoList
        public string PrintToDoList()
        {
            string status = "";

            string toPrint = "";
            int number = 1;

            foreach (ToDoItem toDo in listOfToDoItems)
            {
                if (toDo.statusProperty == false)
                {
                    status = "Ej klar";
                }
                else
                {
                    status = "Klar";
                }
                toPrint += number + ". " + toDo.titleProperty + "\n";
                toPrint += "Status: " + status + "\n"; 

                number++ ;
            }

            return toPrint;
        }

        //GetToDoListCount
        public int GetToDoListCount()
        {
            int toDoListCount = listOfToDoItems.Count;

            return toDoListCount;
        }
    }
}

