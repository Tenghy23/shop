using Application.Leetcode.Grind75Classes;
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
    public class Grind75LeetCode
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
                    return new int[]{ hashMap[remainder], i };
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

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode mergedList = new ListNode(); // init merged list
            ListNode pointer = mergedList; // init pointer

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
    }
}
