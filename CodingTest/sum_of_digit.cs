using System;

public class Solution {
    public int solution(int n) {
        int answer = 0;
            string arr = n.ToString();
            for (int i = 0; i<arr.Length;i++)
            {
                answer+=arr[i]-'0';
               
            }
        return answer;
    }
}
