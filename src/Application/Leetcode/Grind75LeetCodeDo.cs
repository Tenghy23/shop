using Application.Leetcode.Grind75Classes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Application.Leetcode
{
    /// <summary>
    /// HY's attempts
    /// </summary>
    public class Grind75LeetCodeDo
    {
        //  use a hash map (dictionary) to store the values and their indices as you iterate
        //  through the array. This approach allows you to find the solution in a single pass
        //  with a time complexity of O(n).
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            foreach (var (value, index) in nums.Select((value, index) => (value, index)))
            {
                var remain = target - value;
                if (dict.ContainsKey(remain))
                {
                    return new int[] { dict[remain], index };
                }
                dict[value] = index;
            }
            return new int[0];
        }

        // stack would be ideal since it handles via LIFO
        // since every parenthesis has to open first, this method will be valid
        // use hashMap to store opening parenthesis, if closing, pop it off
        public bool IsValid(string s)
        {
            var dict = new Dictionary<char, char>
            {
                { ')', '(' },
                { '}', '{' },
                { ']' , '[' }
            };
            var found = new Stack<char>();
            foreach (char item in s) 
            {
                if (dict.ContainsKey(item))
                {
                    var popped = (found.Count > 0) ? found.Pop() : '0';
                    if (popped != dict[item])
                    {
                        return false;
                    }
                }
                else
                {
                    found.Push(item);
                }
            }
            return found.Count == 0;
        }

        // use of pointers to merge the 2 lists together
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var merged = new ListNode();
            var pointer = merged;

            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    pointer.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    pointer.next = list2;
                    list2 = list2.next;
                }
                pointer = pointer.next;
            }

            pointer.next = list1 ?? list2;
            return merged.next;
        }

        //public int MaxProfit(int[] prices)
        //{
        //}


        // use of pointers from left and right and meet in the middle
        public bool IsPalindrome(string s)
        {
            var l = 0;
            var r = s.Length-1;
            var collection = s.ToArray();
            while (l < r) 
            {
                while (l < r && !char.IsLetterOrDigit(collection[l]))
                {
                    l++;
                }
                while (l < r && !char.IsLetterOrDigit(collection[r]))
                {
                    r--;
                }
                if (char.ToLower(collection[l]) != char.ToLower(collection[r]))
                {
                    return false;
                }
                l++;
                r--;
            }
            return true;
        }

        // inverting here means swapping the left and right child nodes of every node in the tree
        // the root is the topmost node
        // for inversion, the easiest implementation would be recursion
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;

            var temp = root.left;
            root.left = root.right;
            root.right = temp;

            InvertTree(root.left);
            InvertTree(root.right);

            return root;
        }

        // An anagram is a word or phrase formed by rearranging the letters of another word
        // or phrase, using all the original letters exactly once.
        // check if they contain the exact same characters in the same frequency
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            var dictS = new Dictionary< char , int>();

            foreach(char c in s)
            {
                if (dictS.ContainsKey(c))
                {
                    dictS[c]++;
                }
                else
                {
                    dictS[c] = 1;
                }
            }

            foreach (char c in t)
            {
                if (dictS.ContainsKey(c))
                {
                    if (dictS[c] > 1) dictS[c]--;
                    else dictS.Remove(c);
                }
                else return false;
            }

            return dictS.Count == 0;
        }

        // O(log n) requires binary search approach
        public int Search(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {
                var mid = left + (right-left) / 2;
                if (nums[mid] == target) return mid;
                else if (nums[mid] > target) right = mid - 1;
                else if (nums[mid] < target) left = mid + 1;
            }
            return -1;
        }

        // pre-req: learn to manipulate arrays, learn DFS & BFS
        // good explanation: https://www.youtube.com/watch?v=VuiXOc81UDM
        //public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        //{
        //    +
        //}

        //public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        //{
        //}

        // height here represents from any node to leaf, height difference between
        // its left and right subtrees is at most 1
        //public bool IsBalanced(TreeNode root)
        //{
        //}

        //public bool HasCycle(ListNode head)
        //{
        //}

        #region helpers
        #endregion

    }
}
