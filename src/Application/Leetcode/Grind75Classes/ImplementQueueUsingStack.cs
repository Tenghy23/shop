namespace Application.Leetcode.Grind75Classes
{
    public class ImplementQueueUsingStack
    {
        private Stack<int> stack1;
        private Stack<int> stack2;

        public ImplementQueueUsingStack()
        {
            stack1 = new Stack<int>();
            stack2 = new Stack<int>();
        }

        // Push element x to the back of queue
        public void Push(int x)
        {
            stack1.Push(x);
        }

        // Removes the element from the front of queue and returns it
        public int Pop()
        {
            MoveStack1ToStack2IfNeeded();
            return stack2.Pop();
        }

        // Get the front element
        public int Peek()
        {
            MoveStack1ToStack2IfNeeded();
            return stack2.Peek();
        }

        // Returns whether the queue is empty
        public bool Empty()
        {
            return stack1.Count == 0 && stack2.Count == 0;
        }

        private void MoveStack1ToStack2IfNeeded()
        {
            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }
        }

    }
}
