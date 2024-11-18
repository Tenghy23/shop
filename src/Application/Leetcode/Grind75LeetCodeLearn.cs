using Application.Leetcode.Grind75Classes;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Leetcode
{
    /// <summary>
    ///  This is a standalone file to capture a variety of leetcode questions
    /// </summary>
    /// <param name="products"></param>
    /// <returns></returns>
    public class Grind75LeetCodeLearn
    {
        //  use a hash map (dictionary) to store the values and their indices as you iterate
        //  through the array. This approach allows you to find the solution in a single pass
        //  with a time complexity of O(n).
        public int[] TwoSum(int[] nums, int target)
        {
            var hashMap = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var remainder = target - nums[i];
                if (hashMap.ContainsKey(remainder))
                {
                    return new int[] { hashMap[remainder], i };
                }
                hashMap[nums[i]] = i;
            }

            return new int[0];
        }

        // stack would be ideal since it handles via LIFO
        // since every parenthesis has to open first, this method will be valid
        // use hashMap to store opening parenthesis, if closing, pop it off
        public bool IsValid(string s)
        {
            var bracketMap = new Dictionary<char, char>
            {
                { ')', '(' },
                { '}', '{' },
                { ']', '[' }
            };
            var stack = new Stack<char>();
            foreach (char c in s)
            {
                if (bracketMap.ContainsKey(c))
                {
                    char topElement = stack.Count > 0 ? stack.Pop() : '#';
                    if (topElement != bracketMap[c])
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }
            return stack.Count == 0;
        }

        // use of pointers to merge the 2 lists together
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode mergedList = new ListNode(); // init merged linked list
            ListNode pointer = mergedList; // init reference to pointer (aka head)

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

            // Append any remaining nodes from either list
            pointer.next = list1 ?? list2;

            return mergedList.next;
        }

        public int MaxProfit(int[] prices)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;

            foreach (int price in prices)
            {
                if (price < minPrice)
                {
                    minPrice = price;
                }
                else if (price - minPrice > maxProfit)
                {
                    maxProfit = price - minPrice;
                }
            }

            return maxProfit;
        }

        // use of pointers from left and right and meet in the middle
        public bool IsPalindrome(string s)
        {
            // init pointers
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                // this skips non-alphanumeric char
                while (left < right && !char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                while (left < right && !char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }

                // comparison
                if (char.ToLower(s[left]) != char.ToLower(s[right]))
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }

        // inverting here means swapping the left and right child nodes of every node in the tree
        // the root is the topmost node
        // for inversion, the easiest implementation would be recursion
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            // Swap the left and right child nodes
            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;

            // Recursively invert the left and right subtrees
            InvertTree(root.left);
            InvertTree(root.right);

            return root;
        }

        // An anagram is a word or phrase formed by rearranging the letters of another word
        // or phrase, using all the original letters exactly once.
        // check if they contain the exact same characters in the same frequency
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            // Create a dictionary to store the frequency of each character in s
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount[c] = 1;
                }
            }

            // Decrement the count for each character in t
            foreach (char c in t)
            {
                if (!charCount.ContainsKey(c))
                {
                    return false;
                }
                charCount[c]--;
                if (charCount[c] == 0)
                {
                    charCount.Remove(c); // Remove key if count becomes zero
                }
            }

            // If dictionary is empty, s and t are anagrams
            return charCount.Count == 0;
        }

        // O(log n) requires binary search approach
        public int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                // int will always round down
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                    return mid;

                if (nums[mid] < target)
                    left = mid + 1; // Search in the right half
                else
                    right = mid - 1; // Search in the left half
            }

            return -1; // Target not found
        }

        // pre-req: learn to manipulate arrays, learn DFS & BFS
        // good explanation: https://www.youtube.com/watch?v=VuiXOc81UDM
        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            int originalColor = image[sr][sc];

            // If the original color is already the target color, return the image as is
            if (originalColor == color) return image;

            Fill(image, sr, sc, originalColor, color);  
            return image;
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            while (root != null)
            {
                // If both p and q are smaller than root, move to the left subtree
                if (p.val < root.val && q.val < root.val)
                {
                    root = root.left;
                }
                // If both p and q are greater than root, move to the right subtree
                else if (p.val > root.val && q.val > root.val)
                {
                    root = root.right;
                }
                // Otherwise, we have found the split point, which is the LCA
                else
                {
                    return root;
                }
            }
            return null; // In case there's no LCA (this would only happen if p or q are not in the tree)
        }

        // height here represents from any node to leaf, height difference between
        // its left and right subtrees is at most 1
        public bool IsBalanced(TreeNode root)
        {
            return CheckHeight(root) != -1;
        }

        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }

            ListNode slow = head;
            ListNode fast = head.next;

            while (fast != null && fast.next != null)
            {
                if (slow == fast)
                {
                    return true; // Cycle detected
                }
                slow = slow.next;
                fast = fast.next.next;
            }

            return false; // No cycle
        }

        #region helpers
        private void Fill(int[][] image, int r, int c, int originalColor, int newColor)
        {
            // Check if the pixel is out of bounds or if it is not the original color
            if (r < 0 ||
                r >= image.Length ||
                c < 0 ||
                c >= image[0].Length ||
                image[r][c] != originalColor)
            {
                return;
            }

            // Change the color of the current pixel
            image[r][c] = newColor;

            // Recursively call Fill for all 4 adjacent pixels (up, down, left, right)
            Fill(image, r + 1, c, originalColor, newColor);
            Fill(image, r - 1, c, originalColor, newColor);
            Fill(image, r, c + 1, originalColor, newColor);
            Fill(image, r, c - 1, originalColor, newColor);
        }

        private int CheckHeight(TreeNode node)
        {
            if (node == null) return 0;

            // Recursively check the height of the left subtree
            int leftHeight = CheckHeight(node.left);
            if (leftHeight == -1) return -1;

            // Recursively check the height of the right subtree
            int rightHeight = CheckHeight(node.right);
            if (rightHeight == -1) return -1;

            // If the current node is unbalanced, return -1
            if (Math.Abs(leftHeight - rightHeight) > 1) return -1;

            // Otherwise, return the height of the current node
            return Math.Max(leftHeight, rightHeight) + 1;
        }
        #endregion
    }
}
