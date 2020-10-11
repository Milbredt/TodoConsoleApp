
namespace TodoApp
{
    class ToDoItem
    {
        private string title;
        private bool status;

        public string titleProperty
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public bool statusProperty
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        //Konstruktor
        public ToDoItem(string title)
        {
            this.title = title;

            this.status = false;
        }

    }
}

